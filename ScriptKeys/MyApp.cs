using ScriptKeys.DAL;
using ScriptKeys.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScriptKeys
{
    public class MyApp
    {
        private const int WH_KEYBOARD_LL = 13;
        private const int WM_KEYDOWN = 0x0100;
        private const int WM_KEYUP = 0x0101;

        private LowLevelKeyboardProc lowLevelKeyboardProc;
        private IntPtr hookID = IntPtr.Zero;
        private byte[] keys = new byte[256];
        private MainForm frm;
        private Dictionary<string, Script> scripts = new Dictionary<string, Script>();
        private Dictionary<int, HotKey> hotkeys = new Dictionary<int, HotKey>();

        private delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);

        public Dictionary<string, Script> Scripts
        {
            get
            {
                return scripts;
            }
        }

        public Dictionary<int, HotKey> Hotkeys
        {
            get
            {
                return hotkeys;
            }
        }

        public void Run()
        {
            lowLevelKeyboardProc = new LowLevelKeyboardProc(HookCallback);
            hookID = SetHook(lowLevelKeyboardProc);

            InitScripts();
            InitHotkeys();

            using (frm = new MainForm(this))
            {
                Application.Run(frm);
            }

            UnhookWindowsHookEx(hookID);
        }

        //void btnSave_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        int key = frm.GetKeyWithModifiers();
        //        string scriptSource = frm.Editor.Text;
        //        dynamic script = ScriptHelper.LoadCode(scriptSource);

        //        //scripts.Add(key, script);
        //        frm.Hide();
        //    }
        //    catch  (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "Script compilation error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        private IntPtr SetHook(LowLevelKeyboardProc proc)
        {
            using (Process curProcess = Process.GetCurrentProcess())
            {
                using (ProcessModule curModule = curProcess.MainModule)
                {
                    return SetWindowsHookEx(WH_KEYBOARD_LL, proc, GetModuleHandle(curModule.ModuleName), 0);
                }
            }
        }

        private bool IsDown(Keys key)
        {
            return (keys[(int)key] == 1);
        }

        private int GetCurrentModifiers()
        {
            int mask = 0;

            if (IsDown(Keys.LShiftKey)) mask |= KeyMod.L_SHIFT;
            if (IsDown(Keys.LMenu)) mask |= KeyMod.L_ALT;
            if (IsDown(Keys.LControlKey)) mask |= KeyMod.L_CONTROL;
            if (IsDown(Keys.LWin)) mask |= KeyMod.L_WIN;

            if (IsDown(Keys.RShiftKey)) mask |= KeyMod.R_SHIFT;
            if (IsDown(Keys.RMenu)) mask |= KeyMod.R_ALT;
            if (IsDown(Keys.RControlKey)) mask |= KeyMod.R_CONTROL;
            if (IsDown(Keys.RWin)) mask |= KeyMod.R_WIN;

            
            return mask;
        }

        private IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            Keys key = Keys.None;

            if (nCode >= 0 && wParam == (IntPtr)WM_KEYDOWN)
            {
                int vkCode = Marshal.ReadInt32(lParam);
                key = (Keys)vkCode;

                if (keys[vkCode] == 0)
                {
                    keys[vkCode] = 1;

                    int mod = GetCurrentModifiers();
                    int keyWithMod = (vkCode << 8) | mod;

                    Debug.WriteLine(keyWithMod);

                    if (hotkeys.ContainsKey(keyWithMod))
                    {
                        var hotkey = hotkeys[keyWithMod];
                        var script = scripts[hotkey.ScriptName]; //.Run("test test");
                        script.CompiledScript.RunCore(hotkey.Parameters ?? "");

                        
                        return (IntPtr)1;
                    }

                    //if (IsDown(Keys.LWin) && IsDown(Keys.LShiftKey))
                    //{
                        //if (key == Keys.F)
                        //{
                        //    _frm.Text = Clipboard.GetText();
                        //    //WindowsInput.InputSimulator.SimulateKeyDown(WindowsInput.VirtualKeyCode.LCONTROL);
                        //    string s = Guid.NewGuid().ToString();
                        //    // WindowsInput.InputSimulator.SimulateTextEntry(s);
                        //    return (IntPtr) 1;
                        //    //WindowsInput.InputSimulator.SimulateKeyUp(WindowsInput.VirtualKeyCode.LCONTROL);
                        //}
                        //if (key == Keys.D)
                        //{
                        //    return (IntPtr)1;
                        //}
                    //}
                }

            }

            else if (nCode >= 0 && wParam == (IntPtr)WM_KEYUP)
            {
                int vkCode = Marshal.ReadInt32(lParam);

                if (keys[vkCode] == 1)
                {
                    keys[vkCode] = 0;
                }
            }

            if (key != Keys.None && CheckAppKeys(key))
            {
                return (IntPtr)1;
            }

            return CallNextHookEx(hookID, nCode, wParam, lParam);
        }

        private bool CheckAppKeys(Keys key)
        {
            if (IsDown(Keys.LControlKey) && IsDown(Keys.RControlKey))
            {
                if (frm.Visible)
                {
                    frm.Hide();
                }
                else
                {
                    frm.Show();
                }

                return true;
            }

            return false;
        }

        private void InitScripts()
        {
            string scriptsPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "scripts");

            foreach (var fullFileName in Directory.EnumerateFiles(scriptsPath))
            {
                try
                {
                    string fileName = Path.GetFileName(fullFileName);
                    string source = File.ReadAllText(fullFileName, Encoding.UTF8);
                    dynamic compiledCode = ScriptHelper.LoadCode(source);

                    var script = new Script()
                    {
                        CompiledScript = compiledCode,
                        Name = fileName,
                        Source = source,
                        SourceFile = fullFileName
                    };

                    scripts.Add(script.Name, script);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Script compilation error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        public void InitHotkeys()
        {
            var database = new Database();
            
            hotkeys = database.GetHotKeys().ToDictionary(x => x.Key);
        }

        #region Dll Imports

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook, LowLevelKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);

        #endregion
    }
}
