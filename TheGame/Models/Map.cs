using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheGame.Models
{
    public class Map
    {
        private const int n = 3;
        private Cell[,] _cells = new Cell[n * n, n * n];
        private Cell[,] _correctCells = new Cell[n * n, n * n];

        public Cell[,] Cells => _cells;
        public Map()
        {
            GenerateMap();
        }
        private void GenerateMap()
        {
            for (int i = 0; i < n * n; i++)
            {
                for (int j = 0; j < n * n; j++)
                {
                    int number = (i * n + i / n + j) % (n * n) + 1;
                    _cells[i, j] = new Cell(number);
                }
            }
            Random r = new Random();
            for (int i = 0; i < 40; i++)
            {
                ShuffleMap(r.Next(0, 5));
            }

            HideCells();
        }
        private void ShuffleMap(int i)
        {

            switch (i)
            {
                case 0:
                    MatrixTransposition();
                    break;
                case 1:
                    SwapRowsInBlock();
                    break;
                case 2:
                    SwapColumnsInBlock();
                    break;
                case 3:
                    SwapBlocksInRow();
                    break;
                case 4:
                    SwapBlocksInColumn();
                    break;
                default:
                    MatrixTransposition();
                    break;
            }
        }

        private void SwapBlocksInColumn()
        {
            Random r = new Random();
            var block1 = r.Next(0, n);
            var block2 = r.Next(0, n);
            while (block1 == block2)
                block2 = r.Next(0, n);
            block1 *= n;
            block2 *= n;
            for (int i = 0; i < n * n; i++)
            {
                var k = block2;
                for (int j = block1; j < block1 + n; j++)
                {
                    var temp = _cells[i, j];
                    _cells[i, j] = _cells[i, k];
                    _cells[i, k] = temp;
                    k++;
                }
            }
        }

        private void SwapBlocksInRow()
        {
            Random r = new Random();
            var block1 = r.Next(0, n);
            var block2 = r.Next(0, n);
            while (block1 == block2)
                block2 = r.Next(0, n);
            block1 *= n;
            block2 *= n;
            for (int i = 0; i < n * n; i++)
            {
                var k = block2;
                for (int j = block1; j < block1 + n; j++)
                {
                    var temp = _cells[j, i];
                    _cells[j, i] = _cells[k, i];
                    _cells[k, i] = temp;
                    k++;
                }
            }
        }

        private void SwapRowsInBlock()
        {
            Random r = new Random();
            var block = r.Next(0, n);
            var row1 = r.Next(0, n);
            var line1 = block * n + row1;
            var row2 = r.Next(0, n);
            while (row1 == row2)
                row2 = r.Next(0, n);
            var line2 = block * n + row2;
            for (int i = 0; i < n * n; i++)
            {
                var temp = _cells[line1, i];
                _cells[line1, i] = _cells[line2, i];
                _cells[line2, i] = temp;
            }
        }

        private void SwapColumnsInBlock()
        {
            Random r = new Random();
            var block = r.Next(0, n);
            var row1 = r.Next(0, n);
            var line1 = block * n + row1;
            var row2 = r.Next(0, n);
            while (row1 == row2)
                row2 = r.Next(0, n);
            var line2 = block * n + row2;
            for (int i = 0; i < n * n; i++)
            {
                var temp = _cells[i, line1];
                _cells[i, line1] = _cells[i, line2];
                _cells[i, line2] = temp;
            }
        }

        private void MatrixTransposition()
        {
            Cell[,] tMap = new Cell[n * n, n * n];
            for (int i = 0; i < n * n; i++)
            {
                for (int j = 0; j < n * n; j++)
                {
                    tMap[i, j] = _cells[j, i];
                }
            }
            _cells = tMap;
        }

        private void HideCells()
        {
            int N = 40;
            Random r = new Random();
            while (N > 0)
            {
                for (int i = 0; i < n * n; i++)
                {
                    for (int j = 0; j < n * n; j++)
                    {
                        _correctCells[i, j] = new Cell(_cells[i, j].Number);
                        if (_cells[i,j].IsSecret == false && N>0)
                        {
                            int a = r.Next(0, 3);

                            if (a == 0) { 
                                _cells[i, j].SetSecret();
                                N--;
                            }
                        }
                    }
                }
            }
        }
        public bool IsSolved()
        {
            for (int i = 0; i < _cells.GetLength(0); i++)
            {
                for (int j = 0; j < _cells.GetLength(1); j++)
                {
                    if (_cells[i, j].Number != _correctCells[i, j].Number)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
