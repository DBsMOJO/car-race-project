using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarProject.Logic;

namespace CarProject.UnitTests
{
    [TestClass]
    public class TrackTests
    {
        private Section BuildSampleSections()
        {
            Section first = new Section(50, 500);
            Section second = new Section(60, 600);
            Section third = new Section(70, 700);

            first.NextSection = second;
            second.PreviousSection = first;

            second.NextSection = third;
            third.PreviousSection = second;

            return first;
        }

        [TestMethod]
        public void ItShouldReturnCorrectStartSection()
        {
            // ARRANGE
            Section firstSection = BuildSampleSections();
            Track track = new Track(firstSection);

            // ASSERT
            Assert.AreSame(firstSection, track.StartSection, "StartSection ist nicht korrekt.");
        }

        [TestMethod]
        public void ItShouldReturnCorrectLength()
        {
            // ARRANGE
            Section firstSection = BuildSampleSections();
            Track track = new Track(firstSection);

            // ACT
            int length = track.Lenght;

            // ASSERT
            Assert.AreEqual(3, length, "Die Länge der Track-Liste ist falsch.");
        }

        [TestMethod]
        public void ItShouldReturnCorrectSectionByIndex()
        {
            // ARRANGE
            Section firstSection = BuildSampleSections();
            Track track = new Track(firstSection);

            // ACT & ASSERT
            Assert.AreEqual(50, track[0].MaxSpeed, "Index 0 sollte die erste Section zurückgeben.");
            Assert.AreEqual(60, track[1].MaxSpeed, "Index 1 sollte die zweite Section zurückgeben.");
            Assert.AreEqual(70, track[2].MaxSpeed, "Index 2 sollte die dritte Section zurückgeben.");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ItShouldThrowException_GivenInvalidIndex()
        {
            // ARRANGE
            Section firstSection = BuildSampleSections();
            Track track = new Track(firstSection);

            // ACT
            var invalidSection = track[5]; // Ungültiger Index
        }
    }
}