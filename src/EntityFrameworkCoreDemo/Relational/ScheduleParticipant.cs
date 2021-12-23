using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkCoreDemo.Relational
{
    public class ScheduleParticipant
    {
        public string Id { get; set; }

        public string ParticipantType { get; set; }

        public string ParticipantID { get; set; }

        public string ScheduleId { get; set; }
        public virtual Schedule Schedule { get; set; }
    }
}
