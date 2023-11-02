using Sections;
using UnityEngine;

namespace Configs.Scripts
{
    [CreateAssetMenu(fileName = "BombSectionsConfig", menuName = "Bomb/BombSectionsConfig", order = 1)]
    public class BombSectionsConfig : ScriptableObject
    {
        public TimerSection TimerSection;
        public EmptySection EmptySection;
        public BaseSection[] Sections;
    }
}
