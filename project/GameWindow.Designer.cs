namespace project
{
    partial class GameWindow
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
            this.panelViewCards = new System.Windows.Forms.Panel();
            this.cardPanelLeft = new project.QuartetCardPanel();
            this.cardPanelRight = new project.QuartetCardPanel();
            this.listCards = new System.Windows.Forms.FlowLayoutPanel();
            this.panelViewCards.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelViewCards
            // 
            this.panelViewCards.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelViewCards.Controls.Add(this.cardPanelRight);
            this.panelViewCards.Controls.Add(this.cardPanelLeft);
            this.panelViewCards.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelViewCards.Location = new System.Drawing.Point(0, 386);
            this.panelViewCards.MinimumSize = new System.Drawing.Size(0, 300);
            this.panelViewCards.Name = "panelViewCards";
            this.panelViewCards.Size = new System.Drawing.Size(834, 300);
            this.panelViewCards.TabIndex = 1;
            // 
            // cardPanelLeft
            // 
            this.cardPanelLeft.BackColor = System.Drawing.Color.White;
            this.cardPanelLeft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cardPanelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.cardPanelLeft.Location = new System.Drawing.Point(0, 0);
            this.cardPanelLeft.Name = "cardPanelLeft";
            this.cardPanelLeft.Size = new System.Drawing.Size(250, 298);
            this.cardPanelLeft.TabIndex = 0;
            // 
            // cardPanelRight
            // 
            this.cardPanelRight.BackColor = System.Drawing.Color.White;
            this.cardPanelRight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cardPanelRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.cardPanelRight.Location = new System.Drawing.Point(582, 0);
            this.cardPanelRight.Name = "cardPanelRight";
            this.cardPanelRight.Size = new System.Drawing.Size(250, 298);
            this.cardPanelRight.TabIndex = 1;
            // 
            // listCards
            // 
            this.listCards.AutoScroll = true;
            this.listCards.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listCards.Location = new System.Drawing.Point(0, 0);
            this.listCards.Name = "listCards";
            this.listCards.Size = new System.Drawing.Size(834, 386);
            this.listCards.TabIndex = 2;
            // 
            // GameWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(834, 686);
            this.Controls.Add(this.listCards);
            this.Controls.Add(this.panelViewCards);
            this.Name = "GameWindow";
            this.panelViewCards.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.FlowLayoutPanel listCards;
        public System.Windows.Forms.Panel panelViewCards;
        public QuartetCardPanel cardPanelRight;
        public QuartetCardPanel cardPanelLeft;
    }
}