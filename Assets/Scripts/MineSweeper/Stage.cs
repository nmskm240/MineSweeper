using System.Linq;
using System.Collections.Generic;
using UnityEngine;

namespace MineSweeper
{
    public class Stage : MonoBehaviour
    {
        private List<CellController> _cells = new List<CellController>();

        public IEnumerable<CellController> Cells { get { return _cells; } }
        public int Width { get; private set; }
        public int Height { get; private set; }
        public int Mines { get; private set; }
        public bool IsSuccess
        {
            get
            {
                return _cells.Select(cell => !cell.Model.HasMine
                    && cell.Model.IsOpen).Count() == _cells.Count - Mines;
            }
        }

        private void FillCell()
        {
            var factory = new CellFactory();
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    var obj = factory.Create();
                    var cellController = obj.GetComponent<CellController>();
                    cellController.Init(new Vector2(j, i));
                    _cells.Add(cellController);
                    obj.transform.SetParent(transform);
                    obj.transform.localScale = Vector3.one;
                }
            }
        }

        private void CellInit()
        {
            foreach (var cellController in _cells)
            {
                var pos = cellController.Pos;
                for (int i = -1; i < 2; i++)
                {
                    for (int j = -1; j < 2; j++)
                    {
                        var x = (int)pos.x + j;
                        var y = (int)pos.y + i;
                        if ((i == 0 && j == 0) || !(0 <= x && x < Width) || !(0 <= y && y < Height))
                        {
                            continue;
                        }
                        cellController.Model.AddAroundCell(_cells[y * Width + x].Model);
                    }
                }
            }
        }

        private void PutMines()
        {
            var count = 0;
            do
            {
                var index = Random.Range(0, _cells.Count);
                if (!_cells[index].Model.HasMine)
                {
                    _cells[index].Model.PutMine();
                    count++;
                }
            } while (count < Mines);
        }

        public void Create(int width, int height, int mines)
        {
            Width = width;
            Height = height;
            Mines = mines;
            FillCell();
            CellInit();
            PutMines();
        }

        public void ReCreate()
        {
            foreach(var cell in _cells)
            {
                cell.Restore();
            }
            PutMines();
        }
    }
}