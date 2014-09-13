using SharpRipLib.CDRipLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpRipLib
{
    internal sealed class RipperToken : IDisposable
    {
        public RipperToken()
        {
            int errorCode = CDRipLib.CDRipLib.CR_Init(TransportLayer.NTSCSI);

            if (errorCode != ErrorCodes.CDEX_OK)
            {
                throw new CDRipLibException(errorCode, string.Empty);
            }
        }

        public TOCENTRY GetTocEntry(int index)
        {
            return CDRipLib.CDRipLib.CR_GetTocEntry(index);
        }
        
        public void Dispose()
        {
            int errorCode = CDRipLib.CDRipLib.CR_DeInit();

            if (errorCode != ErrorCodes.CDEX_OK)
            {
                throw new CDRipLibException(errorCode, string.Empty);
            }
        }
    }
}
