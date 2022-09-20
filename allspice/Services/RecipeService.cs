using System;
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

        internal Recipe GetById(int id)
        {
            Recipe recipe = _recipeRepo.GetById(id);
            if (recipe == null)
            {
                throw new Exception("no recipe by that id");
            }
            return recipe;
        }

        internal Recipe Create(Recipe newRecipe)
        {
            return _recipeRepo.Create(newRecipe);
        }

        internal string Delete(int id)
        {
            Recipe recipe = GetById(id);
            _recipeRepo.Delete(id);
            return $"Deleted the {recipe.Title}";
        }

        // internal Recipe Update(Recipe update, string userId)
        // {

        // }
    }
}