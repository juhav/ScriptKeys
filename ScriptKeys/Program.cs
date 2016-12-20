using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScriptKeys
{
    static class Program
    {
        [STAThread]
        public static void Main()
        {
            var app = new MyApp();
            app.Run();
            
        }
    }
}
