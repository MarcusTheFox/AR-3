using Configs.Scripts;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public static Bomb Instance;

    [HideInInspector] public Phase Phase = Phase.Wait;

    [SerializeField] private BombConfig _bombConfig;

    private float _timer;

    public SectionController SectionController;

    public float BombTimer { get; private set; }

    private void Start()
    {
        Instance = this;
        SectionController = new SectionController();
        BombTimer = _bombConfig.StartTimerMinutes * 60 + _bombConfig.StartTimerSeconds;
        _timer = Time.time;
    }

    private void Update()
    {
        switch (Phase)
        {
            case Phase.Wait:
                if (Time.time - _timer < _bombConfig.WaitTime) ;
                    // Debug.Log(Time.time);
                else
                    Phase = Phase.Defuse;
                break;

            case Phase.Defuse:
                if (BombTimer <= 0) Phase = Phase.Explode;
                BombTimer -= Time.deltaTime;
                break;

            case Phase.Explode:
                Debug.Log("Dead");
                Destroy(gameObject);
                break;

            case Phase.Stop:
                Debug.Log("You win!!!");
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