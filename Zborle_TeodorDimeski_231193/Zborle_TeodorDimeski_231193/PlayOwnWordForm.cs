using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System;
using System.Drawing;
using System.Linq;

namespace Zborle_TeodorDimeski_231193
{
    public partial class PlayOwnWordForm : Form
    {
        private string targetWord; 
        private int currentAttempt = 0; 
        private const int maxAttempts = 6;
        private const int wordLength = 5;

        
        private Label[,] letterBoxes = new Label[maxAttempts, wordLength];
        WordProvider provider;


        public PlayOwnWordForm( String word)
        {
            InitializeComponent();
            provider = new WordProvider();
            targetWord = word;
            this.Size = new Size(450, 550);
            SetupGrid();
        }

        private void PlayOwnWordForm_Load(object sender, EventArgs e)
        {

        }

        private void SetupGrid()
        {
           
            int startX = 20;
            int startY = 20;
            int boxSize = 50;
            int padding = 5;

            for (int row = 0; row < maxAttempts; row++)
            {
                for (int col = 0; col < wordLength; col++)
                {
                    var lbl = new Label();
                    lbl.Size = new Size(boxSize, boxSize);
                    lbl.Location = new Point(startX + col * (boxSize + padding), startY + row * (boxSize + padding));
                    lbl.BorderStyle = BorderStyle.FixedSingle;
                    lbl.Font = new Font("Arial", 24, FontStyle.Bold);
                    lbl.TextAlign = ContentAlignment.MiddleCenter;
                    lbl.BackColor = Color.White;
                    this.Controls.Add(lbl);
                    letterBoxes[row, col] = lbl;
                }
            }

           
            var txtInput = new TextBox();
            txtInput.Name = "txtInput";
            txtInput.Location = new Point(startX, startY + maxAttempts * (boxSize + padding) + 20);
            txtInput.Size = new Size(boxSize * wordLength + padding * (wordLength - 1), 40);
            txtInput.CharacterCasing = CharacterCasing.Lower;
            txtInput.MaxLength = wordLength;
            this.Controls.Add(txtInput);

            
            var btnConfirm = new Button();
            btnConfirm.Name = "btnConfirm";
            btnConfirm.Text = "Потврди";
            btnConfirm.BackColor = Color.Green;
            btnConfirm.Size = new Size(100, 40);
            btnConfirm.Location = new Point(startX, txtInput.Location.Y + txtInput.Height + 10);
            btnConfirm.Click += BtnConfirm_Click;
            this.Controls.Add(btnConfirm);

            
            var btnBack = new Button();
            btnBack.Name = "btnBack";
            btnBack.Text = "Назад";
            btnBack.Size = new Size(100, 40);
            btnBack.BackColor = Color.Red;
            btnBack.Location = new Point(190, txtInput.Location.Y + txtInput.Height + 10); 
            btnBack.Click += BtnBack_Click;
            this.Controls.Add(btnBack);


            
            var lblMessage = new Label();
            lblMessage.Name = "lblMessage";
            lblMessage.Location = new Point(startX, btnConfirm.Location.Y + btnConfirm.Height + 10);
            lblMessage.Size = new Size(boxSize * wordLength + padding * (wordLength - 1), 40);
            lblMessage.ForeColor = Color.Red;
            lblMessage.Font = new Font("Arial", 12, FontStyle.Bold);
            this.Controls.Add(lblMessage);
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            this.Close(); 
            Form1 form1 = new Form1();
            form1.Show();
        }

        private void BtnConfirm_Click(object sender, EventArgs e)
        {
            var txtInput = this.Controls.Find("txtInput", true).FirstOrDefault() as TextBox;
            var lblMessage = this.Controls.Find("lblMessage", true).FirstOrDefault() as Label;

            if (txtInput == null || lblMessage == null)
                return;

            string guess = txtInput.Text.Trim().ToLower();

            
            if (guess.Length != wordLength || !guess.All(char.IsLetter))
            {
                lblMessage.Text = "Внеси точен збор од 5 букви!";
                return;
            }

          
            if (!provider.IsValidWord(guess) && targetWord!=guess)
            {
                lblMessage.Text = "Внеси постоечки збор!";
                return;
            }

            lblMessage.Text = ""; 

            
            for (int i = 0; i < wordLength; i++)
            {
                letterBoxes[currentAttempt, i].Text = guess[i].ToString();
            }

            
            Color[] colors = new Color[wordLength];

            
            bool[] letterUsed = new bool[wordLength];

            for (int i = 0; i < wordLength; i++)
            {
                if (guess[i] == targetWord[i])
                {
                    colors[i] = Color.Green;
                    letterUsed[i] = true;
                }
                else
                {
                    colors[i] = Color.Gray; 
                }
            }

            
            for (int i = 0; i < wordLength; i++)
            {
                if (colors[i] == Color.Green)
                    continue;

                for (int j = 0; j < wordLength; j++)
                {
                    if (!letterUsed[j] && guess[i] == targetWord[j])
                    {
                        colors[i] = Color.Goldenrod; 
                        letterUsed[j] = true;
                        break;
                    }
                }
            }

            
            for (int i = 0; i < wordLength; i++)
            {
                letterBoxes[currentAttempt, i].BackColor = colors[i];
                letterBoxes[currentAttempt, i].ForeColor = Color.White;
            }

           
            if (guess == targetWord)
            {
                MessageBox.Show("Честитки! Погоди го зборот!", "Победа");
                this.Close(); 
                return;
            }

            currentAttempt++;

            if (currentAttempt >= maxAttempts)
            {
                MessageBox.Show($"Изгуби! Точниот збор беше: {targetWord}", "Крај на играта");
                this.Close();
                return;
            }

            
            txtInput.Text = "";
            txtInput.Focus();
        }
    }
}
