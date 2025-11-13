namespace SupermarketApp
{
    partial class SpisokProduct
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbl_invite = new System.Windows.Forms.Label();
            this.cmb_product = new System.Windows.Forms.ComboBox();
            this.lsb_selectedProducts = new System.Windows.Forms.ListBox();
            this.btn_add = new System.Windows.Forms.Button();
            this.btn_calculate = new System.Windows.Forms.Button();
            this.btn_clear = new System.Windows.Forms.Button();
            this.lbl_summ = new System.Windows.Forms.Label();
            this.txb_summ = new System.Windows.Forms.TextBox();
            this.btn_showCheck = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbl_invite
            // 
            this.lbl_invite.AutoSize = true;
            this.lbl_invite.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_invite.Location = new System.Drawing.Point(244, 30);
            this.lbl_invite.Name = "lbl_invite";
            this.lbl_invite.Size = new System.Drawing.Size(369, 21);
            this.lbl_invite.TabIndex = 0;
            this.lbl_invite.Text = "Выберите продукты для покупки из списка: ";
            // 
            // cmb_product
            // 
            this.cmb_product.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_product.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cmb_product.FormattingEnabled = true;
            this.cmb_product.Location = new System.Drawing.Point(247, 64);
            this.cmb_product.Name = "cmb_product";
            this.cmb_product.Size = new System.Drawing.Size(366, 29);
            this.cmb_product.TabIndex = 1;
            // 
            // lsb_selectedProducts
            // 
            this.lsb_selectedProducts.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lsb_selectedProducts.FormattingEnabled = true;
            this.lsb_selectedProducts.ItemHeight = 21;
            this.lsb_selectedProducts.Location = new System.Drawing.Point(248, 182);
            this.lsb_selectedProducts.Name = "lsb_selectedProducts";
            this.lsb_selectedProducts.Size = new System.Drawing.Size(365, 151);
            this.lsb_selectedProducts.TabIndex = 2;
            // 
            // btn_add
            // 
            this.btn_add.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_add.Location = new System.Drawing.Point(366, 99);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(129, 77);
            this.btn_add.TabIndex = 3;
            this.btn_add.Text = "Добавить";
            this.btn_add.UseVisualStyleBackColor = true;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // btn_calculate
            // 
            this.btn_calculate.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_calculate.Location = new System.Drawing.Point(97, 216);
            this.btn_calculate.Name = "btn_calculate";
            this.btn_calculate.Size = new System.Drawing.Size(129, 77);
            this.btn_calculate.TabIndex = 3;
            this.btn_calculate.Text = "Посчитать итог";
            this.btn_calculate.UseVisualStyleBackColor = true;
            this.btn_calculate.Click += new System.EventHandler(this.btn_calculate_Click);
            // 
            // btn_clear
            // 
            this.btn_clear.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_clear.Location = new System.Drawing.Point(634, 216);
            this.btn_clear.Name = "btn_clear";
            this.btn_clear.Size = new System.Drawing.Size(129, 77);
            this.btn_clear.TabIndex = 3;
            this.btn_clear.Text = "Очистить";
            this.btn_clear.UseVisualStyleBackColor = true;
            this.btn_clear.Click += new System.EventHandler(this.btn_clear_Click);
            // 
            // lbl_summ
            // 
            this.lbl_summ.AutoSize = true;
            this.lbl_summ.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_summ.Location = new System.Drawing.Point(155, 370);
            this.lbl_summ.Name = "lbl_summ";
            this.lbl_summ.Size = new System.Drawing.Size(241, 21);
            this.lbl_summ.TabIndex = 0;
            this.lbl_summ.Text = "Итоговая сумма за покупку: ";
            // 
            // txb_summ
            // 
            this.txb_summ.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txb_summ.Location = new System.Drawing.Point(403, 366);
            this.txb_summ.Name = "txb_summ";
            this.txb_summ.ReadOnly = true;
            this.txb_summ.Size = new System.Drawing.Size(210, 29);
            this.txb_summ.TabIndex = 4;
            // 
            // btn_showCheck
            // 
            this.btn_showCheck.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_showCheck.Location = new System.Drawing.Point(634, 341);
            this.btn_showCheck.Name = "btn_showCheck";
            this.btn_showCheck.Size = new System.Drawing.Size(129, 77);
            this.btn_showCheck.TabIndex = 3;
            this.btn_showCheck.Text = "Вывести чек";
            this.btn_showCheck.UseVisualStyleBackColor = true;
            this.btn_showCheck.Click += new System.EventHandler(this.btn_showCheck_Click);
            // 
            // SpisokProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txb_summ);
            this.Controls.Add(this.btn_calculate);
            this.Controls.Add(this.btn_showCheck);
            this.Controls.Add(this.btn_clear);
            this.Controls.Add(this.btn_add);
            this.Controls.Add(this.lsb_selectedProducts);
            this.Controls.Add(this.cmb_product);
            this.Controls.Add(this.lbl_summ);
            this.Controls.Add(this.lbl_invite);
            this.Name = "SpisokProduct";
            this.Text = "Список продуктов";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_invite;
        private System.Windows.Forms.ComboBox cmb_product;
        private System.Windows.Forms.ListBox lsb_selectedProducts;
        private System.Windows.Forms.Button btn_add;
        private System.Windows.Forms.Button btn_calculate;
        private System.Windows.Forms.Button btn_clear;
        private System.Windows.Forms.Label lbl_summ;
        private System.Windows.Forms.TextBox txb_summ;
        private System.Windows.Forms.Button btn_showCheck;
    }
}

