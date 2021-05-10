using Malacar.Interfaces;
using Malacar.Models;
using Malacar.Repositories;
using Malacar.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace MalacarUnitTesting
{
    static class RentalDescriptionComparer
    {
        public static void AssertAreEqual(Rental expected, Rental actual)
        {
            Assert.AreEqual(expected.Description, actual.Description);
        }
    }

    static class RentalAllFieldsComparer
    {
        public static void AssertAreEqual(Rental expected, Rental actual)
        {
            Assert.AreEqual(expected.RentalId, actual.RentalId);
            Assert.AreEqual(expected.Description, actual.Description);
            Assert.AreEqual(expected.PickUpLocation, actual.PickUpLocation);
            Assert.AreEqual(expected.DropOffLocation, actual.DropOffLocation);
        }
    }

    [TestClass]
    public class RentalServiceTest
    {
        private static RentalService rentalService;
        private List<Rental> expectedAllRentals = new List<Rental>();
        private List<Rental> expectedRentalsByCondition = new List<Rental>();

        [AssemblyInitialize]
        public static void AssemblyInit(TestContext testContext)
        {
            var options = new DbContextOptionsBuilder<CarContext>().UseInMemoryDatabase(databaseName: "MalacarDB").Options;
            CarContext carContext = new CarContext(options);
            IRepositoryWrapper repositoryWrapper = new RepositoryWrapper(carContext);
            rentalService = new RentalService(repositoryWrapper);
            populateDatabase();
        }
        private static void populateDatabase()
        {
            rentalService.AddRental(new Rental
            {
                RentalId = 1,
                Description = "Achitat",
                PickUpLocation = "Craiova",
                DropOffLocation = "Bucuresti",
            });
            rentalService.AddRental(new Rental
            {
                RentalId = 2,
                Description = "Nechitat",
                PickUpLocation = "Covasna",
                DropOffLocation = "Sibiu",
            });
            rentalService.AddRental(new Rental
            {
                RentalId = 3,
                Description = "Achitat",
                PickUpLocation = "Craiova",
                DropOffLocation = "Bucuresti",
            });
            rentalService.Save();
        }

        [TestMethod]
        public void TestGetRentals_HappyFlow()
        {
            //arrange
            populateExpectedAllRentals();

            //act
            List<Rental> actualRentals = rentalService.GetRentals();

            //assert
            Assert.AreEqual(3, actualRentals.Count);
            for (int index = 0; index < actualRentals.Count; index++)
            {
                Rental actualRental = actualRentals[index];
                Rental expectedRental = expectedAllRentals[index];
                RentalAllFieldsComparer.AssertAreEqual(expectedRental, actualRental);
            }
        }

        [TestMethod]
        public void TestGetRentalsByCondition_HappyFlow()
        {
            //arrange
            populateExpectedRentalsByCondition();

            //act
            List<Rental> actualRentals = rentalService.GetRentalsByCondition(rental => rental.PickUpLocation.Equals("Craiova"));

            //assert
            Assert.AreEqual(2, actualRentals.Count);
            for (int index = 0; index < actualRentals.Count; index++)
            {
                Rental actualRental = actualRentals[index];
                Rental expectedRental = expectedRentalsByCondition[index];
                RentalDescriptionComparer.AssertAreEqual(expectedRental, actualRental);
            }
        }

        [TestMethod]
        public void TestAddRental_HappyFlow()
        {
            Rental newRental = new Rental
            {
                RentalId = 4,
                Description = "Neachitat",
                PickUpLocation = "Craiova",
                DropOffLocation = "Constanta",
            };
            //act
            rentalService.AddRental(newRental);

            rentalService.Save();
            List<Rental> actualRentals = rentalService.GetRentals();
            Assert.AreEqual(4, actualRentals.Count);
            rentalService.DeleteRental(newRental);
            rentalService.Save();
        }

        [TestMethod]
        public void TestDeleteRental_HappyFlow()
        {
            Rental newRental = new Rental
            {
                RentalId = 5,
                Description = "Neachitat",
                PickUpLocation = "Craiova",
                DropOffLocation = "Timisoara",
            };

            rentalService.AddRental(newRental);
            rentalService.Save();

            //act
            rentalService.DeleteRental(newRental);

            rentalService.Save();
            List<Rental> actualRentals = rentalService.GetRentals();
            Assert.AreEqual(3, actualRentals.Count);
        }

        [TestMethod]
        public void TestUpdateRental_HapyyFlow()
        {
            Rental rentalToEdit = new Rental
            {
                RentalId = 4,
                Description = "Achitat",
                PickUpLocation = "Craiova",
                DropOffLocation = "Constanta",
            };
            rentalService.AddRental(rentalToEdit);
            rentalService.Save();

            //modify car
            rentalToEdit.Description = "Neachitat";

            //act
            rentalService.UpdateRental(rentalToEdit);

            rentalService.Save();
            List<Rental> actualRentals = rentalService.GetRentalsByCondition(rental => rental.RentalId == 4);
            Rental updatedRental = actualRentals[0];
            Assert.AreEqual("Neachitat", updatedRental.Description);
            rentalService.DeleteRental(rentalToEdit);
            rentalService.Save();
        }

        private void populateExpectedRentalsByCondition()
        {
            expectedRentalsByCondition.Add(new Rental
            {
                RentalId = 1,
                Description = "Achitat",
                PickUpLocation = "Craiova",
                DropOffLocation = "Bucuresti",
            });
            expectedRentalsByCondition.Add(new Rental
            {
                RentalId = 3,
                Description = "Achitat",
                PickUpLocation = "Craiova",
                DropOffLocation = "Bucuresti",
            });
        }

        private void populateExpectedAllRentals()
        {
            expectedAllRentals.Add(new Rental
            {
                RentalId = 1,
                Description = "Achitat",
                PickUpLocation = "Craiova",
                DropOffLocation = "Bucuresti",
            });
            expectedAllRentals.Add(new Rental
            {
                RentalId = 2,
                Description = "Nechitat",
                PickUpLocation = "Covasna",
                DropOffLocation = "Sibiu",
            });
            expectedAllRentals.Add(new Rental
            {
                RentalId = 3,
                Description = "Achitat",
                PickUpLocation = "Craiova",
                DropOffLocation = "Bucuresti",
            });
        }
    }
}