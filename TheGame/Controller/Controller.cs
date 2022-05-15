using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheGame.Controller
{
    public class Controller
    {
        private Model.Model __model;

        public Controller(Model.Model model)
        {
            __model = model;
        }
        public void GenerateMap()
        {
            __model.GenerateMap();
        }
        public void onCellPressed(object sender, EventArgs e)
        {
            __model.OnCellPressed(sender, e);
        }
        public void checkRight()
        {
            __model.checkRight();
        }
    }
}
