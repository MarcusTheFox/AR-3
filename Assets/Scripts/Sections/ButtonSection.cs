using Configs.Scripts;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Sections
{
    public class ButtonSection : SolvableSection
    {
        [SerializeField] private Renderer _buttonRenderer;
        [SerializeField] private Color _color1;
        [SerializeField] private Color _color2;
        [SerializeField] private string _text1;
        [SerializeField] private string _text2;
    
        private bool _variant;
        private TimerSection _timer;

        private void Awake()
        {
            _variant = Random.Range(0, 2) == 0;
            _buttonRenderer.material.color = _variant ? _color1 : _color2;
        }

        private void Start()
        {
            _timer = Bomb.Instance.SectionController.TimerSection;
        }

        public void OnButtonUp()
        {
            if (_variant)
            {
                Interact();
            }
            else
            {
                if (_timer.GetTime().IndexOf('3') > -1)
                    Interact();
                else
                    WrongInteract();
            }
        }
    }
}