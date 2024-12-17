namespace CarProject.Logic;
public class Track
{
    #region fields

    private Section _startSection = null;
    
    #endregion

    #region constructor

    public Track(Section startSection) => _startSection = startSection;

    #endregion
}
