using UnityEngine;
using MineSweeper.UI;

namespace MineSweeper
{
    public class StageController : MonoBehaviour
    {
        [SerializeField]
        private Stage _model;
        [SerializeField]
        private StageViewer _viewer;
        [SerializeField]
        private Counter _counter;

        public Stage Model { get { return _model; } }
        public StageViewer Viewer { get { return _viewer; } }

        public void Start()
        {
            Model.Create(8, 10, 20);
            Viewer.Resize(Model.Width, Model.Height);
            _counter.Value = Model.Mines;
        }
    }
}