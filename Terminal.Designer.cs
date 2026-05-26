namespace Note_Taker2._0
{
    partial class Terminal
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Console = new System.Windows.Forms.RichTextBox();
            this.tb_input = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Console
            // 
            this.Console.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Console.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Console.ForeColor = System.Drawing.Color.White;
            this.Console.Location = new System.Drawing.Point(0, 0);
            this.Console.Name = "Console";
            this.Console.ReadOnly = true;
            this.Console.Size = new System.Drawing.Size(1729, 260);
            this.Console.TabIndex = 0;
            this.Console.Text = "";
            // 
            // tb_input
            // 
            this.tb_input.BackColor = System.Drawing.Color.Gray;
            this.tb_input.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tb_input.ForeColor = System.Drawing.Color.White;
            this.tb_input.Location = new System.Drawing.Point(0, 260);
            this.tb_input.Name = "tb_input";
            this.tb_input.Size = new System.Drawing.Size(1729, 22);
            this.tb_input.TabIndex = 2;
            // 
            // Terminal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.Controls.Add(this.Console);
            this.Controls.Add(this.tb_input);
            this.Name = "Terminal";
            this.Size = new System.Drawing.Size(1729, 282);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox Console;
        internal System.Windows.Forms.TextBox tb_input;
    }
}
