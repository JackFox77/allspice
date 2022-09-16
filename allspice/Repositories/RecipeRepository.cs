using System.Collections.Generic;
using System.Data;
using allspice.Models;

namespace allspice.Repositories
{
    public class RecipeRepository
    {
        private readonly IDbConnection _db;

        public RecipeRepository(IDbConnection db)
        {
            _db = db;
        }

        internal List<Recipe> GetAll()
        {
        }
    }
}