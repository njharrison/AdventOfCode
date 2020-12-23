using AdventOfCode.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode.Day21
{
    class Task1 : Day21TaskBase, ITask
    {
        public string Solve(string[] input)
        {
            var mapping = this.ParseFoods(input);

            var allergenIngredientMapping = GetAllergenIngredientMapping(mapping);

            var allFoods = mapping.Aggregate(new List<Food>(), (a, b) =>
            {
                a.AddRange(b.Value);
                return a;
            }).Distinct();

            var allergenIngredients = allergenIngredientMapping.Aggregate(new List<string>(), (a, b) =>
            {
                a.AddRange(b.Value);
                return a;
            });

            var excludedIngredients = new List<string>();
            foreach (var food in allFoods)
            {
                foreach (var ingredient in food.Ingredients)
                {
                    if (!allergenIngredients.Contains(ingredient))
                    {
                        excludedIngredients.Add(ingredient);
                    }
                }
            }

            return excludedIngredients.Count.ToString();
        }
    }
}
