using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkCoreDemo.Relational
{
    public class Schedule
    {
        public string Id { get; set; }

        public DateTime Day { get; set; }

        public string Note { get; set; }

        public List<ScheduleParticipant> Participants { get; set; }
    }
}
