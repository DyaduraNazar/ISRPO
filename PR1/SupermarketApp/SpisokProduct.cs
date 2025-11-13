using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace SupermarketApp
{
    public partial class SpisokProduct : Form
    {
        private Dictionary<string, decimal> prices = new Dictionary<string, decimal>();

        public SpisokProduct()
        {
            InitializeComponent();
            fillComboBox();
        }

        private void fillComboBox()
        {
            cmb_product.Items.Clear();
            string query = "select name, price from products order by name asc";
            DataTable table = DataBase.executeQuery(query);
            foreach (DataRow row in table.Rows)
            {
                cmb_product.Items.Add($"{row.ItemArray[0]} - {row.ItemArray[1]:C}");
            }
        }

        private void btn_add_Click(object sender, System.EventArgs e)
        {
            if (cmb_product.SelectedIndex != -1)
            {
                lsb_selectedProducts.Items.Add(cmb_product.SelectedItem);
            }
        }

        private void btn_calculate_Click(object sender, System.EventArgs e)
        {
            decimal total_price = 0m;
            foreach (var item in lsb_selectedProducts.Items)
            {
                var parts = Regex.Split(item.ToString(), @"\s-\s");
                total_price += Convert.ToDecimal(parts[1].Split(' ')[0]);
            }
            txb_summ.Text = total_price.ToString("C");
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            lsb_selectedProducts.Items.Clear();
            txb_summ.Text = "";
        }

        private void btn_showCheck_Click(object sender, EventArgs e)
        {
            if (txb_summ.Text != "")
            {
                int index = 0;
                string text = $"=========== ЧЕК ===========n" +
                              $"ул. БравлСтараса, д. 42 \"Пятёрочка\"\n" +
                              $"{DateTime.Now.ToString("dd MMMM yyyyг. H:mm")}\n";
                foreach (var item in lsb_selectedProducts.Items)
                {
                    text += $"\n{index += 1}. {item}";
                }
                text += $"\n\n{txb_summ.Text}";
                for (index = 1; File.Exists($"check_{index}.txt"); index++) ;
                File.WriteAllText($"check_{index}.txt", text);
                MessageBox.Show("Чек сохранен!");
            }
            else
            {
                MessageBox.Show("Сначала рассчитайте стоимость!");
            }
        }
    }
}
