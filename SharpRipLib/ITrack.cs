using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpRipLib
{
    public interface ITrack
    {
        uint Number { get; }

        uint StartSector { get; }

        uint EndSector { get; }

        TimeSpan Duration { get; }

        TrackType Type { get; }
    }
}
