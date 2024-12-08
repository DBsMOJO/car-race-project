namespace CarProject.Logic;

public class TrackBuilder
{
    #region fields
    
    private Track _track;
    
    #endregion

    #region constructor
    
    public TrackBuilder((int speed, int length)[] sectionsData)
    {
        _track = new();
    
        foreach(var (speed, lenght) in sectionsData)
        {
            _track.AddSection(new Section(speed, lenght));
        }
    }
    
    #endregion

    #region methods
    
    public Track Build()
    {
        return _track;
    }
    
    #endregion
}
