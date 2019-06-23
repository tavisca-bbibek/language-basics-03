using System;
using System.Linq;

namespace Tavisca.Bootcamp.LanguageBasics.Exercise1
{
    public static class Program
    {
        static void Main(string[] args)
        {
            Test(
                new[] { 3, 4 },
                new[] { 2, 8 },
                new[] { 5, 2 },
                new[] { "P", "p", "C", "c", "F", "f", "T", "t" },
                new[] { 1, 0, 1, 0, 0, 1, 1, 0 });
            Test(
                new[] { 3, 4, 1, 5 },
                new[] { 2, 8, 5, 1 },
                new[] { 5, 2, 4, 4 },
                new[] { "tFc", "tF", "Ftc" },
                new[] { 3, 2, 0 });
            Test(
                new[] { 18, 86, 76, 0, 34, 30, 95, 12, 21 },
                new[] { 26, 56, 3, 45, 88, 0, 10, 27, 53 },
                new[] { 93, 96, 13, 95, 98, 18, 59, 49, 86 },
                new[] { "f", "Pt", "PT", "fT", "Cp", "C", "t", "", "cCp", "ttp", "PCFt", "P", "pCt", "cP", "Pc" },
                new[] { 2, 6, 6, 2, 4, 4, 5, 0, 5, 5, 6, 6, 3, 5, 6 });
            Console.ReadKey(true);
        }

        private static void Test(int[] protein, int[] carbs, int[] fat, string[] dietPlans, int[] expected)
        {
            var result = SelectMeals(protein, carbs, fat, dietPlans).SequenceEqual(expected) ? "PASS" : "FAIL";
            Console.WriteLine($"Proteins = [{string.Join(", ", protein)}]");
            Console.WriteLine($"Carbs = [{string.Join(", ", carbs)}]");
            Console.WriteLine($"Fats = [{string.Join(", ", fat)}]");
            Console.WriteLine($"Diet plan = [{string.Join(", ", dietPlans)}]");
            Console.WriteLine(result);
        }

        private static int GetMealIndex(int[] protein, int[] carbs, int[] fat, int[] cals, int begin, int end, string dietPlan, int basis)
        {
            if (basis < dietPlan.Length)
            {
                switch (dietPlan[basis])
                {
                    case 'P':
                        int maxProtein = SubArray(protein, begin, end - begin + 1).Max();
                        int maxProteinCount = protein.Count(e => e == maxProtein);
                        if (maxProteinCount > 1)
                            return GetMealIndex(protein, carbs, fat, cals,
                                Array.IndexOf(protein, maxProtein), Array.LastIndexOf(protein, maxProtein),
                                dietPlan, basis + 1);
                        else
                            return Array.IndexOf(protein, maxProtein);
                    case 'p':
                        int minProtein = SubArray(protein, begin, end - begin + 1).Min();
                        int minProteinCount = protein.Count(e => e == minProtein);
                        if (minProteinCount > 1)
                            return GetMealIndex(protein, carbs, fat, cals,
                                Array.IndexOf(protein, minProtein), Array.LastIndexOf(protein, minProtein),
                                dietPlan, basis + 1);
                        else
                            return Array.IndexOf(protein, minProtein);
                    case 'C':
                        int maxCarbs = SubArray(carbs, begin, end - begin + 1).Max();
                        int maxCarbsCount = carbs.Count(e => e == maxCarbs);
                        if (maxCarbsCount > 1)
                            return GetMealIndex(protein, carbs, fat, cals,
                                Array.IndexOf(carbs, maxCarbs), Array.LastIndexOf(carbs, maxCarbs),
                                dietPlan, basis + 1);
                        else
                            return Array.IndexOf(carbs, maxCarbs);
                    case 'c':
                        int minCarbs = SubArray(carbs, begin, end - begin + 1).Min();
                        int minCarbsCount = carbs.Count(e => e == minCarbs);
                        if (minCarbsCount > 1)
                            return GetMealIndex(protein, carbs, fat, cals,
                                Array.IndexOf(carbs, minCarbs), Array.LastIndexOf(carbs, minCarbs),
                                dietPlan, basis + 1);
                        else
                            return Array.IndexOf(carbs, minCarbs);
                    case 'F':
                        int maxFat = SubArray(fat, begin, end - begin + 1).Max();
                        int maxFatCount = fat.Count(e => e == maxFat);
                        if (maxFatCount > 1)
                            return GetMealIndex(protein, carbs, fat, cals,
                                Array.IndexOf(fat, maxFat), Array.LastIndexOf(fat, maxFat),
                                dietPlan, basis + 1);
                        else
                            return Array.IndexOf(fat, maxFat);
                    case 'f':
                        int minFat = SubArray(fat, begin, end - begin + 1).Min();
                        int minFatCount = fat.Count(e => e == minFat);
                        if (minFatCount > 1)
                            return GetMealIndex(protein, carbs, fat, cals,
                                Array.IndexOf(fat, minFat), Array.LastIndexOf(fat, minFat),
                                dietPlan, basis + 1);
                        else
                            return Array.IndexOf(fat, minFat);
                    case 'T':
                        int maxCals = SubArray(cals, begin, end - begin + 1).Max();
                        int maxCalsCount = cals.Count(e => e == maxCals);
                        if (maxCalsCount > 1)
                            return GetMealIndex(protein, carbs, fat, cals,
                                Array.IndexOf(cals, maxCals), Array.LastIndexOf(cals, maxCals),
                                dietPlan, basis + 1);
                        else
                            return Array.IndexOf(cals, maxCals);
                    case 't':
                        int minCals = SubArray(cals, begin, end - begin + 1).Min();
                        int minCalsCount = cals.Count(e => e == minCals);
                        if (minCalsCount > 1)
                            return GetMealIndex(protein, carbs, fat, cals,
                                Array.IndexOf(cals, minCals), Array.LastIndexOf(cals, minCals),
                                dietPlan, basis + 1);
                        else
                            return Array.IndexOf(cals, minCals);
                    default:
                        return -1;
                }
            }
            else
            {
               switch(dietPlan[basis - 1])
                {
                    case 'P':
                        return Array.IndexOf(protein, SubArray(protein, begin, end - begin + 1).Max());
                    case 'p':
                        return Array.IndexOf(protein, SubArray(protein, begin, end - begin + 1).Min());
                    case 'C':
                        return Array.IndexOf(carbs, SubArray(carbs, begin, end - begin + 1).Max());
                    case 'c':
                        return Array.IndexOf(carbs, SubArray(carbs, begin, end - begin + 1).Min());
                    case 'F':
                        return Array.IndexOf(fat, SubArray(fat, begin, end - begin + 1).Max());
                    case 'f':
                        return Array.IndexOf(fat, SubArray(fat, begin, end - begin + 1).Min());
                    case 'T':
                        return Array.IndexOf(cals, SubArray(cals, begin, end - begin + 1).Max());
                    case 't':
                        return Array.IndexOf(cals, SubArray(cals, begin, end - begin + 1).Min());
                    default:
                        return -1;
                }
            }
        }

        private static int[] SubArray(int[] arr, int index, int length)
        {
            int[] result = new int[length];
            Array.Copy(arr, index, result, 0, length);
            return result;
        }

        public static int[] SelectMeals(int[] protein, int[] carbs, int[] fat, string[] dietPlans)
        {
            int[] cals = new int[protein.Length];
            for (int i = 0; i < cals.Length; i++)
                cals[i] = protein[i] * 5 + carbs[i] * 5 + fat[i] * 9;

            int[] mealIndices = new int[dietPlans.Length];
            for (int p = 0; p < dietPlans.Length; p++)
            {
                string dietPlan = dietPlans[p];
                int mealIndex;
                if (dietPlan.Length > 0)
                    mealIndex = GetMealIndex(protein, carbs, fat, cals, 0, protein.Length - 1, dietPlan, 0);
                else
                    mealIndex = 0;
                mealIndices[p] = mealIndex;
            }

            return mealIndices;
        }
    }
}
