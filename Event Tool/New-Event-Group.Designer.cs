namespace Event_Tool
{
    partial class New_Event_Group
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
            this.NameTxt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SaveBt = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // NameTxt
            // 
            this.NameTxt.Location = new System.Drawing.Point(83, 12);
            this.NameTxt.Name = "NameTxt";
            this.NameTxt.Size = new System.Drawing.Size(100, 20);
            this.NameTxt.TabIndex = 0;
            this.NameTxt.TextChanged += new System.EventHandler(this.NameTxt_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Group Name";
            // 
            // SaveBt
            // 
            this.SaveBt.Location = new System.Drawing.Point(189, 12);
            this.SaveBt.Name = "SaveBt";
            this.SaveBt.Size = new System.Drawing.Size(75, 20);
            this.SaveBt.TabIndex = 1;
            this.SaveBt.Text = "Save";
            this.SaveBt.UseVisualStyleBackColor = true;
            this.SaveBt.Click += new System.EventHandler(this.SaveBt_Click);
            // 
            // New_Event_Group
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(276, 45);
            this.Controls.Add(this.SaveBt);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.NameTxt);
            this.Name = "New_Event_Group";
            this.Text = "New_Event_Group";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox NameTxt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button SaveBt;
    }
}