using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSection : MonoBehaviour, ISection
{
    [SerializeField] private Collider _collider;

    private void OnTriggerEnter(Collider other)
    {
        Interact();
    }

    public void Interact()
    {
        if (Bomb.Instance != null)
        {
            Bomb.Instance.Phase = Phase.Stop;
        }
    }
}
