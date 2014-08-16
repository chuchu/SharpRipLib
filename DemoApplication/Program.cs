using SharpRipLib;
using SharpRipLib.CDRipLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DemoApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            using (Ripper ripper = new Ripper())
            {
                //ripper.RippTrack();

                IEnumerable<ITrack> tracks = ripper.GetTracks();

                foreach (ITrack track in tracks)
                {
                    Console.WriteLine(track.ToString());
                }
            }

            Console.WriteLine("Done");
            Console.ReadLine();
        }

        private static void Test01()
        {
            SharpRipLib.CDRipLib.CDRipLib.CR_Init(1);

            try
            {
                Console.WriteLine("Version: {0}", SharpRipLib.CDRipLib.CDRipLib.CR_GetCDRipVersion());

                int result = SharpRipLib.CDRipLib.CDRipLib.CR_ReadToc();
                Console.WriteLine("Result: {0}", result);

                TOCENTRY toc1 = SharpRipLib.CDRipLib.CDRipLib.CR_GetTocEntry(0);
                Console.WriteLine("Track: {0}", toc1.btTrackNumber);

                TOCENTRY toc2 = SharpRipLib.CDRipLib.CDRipLib.CR_GetTocEntry(1);
                Console.WriteLine("Track: {0}", toc2.btTrackNumber);

            }
            finally
            {
                SharpRipLib.CDRipLib.CDRipLib.CR_DeInit();
            }
        }        
    }
}
