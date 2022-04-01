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
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void textBoxLogin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && !char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
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
               comboBoxType.Text.Length > 0 &&
               textBoxLogin.Text.Length > 0 &&
               textBoxPassword.Text.Length > 0)
            {
                Register();
            }
            else
                MessageBox.Show("Некорретный ввод!", "Что-то не так!", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        void Register()
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


            var insUser = @"INSERT INTO SysUser
                                (Passport, Surname, Name, Patronymic, Birthdate, Sex, UserType)
                                VALUES
                                (@passport, @surname, @name, @patronymic, @birthdate, @sex, @userType)";
            var insLogPass = @"INSERT INTO AuthTable
                                   (UserID, Login, Password)
                             VALUES
                                   (@id, @login, @password)";

            using (var cn = new SqlConnection(CRUDForm.ConnectionString))
            {
                cn.Open();

                var cmdUser = new SqlCommand(insUser, cn);
                var cmdLogPass = new SqlCommand(insLogPass, cn);


                cmdUser.Parameters.AddWithValue("@passport", maskedTextBox1.Text);
                cmdUser.Parameters.AddWithValue("@surname", textBoxSurname.Text);
                cmdUser.Parameters.AddWithValue("@name", textBoxName.Text);
                cmdUser.Parameters.AddWithValue("@patronymic", textBoxPatr.Text);
                cmdUser.Parameters.AddWithValue("@birthdate", dateTimePicker1.Value.Date);
                cmdUser.Parameters.AddWithValue("@sex", sex);
                cmdUser.Parameters.AddWithValue("@userType", type);
                cmdUser.ExecuteNonQuery();


                cmdLogPass.Parameters.AddWithValue("@id", GetLastId());
                cmdLogPass.Parameters.AddWithValue("@login", textBoxLogin.Text);
                cmdLogPass.Parameters.AddWithValue("@password", textBoxPassword.Text);
                cmdLogPass.ExecuteNonQuery();



                cn.Close();
            }

            Close();

        }
        int GetLastId()
        {
            using (var cn = new SqlConnection(CRUDForm.ConnectionString))
            {
                cn.Open();
                var sql = "SELECT TOP 1 * FROM SysUser ORDER BY id DESC";
                var cmd = new SqlCommand(sql, cn);

                var dr = cmd.ExecuteReader();
                int index = 0;
                while (dr.Read())
                {
                    index = (int)dr["id"];
                }
                return index;
            }
        }
    }
}
