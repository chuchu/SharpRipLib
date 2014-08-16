using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpRipLib
{
    public interface ITrackTypeConverter
    {
        TrackType FromFlag(short flag);
    }
}
