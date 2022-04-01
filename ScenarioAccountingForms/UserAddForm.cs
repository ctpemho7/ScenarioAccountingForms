using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScenarioAccountingForms
{
    public partial class UserAddForm : Form
    {
        string cs = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Semyon\ScenarioAccounting.mdf;Integrated Security=True;";
        bool isUpdate { set; get; }
        public DataGridViewRow SelectedRow { get; set; }
        DataTable Table { get; set; }
        int Last_id { get; set; }

        public UserAddForm(DataTable temp, int last_id) //добавление
        {
            isUpdate = false;
            Last_id = last_id;
            Table = temp;
            InitializeComponent();
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "yyyy/MM/dd";
        }

        //изменение
        public UserAddForm(DataGridViewRow temp)
        {
            isUpdate = true;
            SelectedRow = temp;
            InitializeComponent();
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "yyyy/MM/dd";

            Text = "Изменение записи";
            maskedTextBox1.Text = SelectedRow.Cells[1].Value.ToString();
            textBoxSurname.Text = SelectedRow.Cells[2].Value.ToString();
            textBoxName.Text = SelectedRow.Cells[3].Value.ToString();
            textBoxPatr.Text = SelectedRow.Cells[4].Value.ToString();
            dateTimePicker1.Value = (DateTime)SelectedRow.Cells[5].Value;
            comboBoxSex.Text = SelectedRow.Cells[6].Value.ToString();
            comboBoxType.Text = SelectedRow.Cells[7].Value.ToString();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (maskedTextBox1.Text.Length > 0 &&
                textBoxSurname.Text.Length > 0 &&
                textBoxName.Text.Length > 0 &&
                textBoxPatr.Text.Length > 0 &&
                dateTimePicker1.Text.Length > 0 &&
                comboBoxSex.Text.Length > 0 &&
                comboBoxType.Text.Length > 0)
            {
                int sex;
                if (comboBoxSex.Text == "Мужской")
                    sex = 1;
                else
                    sex = 2;

                int type;
                if (comboBoxSex.Text == "Инженер")
                    type = 1;
                else
                    type = 2;

                var sql = string.Empty;
                if (isUpdate)
                {
                    SelectedRow.Cells[1].Value = maskedTextBox1.Text;
                    SelectedRow.Cells[2].Value = textBoxSurname.Text;
                    SelectedRow.Cells[3].Value = textBoxName.Text;
                    SelectedRow.Cells[4].Value = textBoxPatr.Text;
                    SelectedRow.Cells[5].Value = dateTimePicker1.Value;
                    SelectedRow.Cells[6].Value = comboBoxSex.Text;
                    SelectedRow.Cells[7].Value = comboBoxType.Text;
                    //@passport, @surname, @name, @patronymic, @birthdate, @sex, @userType
                    sql = @"UPDATE SysUser
                         SET [Passport] = @passport
                            ,[Surname] = @surname
                            ,[Name] = @name
                            ,[Patronymic] = @patronymic 
                            ,[Birthdate] = @birthdate
                            ,[Sex] = @sex
                            ,[UserType] = @userType
                        WHERE id = @id";

                }
                else // not update
                {
                    DataRow newRow = Table.NewRow();
                    //id, Passport, Surname, Name, Patronymic, Birthdate, SexName, TypeName
                    newRow["Passport"] = maskedTextBox1.Text;
                    newRow["Surname"] = textBoxSurname.Text;
                    newRow["Name"] = textBoxName.Text;
                    newRow["Patronymic"] = textBoxPatr.Text;
                    newRow["Birthdate"] = dateTimePicker1.Value.Date;
                    newRow["SexName"] = comboBoxSex.Text;
                    newRow["TypeName"] = comboBoxType.Text;
                    newRow["id"] = Last_id + 1;
                    Table.Rows.Add(newRow);

                    sql = @"INSERT INTO SysUser
                                (Passport, Surname, Name, Patronymic, Birthdate, Sex, UserType)
                                VALUES
                                (@passport, @surname, @name, @patronymic, @birthdate, @sex, @userType)";
                }


                //AddingGrid.Rows.Insert(0, maskedTextBox1.Text, textBoxSurname.Text, textBoxName.Text, textBoxPatr.Text, dateTimePicker1.Value.ToShortDateString(), comboBoxSex.Text, comboBoxType.Text);

                //long passport = Convert.ToInt64(maskedTextBox1.Text.Replace(" ", string.Empty));
                using (var cn = new SqlConnection(cs))
                {
                    cn.Open();

                    var cmd = new SqlCommand(sql, cn);
                    if (isUpdate)
                        cmd.Parameters.AddWithValue("@id", SelectedRow.Cells[0].Value);

                    cmd.Parameters.AddWithValue("@passport", maskedTextBox1.Text);
                    cmd.Parameters.AddWithValue("@surname", textBoxSurname.Text);
                    cmd.Parameters.AddWithValue("@name", textBoxName.Text);
                    cmd.Parameters.AddWithValue("@patronymic", textBoxPatr.Text);
                    cmd.Parameters.AddWithValue("@birthdate", dateTimePicker1.Text);
                    cmd.Parameters.AddWithValue("@sex", sex);
                    cmd.Parameters.AddWithValue("@userType", type);
                    cmd.ExecuteNonQuery();
                    cn.Close();
                }

                Close();
            }
            else
                MessageBox.Show("Некорретный ввод!", "Что-то не так!", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }


    }
}

