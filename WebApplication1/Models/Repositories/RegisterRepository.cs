using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models.EFModels;

namespace WebApplication1.Models.Repositories
{
    public class RegisterRepository
    {
        private AppDbContext db = new AppDbContext();
        public void Create(Register register)
        {
            db.Registers.Add(register);
            db.SaveChanges();
        }
        public Register FindbyEmail(string email)
        {
            return db.Registers.FirstOrDefault(x => x.Email == email);
        }
        public Register FindbyId(int id)
        {
            return db.Registers.Find(id);
        }
        public List<Register> GetAll()
        {
            return db.Registers.ToList();
        }
    }
}