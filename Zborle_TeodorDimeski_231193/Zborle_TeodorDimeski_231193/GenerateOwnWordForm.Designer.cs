namespace Zborle_TeodorDimeski_231193
{
    partial class GenerateOwnWordForm
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
            this.tbgeneratedWord = new System.Windows.Forms.TextBox();
            this.bntCancedOnwWord = new System.Windows.Forms.Button();
            this.btnContinueOwnWord = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tbgeneratedWord
            // 
            this.tbgeneratedWord.Location = new System.Drawing.Point(132, 94);
            this.tbgeneratedWord.Name = "tbgeneratedWord";
            this.tbgeneratedWord.Size = new System.Drawing.Size(196, 22);
            this.tbgeneratedWord.TabIndex = 0;
            // 
            // bntCancedOnwWord
            // 
            this.bntCancedOnwWord.BackColor = System.Drawing.Color.Red;
            this.bntCancedOnwWord.Location = new System.Drawing.Point(79, 184);
            this.bntCancedOnwWord.Name = "bntCancedOnwWord";
            this.bntCancedOnwWord.Size = new System.Drawing.Size(133, 52);
            this.bntCancedOnwWord.TabIndex = 1;
            this.bntCancedOnwWord.Text = "Врати се назад";
            this.bntCancedOnwWord.UseVisualStyleBackColor = false;
            this.bntCancedOnwWord.Click += new System.EventHandler(this.bntCancedOnwWord_Click);
            // 
            // btnContinueOwnWord
            // 
            this.btnContinueOwnWord.BackColor = System.Drawing.Color.Green;
            this.btnContinueOwnWord.Location = new System.Drawing.Point(251, 184);
            this.btnContinueOwnWord.Name = "btnContinueOwnWord";
            this.btnContinueOwnWord.Size = new System.Drawing.Size(136, 52);
            this.btnContinueOwnWord.TabIndex = 2;
            this.btnContinueOwnWord.Text = "Продолжи";
            this.btnContinueOwnWord.UseVisualStyleBackColor = false;
            this.btnContinueOwnWord.Click += new System.EventHandler(this.btnContinueOwnWord_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(129, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(199, 18);
            this.label1.TabIndex = 3;
            this.label1.Text = "Внеси збор кој има 5 букви";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // GenerateOwnWordForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(456, 345);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnContinueOwnWord);
            this.Controls.Add(this.bntCancedOnwWord);
            this.Controls.Add(this.tbgeneratedWord);
            this.Name = "GenerateOwnWordForm";
            this.Text = "GenerateOwnWordForm";
            this.Load += new System.EventHandler(this.GenerateOwnWordForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbgeneratedWord;
        private System.Windows.Forms.Button bntCancedOnwWord;
        private System.Windows.Forms.Button btnContinueOwnWord;
        private System.Windows.Forms.Label label1;
    }
}