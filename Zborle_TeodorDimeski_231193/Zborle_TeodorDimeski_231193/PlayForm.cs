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
    public partial class PlayForm : Form
    {
        private string targetWord; // Збор што треба да се погоди
        private int currentAttempt = 0; // Тековен обид (0-5)
        private const int maxAttempts = 6;
        private const int wordLength = 5;

        // Матрица од Label за прикажување букви и бои
        private Label[,] letterBoxes = new Label[maxAttempts, wordLength];
        WordProvider provider;


        public PlayForm()
        {
            InitializeComponent();
             provider = new WordProvider();
            targetWord = provider.GetRandwomWord() as string;
            if (targetWord == "false")
            {
                MessageBox.Show("Грешка при вчитување на збор");
            }
            this.Size = new Size(450, 550);

            SetupGrid();
        }

        private void PlayForm_Load(object sender, EventArgs e)
        {

        }
        private void SetupGrid()
        {
            // Динамички креирај 6x5 Labels во форма
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

            // Текст бокс за внесување на збор
            var txtInput = new TextBox();
            txtInput.Name = "txtInput";
            txtInput.Location = new Point(startX, startY + maxAttempts * (boxSize + padding) + 20);
            txtInput.Size = new Size(boxSize * wordLength + padding * (wordLength - 1), 40);
            txtInput.CharacterCasing = CharacterCasing.Lower;
            txtInput.MaxLength = wordLength;
            this.Controls.Add(txtInput);

            // Копче за потврда
            var btnConfirm = new Button();
            btnConfirm.Name = "btnConfirm";
            btnConfirm.Text = "Потврди";
            btnConfirm.BackColor = Color.Green;
            btnConfirm.Size = new Size(100, 40);
            btnConfirm.Location = new Point(startX, txtInput.Location.Y + txtInput.Height + 10);
            btnConfirm.Click += BtnConfirm_Click;
            this.Controls.Add(btnConfirm);

            // Копче за НАЗАД
            var btnBack = new Button();
            btnBack.Name = "btnBack";
            btnBack.Text = "Назад";
            btnBack.Size = new Size(100, 40);
            btnBack.BackColor = Color.Red;
            btnBack.Location = new Point(190, txtInput.Location.Y + txtInput.Height + 10); 
            btnBack.Click += BtnBack_Click;
            this.Controls.Add(btnBack);


            // Label за пораки
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
            
        }

        private void BtnConfirm_Click(object sender, EventArgs e)
        {
            var txtInput = this.Controls.Find("txtInput", true).FirstOrDefault() as TextBox;
            var lblMessage = this.Controls.Find("lblMessage", true).FirstOrDefault() as Label;

            if (txtInput == null || lblMessage == null)
                return;

            string guess = txtInput.Text.Trim().ToLower();

            // Валидација: точно 5 букви и само букви
            if (guess.Length != wordLength || !guess.All(char.IsLetter))
            {
                lblMessage.Text = "Внеси точен збор од 5 букви!";
                return;
            }

            // Валидација: дали зборот постои во листата на зборови
            if (!provider.IsValidWord(guess)){
                lblMessage.Text = "Внеси постоечки збор!";
                return;
            }

            lblMessage.Text = ""; // чисти порака

            // Прикажи го внесениот збор во мрежата
            for (int i = 0; i < wordLength; i++)
            {
                letterBoxes[currentAttempt, i].Text = guess[i].ToString();
            }

            // Бојање букви според Wordle правила
            Color[] colors = new Color[wordLength];

            // Прво ја боиме зелената локација
            bool[] letterUsed = new bool[wordLength]; // Кои букви од targetWord се веќе погодени

            for (int i = 0; i < wordLength; i++)
            {
                if (guess[i] == targetWord[i])
                {
                    colors[i] = Color.Green;
                    letterUsed[i] = true;
                }
                else
                {
                    colors[i] = Color.Gray; // засега
                }
            }

            // Сега боиме жолто за букви кои се во зборот, ама не се на точна позиција
            for (int i = 0; i < wordLength; i++)
            {
                if (colors[i] == Color.Green)
                    continue;

                for (int j = 0; j < wordLength; j++)
                {
                    if (!letterUsed[j] && guess[i] == targetWord[j])
                    {
                        colors[i] = Color.Goldenrod; // жолта боја
                        letterUsed[j] = true;
                        break;
                    }
                }
            }

            // Постави бои на Label-ите
            for (int i = 0; i < wordLength; i++)
            {
                letterBoxes[currentAttempt, i].BackColor = colors[i];
                letterBoxes[currentAttempt, i].ForeColor = Color.White;
            }

            // Проверка дали е погоден зборот
            if (guess == targetWord)
            {
                MessageBox.Show("Честитки! Погоди го зборот!", "Победа");
                this.Close(); // Затвори ја формата и врати се на почетната форма
                return;
            }

            currentAttempt++;

            if (currentAttempt >= maxAttempts)
            {
                MessageBox.Show($"Изгуби! Точниот збор беше: {targetWord}", "Крај на играта");
                this.Close();
                return;
            }

            // Испразни TextBox за нов обид
            txtInput.Text = "";
            txtInput.Focus();
        }
    }
}
