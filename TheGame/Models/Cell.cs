using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheGame.Models
{
    public class Cell
    {
        public bool IsSecret { get; private set; } = false;
        public int Number { get; private set; }
        public event Action<int> NumberChanged;
        public Cell(int number) {
            Number = number;
        }

        public void Increment()
        {
            
            Number++;
            if (Number > 9)
            {
                Number = 1; 
            }
            NumberChanged?.Invoke(Number);
        }
        public void SetSecret()
        {
            Number = 0;
            IsSecret = true;
            NumberChanged?.Invoke(Number);
        }
    }
}
