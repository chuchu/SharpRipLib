using CommandLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpRipLib.SharpRipper
{
    internal class CommandLineOptions
    {
        [Option("version", DefaultValue = false, HelpText = "Prints the current version.")]
        public bool Version { get; set; }

        [Option("printtoc", DefaultValue = false, HelpText = "Prints the table of contents.")]
        public bool PrintToc { get; set; }
    }
}
