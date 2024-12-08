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
        public void ItShouldBeNotNull_GivenValidSectionsData()
        {
            // ARRANGE
            (int speed, int length)[] sectionData = { (50, 500), (60, 600), (70, 700) };

            // ACT
            TrackBuilder trackBuilder = new TrackBuilder(sectionData);
            Track track = trackBuilder.Build();
            
            // ASSERT
            Assert.IsNotNull(track);
        }
    }
}