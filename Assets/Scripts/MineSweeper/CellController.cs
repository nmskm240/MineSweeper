using UnityEngine;
using UnityEngine.Events;

namespace MineSweeper
{
    public class CellController : MonoBehaviour
    {
        [SerializeField]
        private Cell _model;
        [SerializeField]
        private CellViewer _viewer;
        [SerializeField]
        private UnityEvent _onOpen = new UnityEvent();
        [SerializeField]
        private UnityEvent _onStepMine = new UnityEvent();

        public UnityEvent OnOpen { get { return _onOpen; } }
        public UnityEvent OnStepMine { get { return _onStepMine; } }
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
                Model.Open();
                Viewer.Open(Model.HasMine, Model.Mines);
                _onOpen?.Invoke();
                if (Model.HasMine)
                {
                    _onStepMine?.Invoke();
                }
            }
        }

        public void OnLongPressed()
        {
            if (Model.CanOpen || Model.OnFlag)
            {
                Viewer.ToggleFlag();
                Model.OnFlag = !Model.OnFlag;
            }
        }
    }
}