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
    public partial class CRUDForm : Form
    {
        public static string ConnectionString { get; set; } = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Semyon\ScenarioAccounting.mdf;Integrated Security=True;";
       
        string Table { get; set; }
        SqlConnection DataBaseConnection { get; set; }

        public CRUDForm(string table)
        {
            DataBaseConnection = new SqlConnection(ConnectionString);
            InitializeComponent();
            Table = table;
            Read();
            CheckUserRights();
        }

        void CheckUserRights()
        {
            if (Form1.UserType == 2)
            {
                contextMenuStrip1.Enabled = false;
                menuStrip1.Enabled = false;
            }
        }
        void Read()
        {
            var sql = string.Empty;
            switch (Table)
            {
                case "SysUser":
                    sql = "SELECT id, Passport, Surname, Name, Patronymic, Birthdate, SexName, TypeName FROM SysUser LEFT JOIN ClassifierSex ON SysUser.Sex = ClassifierSex.SexID LEFT JOIN ClassifierUserType ON SysUser.UserType = ClassifierUserType.TypeID WHERE TerminationDate IS NULL";
                    Size = new Size(900, 430);
                    break;
                case "Room":
                    sql = "SELECT id, Name, Floor, Area, CreationDate FROM Room WHERE TerminationDate IS NULL";
                    Size = new Size(600, 430);
                    break;
                case "SmartThing":
                    Size = new Size(650, 550);
                    label1.Visible = true;
                    dataGridViewSensor.Visible = true; 
                    sql = "SELECT id, Manufacturer AS Производитель, Name AS Название, Помещение, [Тип прибора] " +
                        "FROM SmartThing " +
                        "LEFT JOIN(SELECT id AS rid, Name AS Помещение FROM Room WHERE TerminationDate IS NULL) AS Room " +
                        "ON SmartThing.Room = Room.rid " +
                        "LEFT JOIN(SELECT id AS Sbid, Name AS [Тип прибора] FROM ClassifierSubTypeThing) AS Sbtype " +
                        "ON SmartThing.SubType = Sbtype.Sbid " +
                        "WHERE SmartThing.TerminationDate IS NULL";
                    break;                    
            }

            DataSet ds = new DataSet();
            SqlDataAdapter dataAdapter = new SqlDataAdapter(sql, DataBaseConnection);

            //Вторым параметром для текущей таблицы в датасете
            dataAdapter.Fill(ds, Table);

            //Здесь указываешь имя нужной таблицы            
            dataGridView1.DataSource = ds.Tables[Table];
            dataGridView1.ReadOnly = true;
            dataGridView1.Columns[0].Visible = false;
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //DataGridViewCellCollection selected_row = dataGridView1.SelectedRows[0].Cells;
            DataGridViewRow row = dataGridView1.SelectedRows[0];
            string id = row.Cells[0].Value.ToString();
            dataGridView1.Rows.RemoveAt(row.Index);
            string today = DateTime.Today.ToString("yyyy/MM/dd");

            DataBaseConnection.Open();
            var sql = $"UPDATE {Table} SET TerminationDate = N'{today}' WHERE id = {id}";
            var cmd = new SqlCommand(sql, DataBaseConnection);
            cmd.ExecuteNonQuery();
            DataBaseConnection.Close();
        }

        private void изменитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            switch (Table)
            {
                case "SysUser":
                    UserAddForm userAddForm = new UserAddForm(dataGridView1.SelectedRows[0]);
                    userAddForm.Show();
                    break;
                case "Room":
                    RoomAddForm roomAddForm = new RoomAddForm(dataGridView1.SelectedRows[0]);
                    roomAddForm.Show();
                    break;
                case "SmartThing":
                    ThingAddForm thAddForm = new ThingAddForm(dataGridView1.SelectedRows[0]);
                    thAddForm.Show();
                    break;

            }
        }   
        private void добавитьНовыйЭлементToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int last_id = GetLastId();
            switch (Table)
            {
                case "SysUser":
                    UserAddForm userAddForm = new UserAddForm((DataTable)dataGridView1.DataSource, last_id);
                    userAddForm.Show();
                    break;
                case "Room":
                    RoomAddForm roomAddForm = new RoomAddForm((DataTable)dataGridView1.DataSource, last_id);
                    roomAddForm.Show();
                    break;
                case "SmartThing":
                    ThingAddForm thingAddForm = new ThingAddForm((DataTable)dataGridView1.DataSource, last_id);
                    thingAddForm.Show();
                    break;
                  
            }

        }


        //метод для отображения всех датчиков устройств
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (Table == "SmartThing")
            {
                if (dataGridView1.SelectedRows.Count != 0)
                {
                    DataGridViewRow row = dataGridView1.SelectedRows[0];
                    string id = row.Cells[0].Value.ToString();
                    if (id != "")
                    {
                        var sql = $"SELECT SensorMN.id, ThingID, Type FROM SensorMN LEFT JOIN ClassifierSensor ON TypeID = ClassifierSensor.id WHERE ThingID = {id}";

                        DataSet ds = new DataSet();
                        SqlDataAdapter dataAdapter = new SqlDataAdapter(sql, DataBaseConnection);
                        //Вторым параметром для текущей таблицы в датасете
                        dataAdapter.Fill(ds, Table);
                        //Здесь указываешь имя нужной таблицы            
                        dataGridViewSensor.DataSource = ds.Tables[Table];
                        dataGridViewSensor.ReadOnly = true;
                        label2.Visible = true;
                        labelRoom.Visible = true;
                        labelRoom.Text = row.Cells[3].Value.ToString();
                    }
                }
            }
        }


        int GetLastId()
        {
            using (var cn = new SqlConnection(ConnectionString))
            {
                cn.Open();
                var sql = $"SELECT TOP 1 * FROM {Table} ORDER BY id DESC";
                var cmd = new SqlCommand(sql, cn);
                //cmd.Parameters.AddWithValue("@table", Table);

                var dr = cmd.ExecuteReader();
                int index = 0;
                while (dr.Read())
                {
                    index = (int)dr["id"];
                }

                //var index = dataGridView1.Rows[dataGridView1.Rows.Count - 2].Cells[0].Value;
                return index;
            }
        }
    }
}
