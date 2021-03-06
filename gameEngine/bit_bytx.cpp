#include <stdio.h>
#include <stdlib.h>
/*
 this package the numeric  way io byte file to bit stream
 or bit to byte file. This like but_bytn but scans byte
 in opposite direction.
 done by David Scott 2001 August 
*/

#include "bit_bytx.h"
#include "engine/kyra.h"

int             bit_bytx::r()
{
   /* return -1 on last bit which is last one in file -2 thereafter */
   /* return 0 on zero return 1 most of the time one */
   /* *** bn has first read in it **** */
   if (f == NULL)
      return -2;
   if ((l <<= 1) == 0x100) {
      l = 0x01;
      bo = bn;
      bn = get();
      bo += onef;
      if (++bo > 0xFF) {
	 bo &= 0xFF;
	 onef = 1;
      } else
	 onef = 0;
      if (bn == EOF && onef == 1) {
	 bn = 0;		/* so one bit for last byte goes at 0x01 */
	 onef = 0;
      }
      
   }
   if ((bo & l) == 0)
      return 0;
   bo ^= l;
   if (bn != EOF || bo != 0)
      return 1;
   xx();
   return -1;
}

int             bit_bytx::w(int x)
{
   /* return 0 if ok */
   /* return -1 if sending last byte */
   /* return -2 if closed longer; */
   /* 0 or 1 writes and -1 wirtes last one -2 means previous 1 was last */

   if (f == NULL)
      return -2;
   if (x == -1) {
      w(1);
      w(-2);
      return -1;
   }
   if (x == -2 && bo == 0x00) {
      xx();
      return -2;
   }
   if ((l <<= 1) == 0x100) {
      l = 0x01;
   }
   if (x > 0)
      bo ^= l;

   if (l == 0x80 || x < 0) {
      bo -= onef;
      if (--bo < 0x00) {
	 bo &= 0xFF;
	 onef = 1;
      } else
	 onef = 0;
      for (; zc > 0; zc--) {
	 put(0xFF);
      }
      if (bo == 0xFF && onef == 1)
	 zc++;
      else
	 put(bo);
      bo = 0;
      if (x < 0) {
	 xx();
	 return -2;
      }
   }

   
   return 0;
}



int bit_bytx::get()
{
	if(f)
	{
		if(type == 1)
			return getc((FILE *)f);
		else if(type == 2)
		{		
			Uint8 byte;
			if(SDL_RWread((SDL_RWops *)f, &byte, 1, 1 ) != 1)
				return EOF;
			
			return byte;
		}
		else if(type == 3)
		{
			if(pos < bufLen) 
				return ((unsigned char *)f)[pos++];		
		}
	}

	return EOF;
}

void bit_bytx::put(int b)
{
	if(f)
	{
		if(type == 1)
		{
			fputc(b, (FILE *)f);
			bytesWritten++;
		}
		else if(type == 2)
		{
			Uint8 byte = b;
			SDL_RWwrite( (SDL_RWops *)f, &byte, 1, 1 );
			bytesWritten++;
		}
		else if(type == 3)
		{
			if(pos < bufLen) 
			{
				((unsigned char *)f)[pos++] = b;
				bytesWritten++;
			}
		}
	}
}