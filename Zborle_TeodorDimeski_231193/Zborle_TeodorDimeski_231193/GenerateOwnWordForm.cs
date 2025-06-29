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
    public partial class GenerateOwnWordForm : Form
    {
        public String CustomWord { get; set; }
        

        public GenerateOwnWordForm()
        {
            InitializeComponent();
            
        }
        
        private void GenerateOwnWordForm_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void bntCancedOnwWord_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnContinueOwnWord_Click(object sender, EventArgs e)
        {
            if (tbgeneratedWord.Text.Length != 5)
            {
                MessageBox.Show("Зборот е невалиден");
                    this.DialogResult=DialogResult.Cancel;
            }
            else
            {
                CustomWord= tbgeneratedWord.Text.ToLower();
                this.DialogResult = DialogResult.OK;
                this.Close();
                
            }
        }
    }
}
