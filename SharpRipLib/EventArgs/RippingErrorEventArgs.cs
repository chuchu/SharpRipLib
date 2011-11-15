using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpRipLib.EventArgs
{
    public class RippingErrorEventArgs : System.EventArgs
    {
        private Exception _Exception;        

        public RippingErrorEventArgs(Exception exception) 
        {
            _Exception = exception;
        }        

        public Exception Exception
        {
            get 
            {
                return _Exception;
            }
        }
    }
}
