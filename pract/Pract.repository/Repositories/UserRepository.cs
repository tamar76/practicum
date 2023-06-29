using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using Pract.Repository.Entities;
using Pract.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace Pract.Repository.Repositories
{
    public class UserRepository : IDataRepository<User>
    {
        IContext _context;
        public UserRepository(IContext context)
        {
            _context = context;
        }

        public async Task<List<User>> AddAsync(List<User> entities)
        {
            List<User> news= new List<User>();
            foreach (User item in entities)
            {
                news.Add(_context.UserContext.Add(item).Entity);

            }
            await _context.SaveChangesAsync();
            return news;
        }
        public async Task<User> DeleteAsync(string id)
        {
                     
                try
                {
                User user =await _context.UserContext.FirstOrDefaultAsync(c => c.Identity.Equals(id));
                if (user is null)
                    throw new Exception("this user is not exist");
               
              _context.UserContext.Remove(user);
                await _context.SaveChangesAsync();
            return user;
            
            
            
            }
                catch (Exception es)
                {

                    throw es;
                }
            //return Results.NotFound();
            //d.Items.Remove(newItem);
            //await d.SaveChangesAsync();
            //return Results.NoContent();

          
        }
     
   
    }
}
