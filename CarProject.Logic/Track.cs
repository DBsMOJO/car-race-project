using System.Collections;
using System.Collections.Specialized;

namespace CarProject.Logic;
public class Track : IEnumerable<Section>
{
    #region properties

    public Section StartSection { get; set; }

    #endregion

    #region constructor

    public Track(Section startSection) => StartSection = startSection;

    #endregion

    #region methods

    public IEnumerator<Section> GetEnumerator()
    {
        Section current = StartSection;
        while (current != null)
        {
            yield return current;
            current = current.NextSection;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    #endregion
}
