using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimerSection : MonoBehaviour
{
    [Range(0, 60)]
    [SerializeField] private int _startTimerMinutes = 5;
    [Range(0, 59)]
    [SerializeField] private int _startTimerSeconds = 0;

    [SerializeField] private TextMeshProUGUI _text;

    private float _bombTimer;
    //private float _timer;

    private void Start()
    {
        _bombTimer = _startTimerMinutes * 60 + _startTimerSeconds;
    }

    private void Update()
    {
        if (Bomb.Instance.Phase != Phase.Defuse) return;
        if (_bombTimer <= 0)
        {
            Bomb.Instance.Phase = Phase.End;
        }

        _bombTimer -= Time.deltaTime;
        int m = Mathf.RoundToInt(_bombTimer) / 60;
        int s = Mathf.RoundToInt(_bombTimer) % 60;
        int ms = Mathf.RoundToInt(_bombTimer % 1 * 100);
        Debug.Log(_bombTimer);
        _text.text = m + ":" + s;// + ":" + ms;
    }
}
