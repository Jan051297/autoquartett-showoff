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
            this.listCards = new System.Windows.Forms.FlowLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.cardPanelLeft = new project.QuartetCardPanel();
            this.cardPanelRight = new project.QuartetCardPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listCards
            // 
            this.listCards.AutoScroll = true;
            this.listCards.AutoSize = true;
            this.listCards.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.listCards.BackColor = System.Drawing.Color.LightSteelBlue;
            this.listCards.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listCards.Location = new System.Drawing.Point(0, 0);
            this.listCards.MinimumSize = new System.Drawing.Size(50, 50);
            this.listCards.Name = "listCards";
            this.listCards.Size = new System.Drawing.Size(804, 541);
            this.listCards.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.cardPanelLeft, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.cardPanelRight, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 541);
            this.tableLayoutPanel1.MinimumSize = new System.Drawing.Size(0, 320);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(804, 320);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // cardPanelLeft
            // 
            this.cardPanelLeft.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.cardPanelLeft.BackColor = System.Drawing.Color.White;
            this.cardPanelLeft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cardPanelLeft.Location = new System.Drawing.Point(122, 10);
            this.cardPanelLeft.Margin = new System.Windows.Forms.Padding(3, 3, 30, 3);
            this.cardPanelLeft.Name = "cardPanelLeft";
            this.cardPanelLeft.Size = new System.Drawing.Size(250, 300);
            this.cardPanelLeft.TabIndex = 0;
            // 
            // cardPanelRight
            // 
            this.cardPanelRight.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cardPanelRight.BackColor = System.Drawing.Color.White;
            this.cardPanelRight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cardPanelRight.Location = new System.Drawing.Point(432, 10);
            this.cardPanelRight.Margin = new System.Windows.Forms.Padding(30, 3, 3, 3);
            this.cardPanelRight.Name = "cardPanelRight";
            this.cardPanelRight.Size = new System.Drawing.Size(250, 300);
            this.cardPanelRight.TabIndex = 1;
            // 
            // GameWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(804, 861);
            this.Controls.Add(this.listCards);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "GameWindow";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.FlowLayoutPanel listCards;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private QuartetCardPanel cardPanelLeft;
        private QuartetCardPanel cardPanelRight;
    }
}