using System.Collections;
using Redcode.Extensions;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BombSpawner : MonoBehaviour
{
    [SerializeField] private Bomb _bombPrefab;
    private Bomb _bombInstance;
    private AudioSource _audio;

    private void Start()
    {
        _audio = GetComponent<AudioSource>();
    }

    public void Spawn()
    {
        if (_bombInstance) Destroy(_bombInstance.gameObject);
        
        transform.parent = null;
        if (_bombPrefab != null)
        {
            _bombInstance = Instantiate(_bombPrefab, transform.position.WithY(0), Quaternion.Euler(-90f, 0f, 0f));
            _bombInstance.transform.parent = null;
            _bombInstance.OnBombExploded.AddListener(() => StartCoroutine(Explode()));
            _bombInstance.OnBombSolved.AddListener(() => StartCoroutine(Win()));
        }

        StartCoroutine(RotateBombToPlayer());
    }

    private IEnumerator Explode()
    {
        _audio.clip = _bombInstance.BombConfig.ExplodeSound;
        _audio.Play();
        
        yield return new WaitWhile(() => _audio.isPlaying);
        StartCoroutine(Restart());
    }

    private IEnumerator Win()
    {
        _bombInstance.GetComponent<MeshRenderer>().material.color = new Color(0f, 0.5f, 0f);
        
        _audio.clip = _bombInstance.BombConfig.Win1Sound;
        _audio.Play();
        
        yield return new WaitWhile(() => _audio.isPlaying);
        _audio.clip = _bombInstance.BombConfig.Win2Sound;
        _audio.Play();
        
        yield return new WaitWhile(() => _audio.isPlaying);
        StartCoroutine(Restart());
    }

    private IEnumerator RotateBombToPlayer()
    {
        yield return new WaitForEndOfFrame();
        
        _bombInstance.transform.SetEulerAnglesY(transform.eulerAngles.y);
    }

    private IEnumerator Restart()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(0);
    }
}
