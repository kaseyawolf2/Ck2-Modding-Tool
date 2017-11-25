namespace Ck2ModdingTool
{
    partial class NwArtifact
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
            this.ModifierBt = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.ArtifactNameText = new System.Windows.Forms.TextBox();
            this.DescText = new System.Windows.Forms.RichTextBox();
            this.ScoutingChck = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.PicBt = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ModifierBt
            // 
            this.ModifierBt.Location = new System.Drawing.Point(571, 407);
            this.ModifierBt.Name = "ModifierBt";
            this.ModifierBt.Size = new System.Drawing.Size(100, 38);
            this.ModifierBt.TabIndex = 55;
            this.ModifierBt.Text = "Modifiers";
            this.ModifierBt.UseVisualStyleBackColor = true;
            this.ModifierBt.Click += new System.EventHandler(this.ModifierBt_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(171, 158);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 13);
            this.label6.TabIndex = 59;
            this.label6.Text = "Active*";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(156, 132);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 13);
            this.label5.TabIndex = 58;
            this.label5.Text = "Artifact Name*";
            // 
            // ArtifactNameText
            // 
            this.ArtifactNameText.Location = new System.Drawing.Point(237, 129);
            this.ArtifactNameText.Name = "ArtifactNameText";
            this.ArtifactNameText.Size = new System.Drawing.Size(100, 20);
            this.ArtifactNameText.TabIndex = 57;
            // 
            // DescText
            // 
            this.DescText.Location = new System.Drawing.Point(237, 155);
            this.DescText.Name = "DescText";
            this.DescText.Size = new System.Drawing.Size(202, 85);
            this.DescText.TabIndex = 56;
            this.DescText.Text = "";
            // 
            // ScoutingChck
            // 
            this.ScoutingChck.AutoSize = true;
            this.ScoutingChck.Location = new System.Drawing.Point(220, 292);
            this.ScoutingChck.Name = "ScoutingChck";
            this.ScoutingChck.Size = new System.Drawing.Size(66, 17);
            this.ScoutingChck.TabIndex = 60;
            this.ScoutingChck.Text = "scouting";
            this.ScoutingChck.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(220, 315);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(66, 17);
            this.checkBox1.TabIndex = 61;
            this.checkBox1.Text = "scouting";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // PicBt
            // 
            this.PicBt.Location = new System.Drawing.Point(288, 407);
            this.PicBt.Name = "PicBt";
            this.PicBt.Size = new System.Drawing.Size(102, 20);
            this.PicBt.TabIndex = 63;
            this.PicBt.Text = "Select Picture";
            this.PicBt.UseVisualStyleBackColor = true;
            this.PicBt.Click += new System.EventHandler(this.PicBt_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(224, 410);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 62;
            this.label3.Text = "Picture";
            // 
            // NwArtifact
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(942, 601);
            this.Controls.Add(this.PicBt);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.ScoutingChck);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.ArtifactNameText);
            this.Controls.Add(this.DescText);
            this.Controls.Add(this.ModifierBt);
            this.Name = "NwArtifact";
            this.Text = "NwArtifact";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ModifierBt;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox ArtifactNameText;
        private System.Windows.Forms.RichTextBox DescText;
        private System.Windows.Forms.CheckBox ScoutingChck;
        private System.Windows.Forms.CheckBox checkBox1;
        public System.Windows.Forms.Button PicBt;
        private System.Windows.Forms.Label label3;
    }
}