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
        
        public int BatteriesCount { get; private set; } 

        private void Start()
        {
            var count = Random.Range(1, _batteriesPositions.transform.childCount + 1);
            var childs = _batteriesPositions.transform.GetChilds();

            for (int i = 0; i < count; i++)
            {
                SpawnElement(_batteriesPrefab.GetRandomElement(), childs.PopRandom().element);
            }

            BatteriesCount = _batteriesPositions.GetComponentsInChildren<Battery>().Length;
        }

        private void SpawnElement(GameObject prefab, Transform spawnPoint)
        {
            var element = Instantiate(prefab).transform;
            element.SetParent(spawnPoint);
            element.localRotation = Quaternion.identity;
            element.localPosition = Vector3.zero;
        }
    }
}