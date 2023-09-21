using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSection : MonoBehaviour
{
    [SerializeField] private Collider _collider;

    private void OnTriggerEnter(Collider other)
    {
        if (Bomb.Instance != null)
        {
            Bomb.Instance.Phase = Phase.Stop;
        }
    }
}
