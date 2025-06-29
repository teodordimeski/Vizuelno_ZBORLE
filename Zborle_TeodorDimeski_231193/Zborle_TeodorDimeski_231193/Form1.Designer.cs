namespace Zborle_TeodorDimeski_231193
{
    partial class Form1
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
            this.lbNaslov = new System.Windows.Forms.Label();
            this.btnIgraj = new System.Windows.Forms.Button();
            this.btnGeneriraj = new System.Windows.Forms.Button();
            this.btnIgrajTimer = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbNaslov
            // 
            this.lbNaslov.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNaslov.Location = new System.Drawing.Point(121, 58);
            this.lbNaslov.Name = "lbNaslov";
            this.lbNaslov.Size = new System.Drawing.Size(263, 85);
            this.lbNaslov.TabIndex = 0;
            this.lbNaslov.Text = "Зборле";
            this.lbNaslov.Click += new System.EventHandler(this.lbNaslov_Click);
            // 
            // btnIgraj
            // 
            this.btnIgraj.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIgraj.Location = new System.Drawing.Point(152, 284);
            this.btnIgraj.Name = "btnIgraj";
            this.btnIgraj.Size = new System.Drawing.Size(170, 70);
            this.btnIgraj.TabIndex = 1;
            this.btnIgraj.Text = "Играј";
            this.btnIgraj.UseVisualStyleBackColor = true;
            this.btnIgraj.Click += new System.EventHandler(this.btnIgraj_Click);
            // 
            // btnGeneriraj
            // 
            this.btnGeneriraj.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGeneriraj.Location = new System.Drawing.Point(152, 183);
            this.btnGeneriraj.Name = "btnGeneriraj";
            this.btnGeneriraj.Size = new System.Drawing.Size(170, 70);
            this.btnGeneriraj.TabIndex = 2;
            this.btnGeneriraj.Text = "Генерирај свој збор";
            this.btnGeneriraj.UseVisualStyleBackColor = true;
            this.btnGeneriraj.Click += new System.EventHandler(this.btnGeneriraj_Click);
            // 
            // btnIgrajTimer
            // 
            this.btnIgrajTimer.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIgrajTimer.Location = new System.Drawing.Point(152, 384);
            this.btnIgrajTimer.Name = "btnIgrajTimer";
            this.btnIgrajTimer.Size = new System.Drawing.Size(170, 70);
            this.btnIgrajTimer.TabIndex = 3;
            this.btnIgrajTimer.Text = "Играј со тајмер";
            this.btnIgrajTimer.UseVisualStyleBackColor = true;
            this.btnIgrajTimer.Click += new System.EventHandler(this.btnIgrajTimer_Click_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(478, 504);
            this.Controls.Add(this.btnIgrajTimer);
            this.Controls.Add(this.btnGeneriraj);
            this.Controls.Add(this.btnIgraj);
            this.Controls.Add(this.lbNaslov);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbNaslov;
        private System.Windows.Forms.Button btnIgraj;
        private System.Windows.Forms.Button btnGeneriraj;
        private System.Windows.Forms.Button btnIgrajTimer;
    }
}

