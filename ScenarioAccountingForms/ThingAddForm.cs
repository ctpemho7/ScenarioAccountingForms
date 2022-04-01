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
    public partial class ThingAddForm : Form
    {
        bool isUpdate { set; get; }
        public DataGridViewRow SelectedRow { get; set; }
        DataTable Table { get; set; }
        int Last_id { get; set; }
        public ThingAddForm(DataTable temp, int last_id) //добавление
        {
            isUpdate = false;
            Last_id = last_id;
            Table = temp;
            InitializeComponent();
            FillCmb();
        }

        public ThingAddForm(DataGridViewRow temp) //изменение
        {
            isUpdate = true;
            SelectedRow = temp;

            //id, Manufacturer AS Производитель, Name AS Название, Помещение, [Тип прибора]

            InitializeComponent();
            FillCmb();
            Text = "Изменение записи";
            textBoxManuf.Text = SelectedRow.Cells[1].Value.ToString();
            textBoxName.Text = SelectedRow.Cells[2].Value.ToString();
            comboBoxRoom.Text = SelectedRow.Cells[3].Value.ToString();
            comboBoxThing.Text = SelectedRow.Cells[4].Value.ToString();

            string id = SelectedRow.Cells[0].Value.ToString();

            var sql = $"SELECT ClassifierSensor.id AS id, Type AS Name FROM SensorMN LEFT JOIN ClassifierSensor ON TypeID = ClassifierSensor.id WHERE ThingID = {id}";

            DataSet ds = new DataSet();
            SqlConnection DataBaseConnection = new SqlConnection(CRUDForm.ConnectionString);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(sql, DataBaseConnection);
            
            dataAdapter.Fill(ds, "Sensors");
          
              dataGridViewList.Columns[0].Visible = false;
              dataGridViewList.Columns[1].Visible = false;

            dataGridViewList.DataSource = ds.Tables["Sensors"];
            dataGridViewList.ReadOnly = true;
        }

        void FillCmb()
        {
            using (SqlConnection conn = new SqlConnection(CRUDForm.ConnectionString))
            {
                try
                {
                    //заполнение комбобокса Room
                    string query = "SELECT id, Name FROM Room";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    conn.Open();
                    DataSet ds = new DataSet();
                    da.Fill(ds, "Room");
                    comboBoxRoom.DisplayMember = "Name";
                    comboBoxRoom.ValueMember = "id";
                    comboBoxRoom.DataSource = ds.Tables["Room"];


                    //заполнение комбобокса Sensor
                    query = "SELECT id, Type FROM ClassifierSensor";
                    da = new SqlDataAdapter(query, conn);
                    ds = new DataSet();
                    da.Fill(ds, "ClassifierSensor");
                    comboBoxSensors.DisplayMember = "Type";
                    comboBoxSensors.ValueMember = "id";
                    comboBoxSensors.DataSource = ds.Tables["ClassifierSensor"];


                    //заполнение комбобокса comboBoxThing
                    query = "SELECT id, Name FROM ClassifierSubTypeThing";
                    da = new SqlDataAdapter(query, conn);
                    ds = new DataSet();
                    da.Fill(ds, "ClassifierSubTypeThing");
                    comboBoxThing.DisplayMember = "Name";
                    comboBoxThing.ValueMember = "id";
                    comboBoxThing.DataSource = ds.Tables["ClassifierSubTypeThing"];
                }
                catch (Exception ex)
                {
                    // write exception info to log or anything else
                    MessageBox.Show("Error occured!");
                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (comboBoxSensors.Text.Length > 0)
            {
                if (isUpdate)
                {

                    DataRow newRow = ((DataTable)dataGridViewList.DataSource).NewRow();
                    //id, Passport, Surname, Name, Patronymic, Birthdate, SexName, TypeName
                    newRow["id"] = comboBoxSensors.SelectedValue;
                    newRow["Name"] = comboBoxSensors.Text;
                    ((DataTable)dataGridViewList.DataSource).Rows.Add(newRow);
                }
                else
                    dataGridViewList.Rows.Add(comboBoxSensors.SelectedValue, comboBoxSensors.Text);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (textBoxManuf.Text.Length > 0 &&
                textBoxName.Text.Length > 0 &&
                comboBoxRoom.Text.Length > 0 &&
                comboBoxThing.Text.Length > 0)
            {
                var sql = string.Empty;
                if (isUpdate)
                {
                    SelectedRow.Cells[1].Value = textBoxManuf.Text;
                    SelectedRow.Cells[2].Value = textBoxName.Text;
                    SelectedRow.Cells[3].Value = comboBoxRoom.Text;
                    SelectedRow.Cells[4].Value = comboBoxThing.Text;

                    //@name, @floor, @area, @creatdate
                    sql = @"UPDATE SmartThing
                            SET [Manufacturer] = @manf
                            ,[Name] = @name
                            ,[Room] = @room
                            ,[SubType] = @subtype 
                            WHERE id = @id;
                        DELETE FROM SensorMN
                        WHERE ThingID = @id";

                }
                else // not update
                {
                    DataRow newRow = Table.NewRow();
                    //id, Manufacturer, Name, Room, SubType
                    newRow["Производитель"] = textBoxManuf.Text;
                    newRow["Название"] = textBoxName.Text;
                    newRow["Помещение"] = comboBoxRoom.Text;
                    newRow["Тип прибора"] = comboBoxThing.Text;

                    newRow["id"] = Last_id + 1;
                    Table.Rows.Add(newRow);

                    sql = @"INSERT INTO SmartThing
                                (Manufacturer, Name, Room, SubType)
                                VALUES
                                (@manf, @name, @room, @subtype)";
                }


                using (var cn = new SqlConnection(CRUDForm.ConnectionString))
                {
                    cn.Open();

                    var cmd = new SqlCommand(sql, cn);
                    if (isUpdate)
                        cmd.Parameters.AddWithValue("@id", SelectedRow.Cells[0].Value);

                    cmd.Parameters.AddWithValue("@manf", textBoxManuf.Text);
                    cmd.Parameters.AddWithValue("@name", textBoxName.Text);
                    cmd.Parameters.AddWithValue("@room", comboBoxRoom.SelectedValue);
                    cmd.Parameters.AddWithValue("@subtype", comboBoxThing.SelectedValue);

                    cmd.ExecuteNonQuery();

                    foreach (DataGridViewRow row in dataGridViewList.Rows)
                    {
                        object id;
                        try
                        {
                            id = row.Cells["id"].Value;
                        }
                        catch
                        {
                            continue;
                        }
                        if (id != null)
                        {
                            sql = @"INSERT INTO SensorMN
                                (ThingID, TypeID)
                                VALUES
                                (@thingid, @typeid)";

                            cmd = new SqlCommand(sql, cn);
                            if (isUpdate)
                                cmd.Parameters.AddWithValue("@thingid", SelectedRow.Cells[0].Value);
                            else
                                cmd.Parameters.AddWithValue("@thingid", Last_id + 1);
                            cmd.Parameters.AddWithValue("@typeid", (int)id);
                            cmd.ExecuteNonQuery();

                        }
                    }

                    cn.Close();
                }

                Close();
            }
            else
                MessageBox.Show("Некорретный ввод!", "Что-то не так!", MessageBoxButtons.OK, MessageBoxIcon.Error);


        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridViewList.SelectedRows.Count != 0)
            {
                DataGridViewRow row = dataGridViewList.SelectedRows[0];
                dataGridViewList.Rows.RemoveAt(row.Index);
            }
        }
    }
}

