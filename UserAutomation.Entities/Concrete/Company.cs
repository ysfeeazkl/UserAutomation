using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserAutomation.Entities.Concrete
{
    public class Company
    {
        public string Name{ get; set; }
        public string Sector{ get; set; }
        public int CompanyLocationId { get; set; }
        public Location CompanyLocation { get; set; }
        public DateTime YearOfFoundation { get; set; }
    }
}
