namespace ScriptKeys
{
    partial class HotKeyForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HotKeyForm));
            this.cmbScripts = new System.Windows.Forms.ComboBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtParameters = new System.Windows.Forms.TextBox();
            this.grbModifiers = new System.Windows.Forms.GroupBox();
            this.chkRWin = new System.Windows.Forms.CheckBox();
            this.chkRControl = new System.Windows.Forms.CheckBox();
            this.chkRAlt = new System.Windows.Forms.CheckBox();
            this.chkRShift = new System.Windows.Forms.CheckBox();
            this.chkLWin = new System.Windows.Forms.CheckBox();
            this.chkLControl = new System.Windows.Forms.CheckBox();
            this.chkLAlt = new System.Windows.Forms.CheckBox();
            this.chkLShift = new System.Windows.Forms.CheckBox();
            this.cmbKey = new System.Windows.Forms.ComboBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.grbModifiers.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbScripts
            // 
            this.cmbScripts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbScripts.FormattingEnabled = true;
            this.cmbScripts.Location = new System.Drawing.Point(87, 190);
            this.cmbScripts.Name = "cmbScripts";
            this.cmbScripts.Size = new System.Drawing.Size(200, 21);
            this.cmbScripts.TabIndex = 13;
            this.cmbScripts.SelectedIndexChanged += new System.EventHandler(this.cmbScripts_SelectedIndexChanged);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(112, 347);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 11;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtParameters
            // 
            this.txtParameters.Location = new System.Drawing.Point(87, 217);
            this.txtParameters.Name = "txtParameters";
            this.txtParameters.Size = new System.Drawing.Size(200, 20);
            this.txtParameters.TabIndex = 12;
            // 
            // grbModifiers
            // 
            this.grbModifiers.Controls.Add(this.chkRWin);
            this.grbModifiers.Controls.Add(this.chkRControl);
            this.grbModifiers.Controls.Add(this.chkRAlt);
            this.grbModifiers.Controls.Add(this.chkRShift);
            this.grbModifiers.Controls.Add(this.chkLWin);
            this.grbModifiers.Controls.Add(this.chkLControl);
            this.grbModifiers.Controls.Add(this.chkLAlt);
            this.grbModifiers.Controls.Add(this.chkLShift);
            this.grbModifiers.Location = new System.Drawing.Point(87, 45);
            this.grbModifiers.Name = "grbModifiers";
            this.grbModifiers.Size = new System.Drawing.Size(200, 124);
            this.grbModifiers.TabIndex = 9;
            this.grbModifiers.TabStop = false;
            this.grbModifiers.Text = "Modifiers";
            // 
            // chkRWin
            // 
            this.chkRWin.AutoSize = true;
            this.chkRWin.Location = new System.Drawing.Point(106, 88);
            this.chkRWin.Name = "chkRWin";
            this.chkRWin.Size = new System.Drawing.Size(73, 17);
            this.chkRWin.TabIndex = 8;
            this.chkRWin.Text = "Right Win";
            this.chkRWin.UseVisualStyleBackColor = true;
            // 
            // chkRControl
            // 
            this.chkRControl.AutoSize = true;
            this.chkRControl.Location = new System.Drawing.Point(106, 65);
            this.chkRControl.Name = "chkRControl";
            this.chkRControl.Size = new System.Drawing.Size(87, 17);
            this.chkRControl.TabIndex = 7;
            this.chkRControl.Text = "Right Control";
            this.chkRControl.UseVisualStyleBackColor = true;
            // 
            // chkRAlt
            // 
            this.chkRAlt.AutoSize = true;
            this.chkRAlt.Location = new System.Drawing.Point(106, 42);
            this.chkRAlt.Name = "chkRAlt";
            this.chkRAlt.Size = new System.Drawing.Size(66, 17);
            this.chkRAlt.TabIndex = 6;
            this.chkRAlt.Text = "Right Alt";
            this.chkRAlt.UseVisualStyleBackColor = true;
            // 
            // chkRShift
            // 
            this.chkRShift.AutoSize = true;
            this.chkRShift.Location = new System.Drawing.Point(106, 19);
            this.chkRShift.Name = "chkRShift";
            this.chkRShift.Size = new System.Drawing.Size(75, 17);
            this.chkRShift.TabIndex = 5;
            this.chkRShift.Text = "Right Shift";
            this.chkRShift.UseVisualStyleBackColor = true;
            // 
            // chkLWin
            // 
            this.chkLWin.AutoSize = true;
            this.chkLWin.Location = new System.Drawing.Point(8, 88);
            this.chkLWin.Name = "chkLWin";
            this.chkLWin.Size = new System.Drawing.Size(66, 17);
            this.chkLWin.TabIndex = 4;
            this.chkLWin.Text = "Left Win";
            this.chkLWin.UseVisualStyleBackColor = true;
            // 
            // chkLControl
            // 
            this.chkLControl.AutoSize = true;
            this.chkLControl.Location = new System.Drawing.Point(8, 65);
            this.chkLControl.Name = "chkLControl";
            this.chkLControl.Size = new System.Drawing.Size(80, 17);
            this.chkLControl.TabIndex = 3;
            this.chkLControl.Text = "Left Control";
            this.chkLControl.UseVisualStyleBackColor = true;
            // 
            // chkLAlt
            // 
            this.chkLAlt.AutoSize = true;
            this.chkLAlt.Location = new System.Drawing.Point(8, 42);
            this.chkLAlt.Name = "chkLAlt";
            this.chkLAlt.Size = new System.Drawing.Size(59, 17);
            this.chkLAlt.TabIndex = 2;
            this.chkLAlt.Text = "Left Alt";
            this.chkLAlt.UseVisualStyleBackColor = true;
            // 
            // chkLShift
            // 
            this.chkLShift.AutoSize = true;
            this.chkLShift.Location = new System.Drawing.Point(8, 19);
            this.chkLShift.Name = "chkLShift";
            this.chkLShift.Size = new System.Drawing.Size(68, 17);
            this.chkLShift.TabIndex = 1;
            this.chkLShift.Text = "Left Shift";
            this.chkLShift.UseVisualStyleBackColor = true;
            // 
            // cmbKey
            // 
            this.cmbKey.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbKey.FormattingEnabled = true;
            this.cmbKey.Location = new System.Drawing.Point(87, 15);
            this.cmbKey.Margin = new System.Windows.Forms.Padding(6);
            this.cmbKey.MaxDropDownItems = 10;
            this.cmbKey.Name = "cmbKey";
            this.cmbKey.Size = new System.Drawing.Size(200, 21);
            this.cmbKey.TabIndex = 10;
            this.cmbKey.SelectedIndexChanged += new System.EventHandler(this.cmbKey_SelectedIndexChanged);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(212, 347);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 14;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Key:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 193);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Script to Run:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 220);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Parameters:";
            // 
            // HotKeyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(302, 382);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.cmbScripts);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtParameters);
            this.Controls.Add(this.grbModifiers);
            this.Controls.Add(this.cmbKey);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "HotKeyForm";
            this.Text = "Hot Key";
            this.grbModifiers.ResumeLayout(false);
            this.grbModifiers.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbScripts;
        internal System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtParameters;
        private System.Windows.Forms.GroupBox grbModifiers;
        private System.Windows.Forms.CheckBox chkRWin;
        private System.Windows.Forms.CheckBox chkRControl;
        private System.Windows.Forms.CheckBox chkRAlt;
        private System.Windows.Forms.CheckBox chkRShift;
        private System.Windows.Forms.CheckBox chkLWin;
        private System.Windows.Forms.CheckBox chkLControl;
        private System.Windows.Forms.CheckBox chkLAlt;
        private System.Windows.Forms.CheckBox chkLShift;
        private System.Windows.Forms.ComboBox cmbKey;
        internal System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}