using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpRipLib.CDRipLib;
using System.Runtime.InteropServices;
using SharpRipLib.EventArgs;

namespace SharpRipLib
{
    public class Ripper : IDisposable
    {
        private static Ripper _Instance;

        private bool _IsDisposed;

        public event EventHandler<DataRippedEventArgs> OnDataRipped;

        public event EventHandler OnRippingFinished;

        public event EventHandler<RippingErrorEventArgs> OnRippingError;

        private ITrackTypeConverter _TrackTypeConverter = new TrackTypeConverter();

        public Ripper()
        {
            SharpRipLib.CDRipLib.CDRipLib.CR_Init(1);
        }

        public void RippTrack()
        {
            SharpRipLib.CDRipLib.CDRipLib.CR_ReadToc();
            
            TOCENTRY toc1 = SharpRipLib.CDRipLib.CDRipLib.CR_GetTocEntry(1);
            TOCENTRY toc2 = SharpRipLib.CDRipLib.CDRipLib.CR_GetTocEntry(2);

            int bufferSize = -1;
            int success = SharpRipLib.CDRipLib.CDRipLib.CR_OpenRipper(out bufferSize, (int)toc1.dwStartSector, (int)toc2.dwStartSector);

            Console.WriteLine("Open ripper success: {0}", success);

            bool abort;
            int numberOfBytesRead = -1;
            if (success == 0)
            {
                try
                {
                    while (numberOfBytesRead != 0)
                    {
                        IntPtr pbtStream = Marshal.AllocHGlobal(bufferSize * Marshal.SizeOf(typeof(byte)));
                        SharpRipLib.CDRipLib.CDRipLib.CR_RipChunk(pbtStream, out numberOfBytesRead, out abort);

                        if (numberOfBytesRead != 0)
                        {
                            byte[] byteArray = new byte[numberOfBytesRead];
                            Marshal.Copy(pbtStream, byteArray, 0, numberOfBytesRead);

                            if (OnDataRipped != null)
                            {
                                OnDataRipped(this, new DataRippedEventArgs(byteArray));
                            }
                        }
                        else
                        {
                            if (OnRippingFinished != null)
                            {
                                OnRippingFinished(this, null);
                            }
                        }
                    }
                }
                finally
                {
                    SharpRipLib.CDRipLib.CDRipLib.CR_CloseRipper();
                }
            }
        }

        public bool IsDisposed
        {
            get
            {
                return _IsDisposed;
            }
        }

        public static Ripper GetInstance()
        {
            if (_Instance == null || _Instance.IsDisposed)
            {
                _Instance = new Ripper();
            }

            return _Instance;
        }

        public int GetVersion()
        {
            return SharpRipLib.CDRipLib.CDRipLib.CR_GetCDRipVersion();
        }

        public IEnumerable<ITrack> GetTracks()
        {
            List<ITrack> trackList = new List<ITrack>();
            
            SharpRipLib.CDRipLib.CDRipLib.CR_ReadToc();

            int trackCount = SharpRipLib.CDRipLib.CDRipLib.CR_GetNumTocEntries();

            for (int i = 0; i < trackCount; i++)
            {
                TOCENTRY currentTocEntry = SharpRipLib.CDRipLib.CDRipLib.CR_GetTocEntry(i);
                TOCENTRY nextTocEntry = SharpRipLib.CDRipLib.CDRipLib.CR_GetTocEntry(i+1);

                Track track = new Track(
                    currentTocEntry.btTrackNumber,
                    currentTocEntry.dwStartSector,
                    nextTocEntry.dwStartSector - 1,
                    _TrackTypeConverter.FromFlag(currentTocEntry.btFlag));

                trackList.Add(track);
            }

            return trackList;
        }

        public void Dispose()
        {
            Dispose(true);

            // Use SupressFinalize in case a subclass of this type implements a finalizer.
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            // If you need thread safety, use a lock around these operations, as well as in your methods that use the resource.
            if (!_IsDisposed)
            {
                if (disposing)
                {
                    // Release managed resources.
                }

                // Release unmanaged resources.
                // Set large fields to null.
                // Call Dispose on your base class.
                SharpRipLib.CDRipLib.CDRipLib.CR_DeInit();

                _IsDisposed = true;
            }
        }

        ~Ripper() // Use C# destructor syntax for finalization code.
        {
            Dispose(false);
        }
    }
}
