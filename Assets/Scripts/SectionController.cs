using System.Collections.Generic;
using Sections;

public class SectionController
{
    public TimerSection TimerSection;
    public readonly List<ISolvable> SolvableSections = new();
    private int _countSections;
    public int CountSolvedSections { get; private set; }

    public void RegisterSection(ISolvable section)
    {
        if (section == null) return;

        _countSections++;
        section.OnSectionSolved += IncreaseCountSolvedSections;
        section.OnSectionWrongSolved += SectionWrongSolved;
        section.OnSectionSolved += () => UnregisterSection(section);
        SolvableSections.Add(section);
    }

    private void UnregisterSection(ISolvable section)
    {
        section.OnSectionSolved = null;
    }

    private void IncreaseCountSolvedSections()
    {
        if (++CountSolvedSections == _countSections) Bomb.Instance.Phase = Phase.Win;
    }

    private void SectionWrongSolved()
    {
        Bomb.Instance.Phase = Phase.Explode;
    }
}