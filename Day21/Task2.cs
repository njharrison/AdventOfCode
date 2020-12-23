using AdventOfCode.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode.Day21
{
    class Task2 : Day21TaskBase, ITask
    {
        public string Solve(string[] input)
        {
            var mapping = this.ParseFoods(input);

            var allergenIngredientMapping = GetAllergenIngredientMapping(mapping);

            var orderedAllergens = allergenIngredientMapping.OrderBy(a => a.Value.Count);

            while (orderedAllergens.Any(a => a.Value.Count > 1))
            { 
                foreach (var allergen in orderedAllergens)
                {
                    if (allergen.Value.Count == 1)
                    {
                        foreach (var allergen2 in orderedAllergens)
                        {
                            if (allergen2.Key != allergen.Key)
                            {
                                allergen2.Value.Remove(allergen.Value[0]);
                            }
                        }
                    }
                }
            }

            var result = orderedAllergens.OrderBy(a => a.Key).Select(a => a.Value[0]).ToArray();

            return string.Join(',', result);
        }
    }
}
