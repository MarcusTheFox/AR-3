using Configs.Scripts;
using Microsoft.MixedReality.Toolkit.Utilities;
using Spawners;
using UnityEngine;
using UnityEngine.Events;

public class Bomb : MonoBehaviour
{
    public UnityEvent OnBombExploded;
    public UnityEvent OnBombSolved;
    public static Bomb Instance;

    [HideInInspector] public Phase Phase = Phase.Wait;

    [SerializeField] private BombConfig _bombConfig;

    private float _timer;

    public SectionController SectionController;
    [HideInInspector] public ElementsSpawner ElementsSpawner;

    public float BombTimer { get; private set; }

    private void Start()
    {
        Instance = this;
        SectionController = new SectionController();
        ElementsSpawner = GetComponent<ElementsSpawner>();
        BombTimer = _bombConfig.StartTimerMinutes * 60 + _bombConfig.StartTimerSeconds;
        _timer = Time.time;
    }

    private void Update()
    {
        switch (Phase)
        {
            case Phase.Wait:
                if (Time.time - _timer >= _bombConfig.WaitTime)
                    Phase = Phase.Defuse;
                break;

            case Phase.Defuse:
                if (BombTimer <= 0) Phase = Phase.Explode;
                BombTimer -= Time.deltaTime;
                break;

            case Phase.Explode:
                Debug.Log("Dead");
                OnBombExploded?.Invoke();
                Destroy(gameObject);
                break;

            case Phase.Stop:
                Debug.Log("You win!!!");
                OnBombSolved?.Invoke();
                break;
        }
    }

    private void OnDestroy()
    {
        Instance = null;
    }
}

public enum Phase
{
    Wait,
    Defuse,
    Explode,
    Stop
}