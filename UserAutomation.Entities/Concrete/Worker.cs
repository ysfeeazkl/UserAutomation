using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserOtomation.Shared.Entities.Abstrack;

namespace UserAutomation.Entities.Concrete
{
    public class Worker : EntityBase<int>, IEntity
    {
        public int CompanyId { get; set; }
        public Company Company{ get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public DateTime StartTime{ get; set; }


    }
}
