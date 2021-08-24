using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // SETUP
            List<SpecialOffer> specialOfferList = Setup();
            // SETUP

            // CALCULATION
            List<OptimizedSpecialOffer> optimizedSpecialOfferList = new List<OptimizedSpecialOffer>();
            for (int i = 0; i < specialOfferList.Count; i++)
            {
                decimal totalDiscountRate = specialOfferList.Where(specialOffer => specialOfferList[i].CombinableWith.Contains(specialOffer.ID)).Select(specialOffer => specialOffer.DiscountRate).Sum() + specialOfferList[i].DiscountRate;
                optimizedSpecialOfferList.Add(new OptimizedSpecialOffer
                {
                    SpecialOfferList = string.Join(",", new int[] { specialOfferList[i].ID }.Concat(specialOfferList[i].CombinableWith)),
                    TotalDiscountRate = totalDiscountRate

                });
            }
            // CALCULATION

            // OUTPUT
            Console.WriteLine("Discount ID List \tTotal Discount Rate");
            foreach (OptimizedSpecialOffer specialOffer in optimizedSpecialOfferList.OrderByDescending(specialOffer => specialOffer.TotalDiscountRate))
            {
                Console.WriteLine(string.Concat(specialOffer.SpecialOfferList, "\t\t\t\t\t", specialOffer.TotalDiscountRate));
            }
            // OUTPUT
        }


        /// <summary>
        /// Generates example data
        /// </summary>
        /// <returns></returns>
        public static List<SpecialOffer> Setup()
        {
            return new List<SpecialOffer>()
            {
                new SpecialOffer
                {
                    ID = 1,
                    DiscountRate = 2,
                    CombinableWith = new int[] { 2,3 }
                },
                new SpecialOffer
                {
                    ID = 2,
                    DiscountRate = 4,
                    CombinableWith = new int[] {}
                },
                new SpecialOffer
                {
                    ID = 3,
                    DiscountRate = 2,
                    CombinableWith = new int[] {}
                },
                new SpecialOffer
                {
                    ID = 4,
                    DiscountRate = 5,
                    CombinableWith = new int[] {5}
                },
                new SpecialOffer
                {
                    ID = 5,
                    DiscountRate = 10,
                    CombinableWith = new int[] {}
                },
                new SpecialOffer
                {
                    ID = 6,
                    DiscountRate = 15,
                    CombinableWith = new int[] {}
                },
                new SpecialOffer
                {
                    ID = 7,
                    DiscountRate = 9,
                    CombinableWith = new int[] {}
                },
                new SpecialOffer
                {
                    ID = 8,
                    DiscountRate = 1,
                    CombinableWith = new int[] {1}
                }
            };
        }
    }

    /// <summary>
    /// SpecialOffer
    /// </summary>
    public class SpecialOffer
    {
        /// <summary>
        /// Gets from service
        /// </summary>
        public int ID;
        /// <summary>
        /// Gets from service
        /// </summary>
        public decimal DiscountRate;
        /// <summary>
        /// Sets as a result of the calculation
        /// </summary>
        public decimal TotalDiscountAmount;
        /// <summary>
        /// Other offers which combinable
        /// </summary>
        public int[] CombinableWith;
    }

    public class OptimizedSpecialOffer
    {
        /// <summary>
        /// All combined offers
        /// </summary>
        public string SpecialOfferList;
        /// <summary>
        /// Combined offers' total discount rate
        /// </summary>
        public decimal TotalDiscountRate;
    }
}

