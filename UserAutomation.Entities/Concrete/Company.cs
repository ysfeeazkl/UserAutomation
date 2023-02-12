using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserOtomation.Shared.Entities.Abstrack;

namespace UserAutomation.Entities.Concrete
{
    public class Company : EntityBase<int>, IEntity
    {
        public string Name{ get; set; }
        public string Sector{ get; set; }

        public int CompanyLocationId { get; set; }
        public Location CompanyLocation { get; set; }

        public DateTime YearOfFoundation { get; set; }
        public ICollection<Worker>? Workers{ get; set; }
    }
}
