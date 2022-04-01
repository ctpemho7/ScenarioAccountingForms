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
using System.Xml;

namespace ScenarioAccountingForms
{
    public partial class CRUDScenario : Form
    {
        static string ConnString { get; } = CRUDForm.ConnectionString;
        SqlConnection DataBaseConnection { get; set; } = new SqlConnection(ConnString);

        public CRUDScenario()
        {
            InitializeComponent();
            FillMain();
        }

        void FillMain()
        {
            var sql = "SELECT * FROM Scenario";
            DataSet ds = new DataSet();
            SqlDataAdapter dataAdapter = new SqlDataAdapter(sql, DataBaseConnection);
            //Вторым параметром для текущей таблицы в датасете
            dataAdapter.Fill(ds, "Scenario");
            //Здесь указываешь имя нужной таблицы            
            dataGridViewMain.DataSource = ds.Tables["Scenario"];
            dataGridViewMain.ReadOnly = true;
            dataGridViewMain.Columns[0].Visible = false;
            dataGridViewMain.Columns[5].Visible = false;
            dataGridViewMain.Columns[6].Visible = false;
            dataGridViewMain.ClearSelection();

        }

        private void dataGridViewMain_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewMain.SelectedRows.Count != 0)
            {
                DataGridViewRow row = dataGridViewMain.SelectedRows[0];
                string id = row.Cells[0].Value.ToString();
                if (id != "")
                {
                    var sql = $"SELECT ScenarioID, Помещение, НазваниеУВ, Type AS Датчик, Sign, Value FROM " +
                            $"(SELECT Помещение, НазваниеУВ, Type, SensorMNid FROM " +
                            $"(SELECT Помещение, НазваниеУВ, SensorMN.id AS SensorMNid, SensorMN.TypeID FROM " +
                            $"(SELECT Room.Name AS Помещение, CONCAT(Manufacturer, ' ', SmartThing.Name) AS НазваниеУВ, SmartThing.id " +
                            $"FROM SmartThing  LEFT JOIN Room ON SmartThing.Room = Room.id WHERE SmartThing.TerminationDate IS NULL AND Room.TerminationDate IS NULL) AS ThingRoom " +
                            $"RIGHT JOIN SensorMN ON ThingRoom.id = SensorMN.ThingID) AS ThingRoomSensorMN " +
                            $"LEFT JOIN ClassifierSensor ON ThingRoomSensorMN.TypeID = ClassifierSensor.id) ThingRoomSensorMNType " +
                            $"RIGHT JOIN AtomicCondition ON ThingRoomSensorMNType.SensorMNid = AtomicCondition.SensorID " +
                            $"WHERE TerminationDate IS NULL AND ScenarioID = {id}";

                    DataSet ds = new DataSet();
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(sql, DataBaseConnection);
                    dataAdapter.Fill(ds, "Condition");
                    dataGridViewAtomCond.DataSource = ds.Tables["Condition"];
                    dataGridViewAtomCond.ReadOnly = true;
                    dataGridViewAtomCond.Columns[0].Visible = false;


                    ds = new DataSet();
                    sql = $"SELECT ScenarioID, Помещение, Name AS Тип, НазваниеУВ, Действие FROM " +
                        $"(SELECT ScenarioID, Name AS Помещение, SubType, НазваниеУВ, Действие FROM " +
                        $"(SELECT ScenarioID, Room, SubType, НазваниеУВ, Text AS Действие FROM " +
                        $"(SELECT ScenarioID, Room, SubType, CONCAT(Manufacturer, ' ', SmartThing.Name) AS НазваниеУВ, CommandID " +
                        $"FROM Command LEFT JOIN SmartThing ON ThingID = SmartThing.id " +
                        $"WHERE Command.TerminationDate IS NULL AND SmartThing.TerminationDate IS NULL AND isElse =0) AS CommSmTh " +
                        $"LEFT JOIN ClassifierThingCommand ON CommandID = id) AS CommSmThAct " +
                        $"LEFT JOIN Room ON CommSmThAct.Room = Room.id) AS CommSmThActName LEFT JOIN ClassifierSubTypeThing ON SubType = id " +
                        $"WHERE ScenarioID = {id}";
                    dataAdapter = new SqlDataAdapter(sql, DataBaseConnection);
                    dataAdapter.Fill(ds, "Then");
                    dataGridViewThen.DataSource = ds.Tables["Then"];
                    dataGridViewThen.ReadOnly = true;
                    dataGridViewAtomCond.Columns[0].Visible = false;

                    ds = new DataSet();
                    sql = $"SELECT ScenarioID, Помещение, Name AS Тип, НазваниеУВ, Действие FROM " +
                        $"(SELECT ScenarioID, Name AS Помещение, SubType, НазваниеУВ, Действие FROM " +
                        $"(SELECT ScenarioID, Room, SubType, НазваниеУВ, Text AS Действие FROM " +
                        $"(SELECT ScenarioID, Room, SubType, CONCAT(Manufacturer, ' ', SmartThing.Name) AS НазваниеУВ, CommandID " +
                        $"FROM Command LEFT JOIN SmartThing ON ThingID = SmartThing.id " +
                        $"WHERE Command.TerminationDate IS NULL AND SmartThing.TerminationDate IS NULL AND isElse =1) AS CommSmTh " +
                        $"LEFT JOIN ClassifierThingCommand ON CommandID = id) AS CommSmThAct " +
                        $"LEFT JOIN Room ON CommSmThAct.Room = Room.id) AS CommSmThActName LEFT JOIN ClassifierSubTypeThing ON SubType = id " +
                        $"WHERE ScenarioID = {id}";
                    dataAdapter = new SqlDataAdapter(sql, DataBaseConnection);
                    dataAdapter.Fill(ds, "Else");
                    dataGridViewElse.DataSource = ds.Tables["Else"];
                    dataGridViewElse.ReadOnly = true;
                    dataGridViewElse.Columns[0].Visible = false;

                    string xmltext = GetXML(id);
                    labelCond.Text = FillLabel(xmltext);
                }
            }
        }

        string GetXML(string id)
        {
            string sqlExpression = $"SELECT Condition FROM Scenario WHERE id = {id}";
            object scenario = "";
            using (SqlConnection connection = new SqlConnection(CRUDForm.ConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read()) // построчно считываем данные
                    {
                        scenario = reader.GetValue(0);
                    }
                }
                reader.Close();


            }
            if (scenario != null)
                return scenario.ToString();
            else
                return "";

        }
        string FillLabel(string xml)
        {
            XmlDocument document = new XmlDocument();
            document.LoadXml(xml);
            XmlElement root = document.DocumentElement;
            var list = new List<string>();
            traverse(root, list);


            string conditionString = string.Join("", list);
            return conditionString;
            //Console.WriteLine(conditionString);

        }
        void traverse(XmlNode node, List<string> list)
        {
            if (node is XmlElement)
            {
                bool isFirst = true;
                //list.Add("(");

                foreach (XmlNode child_node in node)
                {
                    if (child_node.Name == "ИЛИ" || child_node.Name == "И")
                    {
                        traverse(child_node, list);
                        if (isFirst)
                        {
                            //list.Add("(");
                            list.Add(' ' + node.Name + ' ');
                            isFirst = false;
                        }
                    }
                    if (child_node.Name == "НЕ")
                    {
                        list.Add(' ' + child_node.Name + ' ');
                        // traverse(child_node, list);

                        if (child_node.FirstChild.Name == "cond")
                            //list.Add(' ' + child_node.FirstChild.Name + ' ');
                            list.Add(' ' + child_node.FirstChild.Attributes["sensorID"].Value + ' ' +
                                child_node.FirstChild.Attributes["sign"].Value + ' ' +
                                child_node.FirstChild.Attributes["value"].Value + ' ');

                        else
                            traverse(child_node, list);

                    }
                    if (child_node.Name == "cond")
                    {
                        list.Add(' ' + child_node.Attributes["sensorID"].Value + ' ' +
                            child_node.Attributes["sign"].Value + ' ' +
                            child_node.Attributes["value"].Value + ' ');
                        if (isFirst)
                        {
                            list.Add(' ' + child_node.ParentNode.Name + ' ');
                            isFirst = false;
                            //list.Add("(");
                        }
                        else
                        {
                            //list.Add(")");
                        }
                    }
                }

            }
        }
    }
}
