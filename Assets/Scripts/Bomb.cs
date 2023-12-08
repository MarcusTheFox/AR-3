using Configs.Scripts;
using Spawners;
using UnityEngine;
using UnityEngine.Events;

public class Bomb : MonoBehaviour
{
    public UnityEvent OnBombExploded;
    public UnityEvent OnBombSolved;
    public static Bomb Instance;

    [HideInInspector] public Phase Phase = Phase.Wait;

    [field: SerializeField] public BombConfig BombConfig { get; private set; }
    private float _timer;

    public SectionController SectionController;
    public ElementsSpawner ElementsSpawner { get; private set; }
    public SeriesNumber SeriesNumber { get; private set; } 

    public float BombTimer { get; private set; }
    
    private void Awake()
    {
        BombTimer = BombConfig.StartTimerMinutes * 60 + BombConfig.StartTimerSeconds;
        _timer = Time.time;
    }

    private void Start()
    {
        Instance = this;
        SectionController = new SectionController();
        ElementsSpawner = GetComponent<ElementsSpawner>();
        SeriesNumber = GetComponentInChildren<SeriesNumber>();
    }

    private void Update()
    {
        switch (Phase)
        {
            case Phase.Wait:
                if (Time.time - _timer >= BombConfig.WaitTime)
                    Phase = Phase.Defuse;
                break;

            case Phase.Defuse:
                if (BombTimer <= 0) Phase = Phase.Explode;
                BombTimer -= Time.deltaTime;
                break;

            case Phase.Explode:
                Explode();
                Phase = Phase.Stop;
                break;

            case Phase.Win:
                Win();
                Phase = Phase.Stop;
                break;
        }
    }

    private void Explode()
    {
        OnBombExploded?.Invoke();
        Destroy(gameObject);
    }

    private void Win()
    {
        OnBombSolved?.Invoke();
    }

    private void OnDestroy()
    {
        OnBombExploded.RemoveAllListeners();
        OnBombSolved.RemoveAllListeners();
        Instance = null;
    }
}

public enum Phase
{
    Wait,
    Defuse,
    Explode,
    Win,
    Stop
}