using System;
using UnityEngine;

namespace Configs.Scripts
{
    [CreateAssetMenu(fileName = "SimonSectionConfig", menuName = "Sections/SimonSectionConfig")]
    public class SimonSectionConfig : ScriptableObject
    {
        public SimonPresets[] ButtonsPreset;
    }

    [Serializable]
    public struct SimonPresets
    {
        public int[] Preset;
    }
}
