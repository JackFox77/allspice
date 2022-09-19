using System.Collections.Generic;
using System.Data;
using System.Linq;
using allspice.Models;
// using allspice.Models
using Dapper;

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
            string sql = @"
            SELECT
            r.*,
            a.*
            FROM recipes r
            JOIN accounts a on a.id = r.creatorId;
            ";

            List<Recipe> recipes = _db.Query<Recipe, Account, Recipe>(sql, (recipe, account) =>
            {
                recipe.CreatorId = account.Id;
                return recipe;
            }).ToList();
            return recipes;
        }

        public Recipe Create(Recipe newRecipe)
        {
            string sql = @"
    INSERT INTO recipes
    (title,subtitle,category,creatorId)
    VALUES
    (@title,@subtitle,@category,@creatorId);
    Select LAST_INSERT_ID();
    ";
            int id = _db.ExecuteScalar<int>(sql, newRecipe);
            newRecipe.Id = id;
            return newRecipe;
        }
    }
}