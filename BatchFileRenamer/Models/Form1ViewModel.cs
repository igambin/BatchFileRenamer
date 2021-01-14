using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Microsoft.VisualBasic.CompilerServices;

namespace BatchFileRenamer.Models
{
    internal class Form1ViewModel
    {
        public Form1ViewModel()
        {
            Files = new List<RenameFileInfo>();
            SimpleReplacePatterns = new List<string>();
            SimpleSearchPatterns = new List<string>();
            RegexReplacePatterns = new List<string>();
            RegexSearchPatterns = new List<string>();

        }

        IList<RenameFileInfo> Files { get; }
        
        IList<string> SimpleSearchPatterns { get; }
        IList<string> SimpleReplacePatterns { get; }
        IList<string> RegexSearchPatterns { get; }
        IList<string> RegexReplacePatterns { get; }
    }
}
