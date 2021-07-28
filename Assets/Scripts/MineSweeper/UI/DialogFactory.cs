using UnityEngine;

namespace MineSweeper.UI
{
    public class DialogFactory : Factory<GameObject>
    {
        public DialogFactory()
        {
            _original = Resources.Load("Prefabs/Dialog") as GameObject;
        }

        public override GameObject Create()
        {
            return Object.Instantiate(_original);
        }
    }
}