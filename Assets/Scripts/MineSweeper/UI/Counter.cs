using UnityEngine;
using UnityEngine.UI;

namespace MineSweeper.UI
{    
    public class Counter : MonoBehaviour 
    {
        [SerializeField]
        private Image _image;
        [SerializeField]
        private Text _value;

        public int Value
        { 
            get{ return int.Parse(_value.text); } 
            set{ _value.text = (0 < value ? value : 0).ToString(); } 
        }
    }
}