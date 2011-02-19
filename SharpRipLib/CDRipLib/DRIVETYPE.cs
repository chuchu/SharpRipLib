﻿/*
 * SharpRipLib provides an .NET Wrapper for the CDRipLib. 
 * This library can be found at: http://sourceforge.net/projects/libcdrip/
 * Copyright (C) 2011  Chris Hußlack
 *
 *  This program is free software: you can redistribute it and/or modify
 *  it under the terms of the GNU General Public License as published by
 *  the Free Software Foundation, either version 3 of the License, or
 *  (at your option) any later version.

 *  This program is distributed in the hope that it will be useful,
 *  but WITHOUT ANY WARRANTY; without even the implied warranty of
 *  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *  GNU General Public License for more details.

 *   You should have received a copy of the GNU General Public License
 *  along with this program.  If not, see <http://www.gnu.org/licenses/>.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpRipLib.CDRipLib
{
    public enum DRIVETYPE
    {
        GENERIC = 0,
        TOSHIBA,
        TOSHIBANEW,
        IBM,
        NEC,
        DEC,
        IMS,
        KODAK,
        RICOH,
        HP,
        PHILIPS,
        PLASMON,
        GRUNDIGCDR100IPW,
        MITSUMICDR,
        PLEXTOR,
        SONY,
        YAMAHA,
        NRC,
        IMSCDD5,
        CUSTOMDRIVE,
        NUMDRIVETYPES
    }
}
