
namespace ScenarioAccountingForms
{
    partial class Form1
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.buttonGetUser = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonExcel = new System.Windows.Forms.Button();
            this.buttonRooms = new System.Windows.Forms.Button();
            this.labelHello = new System.Windows.Forms.Label();
            this.labelRole = new System.Windows.Forms.Label();
            this.labelAbility = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 104);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(172, 72);
            this.button1.TabIndex = 0;
            this.button1.Tag = "SysUser";
            this.button1.Text = "Пользователи";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 200);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(172, 72);
            this.button2.TabIndex = 1;
            this.button2.Tag = "Room";
            this.button2.Text = "Помещения";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button1_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(12, 302);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(172, 72);
            this.button3.TabIndex = 2;
            this.button3.Tag = "SmartThing";
            this.button3.Text = "Умные вещи";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button1_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(12, 403);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(172, 72);
            this.button4.TabIndex = 3;
            this.button4.Tag = "Scenario";
            this.button4.Text = "Сценарии";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // buttonGetUser
            // 
            this.buttonGetUser.Location = new System.Drawing.Point(259, 421);
            this.buttonGetUser.Name = "buttonGetUser";
            this.buttonGetUser.Size = new System.Drawing.Size(172, 54);
            this.buttonGetUser.TabIndex = 4;
            this.buttonGetUser.Text = "Активность пользователей";
            this.buttonGetUser.UseVisualStyleBackColor = true;
            this.buttonGetUser.Click += new System.EventHandler(this.buttonGetUser_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(379, 255);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(138, 44);
            this.button6.TabIndex = 5;
            this.button6.Text = "button6";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(213, 104);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(575, 270);
            this.dataGridView1.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(210, 390);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(162, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "Сформировать отчёты:";
            // 
            // buttonExcel
            // 
            this.buttonExcel.Enabled = false;
            this.buttonExcel.Location = new System.Drawing.Point(651, 381);
            this.buttonExcel.Name = "buttonExcel";
            this.buttonExcel.Size = new System.Drawing.Size(137, 35);
            this.buttonExcel.TabIndex = 8;
            this.buttonExcel.Text = "Открыть в Excel";
            this.buttonExcel.UseVisualStyleBackColor = true;
            this.buttonExcel.Click += new System.EventHandler(this.buttonExcel_Click);
            // 
            // buttonRooms
            // 
            this.buttonRooms.Location = new System.Drawing.Point(482, 421);
            this.buttonRooms.Name = "buttonRooms";
            this.buttonRooms.Size = new System.Drawing.Size(172, 54);
            this.buttonRooms.TabIndex = 9;
            this.buttonRooms.Text = "Cтатистика по помещениям";
            this.buttonRooms.UseVisualStyleBackColor = true;
            this.buttonRooms.Click += new System.EventHandler(this.buttonRooms_Click);
            // 
            // labelHello
            // 
            this.labelHello.AutoSize = true;
            this.labelHello.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelHello.Location = new System.Drawing.Point(12, 9);
            this.labelHello.Name = "labelHello";
            this.labelHello.Size = new System.Drawing.Size(229, 21);
            this.labelHello.TabIndex = 11;
            this.labelHello.Text = "Здравствуйте, Иван Ильич!";
            // 
            // labelRole
            // 
            this.labelRole.AutoSize = true;
            this.labelRole.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelRole.Location = new System.Drawing.Point(12, 40);
            this.labelRole.Name = "labelRole";
            this.labelRole.Size = new System.Drawing.Size(264, 21);
            this.labelRole.TabIndex = 12;
            this.labelRole.Text = "Ваша роль в системе: Аналитик";
            // 
            // labelAbility
            // 
            this.labelAbility.AutoSize = true;
            this.labelAbility.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelAbility.Location = new System.Drawing.Point(12, 70);
            this.labelAbility.Name = "labelAbility";
            this.labelAbility.Size = new System.Drawing.Size(526, 21);
            this.labelAbility.TabIndex = 13;
            this.labelAbility.Text = "Вы можете формировать отчёты и просматривать информацию";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 491);
            this.Controls.Add(this.labelAbility);
            this.Controls.Add(this.labelRole);
            this.Controls.Add(this.labelHello);
            this.Controls.Add(this.buttonRooms);
            this.Controls.Add(this.buttonExcel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.buttonGetUser);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Система учёта сценариев";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button buttonGetUser;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonExcel;
        private System.Windows.Forms.Button buttonRooms;
        private System.Windows.Forms.Label labelHello;
        private System.Windows.Forms.Label labelRole;
        private System.Windows.Forms.Label labelAbility;
    }
}

