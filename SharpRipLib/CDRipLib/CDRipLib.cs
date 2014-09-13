/*
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
using System.Runtime.InteropServices;

namespace SharpRipLib.CDRipLib
{
    public static class CDRipLib
    {
        /// <summary>
        /// Call Init before anything else
        /// </summary>
        /// <param name="nTransportLayer"></param>
        /// <returns>CDEX_ERR</returns>
        [DllImport("CDRip.dll")]
        public static extern int CR_Init(int nTransportLayer);

        /// <summary>
        /// Call DeInit when ripping library is no longer needed.
        /// </summary>
        /// <returns></returns>
        [DllImport("CDRip.dll")]
        public static extern int CR_DeInit();

        /// <summary>
        /// Get the DLL version number.
        /// </summary>
        /// <returns>
        /// The DLL version number
        /// </returns>
        [DllImport("CDRip.dll")]
        public static extern int CR_GetCDRipVersion();

        /// <summary>
        /// Get the number of detected CD-ROM drives.
        /// </summary>
        /// <returns>
        /// Number of detected CD-ROM drives.
        /// </returns>
        [DllImport("CDRip.dll")]
        public static extern int CR_GetNumCDROM();
        
        /// <summary>
        /// Get the CDROM parameters of the active drive.
        /// </summary>
        /// <param name="buf"></param>
        /// <returns></returns>
        [DllImport("CDRip.dll")]
        public static extern int CR_GetCDROMParameters(IntPtr buf);

        /// <summary>
        /// Start ripping section, output is fetched to WriteBufferFunc.
        /// Data is extracted from dwStartSector to dwEndSector.
        /// </summary>        
        [DllImport("CDRip.dll")]
        public static extern int CR_OpenRipper(out int plBufferSize, int dwStartSector, int dwEndSector);

        [DllImport("CDRip.dll")]
        public static extern void CR_SetActiveCDROM(int nActiveDrive);

        /// <summary>
        /// Read the table of contents.
        /// </summary>
        /// <returns>CDEX_ERR</returns>
        [DllImport("CDRip.dll")]
        public static extern int CR_ReadToc();

        /// <summary>
        /// Get the number of TOC entries, including the lead out.
        /// </summary>
        /// <returns></returns>
        [DllImport("CDRip.dll")]
        public static extern int CR_GetNumTocEntries();

        /// <summary>
        /// Close the ripper, has to be called when the ripping process is completed (i.e 100%) 
        /// Or it can be called to abort the current ripping section
        /// </summary>
        /// <returns></returns>
        [DllImport("CDRip.dll")]
        public static extern int CR_CloseRipper();

        /// <summary>
        /// Indicates how far the ripping process is right now
        /// Returns 100% when the ripping is completed
        /// </summary>
        /// <returns></returns>
        [DllImport("CDRip.dll")]
        public static extern int CR_GetPercentCompleted();

        /// <summary>
        /// Get the TOC entry
        /// </summary>
        [DllImport("CDRip.dll")]
        public static extern TOCENTRY CR_GetTocEntry(int nTocEntry);

        /// <summary>
        /// Rip a chunk from the CD, pbtStream contains the ripped data, pNumBytes the
        /// number of bytes that have been ripped and corrected for jitter (if enabled)
        /// DLLEXPORT CDEX_ERR CRCCONV CR_RipChunk(BYTE *pbtStream, LONG *pNumBytes, BOOL &bAbort);
        /// </summary>
        [DllImport("CDRip.dll")]
        public static extern int CR_RipChunk(IntPtr pbtStream, out int pNumBytes, out bool abort);
    }
}
