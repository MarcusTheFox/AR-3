using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombSpawner : MonoBehaviour
{
    [SerializeField] private Transform _bombSpawnPoint;
    [SerializeField] private Bomb _bombPrefab;

    public void Spawn()
    {
        if (_bombPrefab != null) Instantiate(_bombPrefab, _bombSpawnPoint);
    }
}
