namespace project
{
    partial class MainWindow
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelTitleText = new System.Windows.Forms.Label();
            this.quartetCardPanel1 = new project.QuartetCardPanel();
            this.SuspendLayout();
            // 
            // labelTitleText
            // 
            this.labelTitleText.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelTitleText.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitleText.Location = new System.Drawing.Point(0, 0);
            this.labelTitleText.MinimumSize = new System.Drawing.Size(0, 35);
            this.labelTitleText.Name = "labelTitleText";
            this.labelTitleText.Size = new System.Drawing.Size(578, 40);
            this.labelTitleText.TabIndex = 0;
            this.labelTitleText.Text = "Title";
            this.labelTitleText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // quartetCardPanel1
            // 
            this.quartetCardPanel1.Location = new System.Drawing.Point(12, 43);
            this.quartetCardPanel1.Name = "quartetCardPanel1";
            this.quartetCardPanel1.Size = new System.Drawing.Size(200, 250);
            this.quartetCardPanel1.TabIndex = 1;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(578, 376);
            this.Controls.Add(this.quartetCardPanel1);
            this.Controls.Add(this.labelTitleText);
            this.Name = "MainWindow";
            this.Text = "Quartets";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelTitleText;
        private QuartetCardPanel quartetCardPanel1;
    }
}

