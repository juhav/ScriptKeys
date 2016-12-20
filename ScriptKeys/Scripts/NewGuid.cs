//css_reference ScriptKeys.exe;
//css_reference InputSimulator.dll;

using System;
using System.Windows.Forms;
using ScriptKeys;
using WindowsInput;

public class Script : ScriptBase
{
    /// <summary>
    /// Generate new guid and type it.
    /// </summary>
    /// <param name="parameters"></param>
    public override void Run(string[] parameters)
    {
        // MessageBox.Show("Hello World: " + parameters);

        String g = Guid.NewGuid().ToString();
        
        if (Contains(parameters, "upper"))
        {
            g = g.ToUpperInvariant();
        }

        InputSimulator.SimulateTextEntry(g);
    }
}