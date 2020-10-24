// --------------------------------------------------------------------------------
/*  Copyright © 2020, Yasgar Technology Group, Inc.

    Purpose: Generate test data for the In Memory database

    Description: This class is used to generate the Lookup categories and Items that
                 are used in this application. This would normally be used when writing
                 unit tests, but is well suited for this Demo application.

                 No changes to the data in this UI will persist when the application is
                 shut down.

    Any place where there is non-boilerplate code that is of interest, I have added
    comments.

*/
// --------------------------------------------------------------------------------

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

using System;
using System.Linq;

using YTG.Lookups.Repository.Models;

namespace YTG.Lookups.Repository.Context
{

    /// <summary>
    /// LookupsGenerator class to produce data for the data context for this application
    /// Yasgar Technology Group, Inc. http://www.ytgi.com
    /// htts://jackyasgar.net
    /// </summary>
    public class LookupsGenerator
    {


        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public LookupsGenerator() { }

        #endregion // Constructors

        #region Methods

        /// <summary>
        /// Main initialization of the LookupsGenerator
        /// </summary>
        /// <param name="serviceProvider"></param>
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (LookupsDBContext context = new LookupsDBContext(
                serviceProvider.GetRequiredService<DbContextOptions<LookupsDBContext>>()))
            {
                // Look for any categories
                if (context.LuCategories.Any())
                {
                    return;   // Data was already seeded
                }

                Seed(context);

            }
        }

        /// <summary>
        /// Main Seed method that calls all the other Seed methods with one LookupsDBContext reference
        /// </summary>
        /// <param name="dbContext"></param>
        /// <returns></returns>
        public static bool Seed(LookupsDBContext dbContext)
        {

            SeedLuCategories(dbContext);
            SeedLuItems(dbContext);

            return true;

        }

        /// <summary>
        /// Seed the LuCategories, the parent object for LuItems
        /// </summary>
        /// <param name="dbContext"></param>
        private static void SeedLuCategories(LookupsDBContext dbContext)
        {

            dbContext.LuCategories.AddRange(
                new LuCategories
                {
                    DateAdded = DateTime.Now,
                    DateMod = DateTime.Now,
                    Description = "Greeting Salutations",
                    Id = 1,
                    IsActive = true,
                    Name = "Salutations",
                    ShortName = "SALUTATIONS",
                    WhoAdd = "jim@bob.com",
                    WhoMod = "jim@bob.com"
                },
                new LuCategories
                {
                    DateAdded = DateTime.Now,
                    DateMod = DateTime.Now,
                    Description = "Vehicle Makes",
                    Id = 2,
                    IsActive = true,
                    Name = "Vehicle Makes",
                    ShortName = "VEHICLEMAKES",
                    WhoAdd = "bob@jim.com",
                    WhoMod = "bob@jim.com"
                }
                );

            for (int counter = 3; counter < 53; counter++)
            {
                LuCategories _cat = new LuCategories
                {
                    DateAdded = DateTime.Now,
                    DateMod = DateTime.Now,
                    Description = "Category Entry Description" + counter.ToString(),
                    Id = counter,
                    IsActive = true,
                    Name = "Category Name " + counter.ToString(),
                    ShortName = "CATEGORY" + counter.ToString(),
                    WhoAdd = "bob@jim.com",
                    WhoMod = "bob@jim.com"
                };

                dbContext.LuCategories.Add(_cat);

            }

            dbContext.SaveChanges();

        }


        /// <summary>
        /// Seed the LuItems which are the child items to LuCategories
        /// </summary>
        /// <param name="dbContext"></param>
        private static void SeedLuItems(LookupsDBContext dbContext)
        {

            long _catId = 1;
            int _enum = 1;
            long _id = 1;
            dbContext.LuItems.AddRange(
                new LuItems
                {
                    DateAdded = DateTime.Now,
                    DateMod = DateTime.Now,
                    EnumValue = _enum++,
                    LuBoolean = false,
                    LuCatId = _catId,
                    LuCode = "MR",
                    LuItemDesc = "Mister",
                    LuValue = "Mr.",
                    Id = _id++,
                    IsActive = true,
                    WhoAdd = "jim@bob.com",
                    WhoMod = "jim@bob.com"
                },
                new LuItems
                {
                    DateAdded = DateTime.Now,
                    DateMod = DateTime.Now,
                    EnumValue = _enum++,
                    LuBoolean = false,
                    LuCatId = _catId,
                    LuCode = "MRS",
                    LuItemDesc = "Misses",
                    LuValue = "Mrs.",
                    Id = _id++,
                    IsActive = true,
                    WhoAdd = "jim@bob.com",
                    WhoMod = "jim@bob.com"
                },
                new LuItems
                {
                    DateAdded = DateTime.Now,
                    DateMod = DateTime.Now,
                    EnumValue = _enum++,
                    LuBoolean = false,
                    LuCatId = _catId,
                    LuCode = "MS",
                    LuItemDesc = "Miss",
                    LuValue = "Ms.",
                    Id = _id++,
                    IsActive = true,
                    WhoAdd = "jim@bob.com",
                    WhoMod = "jim@bob.com"
                }
                );

            _enum = 1;
            _catId = 2;
            dbContext.LuItems.AddRange(
                new LuItems
                {
                    DateAdded = DateTime.Now,
                    DateMod = DateTime.Now,
                    EnumValue = _enum++,
                    LuBoolean = false,
                    LuCatId = _catId,
                    LuCode = "Acura",
                    LuItemDesc = "Acura",
                    LuValue = "Acura",
                    Id = _id++,
                    IsActive = true,
                    WhoAdd = "jim@bob.com",
                    WhoMod = "jim@bob.com"
                },
                new LuItems
                {
                    DateAdded = DateTime.Now,
                    DateMod = DateTime.Now,
                    EnumValue = _enum++,
                    LuBoolean = false,
                    LuCatId = _catId,
                    LuCode = "AlfaRomeo",
                    LuItemDesc = "Alfa-Romeo",
                    LuValue = "Alfa-Romeo",
                    Id = _id++,
                    IsActive = true,
                    WhoAdd = "jim@bob.com",
                    WhoMod = "jim@bob.com"
                },
                new LuItems
                {
                    DateAdded = DateTime.Now,
                    DateMod = DateTime.Now,
                    EnumValue = _enum++,
                    LuBoolean = false,
                    LuCatId = _catId,
                    LuCode = "AstonMartin",
                    LuItemDesc = "Aston-Martin",
                    LuValue = "Aston-Martin",
                    Id = _id++,
                    IsActive = true,
                    WhoAdd = "jim@bob.com",
                    WhoMod = "jim@bob.com"
                },
                new LuItems
                {
                    DateAdded = DateTime.Now,
                    DateMod = DateTime.Now,
                    EnumValue = _enum++,
                    LuBoolean = false,
                    LuCatId = _catId,
                    LuCode = "Audi",
                    LuItemDesc = "Audi",
                    LuValue = "Audi",
                    Id = _id++,
                    IsActive = true,
                    WhoAdd = "jim@bob.com",
                    WhoMod = "jim@bob.com"
                },
                new LuItems
                {
                    DateAdded = DateTime.Now,
                    DateMod = DateTime.Now,
                    EnumValue = _enum++,
                    LuBoolean = false,
                    LuCatId = _catId,
                    LuCode = "Bentley",
                    LuItemDesc = "Bentley",
                    LuValue = "Bentley",
                    Id = _id++,
                    IsActive = true,
                    WhoAdd = "jim@bob.com",
                    WhoMod = "jim@bob.com"
                },
                new LuItems
                {
                    DateAdded = DateTime.Now,
                    DateMod = DateTime.Now,
                    EnumValue = _enum++,
                    LuBoolean = false,
                    LuCatId = _catId,
                    LuCode = "BMW",
                    LuItemDesc = "BMW",
                    LuValue = "BMW",
                    Id = _id++,
                    IsActive = true,
                    WhoAdd = "jim@bob.com",
                    WhoMod = "jim@bob.com"
                },
                new LuItems
                {
                    DateAdded = DateTime.Now,
                    DateMod = DateTime.Now,
                    EnumValue = _enum++,
                    LuBoolean = false,
                    LuCatId = _catId,
                    LuCode = "Bugatti",
                    LuItemDesc = "Bugatti",
                    LuValue = "Bugatti",
                    Id = _id++,
                    IsActive = true,
                    WhoAdd = "jim@bob.com",
                    WhoMod = "jim@bob.com"
                },
                new LuItems
                {
                    DateAdded = DateTime.Now,
                    DateMod = DateTime.Now,
                    EnumValue = _enum++,
                    LuBoolean = false,
                    LuCatId = _catId,
                    LuCode = "Buick",
                    LuItemDesc = "Buick",
                    LuValue = "Buick",
                    Id = _id++,
                    IsActive = true,
                    WhoAdd = "jim@bob.com",
                    WhoMod = "jim@bob.com"
                },
                new LuItems
                {
                    DateAdded = DateTime.Now,
                    DateMod = DateTime.Now,
                    EnumValue = _enum++,
                    LuBoolean = false,
                    LuCatId = _catId,
                    LuCode = "Cadillac",
                    LuItemDesc = "Cadillac",
                    LuValue = "Cadillac",
                    Id = _id++,
                    IsActive = true,
                    WhoAdd = "jim@bob.com",
                    WhoMod = "jim@bob.com"
                },
                new LuItems
                {
                    DateAdded = DateTime.Now,
                    DateMod = DateTime.Now,
                    EnumValue = _enum++,
                    LuBoolean = false,
                    LuCatId = _catId,
                    LuCode = "Chevrolet",
                    LuItemDesc = "Chevrolet",
                    LuValue = "Chevrolet",
                    Id = _id++,
                    IsActive = true,
                    WhoAdd = "jim@bob.com",
                    WhoMod = "jim@bob.com"
                },
                new LuItems
                {
                    DateAdded = DateTime.Now,
                    DateMod = DateTime.Now,
                    EnumValue = _enum++,
                    LuBoolean = false,
                    LuCatId = _catId,
                    LuCode = "Chrysler",
                    LuItemDesc = "Chrysler",
                    LuValue = "Chrysler",
                    Id = _id++,
                    IsActive = true,
                    WhoAdd = "jim@bob.com",
                    WhoMod = "jim@bob.com"
                },
                new LuItems
                {
                    DateAdded = DateTime.Now,
                    DateMod = DateTime.Now,
                    EnumValue = _enum++,
                    LuBoolean = false,
                    LuCatId = _catId,
                    LuCode = "Citroen",
                    LuItemDesc = "Citroen",
                    LuValue = "Citroen",
                    Id = _id++,
                    IsActive = true,
                    WhoAdd = "jim@bob.com",
                    WhoMod = "jim@bob.com"
                },
                new LuItems
                {
                    DateAdded = DateTime.Now,
                    DateMod = DateTime.Now,
                    EnumValue = _enum++,
                    LuBoolean = false,
                    LuCatId = _catId,
                    LuCode = "Dodge",
                    LuItemDesc = "Dodge",
                    LuValue = "Dodge",
                    Id = _id++,
                    IsActive = true,
                    WhoAdd = "jim@bob.com",
                    WhoMod = "jim@bob.com"
                },
                new LuItems
                {
                    DateAdded = DateTime.Now,
                    DateMod = DateTime.Now,
                    EnumValue = _enum++,
                    LuBoolean = false,
                    LuCatId = _catId,
                    LuCode = "Ferrari",
                    LuItemDesc = "Ferrari",
                    LuValue = "Ferrari",
                    Id = _id++,
                    IsActive = true,
                    WhoAdd = "jim@bob.com",
                    WhoMod = "jim@bob.com"
                },
                new LuItems
                {
                    DateAdded = DateTime.Now,
                    DateMod = DateTime.Now,
                    EnumValue = _enum++,
                    LuBoolean = false,
                    LuCatId = _catId,
                    LuCode = "Fiat",
                    LuItemDesc = "Fiat",
                    LuValue = "Fiat",
                    Id = _id++,
                    IsActive = true,
                    WhoAdd = "jim@bob.com",
                    WhoMod = "jim@bob.com"
                },
                new LuItems
                {
                    DateAdded = DateTime.Now,
                    DateMod = DateTime.Now,
                    EnumValue = _enum++,
                    LuBoolean = false,
                    LuCatId = _catId,
                    LuCode = "Ford",
                    LuItemDesc = "Ford",
                    LuValue = "Ford",
                    Id = _id++,
                    IsActive = true,
                    WhoAdd = "jim@bob.com",
                    WhoMod = "jim@bob.com"
                },
                new LuItems
                {
                    DateAdded = DateTime.Now,
                    DateMod = DateTime.Now,
                    EnumValue = _enum++,
                    LuBoolean = false,
                    LuCatId = _catId,
                    LuCode = "Geely",
                    LuItemDesc = "Geely",
                    LuValue = "Geely",
                    Id = _id++,
                    IsActive = true,
                    WhoAdd = "jim@bob.com",
                    WhoMod = "jim@bob.com"
                },
                new LuItems
                {
                    DateAdded = DateTime.Now,
                    DateMod = DateTime.Now,
                    EnumValue = _enum++,
                    LuBoolean = false,
                    LuCatId = _catId,
                    LuCode = "Genesis",
                    LuItemDesc = "Genesis",
                    LuValue = "Genesis",
                    Id = _id++,
                    IsActive = true,
                    WhoAdd = "jim@bob.com",
                    WhoMod = "jim@bob.com"
                },
                new LuItems
                {
                    DateAdded = DateTime.Now,
                    DateMod = DateTime.Now,
                    EnumValue = _enum++,
                    LuBoolean = false,
                    LuCatId = _catId,
                    LuCode = "GMC",
                    LuItemDesc = "GMC",
                    LuValue = "GMC",
                    Id = _id++,
                    IsActive = true,
                    WhoAdd = "jim@bob.com",
                    WhoMod = "jim@bob.com"
                },
                new LuItems
                {
                    DateAdded = DateTime.Now,
                    DateMod = DateTime.Now,
                    EnumValue = _enum++,
                    LuBoolean = false,
                    LuCatId = _catId,
                    LuCode = "Honda",
                    LuItemDesc = "Honda",
                    LuValue = "Honda",
                    Id = _id++,
                    IsActive = true,
                    WhoAdd = "jim@bob.com",
                    WhoMod = "jim@bob.com"
                },
                new LuItems
                {
                    DateAdded = DateTime.Now,
                    DateMod = DateTime.Now,
                    EnumValue = _enum++,
                    LuBoolean = false,
                    LuCatId = _catId,
                    LuCode = "Hyundai",
                    LuItemDesc = "Hyundai",
                    LuValue = "Hyundai",
                    Id = _id++,
                    IsActive = true,
                    WhoAdd = "jim@bob.com",
                    WhoMod = "jim@bob.com"
                },
                new LuItems
                {
                    DateAdded = DateTime.Now,
                    DateMod = DateTime.Now,
                    EnumValue = _enum++,
                    LuBoolean = false,
                    LuCatId = _catId,
                    LuCode = "Infiniti",
                    LuItemDesc = "Infiniti",
                    LuValue = "Infiniti",
                    Id = _id++,
                    IsActive = true,
                    WhoAdd = "jim@bob.com",
                    WhoMod = "jim@bob.com"
                },
                new LuItems
                {
                    DateAdded = DateTime.Now,
                    DateMod = DateTime.Now,
                    EnumValue = _enum++,
                    LuBoolean = false,
                    LuCatId = _catId,
                    LuCode = "Jaguar",
                    LuItemDesc = "Jaguar",
                    LuValue = "Jaguar",
                    Id = _id++,
                    IsActive = true,
                    WhoAdd = "jim@bob.com",
                    WhoMod = "jim@bob.com"
                },
                new LuItems
                {
                    DateAdded = DateTime.Now,
                    DateMod = DateTime.Now,
                    EnumValue = _enum++,
                    LuBoolean = false,
                    LuCatId = _catId,
                    LuCode = "Jeep",
                    LuItemDesc = "Jeep",
                    LuValue = "Jeep",
                    Id = _id++,
                    IsActive = true,
                    WhoAdd = "jim@bob.com",
                    WhoMod = "jim@bob.com"
                },
                new LuItems
                {
                    DateAdded = DateTime.Now,
                    DateMod = DateTime.Now,
                    EnumValue = _enum++,
                    LuBoolean = false,
                    LuCatId = _catId,
                    LuCode = "Kia",
                    LuItemDesc = "Kia",
                    LuValue = "Kia",
                    Id = _id++,
                    IsActive = true,
                    WhoAdd = "jim@bob.com",
                    WhoMod = "jim@bob.com"
                },
                new LuItems
                {
                    DateAdded = DateTime.Now,
                    DateMod = DateTime.Now,
                    EnumValue = _enum++,
                    LuBoolean = false,
                    LuCatId = _catId,
                    LuCode = "Koenigsegg",
                    LuItemDesc = "Koenigsegg",
                    LuValue = "Koenigsegg",
                    Id = _id++,
                    IsActive = true,
                    WhoAdd = "jim@bob.com",
                    WhoMod = "jim@bob.com"
                },
                new LuItems
                {
                    DateAdded = DateTime.Now,
                    DateMod = DateTime.Now,
                    EnumValue = _enum++,
                    LuBoolean = false,
                    LuCatId = _catId,
                    LuCode = "Lamborghini",
                    LuItemDesc = "Lamborghini",
                    LuValue = "Lamborghini",
                    Id = _id++,
                    IsActive = true,
                    WhoAdd = "jim@bob.com",
                    WhoMod = "jim@bob.com"
                },
                new LuItems
                {
                    DateAdded = DateTime.Now,
                    DateMod = DateTime.Now,
                    EnumValue = _enum++,
                    LuBoolean = false,
                    LuCatId = _catId,
                    LuCode = "Lancia",
                    LuItemDesc = "Lancia",
                    LuValue = "Lancia",
                    Id = _id++,
                    IsActive = true,
                    WhoAdd = "jim@bob.com",
                    WhoMod = "jim@bob.com"
                },
                new LuItems
                {
                    DateAdded = DateTime.Now,
                    DateMod = DateTime.Now,
                    EnumValue = _enum++,
                    LuBoolean = false,
                    LuCatId = _catId,
                    LuCode = "LandRover",
                    LuItemDesc = "Land Rover",
                    LuValue = "Land Rover",
                    Id = _id++,
                    IsActive = true,
                    WhoAdd = "jim@bob.com",
                    WhoMod = "jim@bob.com"
                },
                new LuItems
                {
                    DateAdded = DateTime.Now,
                    DateMod = DateTime.Now,
                    EnumValue = _enum++,
                    LuBoolean = false,
                    LuCatId = _catId,
                    LuCode = "Lexus",
                    LuItemDesc = "Lexus",
                    LuValue = "Lexus",
                    Id = _id++,
                    IsActive = true,
                    WhoAdd = "jim@bob.com",
                    WhoMod = "jim@bob.com"
                },
                new LuItems
                {
                    DateAdded = DateTime.Now,
                    DateMod = DateTime.Now,
                    EnumValue = _enum++,
                    LuBoolean = false,
                    LuCatId = _catId,
                    LuCode = "Lincoln",
                    LuItemDesc = "Lincoln",
                    LuValue = "Lincoln",
                    Id = _id++,
                    IsActive = true,
                    WhoAdd = "jim@bob.com",
                    WhoMod = "jim@bob.com"
                },
                new LuItems
                {
                    DateAdded = DateTime.Now,
                    DateMod = DateTime.Now,
                    EnumValue = _enum++,
                    LuBoolean = false,
                    LuCatId = _catId,
                    LuCode = "Lotus",
                    LuItemDesc = "Lotus",
                    LuValue = "Lotus",
                    Id = _id++,
                    IsActive = true,
                    WhoAdd = "jim@bob.com",
                    WhoMod = "jim@bob.com"
                },
                new LuItems
                {
                    DateAdded = DateTime.Now,
                    DateMod = DateTime.Now,
                    EnumValue = _enum++,
                    LuBoolean = false,
                    LuCatId = _catId,
                    LuCode = "Maserati",
                    LuItemDesc = "Maserati",
                    LuValue = "Maserati",
                    Id = _id++,
                    IsActive = true,
                    WhoAdd = "jim@bob.com",
                    WhoMod = "jim@bob.com"
                },
                new LuItems
                {
                    DateAdded = DateTime.Now,
                    DateMod = DateTime.Now,
                    EnumValue = _enum++,
                    LuBoolean = false,
                    LuCatId = _catId,
                    LuCode = "Maybach",
                    LuItemDesc = "Maybach",
                    LuValue = "Maybach",
                    Id = _id++,
                    IsActive = true,
                    WhoAdd = "jim@bob.com",
                    WhoMod = "jim@bob.com"
                },
                new LuItems
                {
                    DateAdded = DateTime.Now,
                    DateMod = DateTime.Now,
                    EnumValue = _enum++,
                    LuBoolean = false,
                    LuCatId = _catId,
                    LuCode = "Mazda",
                    LuItemDesc = "Mazda",
                    LuValue = "Mazda",
                    Id = _id++,
                    IsActive = true,
                    WhoAdd = "jim@bob.com",
                    WhoMod = "jim@bob.com"
                },
                new LuItems
                {
                    DateAdded = DateTime.Now,
                    DateMod = DateTime.Now,
                    EnumValue = _enum++,
                    LuBoolean = false,
                    LuCatId = _catId,
                    LuCode = "McLaren",
                    LuItemDesc = "McLaren",
                    LuValue = "McLaren",
                    Id = _id++,
                    IsActive = true,
                    WhoAdd = "jim@bob.com",
                    WhoMod = "jim@bob.com"
                },
                new LuItems
                {
                    DateAdded = DateTime.Now,
                    DateMod = DateTime.Now,
                    EnumValue = _enum++,
                    LuBoolean = false,
                    LuCatId = _catId,
                    LuCode = "Mercedes",
                    LuItemDesc = "Mercedes",
                    LuValue = "Mercedes",
                    Id = _id++,
                    IsActive = true,
                    WhoAdd = "jim@bob.com",
                    WhoMod = "jim@bob.com"
                },
                new LuItems
                {
                    DateAdded = DateTime.Now,
                    DateMod = DateTime.Now,
                    EnumValue = _enum++,
                    LuBoolean = false,
                    LuCatId = _catId,
                    LuCode = "Mini",
                    LuItemDesc = "Mini",
                    LuValue = "Mini",
                    Id = _id++,
                    IsActive = true,
                    WhoAdd = "jim@bob.com",
                    WhoMod = "jim@bob.com"
                },
                new LuItems
                {
                    DateAdded = DateTime.Now,
                    DateMod = DateTime.Now,
                    EnumValue = _enum++,
                    LuBoolean = false,
                    LuCatId = _catId,
                    LuCode = "Mitsubishi",
                    LuItemDesc = "Mitsubishi",
                    LuValue = "Mitsubishi",
                    Id = _id++,
                    IsActive = true,
                    WhoAdd = "jim@bob.com",
                    WhoMod = "jim@bob.com"
                },
                new LuItems
                {
                    DateAdded = DateTime.Now,
                    DateMod = DateTime.Now,
                    EnumValue = _enum++,
                    LuBoolean = false,
                    LuCatId = _catId,
                    LuCode = "Nissan",
                    LuItemDesc = "Nissan",
                    LuValue = "Nissan",
                    Id = _id++,
                    IsActive = true,
                    WhoAdd = "jim@bob.com",
                    WhoMod = "jim@bob.com"
                },
                new LuItems
                {
                    DateAdded = DateTime.Now,
                    DateMod = DateTime.Now,
                    EnumValue = _enum++,
                    LuBoolean = false,
                    LuCatId = _catId,
                    LuCode = "Opel",
                    LuItemDesc = "Opel",
                    LuValue = "Opel",
                    Id = _id++,
                    IsActive = true,
                    WhoAdd = "jim@bob.com",
                    WhoMod = "jim@bob.com"
                },
                new LuItems
                {
                    DateAdded = DateTime.Now,
                    DateMod = DateTime.Now,
                    EnumValue = _enum++,
                    LuBoolean = false,
                    LuCatId = _catId,
                    LuCode = "Pagani",
                    LuItemDesc = "Pagani",
                    LuValue = "Pagani",
                    Id = _id++,
                    IsActive = true,
                    WhoAdd = "jim@bob.com",
                    WhoMod = "jim@bob.com"
                },
                new LuItems
                {
                    DateAdded = DateTime.Now,
                    DateMod = DateTime.Now,
                    EnumValue = _enum++,
                    LuBoolean = false,
                    LuCatId = _catId,
                    LuCode = "Peugeot",
                    LuItemDesc = "Peugeot",
                    LuValue = "Peugeot",
                    Id = _id++,
                    IsActive = true,
                    WhoAdd = "jim@bob.com",
                    WhoMod = "jim@bob.com"
                },
                new LuItems
                {
                    DateAdded = DateTime.Now,
                    DateMod = DateTime.Now,
                    EnumValue = _enum++,
                    LuBoolean = false,
                    LuCatId = _catId,
                    LuCode = "Pontiac",
                    LuItemDesc = "Pontiac",
                    LuValue = "Pontiac",
                    Id = _id++,
                    IsActive = true,
                    WhoAdd = "jim@bob.com",
                    WhoMod = "jim@bob.com"
                },
                new LuItems
                {
                    DateAdded = DateTime.Now,
                    DateMod = DateTime.Now,
                    EnumValue = _enum++,
                    LuBoolean = false,
                    LuCatId = _catId,
                    LuCode = "Porshe",
                    LuItemDesc = "Porshe",
                    LuValue = "Porshe",
                    Id = _id++,
                    IsActive = true,
                    WhoAdd = "jim@bob.com",
                    WhoMod = "jim@bob.com"
                },
                new LuItems
                {
                    DateAdded = DateTime.Now,
                    DateMod = DateTime.Now,
                    EnumValue = _enum++,
                    LuBoolean = false,
                    LuCatId = _catId,
                    LuCode = "MS",
                    LuItemDesc = "Ram",
                    LuValue = "Ms.",
                    Id = _id++,
                    IsActive = true,
                    WhoAdd = "jim@bob.com",
                    WhoMod = "jim@bob.com"
                },
                new LuItems
                {
                    DateAdded = DateTime.Now,
                    DateMod = DateTime.Now,
                    EnumValue = _enum++,
                    LuBoolean = false,
                    LuCatId = _catId,
                    LuCode = "Renault",
                    LuItemDesc = "Renault",
                    LuValue = "Renault",
                    Id = _id++,
                    IsActive = true,
                    WhoAdd = "jim@bob.com",
                    WhoMod = "jim@bob.com"
                },
                new LuItems
                {
                    DateAdded = DateTime.Now,
                    DateMod = DateTime.Now,
                    EnumValue = _enum++,
                    LuBoolean = false,
                    LuCatId = _catId,
                    LuCode = "RollsRoyce",
                    LuItemDesc = "Rolls-Royce",
                    LuValue = "Rolls-Royce",
                    Id = _id++,
                    IsActive = true,
                    WhoAdd = "jim@bob.com",
                    WhoMod = "jim@bob.com"
                },
                new LuItems
                {
                    DateAdded = DateTime.Now,
                    DateMod = DateTime.Now,
                    EnumValue = _enum++,
                    LuBoolean = false,
                    LuCatId = _catId,
                    LuCode = "Skoda",
                    LuItemDesc = "Skoda",
                    LuValue = "Skoda",
                    Id = _id++,
                    IsActive = true,
                    WhoAdd = "jim@bob.com",
                    WhoMod = "jim@bob.com"
                },
                new LuItems
                {
                    DateAdded = DateTime.Now,
                    DateMod = DateTime.Now,
                    EnumValue = _enum++,
                    LuBoolean = false,
                    LuCatId = _catId,
                    LuCode = "Smart",
                    LuItemDesc = "Smart",
                    LuValue = "Smart",
                    Id = _id++,
                    IsActive = true,
                    WhoAdd = "jim@bob.com",
                    WhoMod = "jim@bob.com"
                },
                new LuItems
                {
                    DateAdded = DateTime.Now,
                    DateMod = DateTime.Now,
                    EnumValue = _enum++,
                    LuBoolean = false,
                    LuCatId = _catId,
                    LuCode = "Subaru",
                    LuItemDesc = "Subaru",
                    LuValue = "Subaru",
                    Id = _id++,
                    IsActive = true,
                    WhoAdd = "jim@bob.com",
                    WhoMod = "jim@bob.com"
                },
                new LuItems
                {
                    DateAdded = DateTime.Now,
                    DateMod = DateTime.Now,
                    EnumValue = _enum++,
                    LuBoolean = false,
                    LuCatId = _catId,
                    LuCode = "Suzuki",
                    LuItemDesc = "Suzuki",
                    LuValue = "Suzuki",
                    Id = _id++,
                    IsActive = true,
                    WhoAdd = "jim@bob.com",
                    WhoMod = "jim@bob.com"
                },
                new LuItems
                {
                    DateAdded = DateTime.Now,
                    DateMod = DateTime.Now,
                    EnumValue = _enum++,
                    LuBoolean = false,
                    LuCatId = _catId,
                    LuCode = "Tesla",
                    LuItemDesc = "Tesla",
                    LuValue = "Tesla",
                    Id = _id++,
                    IsActive = true,
                    WhoAdd = "jim@bob.com",
                    WhoMod = "jim@bob.com"
                },
                new LuItems
                {
                    DateAdded = DateTime.Now,
                    DateMod = DateTime.Now,
                    EnumValue = _enum++,
                    LuBoolean = false,
                    LuCatId = _catId,
                    LuCode = "Toyota",
                    LuItemDesc = "Toyota",
                    LuValue = "Toyota",
                    Id = _id++,
                    IsActive = true,
                    WhoAdd = "jim@bob.com",
                    WhoMod = "jim@bob.com"
                },
                new LuItems
                {
                    DateAdded = DateTime.Now,
                    DateMod = DateTime.Now,
                    EnumValue = _enum++,
                    LuBoolean = false,
                    LuCatId = _catId,
                    LuCode = "Volkswagen",
                    LuItemDesc = "Volkswagen",
                    LuValue = "Volkswagen",
                    Id = _id++,
                    IsActive = true,
                    WhoAdd = "jim@bob.com",
                    WhoMod = "jim@bob.com"
                },
                new LuItems
                {
                    DateAdded = DateTime.Now,
                    DateMod = DateTime.Now,
                    EnumValue = _enum++,
                    LuBoolean = false,
                    LuCatId = _catId,
                    LuCode = "Volvo",
                    LuItemDesc = "Volvo",
                    LuValue = "Volvo",
                    Id = _id++,
                    IsActive = true,
                    WhoAdd = "jim@bob.com",
                    WhoMod = "jim@bob.com"
                }
                );


            dbContext.SaveChanges();

        }

        #endregion // Methods


    }
}



