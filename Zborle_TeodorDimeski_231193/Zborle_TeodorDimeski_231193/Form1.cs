using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zborle_TeodorDimeski_231193
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        

        private void btnIgraj_Click(object sender, EventArgs e)
        {
            PlayForm playForm=new PlayForm();
            this.Hide();
            playForm.ShowDialog();
            this.Show();


        }

        private void lbNaslov_Click(object sender, EventArgs e)
        {

        }

        private void btnIgrajTimer_Click_1(object sender, EventArgs e)
        {
            PlayTimerMode playTimerMode = new PlayTimerMode();
            this.Hide();
            playTimerMode.ShowDialog();
            this.Show();

        }

        private void btnGeneriraj_Click(object sender, EventArgs e)
        {
            String CustomWord;
            GenerateOwnWordForm GenerateWordForm=new GenerateOwnWordForm();
            
            
            if (GenerateWordForm.ShowDialog() == DialogResult.OK)
            {
                CustomWord=GenerateWordForm.CustomWord;

                PlayOwnWordForm playOwnWordForm = new PlayOwnWordForm(CustomWord);
                this.Hide();
                playOwnWordForm.Show();

            }
        }
    }
}
