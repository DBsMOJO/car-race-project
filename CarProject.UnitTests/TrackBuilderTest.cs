using CarProject.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CarProject.UnitTests
{
    [TestClass]
    public class TrackBuilderTest
    {
        public static (int speed, int length)[] sectionData = { (50, 500), (60, 600), (70, 700) };
        public Track track = new Track(new TrackBuilder(sectionData).Build());

        [TestMethod]
        public void ItShouldReturnNotNullTrack_GivenValidSectionsData()
        {
            // ASSERT
            Assert.IsNotNull(track);
        }

        [TestMethod]
        public void ItShouldInitializeStartSectionWithFirstSectionData_GivenValidSectionsData()
        {
            // ARRANGE
            int startSectionSpeed = sectionData[0].speed;
            int startSectionLenght = sectionData[0].length;

            // ASSERT
            Assert.AreEqual(startSectionSpeed, track.StartSection.MaxSpeed);
            Assert.AreEqual(startSectionLenght, track.StartSection.Length);
        }

        [TestMethod]
        public void ItShouldBuildAProperlyLinkedSectionChain_GivenValidSectionsData()
        {
            // ASSERT
            int idx = 0;
            foreach (Section section in track)
            {
                Assert.AreEqual(sectionData[idx].speed, section.MaxSpeed);
                Assert.AreEqual(sectionData[idx].length, section.Length);
                ++idx;
            }
        }

        [TestMethod]
        public void ItShouldLinkPreviousAndNextSectionsCorrectly_GivenValidSectionsData()
        {
            // ASSERT
            for (int i = 0; i < track.Lenght; ++i)
            {
                if (i != 0)
                {
                    Assert.AreEqual(sectionData[i-1].speed, track[i-1].MaxSpeed);
                    Assert.AreEqual(sectionData[i-1].length, track[i-1].Length);
                }

                if (i != track.Lenght - 1)
                {
                    Assert.AreEqual(sectionData[i+1].speed, track[i+1].MaxSpeed);
                    Assert.AreEqual(sectionData[i+1].length, track[i+1].Length);
                }
            }
        }
    }
}