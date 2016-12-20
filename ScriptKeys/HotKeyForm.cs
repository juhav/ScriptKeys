using ScriptKeys.Helpers;
using ScriptKeys.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScriptKeys
{
    public partial class HotKeyForm : Form
    {
        private MyApp myApp;

        public delegate void SaveHotKeyDelegate(HotKey hotkey);
        public event SaveHotKeyDelegate SaveHotKey;
        

        public HotKeyForm()
        {
            InitializeComponent();
        }

        public HotKeyForm(MyApp myApp)
        {
            InitializeComponent();

            this.myApp = myApp;

            InitKeyComboBox();
            InitScripts();

            btnSave.Enabled = false;
        }

        public int GetKeyWithModifiers()
        {
            int mask = 0;

            if (chkLShift.Checked) mask |= KeyMod.L_SHIFT;
            if (chkLAlt.Checked) mask |= KeyMod.L_ALT;
            if (chkLControl.Checked) mask |= KeyMod.L_CONTROL;
            if (chkLWin.Checked) mask |= KeyMod.L_WIN;

            if (chkRShift.Checked) mask |= KeyMod.R_SHIFT;
            if (chkRAlt.Checked) mask |= KeyMod.R_ALT;
            if (chkRControl.Checked) mask |= KeyMod.R_CONTROL;
            if (chkRWin.Checked) mask |= KeyMod.R_WIN;

            var item = cmbKey.SelectedItem as ListItem<int>;

            int key = (item.Value << 8) | mask;

            return key;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var script = cmbScripts.SelectedItem as ListItem<Script>;

            if (script != null)
            {
                var hotkey = new HotKey()
                {
                    Key = GetKeyWithModifiers(),
                    Parameters = (txtParameters.Text ?? "").Trim(),
                    ScriptName = script.Text 
                };

                OnSaveHotKey(hotkey);

                this.Close();
            }
        }

        private void InitScripts()
        {
            cmbScripts.Items.Clear();

            var scripts = myApp.Scripts.Values
                .Select(x => new ListItem<Script>(x.Name, x))
                .ToArray();
            
            cmbScripts.Items.AddRange(scripts);
        }

        private void InitKeyComboBox()
        {
            cmbKey.Items.Clear();

            var values = (Enum.GetValues(typeof(Keys)) as Keys[])
                .Distinct()
                .Where(v => (int)v > 6 && (int)v < 256)
                .Select(v => new ListItem<int>(v.ToString(), (int)v))
                .ToArray();

            cmbKey.Items.AddRange(values);
            cmbKey.SelectedIndex = 0;
        }

        private void OnSaveHotKey(HotKey hotkey)
        {
            if (this.SaveHotKey != null)
            {
                SaveHotKey(hotkey);
            }
        }

        private void cmbKey_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetSaveButton();
        }

        private void cmbScripts_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetSaveButton();
        }

        private void SetSaveButton()
        {
            if (cmbKey.SelectedIndex == -1) return;
            if (cmbScripts.SelectedIndex == -1) return;

            btnSave.Enabled = true;
        }
    }
}
