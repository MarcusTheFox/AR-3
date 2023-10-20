using System.Collections.Generic;
using Microsoft.MixedReality.Toolkit.Utilities;
using UnityEngine;

public class SectionSpawner : MonoBehaviour
{
    [SerializeField] private GridObjectCollection _topGrid;
    [SerializeField] private GridObjectCollection _bottomGrid;
    [SerializeField] private BombConfig _bombConfig;

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
        list.Add(_bombConfig.TimerSection);
        foreach (var section in _bombConfig.Sections) list.Add(section);
        for (var i = list.Count; i < listLength; i++) list.Add(_bombConfig.EmptySection);
    }
}