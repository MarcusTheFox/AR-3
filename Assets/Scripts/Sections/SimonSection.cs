using System;
using System.Collections;
using System.Collections.Generic;
using Configs.Scripts;
using Microsoft.MixedReality.Toolkit.UI;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Sections
{
    public class SimonSection : SolvableSection
    {
        [SerializeField] private SimonSectionConfig _config;
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
                    var button = _buttons[buttonIndex].GetComponent<SimonButton>();
                
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
            int presetIndex = 0;
            bool bat = Bomb.Instance.ElementsSpawner.BatteriesCount % 2 == 1;
            bool ser = Bomb.Instance.SeriesNumber.HasVowels;
            if (!bat && !ser) presetIndex = 0;
            else if (bat && !ser) presetIndex = 1;
            else if (!bat && ser) presetIndex = 2;
            else if (bat && ser) presetIndex = 3;
            presetIndex = Mathf.Min(presetIndex, _config.ButtonsPreset.Length - 1);
            
            var clicked = _config.ButtonsPreset[presetIndex].Preset[buttonIndex];
            var correct = _buttonOrder[step];
            return clicked == correct;
        }
    }
}