#ifndef STAND_ALONE_GAME //maks

/* Handle clipboard text and data in arbitrary formats */

#include <stdio.h>
#include <limits.h>
#include <stdlib.h> //maks

#include "SDL.h"
#include "SDL_syswm.h"

#include "scrap.h"

#include "../../gameEngine/dlmalloc.h" //maks

/* Miscellaneous defines */
#define PUBLIC
#define PRIVATE	static

/* Determine what type of clipboard we are using */
#if defined(__unix__) && !defined(__QNXNTO__)
    #define X11_SCRAP
#elif defined(__MACOSX__)
	#define X11_SCRAP
#elif defined(WIN32)
    #define WIN_SCRAP
#elif defined(__QNXNTO__)
    #define QNX_SCRAP
#else
    #error Unknown window manager for clipboard handling
#endif /* scrap type */

/* System dependent data types */
#if defined(X11_SCRAP)
/* * */
typedef Atom scrap_type;

#elif defined(WIN_SCRAP)
/* * */
typedef UINT scrap_type;

#elif defined(QNX_SCRAP)
/* * */
typedef uint32_t scrap_type;
#define Ph_CL_TEXT T('T', 'E', 'X', 'T')

#endif /* scrap type */

/* System dependent variables */
#if defined(X11_SCRAP)
/* * */
static Display *SDL_Display;
#if __APPLE
#define SDL_Window SDl_Window //AKR
#endif
static Window SDL_Window;
static void (*Lock_Display)(void);
static void (*Unlock_Display)(void);

#elif defined(WIN_SCRAP)
/* * */
static HWND SDL_Window;

#elif defined(QNX_SCRAP)
/* * */
static unsigned short InputGroup;

#endif /* scrap type */

#define FORMAT_PREFIX	"SDL_scrap_0x"

PRIVATE scrap_type
convert_format(int type)
{
  switch (type)
    {

    case T('T', 'E', 'X', 'T'):
#if defined(X11_SCRAP)
/* * */
      return XA_STRING;

#elif defined(WIN_SCRAP)
/* * */
      return CF_TEXT;

#elif defined(QNX_SCRAP)
/* * */
      return Ph_CL_TEXT;

#endif /* scrap type */

    default:
      {
        char format[sizeof(FORMAT_PREFIX)+8+1];

        sprintf(format, "%s%08lx", FORMAT_PREFIX, (unsigned long)type);

#if defined(X11_SCRAP)
/* * */
        return XInternAtom(SDL_Display, format, False);

#elif defined(WIN_SCRAP)
/* * */
        return RegisterClipboardFormat(format);

#endif /* scrap type */
      }
    }
}

/* Convert internal data to scrap format */
PRIVATE int
convert_data(int type, char *dst, const char *src, int srclen) //maks
{
  int dstlen;

  dstlen = 0;
  switch (type)
    {
    case T('T', 'E', 'X', 'T'):
      if ( dst )
        {
          while ( --srclen >= 0 )
            {
#if defined(__unix__)
              if ( *src == '\r' )
                {
                  *dst++ = '\n';
                  ++dstlen;
                }
              else
#elif defined(WIN32)
              if ( *src == '\r' )
                {
                  *dst++ = '\r';
                  ++dstlen;
                  *dst++ = '\n';
                  ++dstlen;
                }
              else
#endif
                {
                  *dst++ = *src;
                  ++dstlen;
                }
              ++src;
            }
            *dst = '\0';
            ++dstlen;
        }
      else
        {
          while ( --srclen >= 0 )
            {
#if defined(__unix__)
              if ( *src == '\r' )
                {
                  ++dstlen;
                }
              else
#elif defined(WIN32)
              if ( *src == '\r' )
                {
                  ++dstlen;
                  ++dstlen;
                }
              else
#endif
                {
                  ++dstlen;
                }
              ++src;
            }
            ++dstlen;
        }
      break;

    default:
      if ( dst )
        {
          *(int *)dst = srclen;
          dst += sizeof(int);
          memcpy(dst, src, srclen);
        }
      dstlen = sizeof(int)+srclen;
      break;
    }
    return(dstlen);
}

/* Convert scrap data to internal format */
PRIVATE int
convert_scrap(int type, char *dst, char *src, int srclen)
{
  int dstlen;

  dstlen = 0;
  switch (type)
    {
    case T('T', 'E', 'X', 'T'):
      {
        if ( srclen == 0 )
          srclen = strlen(src);
        if ( dst )
          {
            while ( --srclen >= 0 )
              {
#if defined(WIN32)
                if ( *src == '\r' )
                  /* drop extraneous '\r' */;
                else
#endif
                if ( *src == '\n' )
                  {
                    *dst++ = '\r';
                    ++dstlen;
                  }
                else
                  {
                    *dst++ = *src;
                    ++dstlen;
                  }
                ++src;
              }
              *dst = '\0';
              ++dstlen;
          }
        else
          {
            while ( --srclen >= 0 )
              {
#if defined(WIN32)
                if ( *src == '\r' )
                  /* drop extraneous '\r' */;
                else
#endif
                ++dstlen;
                ++src;
              }
              ++dstlen;
          }
        }
      break;

    default:
      dstlen = *(int *)src;
      if ( dst )
        {
          if ( srclen == 0 )
            memcpy(dst, src+sizeof(int), dstlen);
          else
            memcpy(dst, src+sizeof(int), srclen-sizeof(int));
        }
      break;
    }
  return dstlen;
}

#if defined(X11_SCRAP)
/* The system message filter function -- handle clipboard messages */
PRIVATE int clipboard_filter(const SDL_Event *event);
#endif

PUBLIC int
init_scrap(void)
{
  SDL_SysWMinfo info;
  int retval;

  /* Grab the window manager specific information */
  retval = -1;
  //SDL_SetError("SDL is not running on known window manager"); //maks

  SDL_VERSION(&info.version);
  if ( SDL_GetWMInfo(&info) )
  {
      /* Save the information for later use */
#if defined(X11_SCRAP) || defined (__MACOSX__)
/* * */
      if ( info.subsystem == SDL_SYSWM_X11 )
        {
          SDL_Display = info.info.x11.display;
          SDL_Window = info.info.x11.window;
          Lock_Display = info.info.x11.lock_func;
          Unlock_Display = info.info.x11.unlock_func;

          /* Enable the special window hook events */
          SDL_EventState(SDL_SYSWMEVENT, SDL_ENABLE);
#if  (SDL_VERSION_ATLEAST(1, 3, 0)) //AKR, TODO: remove this when all projects use the SDL 13
          SDL_SetEventFilter(clipboard_filter,NULL);
#else
          SDL_SetEventFilter(clipboard_filter);
#endif

          retval = 0;
        }
      else
        {
          //SDL_SetError("SDL is not running on X11"); //maks
        }

#elif defined(WIN_SCRAP)
/* * */
      SDL_Window = info.window;
      retval = 0;

#elif defined(QNX_SCRAP)
/* * */
      InputGroup=PhInputGroup(NULL);
      retval = 0;

#endif /* scrap type */
    }
  return(retval);
}

PUBLIC int
lost_scrap(void)
{
  int retval;

#if defined(X11_SCRAP)
/* * */
  Lock_Display();
#ifdef __MACOSX__ // AKR, because of APPSTORE doesnt support X11	
	return 0; //AKR - appstore
#else
	retval = ( XGetSelectionOwner(SDL_Display, XA_PRIMARY) != SDL_Window );
#endif	
  Unlock_Display();

#elif defined(WIN_SCRAP)
/* * */
  retval = ( GetClipboardOwner() != SDL_Window );

#elif defined(QNX_SCRAP)
/* * */
  retval = ( PhInputGroup(NULL) != InputGroup );

#endif /* scrap type */

  return(retval);
}

PUBLIC void
put_scrap(int type, int srclen, const char *src) //maks
{
  scrap_type format;
  int dstlen;
  char *dst;

  format = convert_format(type);
  dstlen = convert_data(type, NULL, src, srclen);

#if defined(X11_SCRAP)
/* * */
  dst = (char *)malloc(dstlen);
#ifndef __MACOSX__ // AKR, because of APPSTORE doesnt support X11	
  if ( dst != NULL )
    {
      Lock_Display();
      convert_data(type, dst, src, srclen);
      XChangeProperty(SDL_Display, DefaultRootWindow(SDL_Display),
        XA_CUT_BUFFER0, format, 8, PropModeReplace, dst, dstlen);
      free(dst);
      if ( lost_scrap() )
        XSetSelectionOwner(SDL_Display, XA_PRIMARY, SDL_Window, CurrentTime);
      Unlock_Display();
    }
#endif
#elif defined(WIN_SCRAP)
/* * */
  if ( OpenClipboard(SDL_Window) )
    {
      HANDLE hMem;

      hMem = GlobalAlloc((GMEM_MOVEABLE|GMEM_DDESHARE), dstlen);
      if ( hMem != NULL )
        {
          dst = (char *)GlobalLock(hMem);
          convert_data(type, dst, src, srclen);
          GlobalUnlock(hMem);
          EmptyClipboard();
          SetClipboardData(format, hMem);
        }
      CloseClipboard();
    }

#elif defined(QNX_SCRAP)
/* * */
  #if (_NTO_VERSION < 620) /* before 6.2.0 releases */
  {
     PhClipHeader clheader={Ph_CLIPBOARD_TYPE_TEXT, 0, NULL};
     int* cldata;
     int status;

     dst = (char *)malloc(dstlen+4);
     if (dst != NULL)
     {
        cldata=(int*)dst;
        *cldata=type;
        convert_data(type, dst+4, src, srclen);
        clheader.data=dst;
        if (dstlen>65535)
        {
           clheader.length=65535; /* maximum photon clipboard size :( */
        }
        else
        {
           clheader.length=dstlen+4;
        }
        status=PhClipboardCopy(InputGroup, 1, &clheader);
        if (status==-1)
        {
           fprintf(stderr, "Photon: copy to clipboard was failed !\n");
        }
        free(dst);
     }
  }
  #else /* 6.2.0 and 6.2.1 and future releases */
  {
     PhClipboardHdr clheader={Ph_CLIPBOARD_TYPE_TEXT, 0, NULL};
     int* cldata;
     int status;

     dst = (char *)malloc(dstlen+4);
     if (dst != NULL)
     {
        cldata=(int*)dst;
        *cldata=type;
        convert_data(type, dst+4, src, srclen);
        clheader.data=dst;
        clheader.length=dstlen+4;
        status=PhClipboardWrite(InputGroup, 1, &clheader);
        if (status==-1)
        {
           fprintf(stderr, "Photon: copy to clipboard was failed !\n");
        }
        free(dst);
     }
  }
  #endif
#endif /* scrap type */
}

PUBLIC void
get_scrap(int type, int *dstlen, char **dst)
{
  scrap_type format;

  *dstlen = 0;
  format = convert_format(type);

#if defined(X11_SCRAP)
/* * */
  {
    Window owner;
    Atom selection;
    Atom seln_type;
    int seln_format;
    unsigned long nbytes;
    unsigned long overflow;
    char *src;

    Lock_Display();
#ifdef __MACOSX__ // AKR, because of APPSTORE doesnt support X11	  
	  owner=NULL;
#else
	  owner = XGetSelectionOwner(SDL_Display, XA_PRIMARY);
#endif	  
    Unlock_Display();
    if ( (owner == None) || (owner == SDL_Window) )
      {
        owner = DefaultRootWindow(SDL_Display);
        selection = XA_CUT_BUFFER0;
      }
    else
      {
        int selection_response = 0;
        SDL_Event event;

        owner = SDL_Window;
        Lock_Display();
        selection = XInternAtom(SDL_Display, "SDL_SELECTION", False);
#ifndef __MACOSX__ // AKR, because of APPSTORE doesnt support X11
		XConvertSelection(SDL_Display, XA_PRIMARY, format,
                                        selection, owner, CurrentTime);
#endif
		Unlock_Display();
        while ( ! selection_response )
          {
            SDL_WaitEvent(&event);
            if ( event.type == SDL_SYSWMEVENT )
              {
                XEvent xevent = event.syswm.msg->event.xevent;

                if ( (xevent.type == SelectionNotify) &&
                     (xevent.xselection.requestor == owner) )
                    selection_response = 1;
              }
          }
      }
#ifndef __MACOSX__ // AKR, because of APPSTORE doesnt support X11 

	Lock_Display();
    if ( XGetWindowProperty(SDL_Display, owner, selection, 0, INT_MAX/4,
                            False, format, &seln_type, &seln_format,
                       &nbytes, &overflow, (unsigned char **)&src) == Success )
      {
        if ( seln_type == format )
          {
            *dstlen = convert_scrap(type, NULL, src, nbytes);
            *dst = (char *)realloc(*dst, *dstlen);
            if ( *dst == NULL )
              *dstlen = 0;
            else
              convert_scrap(type, *dst, src, nbytes);
          }
        XFree(src);
      }
#endif

  }
	
    Unlock_Display();
#elif defined(WIN_SCRAP)
/* * */
  if ( IsClipboardFormatAvailable(format) && OpenClipboard(SDL_Window) )
    {
      HANDLE hMem;
      char *src;

      hMem = GetClipboardData(format);
      if ( hMem != NULL )
        {
          src = (char *)GlobalLock(hMem);
          *dstlen = convert_scrap(type, NULL, src, 0);
          *dst = (char *)realloc(*dst, *dstlen);
          if ( *dst == NULL )
            *dstlen = 0;
          else
            convert_scrap(type, *dst, src, 0);
          GlobalUnlock(hMem);
        }
      CloseClipboard();
    }
#elif defined(QNX_SCRAP)
/* * */
  #if (_NTO_VERSION < 620) /* before 6.2.0 releases */
  {
     void* clhandle;
     PhClipHeader* clheader;
     int* cldata;

     clhandle=PhClipboardPasteStart(InputGroup);
     if (clhandle!=NULL)
     {
        clheader=PhClipboardPasteType(clhandle, Ph_CLIPBOARD_TYPE_TEXT);
        if (clheader!=NULL)
        {
           cldata=clheader->data;
           if ((clheader->length>4) && (*cldata==type))
           {
              *dstlen = convert_scrap(type, NULL, (char*)clheader->data+4, clheader->length-4);
              *dst = (char *)realloc(*dst, *dstlen);
              if (*dst == NULL)
              {
                 *dstlen = 0;
              }
              else
              {
                 convert_scrap(type, *dst, (char*)clheader->data+4, clheader->length-4);
              }
           }
        }
        PhClipboardPasteFinish(clhandle);
     }
  }
  #else /* 6.2.0 and 6.2.1 and future releases */
  {
     void* clhandle;
     PhClipboardHdr* clheader;
     int* cldata;

     clheader=PhClipboardRead(InputGroup, Ph_CLIPBOARD_TYPE_TEXT);
     if (clheader!=NULL)
     {
        cldata=clheader->data;
        if ((clheader->length>4) && (*cldata==type))
        {
           *dstlen = convert_scrap(type, NULL, (char*)clheader->data+4, clheader->length-4);
           *dst = (char *)realloc(*dst, *dstlen);
           if (*dst == NULL)
           {
              *dstlen = 0;
           }
           else
           {
              convert_scrap(type, *dst, (char*)clheader->data+4, clheader->length-4);
           }
        }
     }
  }
  #endif
#endif /* scrap type */
}

#if defined(X11_SCRAP)
PRIVATE int clipboard_filter(const SDL_Event *event)
{
  /* Post all non-window manager specific events */
  if (event==NULL || event->type != SDL_SYSWMEVENT ) { //AKR sometimes NULL arrives
    return(1);
  }

  /* Handle window-manager specific clipboard events */
  switch (event->syswm.msg->event.xevent.type) {
    /* Copy the selection from XA_CUT_BUFFER0 to the requested property */
    case SelectionRequest: {
      XSelectionRequestEvent *req;
      XEvent sevent;
      int seln_format;
      unsigned long nbytes;
      unsigned long overflow;
      unsigned char *seln_data;

      req = &event->syswm.msg->event.xevent.xselectionrequest;
      sevent.xselection.type = SelectionNotify;
      sevent.xselection.display = req->display;
      sevent.xselection.selection = req->selection;
      sevent.xselection.target = None;
      sevent.xselection.property = None;
      sevent.xselection.requestor = req->requestor;
      sevent.xselection.time = req->time;
#ifndef __MACOSX__ // AKR, because of APPSTORE doesnt support X11		
      if ( XGetWindowProperty(SDL_Display, DefaultRootWindow(SDL_Display),
                              XA_CUT_BUFFER0, 0, INT_MAX/4, False, req->target,
                              &sevent.xselection.target, &seln_format,
                              &nbytes, &overflow, &seln_data) == Success )
        {
          if ( sevent.xselection.target == req->target )
            {
              if ( sevent.xselection.target == XA_STRING )
                {
                  if ( seln_data[nbytes-1] == '\0' )
                    --nbytes;
                }
              XChangeProperty(SDL_Display, req->requestor, req->property,
                sevent.xselection.target, seln_format, PropModeReplace,
                                                      seln_data, nbytes);
              sevent.xselection.property = req->property;
            }
          XFree(seln_data);
        }
      XSendEvent(SDL_Display,req->requestor,False,0,&sevent);
      XSync(SDL_Display, False);
#endif		
    }
    break;
  }

  /* Post the event for X11 clipboard reading above */
  return(1);
}
#endif /* X11_SCRAP */

#endif //#ifndef STAND_ALONE_GAME 
