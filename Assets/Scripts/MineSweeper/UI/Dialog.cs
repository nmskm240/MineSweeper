using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace MineSweeper.UI
{    
    public class Dialog : MonoBehaviour 
    {
        [SerializeField]
        private TextMeshProUGUI _body;
        [SerializeField]
        private Button _agree;
        [SerializeField]
        private Button _disAgree;

        private void Awake() 
        {
            gameObject.SetActive(false);
        }

        public void Show(string text, Action onAgree, Action onDisAgree = null)
        {
            _body.text = text;
            _agree.onClick.AddListener(() => 
            {
                onAgree?.Invoke();
                Destroy(gameObject);
            });
            _disAgree.onClick.AddListener(() => 
            {
                onDisAgree?.Invoke();
                Destroy(gameObject);
            });
            gameObject.SetActive(true);
        }
    }
}