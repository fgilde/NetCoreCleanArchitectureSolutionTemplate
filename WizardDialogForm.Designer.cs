namespace VSIX_CCA_ProjectTemplate
{
    partial class WizardDialogForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WizardDialogForm));
            this.buttonApply = new System.Windows.Forms.Button();
            this.groupBoxOptions = new System.Windows.Forms.GroupBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBoxServiceBus = new System.Windows.Forms.CheckBox();
            this.checkBoxSignalR = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBoxAddBlazor = new System.Windows.Forms.CheckBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.groupBoxOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonApply
            // 
            this.buttonApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonApply.BackColor = System.Drawing.Color.White;
            this.buttonApply.DialogResult = System.Windows.Forms.DialogResult.No;
            this.buttonApply.Location = new System.Drawing.Point(1103, 592);
            this.buttonApply.Name = "buttonApply";
            this.buttonApply.Size = new System.Drawing.Size(205, 80);
            this.buttonApply.TabIndex = 0;
            this.buttonApply.Text = "Create";
            this.buttonApply.UseVisualStyleBackColor = false;
            this.buttonApply.Click += new System.EventHandler(this.buttonApply_Click);
            // 
            // groupBoxOptions
            // 
            this.groupBoxOptions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxOptions.Controls.Add(this.checkBox4);
            this.groupBoxOptions.Controls.Add(this.checkBox3);
            this.groupBoxOptions.Controls.Add(this.checkBoxServiceBus);
            this.groupBoxOptions.Controls.Add(this.checkBoxSignalR);
            this.groupBoxOptions.Controls.Add(this.checkBox1);
            this.groupBoxOptions.Controls.Add(this.checkBoxAddBlazor);
            this.groupBoxOptions.Location = new System.Drawing.Point(457, 36);
            this.groupBoxOptions.Name = "groupBoxOptions";
            this.groupBoxOptions.Size = new System.Drawing.Size(851, 504);
            this.groupBoxOptions.TabIndex = 7;
            this.groupBoxOptions.TabStop = false;
            this.groupBoxOptions.Text = "Options";
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Location = new System.Drawing.Point(30, 221);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(279, 29);
            this.checkBox4.TabIndex = 13;
            this.checkBox4.Tag = "$addConsole$";
            this.checkBox4.Text = "Add Console Application";
            this.checkBox4.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(30, 160);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(247, 29);
            this.checkBox3.TabIndex = 12;
            this.checkBox3.Tag = "$addWPF$";
            this.checkBox3.Text = "Add WPF Application";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // checkBoxServiceBus
            // 
            this.checkBoxServiceBus.AutoSize = true;
            this.checkBoxServiceBus.Location = new System.Drawing.Point(485, 102);
            this.checkBoxServiceBus.Name = "checkBoxServiceBus";
            this.checkBoxServiceBus.Size = new System.Drawing.Size(343, 29);
            this.checkBoxServiceBus.TabIndex = 10;
            this.checkBoxServiceBus.Tag = "$addServiceBus$";
            this.checkBoxServiceBus.Text = "Add ServiceBus with RabbitMQ";
            this.checkBoxServiceBus.UseVisualStyleBackColor = true;
            // 
            // checkBoxSignalR
            // 
            this.checkBoxSignalR.AutoSize = true;
            this.checkBoxSignalR.Location = new System.Drawing.Point(485, 45);
            this.checkBoxSignalR.Name = "checkBoxSignalR";
            this.checkBoxSignalR.Size = new System.Drawing.Size(340, 29);
            this.checkBoxSignalR.TabIndex = 9;
            this.checkBoxSignalR.Tag = "$addSignalR$";
            this.checkBoxSignalR.Text = "Add Client Events with SignalR";
            this.checkBoxSignalR.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(30, 102);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(304, 29);
            this.checkBox1.TabIndex = 8;
            this.checkBox1.Tag = "$addSPA$";
            this.checkBox1.Text = "Add React SPA Application";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBoxAddBlazor
            // 
            this.checkBoxAddBlazor.AutoSize = true;
            this.checkBoxAddBlazor.Location = new System.Drawing.Point(30, 45);
            this.checkBoxAddBlazor.Name = "checkBoxAddBlazor";
            this.checkBoxAddBlazor.Size = new System.Drawing.Size(261, 29);
            this.checkBoxAddBlazor.TabIndex = 7;
            this.checkBoxAddBlazor.Tag = "$addBlazor$";
            this.checkBoxAddBlazor.Text = "Add Blazor Application";
            this.checkBoxAddBlazor.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(82, 36);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(272, 272);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // checkBox2
            // 
            this.checkBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(884, 619);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(185, 29);
            this.checkBox2.TabIndex = 12;
            this.checkBox2.Tag = "$enableDocker$";
            this.checkBox2.Text = "Enable Docker";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // WizardDialogForm
            // 
            this.AcceptButton = this.buttonApply;
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1357, 694);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groupBoxOptions);
            this.Controls.Add(this.buttonApply);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WizardDialogForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Setup your new Clean Architecture Project";
            this.groupBoxOptions.ResumeLayout(false);
            this.groupBoxOptions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonApply;
        private System.Windows.Forms.GroupBox groupBoxOptions;
        private System.Windows.Forms.CheckBox checkBoxServiceBus;
        private System.Windows.Forms.CheckBox checkBoxSignalR;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBoxAddBlazor;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox checkBox2;
    }
}