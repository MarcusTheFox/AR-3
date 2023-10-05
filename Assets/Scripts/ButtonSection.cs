using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSection : BaseSection
{
    [SerializeField] private Collider _collider;

    private void OnTriggerEnter(Collider other)
    {
        Interact();
    }

    public override void Interact()
    {
        if (Bomb.Instance != null)
        {
            Bomb.Instance.Phase = Phase.Stop;
        }
    }
}
