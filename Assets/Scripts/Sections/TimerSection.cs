using System;
using TMPro;
using UnityEngine;

namespace Sections
{
    public class TimerSection : BaseSection
    {
        [SerializeField] private TextMeshProUGUI _text;

        private void Update()
        {
            UpdateText(Bomb.Instance.BombTimer);
        }

        private void UpdateText(float timer)
        {
            var m = GetMinutes();
            var s = Mathf.FloorToInt(timer) % 60;
            var ms = Mathf.CeilToInt(timer % 1 * 100);
            _text.text = m > 0 ? $"{m:D2}:{s:D2}" : $"{s:D2}:{ms:D2}";
        }

        public int GetMinutes() => Mathf.FloorToInt(Bomb.Instance.BombTimer) / 60;

        public string GetTime()
        {
            return _text.text;
        }
    }
}