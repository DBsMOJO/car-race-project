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
        [TestMethod]
        public void ItShouldReturnNotNullTrack_GivenValidSectionsData()
        {
            // ARRANGE
            (int speed, int length)[] sectionData = { (50, 500), (60, 600), (70, 700) };

            // ACT
            Track track = new Track(new TrackBuilder(sectionData).Build());

            // ASSERT
            Assert.IsNotNull(track);
        }

        [TestMethod]
        public void ItShouldInitializeStartSectionWithFirstSectionData_GivenValidSectionsData()
        {
            // ARRANGE
            (int speed, int length)[] sectionData = { (50, 500), (60, 600), (70, 700) };
            int startSectionSpeed = sectionData[0].speed;
            int startSectionLenght = sectionData[0].length;

            // ACT
            Track track = new Track(new TrackBuilder(sectionData).Build());

            // ASSERT
            Assert.AreEqual(startSectionSpeed, track.StartSection.MaxSpeed);
            Assert.AreEqual(startSectionLenght, track.StartSection.Length);
        }
    }
}