using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScriptKeys.Model
{
    public class Script
    {
        public string Name { get; set; }
        public string SourceFile { get; set; }
        public string Source { get; set; }
        public dynamic CompiledScript { get; set; } 
    }
}
