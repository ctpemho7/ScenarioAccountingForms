using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Microsoft.Office.Interop.Excel;
using System.Xml;

namespace ScenarioAccountingForms
{
    public partial class Form1 : Form
    {
        static public int UserType { get; set; }
        void GetUserInfo(int userID)
        {
            using (var cn = new SqlConnection(CRUDForm.ConnectionString))
            {
                cn.Open();
                var sql = $"SELECT CONCAT(' ' , Surname, ' ' ,Name, ' ' , Patronymic) AS ФИО, UserType FROM SysUser WHERE id = {userID}";
                var cmd = new SqlCommand(sql, cn);

                var dr = cmd.ExecuteReader();
                string name = string.Empty;
                int usertype = 0;

                while (dr.Read())
                {
                    name = (string)dr["ФИО"];
                    usertype = (int)dr["UserType"];
                }

                UserType = usertype;
                labelHello.Text = "Здравствуйте," + name + "!";
                if (usertype == 1)
                {
                    labelRole.Text = "Ваша роль в системе: Инженер";
                    labelAbility.Text = "Вы можете формировать отчёты и изменять информацию в БД";

                }
                else
                {
                    labelRole.Text = "Ваша роль в системе: Аналитик";
                    labelAbility.Text = "Вы можете формировать отчёты и просматривать информацию";
                }
                cn.Close();
            }
        }

        public Form1(int userID)
        {
            InitializeComponent();
            GetUserInfo(userID);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CRUDForm form = new CRUDForm((string)((System.Windows.Forms.Button)sender).Tag);
            form.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            CRUDScenario scenarioform = new CRUDScenario();
            scenarioform.Show();
        }


        private void button6_Click(object sender, EventArgs e)
        {
            XmlDocument document = new XmlDocument();
            document.Load("scenario.xml");
            XmlElement root = document.DocumentElement;
            var list = new List<string>();
            traverse(root, list);


            string conditionString = string.Join("", list);
            Console.WriteLine(conditionString);

        }



        void traverse(XmlNode node, List<string> list)
        {
            if (node is XmlElement)
            {
                bool isFirst = true;
                //list.Add("(");

                foreach (XmlNode child_node in node)
                {
                    if (child_node.Name == "br")
                    {
                        list.Add(" ( ");
                        traverse(child_node.FirstChild, list);
                        list.Add(" ) ");
                    }
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

        private void buttonGetUser_Click(object sender, EventArgs e)
        {
            //GetiT();
            string cmd = @"SELECT Surname, UserName, Patronymic,TypeName, Count(Scenario.id) AS ScenarioCount FROM 
                                            (SELECT id, Surname, Name AS UserName, Patronymic, 
                                            ClassifierUserType.TypeName AS TypeName FROM SysUser
                                            RIGHT JOIN ClassifierUserType ON UserType = ClassifierUserType.TypeID
                                            WHERE TerminationDate IS NULL) As UserInfo
                                            LEFT JOIN Scenario ON Scenario.Author = UserInfo.id
                                            GROUP BY Surname, UserName, Patronymic,TypeName
                                            ORDER BY ScenarioCount DESC";
            FillDataGridView(cmd);
            buttonExcel.Enabled = true;

        }


        void FillDataGridView(string sql)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter dataAdapter = new SqlDataAdapter(sql, CRUDForm.ConnectionString);
            dataAdapter.Fill(ds, "Table");
            dataGridView1.DataSource = ds.Tables["Table"];
        }

        private void buttonRooms_Click(object sender, EventArgs e)
        {
            string sql = @"SELECT RoomInfo.Name AS Помещение, Floor AS Этаж, Area AS Площадь, 
                    COUNT(Area) AS [Количество приборов], COUNT(Area)/Area AS [Приборов на м2]  FROM
                    (SELECT Name, Floor, Area,id FROM Room WHERE TerminationDate IS NULL) AS RoomInfo
                    INNER JOIN SmartThing ON RoomInfo.id = SmartThing.Room
                    GROUP BY RoomInfo.Name, Floor, Area";
            FillDataGridView(sql);
            buttonExcel.Enabled = true;
        }

        void GetEXCEL()
        {

            Microsoft.Office.Interop.Excel.Application app =
        new Microsoft.Office.Interop.Excel.Application();

            app.Visible = true;

            Workbook wb = app.Workbooks.Add();
            Worksheet ws = wb.Worksheets[1];

            SqlConnection conn = new SqlConnection(CRUDForm.ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(@"SELECT Surname, UserName, Patronymic,TypeName, Count(Scenario.id) AS ScenarioCount FROM 
                                            (SELECT id, Surname, Name AS UserName, Patronymic, ClassifierUserType.TypeName AS TypeName FROM SysUser
                                            RIGHT JOIN ClassifierUserType ON UserType = ClassifierUserType.TypeID
                                            WHERE TerminationDate IS NULL) As UserInfo
                                            LEFT JOIN Scenario ON Scenario.Author = UserInfo.id
                                            GROUP BY Surname, UserName, Patronymic,TypeName
                                            ORDER BY ScenarioCount DESC", conn);

            SqlDataReader reader = cmd.ExecuteReader();

            ws.Cells[1, 1].Value = reader.GetName(0);
            ws.Cells[1, 2].Value = reader.GetName(1);
            ws.Cells[1, 3].Value = reader.GetName(2);
            ws.Cells[1, 4].Value = reader.GetName(3);
            ws.Cells[1, 5].Value = reader.GetName(4);


            int i = 2;
            while (reader.Read())
            {
                ws.Cells[i, 1].Value = reader[0];
                ws.Cells[i, 2].Value = reader[1];
                ws.Cells[i, 3].Value = reader[2];
                ws.Cells[i, 4].Value = reader[3];
                ws.Cells[i, 5].Value = reader[4];

                i++;
            }

            reader.Close();
            conn.Close();

        }

        void MakeExcel()
        {
            //Приложение
            Microsoft.Office.Interop.Excel.Application ExcelApp = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook ExcelWorkBook;
            Microsoft.Office.Interop.Excel.Worksheet ExcelWorkSheet;
            //Книга.
            ExcelWorkBook = ExcelApp.Workbooks.Add(System.Reflection.Missing.Value);
            //Таблица.
            ExcelWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)ExcelWorkBook.Worksheets.get_Item(1);

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                for (int j = 0; j < dataGridView1.ColumnCount; j++)
                {
                    ExcelApp.Cells[i + 1, j + 1] = dataGridView1.Rows[i].Cells[j].Value;
                }
            }
            //Вызываем нашу созданную эксельку.
            ExcelApp.Visible = true;
            ExcelApp.UserControl = true;

        }

        private void buttonExcel_Click(object sender, EventArgs e)
        {
            MakeExcel();
        }

        private void buttonThings_Click(object sender, EventArgs e)
        {

        }
    }
}
