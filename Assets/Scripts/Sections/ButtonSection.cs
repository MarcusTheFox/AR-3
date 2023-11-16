using UnityEngine;

namespace Sections
{
    public class ButtonSection : SolvableSection
    {
        [SerializeField] private Renderer _buttonRenderer;
        [SerializeField] private Color _color1;
        [SerializeField] private Color _color2;

        private TimerSection _timer;
        // [SerializeField] private string _text1;
        // [SerializeField] private string _text2;

        private bool _variant;

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
                if (Bomb.Instance.ElementsSpawner.BatteriesCount % 2 == 0)
                {
                    Interact();
                }
                else
                {
                    if (_timer.GetTime().IndexOf('1') > -1)
                        Interact();
                    else
                        WrongInteract();
                }
            }
            else
            {
                var number = Bomb.Instance.ElementsSpawner.BatteriesCount % 2 == 0 ? '3' : '5';

                if (_timer.GetTime().IndexOf(number) > -1)
                    Interact();
                else
                    WrongInteract();
            }
        }
    }
}