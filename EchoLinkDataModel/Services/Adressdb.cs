using EchoLinkDataModel.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EchoLinkDataModel.Services
{
    public class Adressdb : IGenric<Adress>
    {
        private DataContext db;
        private DbSet<Adress> Adressentity;
        public Adressdb(DataContext _db)
        {
            db = _db;
            Adressentity = db.Set<Adress>();
        }

        public List<Adress> GetAll()
        {

            return Adressentity.ToList();
        }
        public Adress GetById(int id)
        {
            return Adressentity.SingleOrDefault(a => a.ID == id);
        }
        public int Insert(List<Adress> obj , Adress add)
        {
            foreach(var item in obj)
            {
                db.Entry(item).State = EntityState.Added;
                db.SaveChanges();
            }  
            return (obj.Count);
        }
        public int Update(Adress[]add, Adress obj)
        {
            foreach (var item in add)
            {
                db.Entry(item).State = EntityState.Modified;
                db.SaveChanges();
            }
            return (add.Length);
        }
    }
}
