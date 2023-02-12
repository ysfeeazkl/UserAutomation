using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserAutomation.Entities.Concrete
{
    public class Worker
    {
        public int CompanyId { get; set; }
        public Company Company{ get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public DateTime StartTime{ get; set; }


    }
}
