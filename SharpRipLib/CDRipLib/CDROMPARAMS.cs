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
    [StructLayout(LayoutKind.Sequential)]
    public struct CDROMPARAMS
    {
        /// <summary>
        /// CD-ROM ID, must be unique to index settings in INI file
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 255)]
        public string lpszCDROMID;

        /// <summary>
        /// Number of sector to read per burst
        /// </summary>
        public int nNumReadSectors;

        /// <summary>
        /// Number of overlap sectors for jitter correction
        /// </summary>
        public int nNumOverlapSectors;

        /// <summary>
        /// Number of sector to compare for jitter correction
        /// </summary>
        public int nNumCompareSectors;

        /// <summary>
        /// Fudge factor at start of ripping in sectors
        /// </summary>
        public int nOffsetStart;

        /// <summary>
        /// Fudge factor at the end of ripping in sectors
        /// </summary>
        public int nOffsetEnd;

        /// <summary>
        /// CD-ROM speed factor 0 .. 32 x
        /// </summary>
        public int nSpeed;

        /// <summary>
        /// CD-ROM spin up time in seconds
        /// </summary>
        public int nSpinUpTime;

        /// <summary>
        /// Boolean indicates whether to use Jitter Correction
        /// </summary>
        public bool bJitterCorrection;

        /// <summary>
        /// Swap left and right channel ? 
        /// </summary>
        public bool bSwapLefRightChannel;

        /// <summary>
        /// Drive specific parameters
        /// </summary>
        public DRIVETABLE DriveTable;

        /// <summary>
        /// SCSI target ID
        /// </summary>
        public byte btTargetID;

        /// <summary>
        /// SCSI Adapter ID
        /// </summary>
        public byte btAdapterID;

        /// <summary>
        /// SCSI LUN ID
        /// </summary>
        public byte btLunID;

        /// <summary>
        /// When set ASPI posting is used, otherwhiese ASPI polling is used
        /// </summary>
        public bool bAspiPosting;

        public int nAspiRetries;

        public int nAspiTimeOut;

        /// <summary>
        /// Enables Multiple Read Verify Feature
        /// </summary>
        public bool bEnableMultiRead;

        /// <summary>
        /// Only do the multiple reads on the first block
        /// </summary>
        public bool bMultiReadFirstOnly;

        /// <summary>
        /// Number of times to reread and compare
        /// </summary>
        public int nMultiReadCount;

        /// <summary>
        /// Lock the CD-ROM drive tray during the ripping
        /// </summary>
        public bool bLockDuringRead;

        public int nRippingMode;

        public int nParanoiaMode;

        /// <summary>
        /// Read CD Text info?
        /// </summary>
        public bool bUseCDText;

    }    
}
