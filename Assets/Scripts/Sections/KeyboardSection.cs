using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Configs.Scripts;
using Microsoft.MixedReality.Toolkit.UI;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Sections
{
    public class KeyboardSection : SolvableSection
    {
        [SerializeField] private KeyboardSectionConfig _config;
        private readonly List<int> _buttonOrder = new();
        private Interactable[] _buttons;
        private int _step;

        private void Start()
        {
            _buttons = GetComponentsInChildren<Interactable>();
            for (var i = 0; i < 4; i++) _buttonOrder.Add(Random.Range(0, 4));

            foreach (var button in _buttons)
                button.OnClick.AddListener(() =>
                {
                    var buttonIndex = Array.IndexOf(_buttons, button);
                    if (!CheckButton(buttonIndex, _step++))
                    {
                        _step = 0;
                        WrongInteract();
                    }

                    if (_step == 4)
                        Interact();
                });

            StartCoroutine(ShowButtons());
        }

        public override void Interact()
        {
            base.Interact();
            foreach (var button in _buttons)
                button.OnClick.RemoveAllListeners();
        }

        private IEnumerator ShowButtons()
        {
            while (!Solved)
            {
                foreach (var buttonIndex in _buttonOrder)
                {
                    var button = _buttons[buttonIndex].GetComponent<KeyboardButton>();
                
                    yield return new WaitForSeconds(0.5f);
                    button.TurnOn();
                    yield return new WaitForSeconds(0.5f);
                    button.TurnOff();
                }

                yield return new WaitForSeconds(2);
            }
        }

        private bool CheckButton(int buttonIndex, int step)
        {
            var presetIndex = Bomb.Instance.SectionController.TimerSection.GetMinutes();
            presetIndex = Mathf.Min(presetIndex, _config.ButtonsPreset.Length - 1);
            var clicked = _config.ButtonsPreset[presetIndex].Preset[buttonIndex];
            var correct = _buttonOrder[step];
            return clicked == correct;
        }
    }
}