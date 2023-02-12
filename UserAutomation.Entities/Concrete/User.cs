using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserOtomation.Shared.Entities.Abstrack;

namespace UserAutomation.Entities.Concrete
{
    public class User : EntityBase<int>, IEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public DateTime BirthDate { get; set; }
        public int HomeLocationId { get; set; }
        public Location HomeLocation { get; set; }

        public ICollection<Worker>? Workers { get; set; }

    }
}
