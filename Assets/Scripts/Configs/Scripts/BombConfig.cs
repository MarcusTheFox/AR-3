using UnityEngine;

namespace Configs.Scripts
{
    [CreateAssetMenu(fileName = "BombConfig", menuName = "Bomb/BombConfig", order = 0)]
    public class BombConfig : ScriptableObject
    {
        [Header("Time")]
        [Range(60, 0)] public int WaitTime = 5;
        [Range(0, 60)] public int StartTimerMinutes = 5;
        [Range(0, 59)] public int StartTimerSeconds;
        
        [Space] [Header("Audio")]
        public AudioClip ExplodeSound;
        public AudioClip Win1Sound;
        public AudioClip Win2Sound;
    }
}
