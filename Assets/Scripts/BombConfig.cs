using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;

[CreateAssetMenu(fileName = "BombConfig", menuName = "ScriptableObjects/BombConfig", order = 0)]
public class BombConfig : ScriptableObject
{
    public TimerSection TimerSection;
    public EmptySection EmptySection;
    public BaseSection[] Sections;
}
