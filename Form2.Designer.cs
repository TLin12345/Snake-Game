namespace PA5_Draft
{
    partial class Custom
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Custom));
            this.numberOfApples = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.OK = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numberOfApples)).BeginInit();
            this.SuspendLayout();
            // 
            // numberOfApples
            // 
            this.numberOfApples.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numberOfApples.Location = new System.Drawing.Point(270, 78);
            this.numberOfApples.Maximum = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            this.numberOfApples.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numberOfApples.Name = "numberOfApples";
            this.numberOfApples.Size = new System.Drawing.Size(88, 35);
            this.numberOfApples.TabIndex = 0;
            this.numberOfApples.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numberOfApples.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numberOfApples.ValueChanged += new System.EventHandler(this.numberOfApples_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(57, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(207, 29);
            this.label1.TabIndex = 1;
            this.label1.Text = "Number of Apples";
            // 
            // OK
            // 
            this.OK.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OK.Location = new System.Drawing.Point(164, 170);
            this.OK.Name = "OK";
            this.OK.Size = new System.Drawing.Size(100, 50);
            this.OK.TabIndex = 2;
            this.OK.Text = "OK";
            this.OK.UseVisualStyleBackColor = true;
            this.OK.Click += new System.EventHandler(this.OK_Click);
            // 
            // Custom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 276);
            this.Controls.Add(this.OK);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numberOfApples);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Custom";
            this.Text = "Custom";
            ((System.ComponentModel.ISupportInitialize)(this.numberOfApples)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numberOfApples;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button OK;
    }
}