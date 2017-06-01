namespace project
{
    partial class QuartetCardPanel
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
            this.labelCardName = new System.Windows.Forms.Label();
            this.cardImage = new System.Windows.Forms.PictureBox();
            this.tableProperties = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.cardImage)).BeginInit();
            this.SuspendLayout();
            // 
            // labelCardName
            // 
            this.labelCardName.BackColor = System.Drawing.Color.Silver;
            this.labelCardName.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelCardName.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCardName.Location = new System.Drawing.Point(0, 0);
            this.labelCardName.MinimumSize = new System.Drawing.Size(0, 35);
            this.labelCardName.Name = "labelCardName";
            this.labelCardName.Size = new System.Drawing.Size(250, 35);
            this.labelCardName.TabIndex = 0;
            this.labelCardName.Text = "Card Name";
            this.labelCardName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cardImage
            // 
            this.cardImage.BackColor = System.Drawing.Color.White;
            this.cardImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cardImage.Location = new System.Drawing.Point(0, 35);
            this.cardImage.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            this.cardImage.MinimumSize = new System.Drawing.Size(250, 100);
            this.cardImage.Name = "cardImage";
            this.cardImage.Size = new System.Drawing.Size(250, 315);
            this.cardImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.cardImage.TabIndex = 1;
            this.cardImage.TabStop = false;
            // 
            // tableProperties
            // 
            this.tableProperties.AutoSize = true;
            this.tableProperties.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableProperties.ColumnCount = 2;
            this.tableProperties.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableProperties.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableProperties.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableProperties.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tableProperties.Location = new System.Drawing.Point(0, 329);
            this.tableProperties.Margin = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.tableProperties.Name = "tableProperties";
            this.tableProperties.RowCount = 1;
            this.tableProperties.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 21F));
            this.tableProperties.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 21F));
            this.tableProperties.Size = new System.Drawing.Size(250, 21);
            this.tableProperties.TabIndex = 2;
            // 
            // QuartetCardPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.tableProperties);
            this.Controls.Add(this.cardImage);
            this.Controls.Add(this.labelCardName);
            this.Name = "QuartetCardPanel";
            this.Size = new System.Drawing.Size(250, 350);
            ((System.ComponentModel.ISupportInitialize)(this.cardImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelCardName;
        private System.Windows.Forms.PictureBox cardImage;
        public System.Windows.Forms.TableLayoutPanel tableProperties;
    }
}
