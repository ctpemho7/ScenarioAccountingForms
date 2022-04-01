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
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void labelRegister_Click(object sender, EventArgs e)
        {
            RegisterForm registerForm = new RegisterForm();
            registerForm.Show();
        }

        private void buttonLogIn_Click(object sender, EventArgs e)
        {
            if (textBoxLogin.Text.Length > 0 &&
                textBoxPassword.Text.Length > 0)
            {
                int islogin = Login();
                if (islogin != 0)
                {
                    Program.UserID = islogin;
                    Close();
                }
                MessageBox.Show("Проверьте правильность введённого пароля!", "Ошибка входа!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
                MessageBox.Show("Некорретный ввод!", "Что-то не так!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        int Login()
        {
            using (var cn = new SqlConnection(CRUDForm.ConnectionString))
            {
                cn.Open();
                var sql = @"SELECT * FROM AuthTable 
                            WHERE Login = @login AND Password = @password";
                var cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("@login", textBoxLogin.Text);
                cmd.Parameters.AddWithValue("@password", textBoxPassword.Text);

                var dr = cmd.ExecuteReader();
                string login;
                string password;
                int userid = 0;
                try
                {
                    while (dr.Read())
                    {
                        password = (string)dr["Password"];
                        login = (string)dr["Login"];
                        userid = (int)dr["UserID"];

                    }
                    return userid;
                }
                catch
                {
                    return 0;
                }
            }
        }

        private void textBoxPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && !char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
