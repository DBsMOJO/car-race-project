using System.Collections.Specialized;

namespace CarProject.Logic;

public class TrackBuilder
{
    #region properties

    public Section StartSection { get; private set; }

    public int Length
    {
        get
        {
            int result = StartSection != null ? 1 : 0;
            Section currentSection = StartSection;

            while (currentSection.NextSection != null)
            {
                result++;
                currentSection = currentSection.NextSection;
            }

            return result;
        }
    }

    public Section this[int index]
    {
        get
        {
            if (index < 0 || index >= this.Length) throw new ArgumentOutOfRangeException();

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
        set
        {
            if (index < 0 || value == null) throw new ArgumentOutOfRangeException();

            Section currentSection = this[index];
            
            
            if (index == 0)
            {
                value.NextSection = currentSection;
                currentSection.PreviousSection = value;
                StartSection = value;
            }
            else
            {
                Section previousSection = currentSection.PreviousSection;

                previousSection.NextSection = value;
                value.PreviousSection = previousSection;

                value.NextSection = currentSection;
                currentSection.PreviousSection = value;
            }
        }
    }

    #endregion

    #region constructor

    public TrackBuilder((int speed, int length)[] sectionsData)
    {
        StartSection = new Section(sectionsData[0].speed, sectionsData[0].length);

        Section lastSection = StartSection;
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
        return StartSection;
    }

    public void Add(Section newSection)
    {
        Section currentSection = StartSection;

        while (currentSection.NextSection != null)
        {
            currentSection = currentSection.NextSection;
        }

        currentSection.AddAfterMe(newSection);
    }

    #endregion

    public void RemoveSection(int index)
    {
        if (index < 0 || index >= this.Length) throw new ArgumentOutOfRangeException();

        Section sectionToRemove = this[index];

        if (index == 0)
        {
            StartSection = StartSection.NextSection;
            if (StartSection != null)
            {
                StartSection.PreviousSection = null;
            }
        }
        else
        {
            Section previousSection = sectionToRemove.PreviousSection;
            Section nextSection = sectionToRemove.NextSection;

            if (previousSection != null)
            {
                previousSection.NextSection = nextSection;
            }

            if (nextSection != null)
            {
                nextSection.PreviousSection = previousSection;
            }
        }

        sectionToRemove.NextSection = null;
        sectionToRemove.PreviousSection = null;
    }
}