using UnityEngine;

public class Bomb : MonoBehaviour
{
    [Range(60, 0)]
    [SerializeField] private int _waitTime = 5;

    public static Bomb Instance;
    public SectionController SectionController;
    public Phase Phase = Phase.Wait;

    private float _timer;

    private void Start()
    {
        Instance = this;
        SectionController = new SectionController();
        _timer = Time.time;
    }

    private void Update()
    {
        switch (Phase)
        {
            case Phase.Wait:
                if (Time.time - _timer < _waitTime)
                {
                    Debug.Log(Time.time);
                }
                else
                {
                    Phase = Phase.Defuse;
                }
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
