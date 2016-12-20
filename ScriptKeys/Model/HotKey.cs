using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScriptKeys.Model
{
    public class HotKey
    {
        public int Id { get; set; }
        public string ScriptName { get; set; }
        public string Parameters { get; set; }
        public int Key { get; set; }
    }
}
