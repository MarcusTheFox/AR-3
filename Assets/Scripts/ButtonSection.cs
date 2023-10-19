using UnityEngine;

public class ButtonSection : BaseSection
{
    [SerializeField] private Collider _collider;

    public override void Interact()
    {
        if (Bomb.Instance != null) Bomb.Instance.Phase = Phase.Stop;
    }
}