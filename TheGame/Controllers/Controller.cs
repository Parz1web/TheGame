using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TheGame.Models;
using static System.Windows.Forms.Control;

namespace TheGame.Controllers
{
    public class Controller
    {
        public Map Map;
        private Cell[,] _correctCells;
        public Controller()
        {
            Map = new Map();
            _correctCells = Map.Cells.Clone() as Cell[,];
        }

        

        public void checkRight(Action<Map> renderHandler)
        {
            if (Map.IsSolved())
            {
                MessageBox.Show("Верно!");
                Map = new Map();
                renderHandler(Map);
                _correctCells = Map.Cells.Clone() as Cell[,];
            }
            else
            {
               
                MessageBox.Show("Неправильно!");
            }
                
        }
        public void OnCellPressed(Cell cell)
        {
            cell.Increment();
        }
    }
}
