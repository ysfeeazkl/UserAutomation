using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserOtomation.Shared.Entities.Abstrack;

namespace UserAutomation.Entities.Concrete
{
    public class Location : EntityBase<int>, IEntity
    {
        public string Country { get; set; }
        public string Province { get; set; }
        public Company? Company { get; set; }
        public int? CompanyId { get; set; }
        public User? User{ get; set; }
        public int? UserId{ get; set; }
    }
}
