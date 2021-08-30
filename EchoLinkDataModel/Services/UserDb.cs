using EchoLinkDataModel.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EchoLinkDataModel.Services
{
    public class UserDb : IGenric<User>
    {
        private DataContext db;
        private DbSet<User> userentity;
        public UserDb(DataContext _db)
        {
            this.db = _db;
            userentity = db.Set<User>();
        }
        public List<User> GetAll()
        {
            
            return userentity.ToList();
        }
        public User GetById(int id)
        {
            return userentity.SingleOrDefault(a => a.ID == id);
        }
        public int Insert(List<User> uss ,User obj)
        {
            db.Entry(obj).State = EntityState.Added;
            db.SaveChanges();
            return (obj.ID);
        }
        public int Update(User[]uss,User obj)
        {
            db.Entry(obj).State = EntityState.Modified;
            db.SaveChanges();
            return obj.ID;

        }
    }
}
