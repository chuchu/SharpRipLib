using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpRipLib.EventArgs
{
    public class DataRippedEventArgs : System.EventArgs
    {
        private byte[] _Data;        

        public DataRippedEventArgs( byte[] data) 
        {            
            _Data = data;
        }        

        public byte[] Data
        {
            get 
            {
                return _Data;
            }
        }
    }
}
