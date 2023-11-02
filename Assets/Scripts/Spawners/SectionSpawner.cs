using System.Collections.Generic;
using Configs.Scripts;
using Microsoft.MixedReality.Toolkit.Utilities;
using Sections;
using UnityEngine;
using UnityEngine.Serialization;

public class SectionSpawner : MonoBehaviour
{
    [SerializeField] private GridObjectCollection _topGrid;
    [SerializeField] private GridObjectCollection _bottomGrid;
    [SerializeField] private BombSectionsConfig _sectionsConfig;

    private readonly List<BaseSection> _sectionList = new();

    public void Start()
    {
        FillSectionList(_sectionList);
        for (var i = 0; i < 12; i++)
        {
            var sectionPrefab = PopRandomBaseSection(_sectionList);
            var section = Instantiate(sectionPrefab).transform;

            section.parent = (i < 6 ? _topGrid : _bottomGrid).transform;
            section.localRotation = section.rotation;
            section.localPosition = Vector3.zero;
            
            Bomb.Instance.SectionController.RegisterSection(section.GetComponent<ISolvable>());
            
            var timerSection = section.GetComponent<TimerSection>();
            if (timerSection) Bomb.Instance.SectionController.TimerSection = timerSection;
        }
        _topGrid.UpdateCollection();
        _bottomGrid.UpdateCollection();
    }
    
    private BaseSection PopRandomBaseSection(IList<BaseSection> list)
    {
        var randomIndex = Random.Range(0, list.Count);
        var section = list[randomIndex];
        list.RemoveAt(randomIndex);
        return section;
    }

    private void FillSectionList(ICollection<BaseSection> list, int listLength = 12)
    {
        list.Add(_sectionsConfig.TimerSection);
        foreach (var section in _sectionsConfig.Sections) list.Add(section);
        for (var i = list.Count; i < listLength; i++) list.Add(_sectionsConfig.EmptySection);
    }
}