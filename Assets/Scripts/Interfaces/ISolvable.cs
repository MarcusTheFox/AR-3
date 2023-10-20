using System;

public interface ISolvable: IInteractable
{
    public Action OnSectionSolved { get; set; }
    public Action OnSectionWrongSolved { get; set; }
    public bool Solved { get; }
}
