using System;
using Elements;
using Redcode.Extensions;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Spawners
{
    public class ElementsSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject _batteriesPositions;
        [SerializeField] private GameObject[] _batteriesPrefab;

        private void Start()
        {
            var count = Random.Range(1, _batteriesPositions.transform.childCount + 1);
            var childs = _batteriesPositions.transform.GetChilds();

            for (int i = 0; i < count; i++)
            {
                var spawnPoint = childs.PopRandom().element;
                var battery = Instantiate(_batteriesPrefab.GetRandomElement()).transform;
                battery.SetParent(spawnPoint);
                battery.localRotation = Quaternion.identity;
                battery.localPosition = Vector3.zero;
            }
        }
    }
}