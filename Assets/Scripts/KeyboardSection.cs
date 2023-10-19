using System;
using System.Collections.Generic;
using Microsoft.MixedReality.Toolkit.UI;
using UnityEngine;
using Random = UnityEngine.Random;

public class KeyboardSection : BaseSection
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
                Debug.Log(CheckButton(buttonIndex, _step++));

                Debug.Log(string.Join(", ", _buttonOrder) + " " + _winPreset[buttonIndex]);
                if (_step == 4) _step = 0;
            });
    }

    public override void Interact()
    {
        if (Bomb.Instance != null) Bomb.Instance.Phase = Phase.Stop;
    }

    private bool CheckButton(int buttonIndex, int step)
    {
        return _winPreset[buttonIndex] == _buttonOrder[step];
    }
}