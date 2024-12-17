using System.Collections;
using System.Collections.Specialized;

namespace CarProject.Logic;

public class Track : IEnumerable<Section>
{
    #region fields

    private Section _startSection;

    #endregion

    #region properties

    public Section StartSection
    {
        get => UpdateStartSection();
        private set => _startSection = value;
    }

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
            if (index < 0 || index >= this.Lenght) throw new ArgumentOutOfRangeException();

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

    public int MaxSpeedOfTrack
    {
        get
        {
            int result = default;
            foreach (Section section in this)
            {
                if (result < section.MaxSpeed)
                {
                    result = section.MaxSpeed;
                }
            }

            return result;
        }
    }

    public int LongestSection
    {
        get
        {
            int result = 0;
            foreach (Section section in this)
            {
                if (result < section.Length)
                {
                    result = section.Length;
                }
            }

            return result;
        }
    }

    // Min Speed
    // TrackLength

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

    private Section UpdateStartSection()
    {
        Section result = _startSection;
        while (result.PreviousSection != null)
        {
            result = result.PreviousSection;
        }

        return result;
    }

    #endregion
}