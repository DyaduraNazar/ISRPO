using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Calculator
{
    public partial class MainForm : Form
    {
        string input_number = "0";                  // текущий ввод
        List<double> operands = new List<double>(); // список чисел
        List<string> operations = new List<string>(); // список операций
        string[] priorities = { "^", "*/", "+-" };  // приоритеты операций

        public MainForm()
        {
            InitializeComponent();
        }

        // Обработка нажатия на цифры и константы
        private void btnNumber_Click(object sender, EventArgs e)
        {
            string text = ((Button)sender).Text;

            switch (text)
            {
                case "PI":
                    input_number += "3,141592";
                    txtConsole.Text += "3,141592";
                    break;
                case "e":
                    input_number += "2,718281828";
                    txtConsole.Text += "2,718281828";
                    break;
                default:
                    input_number += text;
                    txtConsole.Text += text;
                    break;
            }

            // Блокируем повторную точку
            if (text == ",")
                btnPoint.Enabled = false;
        }

        // Обработка нажатия на операции
        private void btnMathoOperation_Click(object sender, EventArgs e)
        {
            string op = ((Button)sender).Text;
            txtConsole.Text += op;
            operations.Add(op);
            AddOperand();
        }

        // Добавление числа в список операндов
        private void AddOperand()
        {
            if (double.TryParse(input_number, out double number))
                operands.Add(number);

            input_number = "0";
            btnPoint.Enabled = true;
        }

        // Калькуляция результата
        private void btnCalculate_Click(object sender, EventArgs e)
        {
            AddOperand();

            foreach (string level in priorities)
            {
                for (int i = 0; i < operations.Count; i++)
                {
                    if (level.Contains(operations[i]))
                    {
                        double result = 0;
                        switch (operations[i])
                        {
                            case "^":
                                result = Math.Pow(operands[i], operands[i + 1]);
                                break;
                            case "*":
                                result = operands[i] * operands[i + 1];
                                break;
                            case "/":
                                result = operands[i] / operands[i + 1];
                                break;
                            case "+":
                                result = operands[i] + operands[i + 1];
                                break;
                            case "-":
                                result = operands[i] - operands[i + 1];
                                break;
                        }
                        operands[i + 1] = result;
                        operands[i] = 0; // старое значение обнуляем
                    }
                }
            }

            double finalResult = operands[operands.Count - 1];
            txtConsole.Text = finalResult.ToString();
            input_number = finalResult.ToString();

            operands.Clear();
            operations.Clear();
        }

        // Очистка ввода
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtConsole.Clear();
            operands.Clear();
            operations.Clear();
            input_number = "0";
            btnPoint.Enabled = true;
        }

        // Удаление последнего символа
        private void btnReverse_Click(object sender, EventArgs e)
        {
            if (txtConsole.Text.Length > 0)
            {
                txtConsole.Text = txtConsole.Text.Remove(txtConsole.Text.Length - 1, 1);
            }

            if (input_number.Length > 1)
                input_number = input_number.Remove(input_number.Length - 1);
            else
                input_number = "0";
        }
    }
}
