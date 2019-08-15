using Microsoft.EntityFrameworkCore;
using SurveyOnlineCore.Data.Entities;
using SurveyOnlineCore.Data.Helpers;
using SurveyOnlineCore.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyOnlineCore.Data.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly SurveyOnlineContext _surveyOnlineContext;

        public AuthRepository(SurveyOnlineContext surveyOnlineContext)
        {
            _surveyOnlineContext = surveyOnlineContext;
        }

        public async Task<bool> CustomerExists(string customerName)
        {
            if (await _surveyOnlineContext.Customers.AnyAsync(c => c.CustomerName == customerName))
                return true;
            return false;
        }

        /// <summary>
        /// Async login customer
        /// </summary>
        /// <param name="customerName">Input customer name</param>
        /// <param name="password">Input customer password</param>
        /// <returns>Loginned customer</returns>
        public async Task<Customers> Login(string customerName, string password)
        {
            var customer = await _surveyOnlineContext.Customers.FirstOrDefaultAsync(c => c.CustomerName == customerName);

            if (customer == null)
                return null;

            if (!AuthHelpers.VerifyPassword(password, customer.CustomerPassword, customer.CustomerSalt))
                return null;

            return customer;
        }

        /// <summary>
        /// Async register customer
        /// </summary>
        /// <param name="customer">Csutomer entity</param>
        /// <param name="password">Customer password</param>
        /// <returns>Registrated customer</returns>
        public async Task<Customers> Register(Customers customer, string password)
        {
            byte[] passwordHash;
            byte[] passwordSalt;
            AuthHelpers.CreatePasswordHash(password, out passwordHash, out passwordSalt);

            customer.CustomerPassword = passwordHash;
            customer.CustomerSalt = passwordSalt;

            using (var transaction = _surveyOnlineContext.Database.BeginTransaction())
            {
                try
                {
                    await _surveyOnlineContext.AddAsync(customer);
                    await _surveyOnlineContext.SaveChangesAsync();
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                }
            }
            return customer;
        }
    }
}
