using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpRipLib.CDRipLib
{
    public static class ErrorCodes
    {
        public const int CDEX_OK = 0x00000000;

        public const int CDEX_ERROR = 0x00000001;

        public const int CDEX_FILEOPEN_ERROR = 0x00000002;

        public const int CDEX_JITTER_ERROR = 0x00000003;

        public const int CDEX_RIPPING_DONE = 0x00000004;

        public const int CDEX_RIPPING_INPROGRESS = 0x00000005;

        public const int CDEX_FILEWRITE_ERROR = 0x00000006;

        public const int CDEX_OUTOFMEMORY = 0x00000007;

        public const int CDEX_NOCDROMDEVICES = 0x00000008;

        public const int CDEX_FAILEDTOLOADASPIDRIVERS = 0x00000009;

        public const int CDEX_NATIVEEASPINOTSUPPORTED = 0x0000000A;

        public const int CDEX_FAILEDTOGETASPISTATUS = 0x0000000B;

        public const int CDEX_NATIVEEASPISUPPORTEDNOTSELECTED = 0x0000000C;

        public const int CDEX_ACCESSDENIED = 0x0000000D;

        public const int CDEX_SOMEACCESSDENIED = 0x0000000E;
    }
}
