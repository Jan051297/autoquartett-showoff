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
            this.listGames = new System.Windows.Forms.ListBox();
            this.buttonLoad = new System.Windows.Forms.Button();
            this.labelGameInfo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelTitleText
            // 
            this.labelTitleText.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelTitleText.Font = new System.Drawing.Font("Arial", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitleText.Location = new System.Drawing.Point(0, 0);
            this.labelTitleText.MinimumSize = new System.Drawing.Size(0, 35);
            this.labelTitleText.Name = "labelTitleText";
            this.labelTitleText.Size = new System.Drawing.Size(409, 55);
            this.labelTitleText.TabIndex = 0;
            this.labelTitleText.Text = "Quartets";
            this.labelTitleText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // listGames
            // 
            this.listGames.FormattingEnabled = true;
            this.listGames.Location = new System.Drawing.Point(10, 65);
            this.listGames.Name = "listGames";
            this.listGames.Size = new System.Drawing.Size(180, 160);
            this.listGames.TabIndex = 1;
            this.listGames.SelectedIndexChanged += new System.EventHandler(this.OnSelectGame);
            // 
            // buttonLoad
            // 
            this.buttonLoad.Enabled = false;
            this.buttonLoad.Location = new System.Drawing.Point(197, 195);
            this.buttonLoad.Name = "buttonLoad";
            this.buttonLoad.Size = new System.Drawing.Size(200, 29);
            this.buttonLoad.TabIndex = 2;
            this.buttonLoad.Text = "Load";
            this.buttonLoad.UseVisualStyleBackColor = true;
            // 
            // labelGameInfo
            // 
            this.labelGameInfo.Location = new System.Drawing.Point(197, 65);
            this.labelGameInfo.Name = "labelGameInfo";
            this.labelGameInfo.Size = new System.Drawing.Size(200, 127);
            this.labelGameInfo.TabIndex = 3;
            this.labelGameInfo.Text = "Please select a game...";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(409, 236);
            this.Controls.Add(this.labelGameInfo);
            this.Controls.Add(this.buttonLoad);
            this.Controls.Add(this.listGames);
            this.Controls.Add(this.labelTitleText);
            this.Name = "MainWindow";
            this.Text = "Quartets";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelTitleText;
        private System.Windows.Forms.ListBox listGames;
        private System.Windows.Forms.Button buttonLoad;
        private System.Windows.Forms.Label labelGameInfo;
    }
}