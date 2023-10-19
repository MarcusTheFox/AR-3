using System.Collections.Generic;
using Microsoft.MixedReality.Toolkit.Utilities;
using UnityEngine;

public class SectionSpawner : MonoBehaviour
{
    [SerializeField] private GridObjectCollection _topGrid;
    [SerializeField] private GridObjectCollection _bottomGrid;
    [SerializeField] private BombConfig _bombConfig;

    private readonly List<GameObject> _sectionList = new();

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
        }
        _topGrid.UpdateCollection();
        _bottomGrid.UpdateCollection();
    }
    
    private GameObject PopRandomBaseSection(IList<GameObject> list)
    {
        var randomIndex = Random.Range(0, list.Count);
        var section = list[randomIndex];
        list.RemoveAt(randomIndex);
        return section;
    }

    private void FillSectionList(ICollection<GameObject> list, int listLength = 12)
    {
        list.Add(_bombConfig.TimerSection.gameObject);
        foreach (var section in _bombConfig.Sections) list.Add(section);
        for (var i = list.Count; i < listLength; i++) list.Add(_bombConfig.EmptySection.gameObject);
    }
}