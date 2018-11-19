using System;
using System.Collections.Generic;

namespace SurveyOnlineCore.Data.Entities
{
    public partial class Customers
    {
        public Customers()
        {
            Surveys = new HashSet<Surveys>();
        }

        public Guid CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerSalt { get; set; }
        public string CustomerPassword { get; set; }
        public string CustomerAbilities { get; set; }

        public ICollection<Surveys> Surveys { get; set; }
    }
}
