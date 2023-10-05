using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimerSection : BaseSection
{
    [Range(0, 60)]
    [SerializeField] private int _startTimerMinutes = 5;
    [Range(0, 59)]
    [SerializeField] private int _startTimerSeconds = 0;

    [SerializeField] private TextMeshProUGUI _text;

    private float _bombTimer;

    private void Start()
    {
        _bombTimer = _startTimerMinutes * 60 + _startTimerSeconds;
        UpdateText();
    }

    private void Update()
    {
        if (Bomb.Instance.Phase != Phase.Defuse) return;
        if (_bombTimer <= 0)
        {
            Bomb.Instance.Phase = Phase.End;
        }

        _bombTimer -= Time.deltaTime;
        UpdateText();
    }

    private void UpdateText()
    {
        int m = Mathf.FloorToInt(_bombTimer) / 60;
        int s = Mathf.FloorToInt(_bombTimer) % 60;
        int ms = Mathf.CeilToInt(_bombTimer % 1 * 100);
        Debug.Log(_bombTimer);
        _text.text = $"{m:D2}:{s:D2}:{ms:D2}";
    }
}
