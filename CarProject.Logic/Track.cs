namespace CarProject.Logic;
public class Track
{
    #region fields
    
    private List<Section> _sections = new();
    
    #endregion

    public IReadOnlyList<Section> Sections => _sections.AsReadOnly();

    #region constructor
    
    
    #endregion

    #region methods
    
    public void AddSection(Section section)
    {
        _sections.Add(section);
    }
    
    #endregion
}
