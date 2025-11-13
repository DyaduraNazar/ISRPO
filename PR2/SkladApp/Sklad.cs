using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;

namespace SkladApp
{
    public partial class Sklad : Form
    {
        private const string ConnStr = "Server=DESKTOP-33V95C9\\SQLEXPRESS;Database=sklad;Integrated Security=True;";

        public Sklad()
        {
            InitializeComponent();
            UpdateProductsGrid();
            FillProductList();
        }

        private void UpdateProductsGrid()
        {
            try
            {
                using (var connection = new SqlConnection(ConnStr))
                {
                    var adapter = new SqlDataAdapter("SELECT * FROM products", connection);
                    var table = new DataTable();
                    adapter.Fill(table);

                    dgvProducts.DataSource = table;
                    dgvProducts.Columns["id"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки данных: {ex.Message}");
            }
        }

        private void FillProductList()
        {
            comboBox1.Items.Clear();

            try
            {
                using (var connection = new SqlConnection(ConnStr))
                using (var command = new SqlCommand("SELECT name FROM products", connection))
                {
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                            comboBox1.Items.Add(reader["name"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки списка товаров: {ex.Message}");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvProducts.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите товар для удаления");
                return;
            }

            int id = Convert.ToInt32(dgvProducts.SelectedRows[0].Cells["id"].Value);

            try
            {
                using (var conn = new SqlConnection(ConnStr))
                using (var cmd = new SqlCommand("DELETE FROM products WHERE id = @id", conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Товар удалён");
                UpdateProductsGrid();
                FillProductList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка удаления: {ex.Message}");
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Введите название товара");
                return;
            }

            string insertQuery = @"INSERT INTO products (name, stillage, cell, quantity) 
                                   VALUES (@name, @stillage, @cell, @quantity)";

            try
            {
                using (var conn = new SqlConnection(ConnStr))
                using (var cmd = new SqlCommand(insertQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@name", textBox1.Text);
                    cmd.Parameters.AddWithValue("@stillage", numericUpDown1.Value);
                    cmd.Parameters.AddWithValue("@cell", numericUpDown2.Value);
                    cmd.Parameters.AddWithValue("@quantity", numericUpDown3.Value);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Товар добавлен");
                textBox1.Clear();
                UpdateProductsGrid();
                FillProductList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка добавления: {ex.Message}");
            }
        }

        private void btnSaveCSV_Click(object sender, EventArgs e)
        {
            using (var dialog = new SaveFileDialog
            {
                Filter = "CSV файлы (*.csv)|*.csv|Все файлы (*.*)|*.*",
                Title = "Сохранить данные о товарах"
            })
            {
                if (dialog.ShowDialog() != DialogResult.OK) return;

                try
                {
                    using (var writer = new StreamWriter(dialog.FileName))
                    {
                        writer.WriteLine("Наименование;Стеллаж;Ячейка;Количество");

                        foreach (DataGridViewRow row in dgvProducts.Rows)
                        {
                            if (row.IsNewRow) continue;

                            writer.WriteLine($"{row.Cells["name"].Value};" +
                                             $"{row.Cells["stillage"].Value};" +
                                             $"{row.Cells["cell"].Value};" +
                                             $"{row.Cells["quantity"].Value}");
                        }
                    }

                    MessageBox.Show("CSV файл успешно сохранён");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка сохранения: {ex.Message}");
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Выберите товар для изменения");
                return;
            }

            string updateQuery = @"UPDATE products 
                                   SET name = @newName, stillage = @stillage, cell = @cell, quantity = @quantity 
                                   WHERE name = @oldName";

            try
            {
                using (var conn = new SqlConnection(ConnStr))
                using (var cmd = new SqlCommand(updateQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@newName", textBox1.Text);
                    cmd.Parameters.AddWithValue("@oldName", comboBox1.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@stillage", numericUpDown1.Value);
                    cmd.Parameters.AddWithValue("@cell", numericUpDown2.Value);
                    cmd.Parameters.AddWithValue("@quantity", numericUpDown3.Value);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Данные обновлены");
                UpdateProductsGrid();
                FillProductList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка обновления: {ex.Message}");
            }
        }

        private void btnLoadCSV_Click(object sender, EventArgs e)
        {
            using (var dialog = new OpenFileDialog
            {
                Filter = "CSV файлы (*.csv)|*.csv|Все файлы (*.*)|*.*",
                Title = "Загрузить данные о товарах"
            })
            {
                if (dialog.ShowDialog() != DialogResult.OK) return;

                try
                {
                    ClearTable();

                    using (var reader = new StreamReader(dialog.FileName))
                    {
                        reader.ReadLine(); // пропускаем заголовки
                        while (!reader.EndOfStream)
                        {
                            var parts = reader.ReadLine().Split(';');
                            if (parts.Length == 4)
                            {
                                InsertProduct(parts[0],
                                              int.Parse(parts[1]),
                                              int.Parse(parts[2]),
                                              int.Parse(parts[3]));
                            }
                        }
                    }

                    MessageBox.Show("Данные успешно загружены из CSV");
                    UpdateProductsGrid();
                    FillProductList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка загрузки: {ex.Message}");
                }
            }
        }

        private void ClearTable()
        {
            try
            {
                using (var conn = new SqlConnection(ConnStr))
                using (var cmd = new SqlCommand("DELETE FROM products", conn))
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка очистки базы: {ex.Message}");
            }
        }

        private void InsertProduct(string name, int shelf, int cell, int qty)
        {
            try
            {
                using (var conn = new SqlConnection(ConnStr))
                using (var cmd = new SqlCommand(
                    @"INSERT INTO products (name, stillage, cell, quantity)
                      VALUES (@name, @stillage, @cell, @quantity)", conn))
                {
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@stillage", shelf);
                    cmd.Parameters.AddWithValue("@cell", cell);
                    cmd.Parameters.AddWithValue("@quantity", qty);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка добавления: {ex.Message}");
            }
        }

        private void btnSearchByName_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("Введите название для поиска");
                return;
            }

            try
            {
                using (var conn = new SqlConnection(ConnStr))
                using (var adapter = new SqlDataAdapter("SELECT * FROM products WHERE name LIKE @name", conn))
                {
                    adapter.SelectCommand.Parameters.AddWithValue("@name", "%" + textBox2.Text + "%");
                    var dt = new DataTable();
                    adapter.Fill(dt);

                    dgvProducts.DataSource = dt;
                    dgvProducts.Columns["id"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка поиска: {ex.Message}");
            }
        }

        private void btnSearchByCoord_Click(object sender, EventArgs e)
        {
            try
            {
                using (var conn = new SqlConnection(ConnStr))
                using (var adapter = new SqlDataAdapter(
                    "SELECT * FROM products WHERE stillage = @stillage AND cell = @cell", conn))
                {
                    adapter.SelectCommand.Parameters.AddWithValue("@stillage", numericUpDown4.Value);
                    adapter.SelectCommand.Parameters.AddWithValue("@cell", numericUpDown5.Value);

                    var dt = new DataTable();
                    adapter.Fill(dt);

                    dgvProducts.DataSource = dt;
                    dgvProducts.Columns["id"].Visible = false;

                    if (dt.Rows.Count == 0)
                        MessageBox.Show("Товары не найдены");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка поиска: {ex.Message}");
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null) return;

            try
            {
                using (var conn = new SqlConnection(ConnStr))
                using (var cmd = new SqlCommand(
                    "SELECT stillage, cell, quantity FROM products WHERE name = @name", conn))
                {
                    cmd.Parameters.AddWithValue("@name", comboBox1.SelectedItem.ToString());
                    conn.Open();

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            numericUpDown1.Value = Convert.ToDecimal(reader["stillage"]);
                            numericUpDown2.Value = Convert.ToDecimal(reader["cell"]);
                            numericUpDown3.Value = Convert.ToDecimal(reader["quantity"]);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки данных: {ex.Message}");
            }
        }
    }
}
