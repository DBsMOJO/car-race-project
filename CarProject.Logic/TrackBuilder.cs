using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarProject.Logic
{
    public class TrackBuilder
    {
        private (int, int)[] sectionInfos;

        public TrackBuilder((int, int)[] sectionInfos)
        {
            this.sectionInfos = sectionInfos;
        }

        private Track BuildTrack((int, int)[] sectionInfos)
        {
            throw new NotImplementedException();
        }

        public Track Build()
        {
            throw new NotImplementedException();
        }
    }
}
