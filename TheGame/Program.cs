using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheGame
{
    static class Program
    {
        
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            
           
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Model.Model _model = new Model.Model();
            Controller.Controller controller = new Controller.Controller(_model);
            Form1 form1 = new Form1(controller);
            Application.Run(form1);
        }
    }
}
