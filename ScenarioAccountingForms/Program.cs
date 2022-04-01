using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScenarioAccountingForms
{
    static class Program
    {
        public static int UserID = 0;

        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
 
            using (LoginForm login = new LoginForm())
            {
                login.ShowDialog();
                if (UserID != 0)
                {
                    Application.Run(new Form1(UserID));
                }

            }
        }
    }
}