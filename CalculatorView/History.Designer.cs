namespace CalculatorView
{
    partial class History
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
            this.ListboxHistory = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // ListboxHistory
            // 
            this.ListboxHistory.FormattingEnabled = true;
            this.ListboxHistory.ItemHeight = 20;
            this.ListboxHistory.Location = new System.Drawing.Point(13, 13);
            this.ListboxHistory.Name = "ListboxHistory";
            this.ListboxHistory.Size = new System.Drawing.Size(775, 424);
            this.ListboxHistory.TabIndex = 0;
            this.ListboxHistory.DoubleClick += new System.EventHandler(this.History_DoubleClick);
            // 
            // History
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ListboxHistory);
            this.Name = "History";
            this.Text = "History";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox ListboxHistory;
    }
}