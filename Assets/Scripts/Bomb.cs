using UnityEngine;

public class Bomb : MonoBehaviour
{
    public static Bomb Instance;

    [Range(60, 0)] [SerializeField] private int _waitTime = 5;
    [Range(0, 60)] [SerializeField] private int _startTimerMinutes = 5;
    [Range(0, 59)] [SerializeField] private int _startTimerSeconds;

    public Phase Phase = Phase.Wait;

    private float _timer;
    public SectionController SectionController;
    public float BombTimer { get; private set; }

    private void Start()
    {
        Instance = this;
        SectionController = new SectionController();
        BombTimer = _startTimerMinutes * 60 + _startTimerSeconds;
        _timer = Time.time;
    }

    private void Update()
    {
        switch (Phase)
        {
            case Phase.Wait:
                if (Time.time - _timer < _waitTime)
                    Debug.Log(Time.time);
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