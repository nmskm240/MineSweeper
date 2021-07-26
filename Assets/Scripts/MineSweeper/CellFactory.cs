using UnityEngine;

namespace MineSweeper
{
    public class CellFactory : Factory<GameObject>
    {
        public CellFactory()
        {
            _original = Resources.Load("Prefabs/Cell") as GameObject;
        }

        public override GameObject Create()
        {
            return Object.Instantiate(_original);
        }
    }
}