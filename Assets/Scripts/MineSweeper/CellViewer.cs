using UnityEngine;
using UnityEngine.UI;

namespace MineSweeper
{
    public class CellViewer : MonoBehaviour
    {
        [SerializeField]
        private Image _image;
        [SerializeField]
        private Image _contents;
        [SerializeField]
        private Sprite _none;
        [SerializeField]
        private Sprite _mine;
        [SerializeField]
        private Sprite _flag;
        [SerializeField]
        private Sprite[] _number;
        [SerializeField]
        private Color _open;
        [SerializeField]
        private Color _close;

        private void Awake()
        {
            _image.color = _close;
        }

        public void Open(bool hasMine, int mines)
        {
            _image.color = _open;
            _contents.sprite = (hasMine) ? _mine : _number[mines];
        }

        public void ToggleFlag()
        {
            _contents.sprite = (_contents.sprite == _flag) ? _none : _flag;
        }

        public void Restore()
        {
            _image.color = _close;
            _contents.sprite = _none;
        }
    }
}