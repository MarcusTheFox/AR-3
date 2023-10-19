using UnityEngine;

[CreateAssetMenu(fileName = "BombConfig", menuName = "ScriptableObjects/BombConfig", order = 0)]
public class BombConfig : ScriptableObject
{
    public TimerSection TimerSection;
    public EmptySection EmptySection;
    public GameObject[] Sections;
}
