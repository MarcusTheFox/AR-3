using Microsoft.MixedReality.Toolkit.Utilities;
using Microsoft.MixedReality.Toolkit.UI;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SectionSpawner : MonoBehaviour
{
    [SerializeField] private GridObjectCollection _topGrid;
    [SerializeField] private GridObjectCollection _bottomGrid;
    [SerializeField] private BombConfig _bombConfig;

    private BaseSection[] _sections = new BaseSection[12];

    public void Start()
    {
        int sectionIndex = Random.Range(0, 12);
        _sections[sectionIndex] = Instantiate(_bombConfig.TimerSection);
        _sections[sectionIndex].transform.localRotation = Quaternion.Euler(sectionIndex > 5 ? 90 : -90, 0, 0);
        if (sectionIndex <= 5) _sections[sectionIndex].transform.parent = _topGrid.transform.GetChild(sectionIndex).transform;
        else _sections[sectionIndex].transform.parent = _bottomGrid.transform.GetChild(sectionIndex - 6).transform;
        _sections[sectionIndex].transform.localPosition = new Vector3(0, 0, 0.0115f);

        int counter = _bombConfig.Sections.Length;
        while (counter > 0)
        {
            sectionIndex = Random.Range(0, 12);
            if (_sections[sectionIndex] != null) continue;
            _sections[sectionIndex] = Instantiate(_bombConfig.Sections[--counter]);
            _sections[sectionIndex].transform.localRotation = Quaternion.Euler(sectionIndex > 5 ? 90 : -90, 0, 0);
            if (sectionIndex <= 5) _sections[sectionIndex].transform.parent = _topGrid.transform.GetChild(sectionIndex).transform;
            else _sections[sectionIndex].transform.parent = _bottomGrid.transform.GetChild(sectionIndex - 6).transform;
            _sections[sectionIndex].transform.localPosition = new Vector3(0, 0, 0.0115f);

            _sections[sectionIndex].transform.parent.gameObject.GetComponent<Interactable>().OnClick.AddListener(_sections[sectionIndex].GetComponent<BaseSection>().Interact);
        }

        for (int i = 0; i < _topGrid.transform.childCount + _bottomGrid.transform.childCount; i++)
        {
            if (_sections[i] != null) continue;
            
            _sections[i] = Instantiate(_bombConfig.EmptySection);
            _sections[i].transform.localRotation = Quaternion.Euler(i > 5 ? 90 : -90, 0, 0);
            if (i <= 5) _sections[i].transform.parent = _topGrid.transform.GetChild(i).transform;
            else _sections[i].transform.parent = _bottomGrid.transform.GetChild(i - 6).transform;
            _sections[i].transform.localPosition = new Vector3(0, 0, 0.0115f);
        }
    }
}
