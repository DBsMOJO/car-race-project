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
            TrackBuilder trackBuilder = new TrackBuilder(sectionData);
            Track track = trackBuilder.Build();

            // ASSERT
            Assert.IsNotNull(track);
        }

        [TestMethod]
        public void ItShouldHaveCorrectNumberOfSections_GivenValidSectionsData()
        {
            // ARRANGE
            (int speed, int length)[] sectionsData = { (200, 20), (300, 30) };

            // ACT
            TrackBuilder trackBuilder = new TrackBuilder(sectionsData);
            Track track = trackBuilder.Build();

            // ASSERT
            Assert.AreEqual(2, track.Sections.Count);
        }

        [TestMethod]
        public void IsShouldHasCorrectValuesAtFirstSection_GivenValidSectionsData()
        {
            // ARRANGE
            (int speed, int length)[] sectionsData = new (int, int)[] { (200, 20), (300, 30) };

            // ACT
            TrackBuilder trackBuilder = new TrackBuilder(sectionsData);
            Track track = trackBuilder.Build();

            // ASSERT
            Assert.AreEqual(200, track.Sections[0].MaxSpeed, "First section speed is incorrect.");
            Assert.AreEqual(20, track.Sections[0].Length, "First section length is incorrect.");
        }

        [TestMethod]
        public void ItShouldBeLinkedCorrectlySections_GivenValidSectionsData()
        {
            // ARRANGE
            (int speed, int length)[] sectionsData = new (int, int)[] { (200, 20), (300, 30) };

            // Act
            TrackBuilder trackBuilder = new TrackBuilder(sectionsData);
            Track track = trackBuilder.Build();

            // ASSERT
            Assert.IsNull(track.Sections[0].PreviousSection);
            Assert.AreSame(track.Sections[1], track.Sections[0].NextSection);
            Assert.AreSame(track.Sections[0], track.Sections[1].PreviousSection);
            Assert.IsNull(track.Sections[1].NextSection);
        }
    }
}