using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.MixedReality.Toolkit.UI;
using UnityEngine;
using Random = UnityEngine.Random;

public class KeyboardSection : SolvableSection
{
    [SerializeField] private int[] _winPreset = { 1, 0, 3, 2 };
    private readonly List<int> _buttonOrder = new();
    private Interactable[] _buttons;
    private int _step;

    private void Start()
    {
        _buttons = GetComponentsInChildren<Interactable>();
        for (var i = 0; i < 4; i++) _buttonOrder.Add(Random.Range(0, 4));

        Debug.Log(string.Join(", ", _buttonOrder));
        foreach (var button in _buttons)
            button.OnClick.AddListener(() =>
            {
                var buttonIndex = Array.IndexOf(_buttons, button);
                if (!CheckButton(buttonIndex, _step++))
                {
                    _step = 0;
                    WrongInteract();
                }

                if (_step == 4) Interact();
            });

        StartCoroutine(ShowButtons());
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
        return _winPreset[buttonIndex] == _buttonOrder[step];
    }
}