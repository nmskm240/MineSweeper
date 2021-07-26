using System.Linq;
using System.Collections.Generic;
using UnityEngine;

namespace MineSweeper
{
    public class Cell : MonoBehaviour
    {
        private List<Cell> _aroundCells = new List<Cell>();

        public bool OnFlag { get; private set; } = false;
        public bool IsOpen { get; private set; } = false;
        public bool CanOpen { get { return !OnFlag && !IsOpen; } }
        public bool HasMine { get; private set; } = false;
        public int Mines { get { return _aroundCells.Where(cell => cell.HasMine).Count(); } }

        public void AddAroundCell(Cell cell)
        {
            _aroundCells.Add(cell);
        }

        public void PutMine()
        {
            HasMine = true;
        }

        public void Open()
        {
            IsOpen = true;
        }
    }
}