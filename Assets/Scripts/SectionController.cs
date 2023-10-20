public class SectionController
{
    private int _countSections;
    private int _countSolvedSections;

    public void RegisterSection(ISolvable section)
    {
        if (section == null) return;

        _countSections++;
        section.OnSectionSolved += IncreaseCountSolvedSections;
        section.OnSectionWrongSolved += SectionWrongSolved;
        section.OnSectionSolved += () => UnregisterSection(section);
    }

    private void UnregisterSection(ISolvable section)
    {
        section.OnSectionSolved = null;
    }

    private void IncreaseCountSolvedSections()
    {
        if (++_countSolvedSections == _countSections) Bomb.Instance.Phase = Phase.Stop;
    }

    private void SectionWrongSolved()
    {
        Bomb.Instance.Phase = Phase.Explode;
    }
}