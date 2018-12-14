namespace _006_ChessboardQueens
{
    partial class HelloWorldChessboard
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
            this.components = new System.ComponentModel.Container();
            this.visualizeButton = new System.Windows.Forms.Button();
            this.visualizationTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // visualizeButton
            // 
            this.visualizeButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.visualizeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.visualizeButton.Location = new System.Drawing.Point(165, 30);
            this.visualizeButton.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.visualizeButton.Name = "visualizeButton";
            this.visualizeButton.Size = new System.Drawing.Size(215, 55);
            this.visualizeButton.TabIndex = 128;
            this.visualizeButton.Text = "Visualize";
            this.visualizeButton.UseVisualStyleBackColor = true;
            this.visualizeButton.Click += new System.EventHandler(this.VisualizeButton_Click);
            // 
            // visualizationTimer
            // 
            this.visualizationTimer.Interval = 30;
            this.visualizationTimer.Tick += new System.EventHandler(this.VisualizationTimer_Tick);
            // 
            // HelloWorldChessboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(578, 664);
            this.Controls.Add(this.visualizeButton);
            this.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.Name = "HelloWorldChessboard";
            this.Text = "Hello World Chessboard Visualization";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button visualizeButton;
        private System.Windows.Forms.Timer visualizationTimer;
    }
}

