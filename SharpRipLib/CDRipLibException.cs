using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpRipLib
{
    internal class CDRipLibException : Exception
    {
        private int _ErrorCode;

        private string _ErrorCodeMeaning;

        public CDRipLibException(int errorCode, string errorCodeMeaning)
            : base()
        {
            _ErrorCode = errorCode;
            _ErrorCodeMeaning = errorCodeMeaning;
        }

        public int ErrorCode
        {
            get
            {
                return _ErrorCode;
            }
        }

        public string ErrorCodeMeaning
        {
            get
            {
                return _ErrorCodeMeaning;
            }
        }
    }
}
