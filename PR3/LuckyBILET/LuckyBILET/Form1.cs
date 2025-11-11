using System;
using System.Drawing;
using System.Windows.Forms;

namespace LuckyBILET
{
    public partial class Form1 : Form
    {
        Random rnd = new Random();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int ticket = GenerateTicket();
            label2.Text = ticket.ToString();

            if (IsLucky(ticket))
            {
                label3.Text = "Счастливый билет!";
                label3.ForeColor = Color.Green;
                label2.ForeColor = Color.Green;
            }
            else
            {
                label3.Text = "Обычный билет";
                label3.ForeColor = Color.Red;
                label2.ForeColor = Color.Red;
            }
        }

        private int GenerateTicket()
        {
            // Генерируем число от 100000 до 999999
            return rnd.Next(100000, 1000000);
        }

        private bool IsLucky(int num)
        {
            // Преобразуем в строку, чтобы проще было работать с цифрами
            string s = num.ToString();
            int left = (s[0] - '0') + (s[1] - '0') + (s[2] - '0');
            int right = (s[3] - '0') + (s[4] - '0') + (s[5] - '0');
            return left == right;
        }
    }
}
