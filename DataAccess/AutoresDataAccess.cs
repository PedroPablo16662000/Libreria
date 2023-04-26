using Models.Entities;
using Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class AutoresDataAccess : IAutoresDataAccess
    {
        readonly LibreriaContext _context;
        public AutoresDataAccess()
        {
            _context = new LibreriaContext();
        }
        public async Task<List<Autore>> GetAutors()
        {
            return _context.Autores.ToList();
        }
    }
}
