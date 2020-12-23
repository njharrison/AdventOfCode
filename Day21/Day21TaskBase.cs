using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode.Day21
{
    abstract internal class Day21TaskBase
    {
        internal Dictionary<string, List<Food>> ParseFoods(string[] input)
        {
            var allergenFoodMapping = new Dictionary<string, List<Food>>();

            foreach (var line in input)
            {
                var description = line.Split(" (contains ");
                description[1] = description[1].Replace(")", string.Empty);

                var allergens = description[1].Split(", ");

                var food = new Food(description[0].Split(" "));
                foreach (var allergen in allergens)
                {
                    if (!allergenFoodMapping.ContainsKey(allergen))
                    {
                        allergenFoodMapping.Add(allergen, new List<Food>());
                    }

                    allergenFoodMapping[allergen].Add(food);
                }
            }

            return allergenFoodMapping;
        }

        protected Dictionary<string, List<string>> GetAllergenIngredientMapping(Dictionary<string, List<Food>> mapping)
        {
            var allergenIngredientMapping = new Dictionary<string, List<string>>();

            foreach (var allergen in mapping.Keys)
            {
                allergenIngredientMapping.Add(allergen, new List<string>());
                foreach (var ingredient in mapping[allergen].First().Ingredients)
                {
                    if (mapping[allergen].All(a => a.Ingredients.Any(b => b == ingredient)))
                    {
                        allergenIngredientMapping[allergen].Add(ingredient);
                    }
                }
            }

            return allergenIngredientMapping;
        }
    }
}