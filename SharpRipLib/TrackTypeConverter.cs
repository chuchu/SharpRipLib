using SharpRipLib.CDRipLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpRipLib
{
    internal class TrackTypeConverter : ITrackTypeConverter
    {
        public TrackType FromFlag(short flag)
        {
            switch(flag)
            {
                case Constants.AUDIOTRKFLAG:
                    return TrackType.Audio;
                case Constants.CDROMDATAFLAG:
                    return TrackType.Data;
                default:
                    throw new ArgumentException(string.Format("Unknown flag: {0}", flag));
            }
        }
    }
}
