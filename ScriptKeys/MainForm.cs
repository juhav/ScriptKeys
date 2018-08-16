using FastColoredTextBoxNS;
using ScriptKeys.DAL;
using ScriptKeys.Helpers;
using ScriptKeys.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScriptKeys
{
    public partial class MainForm : Form
    {
        private MyApp myApp;
        private Dictionary<string, Script> scripts = new Dictionary<string, Script>(StringComparer.InvariantCultureIgnoreCase);
        private FastColoredTextBox editor;
        private FastColoredTextBox editor1;
        private FastColoredTextBox editor2;

        public FastColoredTextBox Editor
        {
            get
            {
                return editor;
            }
        }

        public MainForm()
        {
            InitializeComponent();
        }

        public MainForm(MyApp myApp)
        {
            InitializeComponent();

            editor  = new FastColoredTextBoxNS.FastColoredTextBox();
            editor.Dock = DockStyle.Fill;
            editor.Language = FastColoredTextBoxNS.Language.CSharp;
            tableLayoutPanel2.Controls.Add(editor, 0, 1);

            CreateTextToolsEditors();

            this.myApp = myApp;

            InitScripts();
            InitHotKeys();

            mnuExit.Click += mniExit_Click;
            this.Load += NewHotKeyForm_Load;
        }

        private void CreateTextToolsEditors()
        {
            editor1  = new FastColoredTextBox();
            editor1.Dock = DockStyle.Fill;
            editor1.Language = Language.Custom;
            TextToolsTextBoxesSplitContainer.Panel1.Controls.Add(editor1);

            editor2 = new FastColoredTextBox();
            editor2.Dock = DockStyle.Fill;
            editor2.Language = Language.Custom;
            TextToolsTextBoxesSplitContainer.Panel2.Controls.Add(editor2);

        }

        private void InitScripts()
        {
            var scripts = myApp.Scripts.Values
                .Select(x => new ListItem<Script>(x.Name, x))
                .ToArray();

            cmbScripts.Items.AddRange(scripts);
        }

        private void InitHotKeys()
        {
            lvwHotkeys.Items.Clear();

            foreach (var hk in myApp.Hotkeys)
            {
                var script = hk.Value;

                var li = lvwHotkeys.Items.Add(KeyMod.GetKeyAsText(script.Key).ToString());
                li.SubItems.Add(script.ScriptName);
                li.SubItems.Add(script.Parameters);
                li.Tag = script;
            }
        }

        void NewHotKeyForm_Load(object sender, EventArgs e)
        {
            ShowTrayIcon();
            //notifyIcon.Visible = false;
            //notifyIcon.Icon = null;
            //notifyIcon.Dispose();
        }

        public void ShowTrayIcon()
        {
            myNotifyIcon.Visible = true;
        }

        void mniExit_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            myNotifyIcon.Visible = false;
            this.Close();
            Application.Exit();
        }

        private void cmbScripts_SelectedIndexChanged(object sender, EventArgs e)
        {
            var item = cmbScripts.SelectedItem as ListItem<Script>;

            if (item != null)
            {
                editor.Text = item.Value.Source; 
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            using (var f = new HotKeyForm(myApp))
            {
                f.SaveHotKey += SaveHotKey;
                f.StartPosition = FormStartPosition.CenterParent;
                f.ShowDialog();
                f.SaveHotKey -= SaveHotKey;
            }
        }

        private void SaveHotKey(HotKey hotkey)
        {
            var database = new Database();

            database.SaveHotKey(hotkey);
            myApp.InitHotkeys();
            InitHotKeys();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lvwHotkeys.SelectedItems.Count > 0)
            {
                var database = new Database();

                foreach (ListViewItem li in lvwHotkeys.SelectedItems)
                {
                    var hk = li.Tag as HotKey;

                    database.DeleteHotKey(hk);
                }

                myApp.InitHotkeys();
                InitHotKeys();
            }
        }

        private void myNotifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
        }

        private void btnTextToolsTrim_Click(object sender, EventArgs e)
        {
            editor2.Text = TrimLines(editor1.Text);
        }

        private string TrimLines(string text)
        {
            var lines = text.Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                
            for (int i=0; i<lines.Length; i++)
            {
                lines[i] = lines[i].Trim();
            }

            return string.Join(Environment.NewLine, lines);
        }
    }
}
