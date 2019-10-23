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
            this.buttonApply = new System.Windows.Forms.Button();
            this.checkBoxAddBlazor = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBoxSignalR = new System.Windows.Forms.CheckBox();
            this.checkBoxServiceBus = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // buttonApply
            // 
            this.buttonApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonApply.BackColor = System.Drawing.Color.White;
            this.buttonApply.DialogResult = System.Windows.Forms.DialogResult.No;
            this.buttonApply.Location = new System.Drawing.Point(633, 354);
            this.buttonApply.Name = "buttonApply";
            this.buttonApply.Size = new System.Drawing.Size(205, 80);
            this.buttonApply.TabIndex = 0;
            this.buttonApply.Text = "Create";
            this.buttonApply.UseVisualStyleBackColor = false;
            this.buttonApply.Click += new System.EventHandler(this.buttonApply_Click);
            // 
            // checkBoxAddBlazor
            // 
            this.checkBoxAddBlazor.AutoSize = true;
            this.checkBoxAddBlazor.Location = new System.Drawing.Point(47, 40);
            this.checkBoxAddBlazor.Name = "checkBoxAddBlazor";
            this.checkBoxAddBlazor.Size = new System.Drawing.Size(149, 29);
            this.checkBoxAddBlazor.TabIndex = 1;
            this.checkBoxAddBlazor.Tag = "$useBlazor$";
            this.checkBoxAddBlazor.Text = "Add Blazor";
            this.checkBoxAddBlazor.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(47, 97);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(304, 29);
            this.checkBox1.TabIndex = 3;
            this.checkBox1.Tag = "$addSPA$";
            this.checkBox1.Text = "Add React SPA Application";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBoxSignalR
            // 
            this.checkBoxSignalR.AutoSize = true;
            this.checkBoxSignalR.Location = new System.Drawing.Point(502, 40);
            this.checkBoxSignalR.Name = "checkBoxSignalR";
            this.checkBoxSignalR.Size = new System.Drawing.Size(340, 29);
            this.checkBoxSignalR.TabIndex = 4;
            this.checkBoxSignalR.Tag = "$addSignalR$";
            this.checkBoxSignalR.Text = "Add Client Events with SignalR";
            this.checkBoxSignalR.UseVisualStyleBackColor = true;
            // 
            // checkBoxServiceBus
            // 
            this.checkBoxServiceBus.AutoSize = true;
            this.checkBoxServiceBus.Location = new System.Drawing.Point(502, 97);
            this.checkBoxServiceBus.Name = "checkBoxServiceBus";
            this.checkBoxServiceBus.Size = new System.Drawing.Size(343, 29);
            this.checkBoxServiceBus.TabIndex = 5;
            this.checkBoxServiceBus.Tag = "$addServiceBus$";
            this.checkBoxServiceBus.Text = "Add ServiceBus with RabbitMQ";
            this.checkBoxServiceBus.UseVisualStyleBackColor = true;
            // 
            // WizardDialogForm
            // 
            this.AcceptButton = this.buttonApply;
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(887, 456);
            this.Controls.Add(this.checkBoxServiceBus);
            this.Controls.Add(this.checkBoxSignalR);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.checkBoxAddBlazor);
            this.Controls.Add(this.buttonApply);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WizardDialogForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Setup your new Clean Architecture Project";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonApply;
        private System.Windows.Forms.CheckBox checkBoxAddBlazor;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBoxSignalR;
        private System.Windows.Forms.CheckBox checkBoxServiceBus;
    }
}