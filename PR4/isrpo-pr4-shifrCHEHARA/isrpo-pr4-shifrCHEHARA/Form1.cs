using System;
using System.Windows.Forms;

namespace isrpo_pr4_shifrCHEHARA
{
    public partial class Form1 : Form
    {
        string rus = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";
        string eng = "abcdefghijklmnopqrstuvwxyz";

        public Form1()
        {
            InitializeComponent();
            domainUpDown1.Text = "3"; // стандартный сдвиг
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Зашифровать
            string input = textBox1.Text.ToLower();

            if (string.IsNullOrWhiteSpace(input))
            {
                MessageBox.Show("Введите текст для шифрования!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int shift = Convert.ToInt32(domainUpDown1.Text);
            int lang = comboBox1.SelectedIndex;

            if (lang == -1)
            {
                MessageBox.Show("Выберите язык!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (lang == 0)
                textBox2.Text = CaesarShift(input, rus, shift);
            else
                textBox2.Text = CaesarShift(input, eng, shift);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Дешифровать
            string input = textBox1.Text.ToLower();

            if (string.IsNullOrWhiteSpace(input))
            {
                MessageBox.Show("Введите текст для дешифровки!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int shift = -Convert.ToInt32(domainUpDown1.Text);
            int lang = comboBox1.SelectedIndex;

            if (lang == -1)
            {
                MessageBox.Show("Выберите язык!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (lang == 0)
                textBox2.Text = CaesarShift(input, rus, shift);
            else
                textBox2.Text = CaesarShift(input, eng, shift);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Очистка полей
            textBox1.Clear();
            textBox2.Clear();
            comboBox1.SelectedIndex = -1;
            domainUpDown1.Text = "3";
        }

        private string CaesarShift(string text, string alphabet, int shift)
        {
            string result = "";

            foreach (char c in text)
            {
                int pos = alphabet.IndexOf(c);
                if (pos == -1)
                {
                    result += c; // не буква — просто добавляем
                }
                else
                {
                    int newPos = (pos + shift) % alphabet.Length;
                    if (newPos < 0) newPos += alphabet.Length;
                    result += alphabet[newPos];
                }
            }

            return result;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Добавляем языки при запуске
            comboBox1.Items.Add("Русский");
            comboBox1.Items.Add("Английский");
        }
    }
}
