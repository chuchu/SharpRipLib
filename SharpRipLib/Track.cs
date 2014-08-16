using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpRipLib
{
    internal class Track : ITrack
    {
        private readonly uint _Number;
        private readonly uint _StartSector;
        private readonly uint _EndSector;
        private readonly TrackType _Type;

        public Track(uint number, uint startSector, uint endSector, TrackType type)
        {
            if (number < 0)
            {
                throw new ArgumentOutOfRangeException("Number shall be not smaller then zero.");
            }

            if( endSector < startSector )
            {
                throw new ArgumentException("The endSector shall be greater then the startSector.");
            }

            _Number = number;
            _StartSector = startSector;
            _EndSector = endSector;
            _Type = type;            
        }

        public uint Number
        {
            get 
            {
                return _Number;
            }            
        }

        public uint StartSector
        {
            get 
            {
                return _StartSector;
            }
        }

        public uint EndSector
        {
            get 
            {
                return _EndSector;
            }
        }

        public TimeSpan Duration
        {
            get 
            {
                long sectorCount = _EndSector - _StartSector;
                int seconds = (int)Math.Ceiling(sectorCount / 75.0);
                return new TimeSpan(0, 0, seconds);
            }
        }

        public TrackType Type
        {
            get 
            {
                return _Type;
            }
        }

        public override string ToString()
        {
            return string.Format("{0}\t{1}\t{2}", Number, Type, Duration.ToString());
        }
    }
}
