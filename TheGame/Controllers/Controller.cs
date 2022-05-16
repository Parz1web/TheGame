﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheGame.Models;
using static System.Windows.Forms.Control;

namespace TheGame.Controllers
{
    public class Controller
    {
        private Model _model;

        // модель передавать через конструктор
        public void GenerateMap(ControlCollection controlCollection)
        {
            _model = new Model(controlCollection);
           
        }
        public void onCellPressed(object sender, EventArgs e)
        {
            _model.OnCellPressed(sender, e);
        }
        public void checkRight()
        {
            _model.checkRight();
        }

        public void StartGame() { 
          _model.GenerateMap();
        }
    }
}
