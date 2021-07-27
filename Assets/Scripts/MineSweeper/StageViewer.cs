using UnityEngine;
using UnityEngine.UI;

namespace MineSweeper
{
    public class StageViewer : MonoBehaviour
    {
        [SerializeField]
        private GridLayoutGroup _gridLayout;

        public void Resize(int width, int height)
        {
            _gridLayout.constraintCount = width;
        }
    }
}