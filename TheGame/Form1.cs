using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TheGame.Controllers;

namespace TheGame
{
    public partial class Form1 : Form
    {

        private Controller __controller;
        public Form1(Controller controller)
        {
            InitializeComponent();
            __controller = controller;
            __controller.GenerateMap(Controls);
        }

        public void ShowData(int[,] data) { 
            //заполняем данными форму
        }
        

        //Кнопка старта
        private void button1_Click(object sender, EventArgs e)
        {
            __controller.startGame();
        }
    }
}
