using Models.Entities;
using Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessRules
{
    public class AutoresBusiness : IAutoresBusiness
    {
        readonly IAutoresDataAccess _dataAccess;
        public AutoresBusiness(IAutoresDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public async Task<List<Autore>> GetAll() {
            try
            {
                List<Autore> result = new List<Autore>();
                result= await _dataAccess.GetAutors();
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
