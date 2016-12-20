//css_reference ScriptKeys.exe;
//css_reference InputSimulator.dll;
//css_reference Cyotek.Windows.Forms.ColorPicker;

using System;
using System.Drawing;
using System.Windows.Forms;
using ScriptKeys;
using WindowsInput;

public class Script : ScriptBase
{
    public override void Run(string[] parameters)
    {
        string result = "";

        using (var form = new Cyotek.Windows.Forms.ColorPickerDialog()
        {
            StartPosition = FormStartPosition.Manual,
            TopMost = true
        })
        {
            form.SetDesktopLocation(Cursor.Position.X - 20, Cursor.Position.Y - 20);
            var dialogResult = form.ShowDialog();

            if (dialogResult == DialogResult.OK)
            {
                Color c = form.Color;

                if (c.A == 255)
                {
                    result = "#" + c.R.ToString("X2") + c.G.ToString("X2") + c.B.ToString("X2");
                }
                else
                {
                    result = "#" + c.R.ToString("X2") + c.G.ToString("X2") + c.B.ToString("X2") + c.A.ToString("X2");
                }

            }
        }

        InputSimulator.SimulateTextEntry(result);
    }
}