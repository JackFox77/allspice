using System.Collections.Generic;
using allspice.Models;
using allspice.Repositories;

namespace allspice.Services
{
    public class RecipeService
    {
        private readonly RecipeRepository _recipeRepo;

        public RecipeService(RecipeRepository recipeRepo)
        {
            _recipeRepo = recipeRepo;
        }

        internal List<Recipe> GetAll()
        {
            return _recipeRepo.GetAll();
        }

        internal Recipe Create(Recipe newRecipe)
        {
            return _recipeRepo.Create(newRecipe);
        }
    }
}