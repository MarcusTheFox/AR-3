using TMPro;
using UnityEngine;

public class TimerSection : BaseSection
{
    [SerializeField] private TextMeshProUGUI _text;

    private void Update()
    {
        UpdateText(Bomb.Instance.BombTimer);
    }

    private void UpdateText(float timer)
    {
        var m = Mathf.FloorToInt(timer) / 60;
        var s = Mathf.FloorToInt(timer) % 60;
        var ms = Mathf.CeilToInt(timer % 1 * 100);
        _text.text = $"{m:D2}:{s:D2}:{ms:D2}";
    }
}