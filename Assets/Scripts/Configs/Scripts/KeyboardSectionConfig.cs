using System;
using UnityEngine;

namespace Configs.Scripts
{
    [CreateAssetMenu(fileName = "KeyboardSectionConfig", menuName = "Sections/KeyboardSectionConfig", order = 0)]
    public class KeyboardSectionConfig : ScriptableObject
    {
        public KeyboardPresets[] ButtonsPreset;
    }

    [Serializable]
    public struct KeyboardPresets
    {
        public int[] Preset;
    }
}
