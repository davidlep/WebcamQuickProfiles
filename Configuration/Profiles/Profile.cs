using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebcamQuickProfiles.Webcam;

namespace WebcamQuickProfiles.Configuration.Profiles
{
    public class Profile
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string VideoSourceId { get; set; }
        public WebcamSettings WebcamSettings { get; set; }
    }
}
