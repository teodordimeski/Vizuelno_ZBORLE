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
    public partial class PlayTimerMode : Form
    {
        private string targetWord;
        private int currentAttempt = 0;
        private const int maxAttempts = 6;
        private const int wordLength = 5;

        private Label[,] letterBoxes = new Label[maxAttempts, wordLength];
        private Timer countdownTimer;
        private int timeLeft = 120; 
        private Label lblTimer;

        WordProvider provider;

        public PlayTimerMode()
        {
            InitializeComponent();
            provider = new WordProvider();
            targetWord = provider.GetRandwomWord() as string;

            if (targetWord == "false")
            {
                MessageBox.Show("Грешка при вчитување на збор");
                this.Close();
                return;
            }
            this.Size = new Size(450, 550);
            SetupGrid();
            StartTimer();
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
                    var lbl = new Label
                    {
                        Size = new Size(boxSize, boxSize),
                        Location = new Point(startX + col * (boxSize + padding), startY + row * (boxSize + padding)),
                        BorderStyle = BorderStyle.FixedSingle,
                        Font = new Font("Arial", 24, FontStyle.Bold),
                        TextAlign = ContentAlignment.MiddleCenter,
                        BackColor = Color.White
                    };
                    this.Controls.Add(lbl);
                    letterBoxes[row, col] = lbl;
                }
            }

            var txtInput = new TextBox
            {
                Name = "txtInput",
                Location = new Point(startX, startY + maxAttempts * (boxSize + padding) + 20),
                Size = new Size(boxSize * wordLength + padding * (wordLength - 1), 40),
                CharacterCasing = CharacterCasing.Lower,
                MaxLength = wordLength
            };
            this.Controls.Add(txtInput);

            var btnConfirm = new Button
            {
                Name = "btnConfirm",
                Text = "Потврди",
                BackColor = Color.Green,
                Size = new Size(100, 40),
                Location = new Point(startX, txtInput.Location.Y + txtInput.Height + 10)
            };
            btnConfirm.Click += BtnConfirm_Click;
            this.Controls.Add(btnConfirm);

            var btnBack = new Button
            {
                Name = "btnBack",
                Text = "Назад",
                Size = new Size(100, 40),
                BackColor = Color.Red,
                Location = new Point(190, txtInput.Location.Y + txtInput.Height + 10)
            };
            btnBack.Click += BtnBack_Click;
            this.Controls.Add(btnBack);

            var lblMessage = new Label
            {
                Name = "lblMessage",
                Location = new Point(startX, btnConfirm.Location.Y + btnConfirm.Height + 10),
                Size = new Size(boxSize * wordLength + padding * (wordLength - 1), 40),
                ForeColor = Color.Red,
                Font = new Font("Arial", 12, FontStyle.Bold)
            };
            this.Controls.Add(lblMessage);

            // Label за тајмер - горен десен агол
            lblTimer = new Label
            {
                Name = "lblTimer",
                AutoSize = true,
                Location = new Point(this.ClientSize.Width - 120, 10),
                Font = new Font("Arial", 14, FontStyle.Bold),
                ForeColor = Color.Blue,
                Anchor = AnchorStyles.Top | AnchorStyles.Right
            };
            this.Controls.Add(lblTimer);
        }

        private void StartTimer()
        {
            countdownTimer = new Timer();
            countdownTimer.Interval = 1000; 
            countdownTimer.Tick += CountdownTimer_Tick;
            countdownTimer.Start();
            UpdateTimerLabel();
        }

        private void CountdownTimer_Tick(object sender, EventArgs e)
        {
            timeLeft--;
            UpdateTimerLabel();

            if (timeLeft <= 0)
            {
                countdownTimer.Stop();
                var lblMessage = this.Controls.Find("lblMessage", true).FirstOrDefault() as Label;
                var btnConfirm = this.Controls.Find("btnConfirm", true).FirstOrDefault() as Button;

                if (lblMessage != null)
                    lblMessage.Text = "Времето истече!";

                if (btnConfirm != null)
                    btnConfirm.Enabled = false;

                MessageBox.Show($"Изгуби! Точниот збор беше: {targetWord}", "Крај на играта");
                this.Close();
                return;

            }
        }

        private void UpdateTimerLabel()
        {
            int minutes = timeLeft / 60;
            int seconds = timeLeft % 60;
            lblTimer.Text = $"⏱️ {minutes:D2}:{seconds:D2}";
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            this.Close();
            countdownTimer.Stop();
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

            if (!provider.IsValidWord(guess))
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
                countdownTimer.Stop();
                MessageBox.Show("Честитки! Го погоди  зборот!", "Победа");
                this.Close();
                return;
            }

            currentAttempt++;

            if (currentAttempt >= maxAttempts)
            {
                countdownTimer.Stop();
                MessageBox.Show($"Изгуби! Точниот збор беше: {targetWord}", "Крај на играта");
                this.Close();
                return;
            }

            txtInput.Text = "";
            txtInput.Focus();
        }

        private void PlayTimerMode_Load(object sender, EventArgs e)
        {

        }
    }
}
