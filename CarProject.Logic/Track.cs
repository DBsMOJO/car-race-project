using System.Collections;
using System.Collections.Specialized;

namespace CarProject.Logic;
public class Track : IEnumerable<Section>
{
    #region properties

    public Section StartSection { get; set; }

    public int Lenght
    {
        get
        {
            int result = StartSection != null ? 1 : 0;

            Section currentSection = StartSection;
            while (currentSection.NextSection != null)
            {
                ++result;
                currentSection = currentSection.NextSection;
            }

            return result;
        }
    }
    public Section this[int index]
    {
        get
        {
            if (index < 0) throw new ArgumentOutOfRangeException();

            Section current = StartSection;
            int currentIndex = 0;

            while (current != null)
            {
                if (currentIndex == index)
                {
                    return current;
                }

                current = current.NextSection;
                currentIndex++;
            }

            throw new IndexOutOfRangeException();
        }
    }

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
