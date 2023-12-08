using System;
using TMPro;
using UnityEngine;
using Debug = Sisus.Debugging.Debug;

namespace Sections
{
    public class TimerSection : BaseSection
    {
        [SerializeField] private TextMeshProUGUI _text;
        private AudioSource _audio;
        private int _lastSecond;

        private void Start()
        {
            _audio = GetComponent<AudioSource>();
            _lastSecond = GetSeconds();
        }

        private void Update()
        {
            UpdateText(Bomb.Instance.BombTimer);
            if (_lastSecond != GetSeconds())
            {
                _audio.Play();
                _lastSecond = GetSeconds();
            }
        }

        private void UpdateText(float timer)
        {
            var m = GetMinutes();
            var s = GetSeconds();
            var ms = Mathf.CeilToInt(timer % 1 * 100);
            _text.text = m > 0 ? $"{m:D2}:{s:D2}" : $"{s:D2}:{ms:D2}";
        }

        public int GetMinutes() => Mathf.FloorToInt(Bomb.Instance.BombTimer) / 60;
        public int GetSeconds() => Mathf.FloorToInt(Bomb.Instance.BombTimer) % 60;
        public string GetTime() => _text.text;
    }
}