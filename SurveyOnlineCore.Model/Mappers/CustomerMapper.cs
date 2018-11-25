using SurveyOnlineCore.Data.Entities;
using SurveyOnlineCore.Model.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SurveyOnlineCore.Model.Mappers
{
    public static class CustomerMapper
    {
        public static Customers Map(CustomerCreate customerCreate)
        {
            return new Customers
            {
                CustomerId = Guid.NewGuid(),
                CustomerName = customerCreate.CustomerName,
                CustomerEmail = customerCreate.CustomerEmail,
                CustomerAbilities = customerCreate.CustomerAbilities
            };
        }
    }
}
