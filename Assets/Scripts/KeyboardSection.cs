using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.MixedReality.Toolkit.UI;
using UnityEngine;
using Random = UnityEngine.Random;

public class KeyboardSection : BaseSection
{
    [SerializeField] private int[] _winPreset = { 1, 0, 3, 2 };
    private readonly List<int> _buttonOrder = new();
    private Interactable[] _buttons;
    private bool _solved;
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
                Debug.LogWarning(CheckButton(buttonIndex, _step++));

                Debug.LogWarning(string.Join(", ", _buttonOrder) + " " + _winPreset[buttonIndex]);
                if (_step == 4)
                {
                    _solved = true;
                    GetComponent<MeshRenderer>().material.color = Color.green;
                }
            });

        StartCoroutine(ShowButtons());
    }

    private IEnumerator ShowButtons()
    {
        while (!_solved)
        {
            foreach (var buttonIndex in _buttonOrder)
            {
                var buttonTransform = _buttons[buttonIndex].transform;
                var lastChildIndex = buttonTransform.childCount - 1;
                var material = buttonTransform.GetChild(lastChildIndex).GetComponent<Renderer>().material;

                var tempColor = material.color;
                material.color = Color.white;

                yield return new WaitForSeconds(0.5f);
                material.color = tempColor;

                yield return new WaitForSeconds(0.5f);
            }

            yield return new WaitForSeconds(2);
        }
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