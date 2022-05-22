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
using TheGame.Models;

namespace TheGame
{
    public partial class Form1 : Form
    {
        const int n = 3;
        const int sizeButton = 50;
        public Button[,] buttons = new Button[n * n, n * n];

        private Controller _controller;
        public Form1(Controller controller)
        {
            InitializeComponent();
            _controller = controller;
            RenderMap(_controller.Map);
        }

        private void RenderMap(Map map)
        {
            Controls.Clear();
            Button button1 = new Button();
            button1.Text = "Проверить";
            button1.Location = new Point(550, 0);
            button1.Click += button1_Click;
            Controls.Add(button1);
            for(int i = 0; i < map.Cells.GetLength(0); i++)
            {
                for(int j = 0; j < map.Cells.GetLength(1); j++)
                {
                    var cell = map.Cells[i,j];
                    Button button = new Button();
                    button.Size = new Size(sizeButton, sizeButton);
                    if(cell.IsSecret)
                    {
                        button.Text = "";
                        cell.NumberChanged += (number) => button.Text = number.ToString();
                    }
                    else
                    {
                        button.Text = cell.Number.ToString();
                        button.Enabled = false;
                    }
                    button.Click += (object sender, EventArgs e) => _controller.OnCellPressed(cell);
                    button.Location = new Point(j * sizeButton, i * sizeButton);
                    Controls.Add(button);
                }
            }
        }
        

        //Кнопка старта
        private void button1_Click(object sender, EventArgs e)
        {
            _controller.checkRight(RenderMap);
        }
    }
}
