namespace ScriptKeys
{
    using CSScriptLibrary;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public static class ScriptHelper
    {
        public static dynamic LoadCode(string code)
        {
            dynamic script = CSScript.Evaluator.LoadCode(code);

            return script;
        }
    }
}
