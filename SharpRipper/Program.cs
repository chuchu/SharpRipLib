using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SharpRipLib.SharpRipper
{
    class Program
    {
        static void Main(string[] args)
        {
            CommandLineOptions options = new CommandLineOptions();
            if (CommandLine.Parser.Default.ParseArguments(args, options))
            {
                if(options.Version)
                {
                    Console.WriteLine(Assembly.GetExecutingAssembly().GetName().Version);
                }
                else if(options.PrintToc)
                {
                    using (Ripper ripper = new Ripper())
                    {
                        IEnumerable<ITrack> tracks = ripper.GetTracks();

                        foreach (ITrack track in tracks)
                        {
                            Console.WriteLine(track.ToString());
                        }
                    }
                }
            }
        }
    }
}
