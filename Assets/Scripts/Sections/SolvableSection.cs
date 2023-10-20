using System;
using UnityEngine;

public class SolvableSection : BaseSection, ISolvable
{
    [SerializeField] protected MeshRenderer _bulb;
    public Action OnSectionSolved { get; set; }
    public Action OnSectionWrongSolved { get; set; }
    public bool Solved { get; private set; }

    public virtual void Interact()
    {
        if (Solved) return;
        
        Solved = true;
        _bulb.material.color = Color.green;
        OnSectionSolved?.Invoke();
    }

    public void WrongInteract()
    {
        if (Solved) return;
        
        OnSectionWrongSolved?.Invoke();
    }
}