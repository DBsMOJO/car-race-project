namespace CarProject.Logic;
public class Track
{
    #region properties

    public Section StartSection { get; set; }

    #endregion

    #region constructor

    public Track(Section startSection) => StartSection = startSection;

    #endregion
}
