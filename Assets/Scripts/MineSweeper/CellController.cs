using UnityEngine;

namespace MineSweeper
{
    public class CellController : MonoBehaviour
    {
        [SerializeField]
        private Cell _model;
        [SerializeField]
        private CellViewer _viewer;
        [SerializeField]
        private Animator _animator;

        public Cell Model { get { return _model; } }
        public CellViewer Viewer { get { return _viewer; } }
        public Vector2 Pos { get; private set; } = Vector2.zero;

        public void Init(Vector2 pos)
        {
            Pos = pos;
        }

        public void Open()
        {
            if (Model.CanOpen)
            {
                _animator.Play("Open");
                Model.Open();
                Viewer.Open(Model.HasMine, Model.Mines);
            }
        }
    }
}