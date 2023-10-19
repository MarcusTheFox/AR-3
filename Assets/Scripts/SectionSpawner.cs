using System.Collections.Generic;
using Microsoft.MixedReality.Toolkit.UI;
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

            section.rotation = Quaternion.Euler(-90, 0, i < 6 ? 0 : 180);
            section.parent = i < 6 ? _topGrid.transform.GetChild(i) : _bottomGrid.transform.GetChild(i - 6);
            section.localPosition = new Vector3(0, 0, 0.0115f);
            
            section.parent.gameObject.GetComponent<Interactable>().OnClick
                .AddListener(section.GetComponent<BaseSection>().Interact);
        }
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