using TMPro;
using UnityEngine;

namespace Sections
{
    public class KeyboardButton : MonoBehaviour
    {
        [SerializeField] private MeshRenderer _indicator;
        [SerializeField] private TextMeshPro _text;
        private bool _clicked;
    
        public char Symbol
        {
            get => _text.text[0];
            set => _text.text = $"{value}";
        }

        public void Click()
        {
            if (!_clicked)
            {
                _clicked = true;
                _indicator.material.color = Color.green;
            }
        }
    }
}