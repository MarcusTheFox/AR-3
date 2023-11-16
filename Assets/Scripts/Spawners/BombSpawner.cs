using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombSpawner : MonoBehaviour
{
    [SerializeField] private Bomb _bombPrefab;
    private Transform _parent;
    private Bomb _bombInstance;

    public void Spawn()
    {
        if (_bombInstance) Destroy(_bombInstance.gameObject);
        
        _parent = transform.parent;
        transform.parent = null;
        if (_bombPrefab != null)
        {
            _bombInstance = Instantiate(_bombPrefab, transform);
            _bombInstance.transform.parent = null;
            _bombInstance.OnBombExploded.AddListener(() => StartCoroutine(Restart()));
            _bombInstance.OnBombSolved.AddListener(() => StartCoroutine(Restart()));
        }
    }

    private IEnumerator Restart()
    {
        yield return new WaitForSeconds(2f);
        _parent.gameObject.SetActive(true);
        transform.parent = _parent;
        transform.localRotation = Quaternion.Euler(-90, 0, 0);
    }
}
