namespace CarProject.Logic;

public class TrackBuilder
{
    #region fields

    private Section _startSection = null;

    #endregion
    #region constructor
    
    public TrackBuilder((int speed, int length)[] sectionsData)
    {
        _startSection = new Section(sectionsData[0].speed, sectionsData[0].length);

        Section lastSection = _startSection;
        for (int i = 1; i < sectionsData.Length; ++i)
        {
            Section currentSection = new Section(sectionsData[i].speed, sectionsData[i].length);
            lastSection.AddAfterMe(currentSection);
            lastSection = currentSection;
        }
    }
    
    #endregion

    #region methods
    
    public Section Build()
    {
        return _startSection;
    }
    
    #endregion
}
