using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsInput;

namespace ScriptKeys
{
    public abstract class ScriptBase
    {
        public void RunCore(string parameters)
        {
            try
            {
                var arrayOfParams = (parameters ?? "").Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

                
                Run(arrayOfParams);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Script error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Override this in the actual script
        public abstract void Run(string[] parameters);

        protected string GetClipboard()
        {
            return Clipboard.GetText();
        }

        protected string[] GetClipboardLines()
        {
            return Clipboard.GetText().Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
        }

        protected void Copy()
        {
            InputSimulator.SimulateKeyDown(VirtualKeyCode.CONTROL);
            InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_C);
            InputSimulator.SimulateKeyUp(VirtualKeyCode.CONTROL);
        }

        protected void Paste()
        {
            InputSimulator.SimulateKeyDown(VirtualKeyCode.CONTROL);
            InputSimulator.SimulateKeyDown(VirtualKeyCode.VK_V);
            InputSimulator.SimulateKeyUp(VirtualKeyCode.VK_V);
            InputSimulator.SimulateKeyUp(VirtualKeyCode.CONTROL);
        }

        protected void SelectAll()
        {
            InputSimulator.SimulateKeyDown(VirtualKeyCode.CONTROL);
            InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_A);
            InputSimulator.SimulateKeyUp(VirtualKeyCode.CONTROL);
        }

        protected bool Contains(string[] parameters, string value)
        {
            return parameters.Any(p => string.Equals(p, value, StringComparison.InvariantCultureIgnoreCase));
        }
    }
}
