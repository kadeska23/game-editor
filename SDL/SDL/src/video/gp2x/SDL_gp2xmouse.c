/*
    SDL - Simple DirectMedia Layer
    Copyright (C) 1997-2004 Sam Lantinga

    This library is free software; you can redistribute it and/or
    modify it under the terms of the GNU Library General Public
    License as published by the Free Software Foundation; either
    version 2 of the License, or (at your option) any later version.

    This library is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
    Library General Public License for more details.

    You should have received a copy of the GNU Library General Public
    License along with this library; if not, write to the Free
    Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA  02111-1307  USA

    Sam Lantinga
    slouken@libsdl.org
*/

#ifdef SAVE_RCSID
static char rcsid =
 "@(#) $Id: SDL_gp2xmouse.c,v 1.4 2004/01/04 16:49:24 slouken Exp $";
#endif

#include <stdio.h>

#include "SDL_error.h"
#include "SDL_mouse.h"
#include "SDL_events_c.h"

#include "SDL_gp2xmouse_c.h"


/* The implementation dependent data for the window manager cursor */
struct WMcursor {
  video_bucket *bucket;
  int dimension;
  unsigned short fgr, fb, bgr, bb, falpha, balpha;
};
