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
    public partial class RoomAddForm : Form
    {
        string cs = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Semyon\ScenarioAccounting.mdf;Integrated Security=True;";
        bool isUpdate { set; get; }
        public DataGridViewRow SelectedRow { get; set; }
        DataTable Table { get; set; }
        int Last_id { get; set; }

        public RoomAddForm(DataTable temp, int last_id)
        {
            isUpdate = false;
            Last_id = last_id;
            Table = temp;
            InitializeComponent();
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "yyyy/MM/dd";
        }

        public RoomAddForm(DataGridViewRow temp)
        {
            isUpdate = true;
            SelectedRow = temp;
            InitializeComponent();
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "yyyy/MM/dd";

            Text = "Изменение записи";
            textBoxName.Text = SelectedRow.Cells[1].Value.ToString();
            textBoxFloor.Text = SelectedRow.Cells[2].Value.ToString();
            textBoxArea.Text = SelectedRow.Cells[3].Value.ToString();
            dateTimePicker1.Value = (DateTime)SelectedRow.Cells[4].Value;
        }

        #region textboxproof
        private void textBoxFloor_TextChanged(object sender, EventArgs e)
        {
            if (textBoxFloor.Text.Length > 0)
            {
                try
                {
                    _ = Convert.ToInt32(textBoxFloor.Text);
                }
                catch
                {
                    textBoxFloor.Text = "1";
                    //Area = 50;
                }
            }
        }
        private void textBoxArea_TextChanged(object sender, EventArgs e)
        {
            if (textBoxArea.Text.Length > 0)
            {
                try
                {
                    //_ = Convert.ToDouble(textBoxArea.Text);
                }
                catch
                {
                    textBoxArea.Text = "50";
                }
            }
        }
        private void textBoxFloor_KeyPress(object sender, KeyPressEventArgs e)
        {

            char number = e.KeyChar;
            if (!char.IsControl(e.KeyChar) && !Char.IsDigit(number))
            {
                e.Handled = true;
            }
        }
        private void textBoxArea_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ','))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == ',') && ((sender as TextBox).Text.IndexOf(',') > -1))
            {
                e.Handled = true;
            }
        }
        #endregion

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (textBoxName.Text.Length > 0 &&
                textBoxArea.Text.Length > 0 &&
                textBoxFloor.Text.Length > 0 &&
                dateTimePicker1.Text.Length > 0)
            {

                var sql = string.Empty;
                if (isUpdate)
                {
                    SelectedRow.Cells[1].Value = textBoxName.Text;
                    SelectedRow.Cells[2].Value = textBoxFloor.Text;
                    SelectedRow.Cells[3].Value = textBoxArea.Text;
                    SelectedRow.Cells[4].Value = dateTimePicker1.Value;

                    //@name, @floor, @area, @creatdate
                    sql = @"UPDATE Room
                         SET [Name] = @name
                            ,[Floor] = @floor
                            ,[Area] = @area
                            ,[CreationDate] = @creatdate 
                        WHERE id = @id";

                }
                else // not update
                {
                    DataRow newRow = Table.NewRow();
                    //id, Passport, Surname, Name, Patronymic, Birthdate, SexName, TypeName
                    newRow["Name"] = textBoxName.Text;
                    newRow["Floor"] = textBoxFloor.Text;
                    newRow["Area"] = Convert.ToDouble(textBoxArea.Text);
                    newRow["CreationDate"] = dateTimePicker1.Value;

                    newRow["id"] = Last_id + 1;
                    Table.Rows.Add(newRow);

                    sql = @"INSERT INTO Room
                                (Name, Floor, Area, CreationDate)
                                VALUES
                                (@name, @floor, @area, @creatdate)";
                }


                using (var cn = new SqlConnection(cs))
                {
                    cn.Open();

                    var cmd = new SqlCommand(sql, cn);
                    if (isUpdate)
                        cmd.Parameters.AddWithValue("@id", SelectedRow.Cells[0].Value);

                    cmd.Parameters.AddWithValue("@name", textBoxName.Text);
                    cmd.Parameters.AddWithValue("@floor", textBoxFloor.Text);
                    cmd.Parameters.AddWithValue("@area", Convert.ToDouble(textBoxArea.Text));
                    cmd.Parameters.AddWithValue("@creatdate", dateTimePicker1.Text);

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
