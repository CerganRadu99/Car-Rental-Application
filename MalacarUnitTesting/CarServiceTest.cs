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
    [TestClass]
    public class CarServiceTest
    {
        private static CarService carService;
        private List<Car> expectedAllCars = new List<Car>();
        private List<Car> expectedCarsByCondition = new List<Car>();

        [AssemblyInitialize]
        public static void AssemblyInit(TestContext testContext)
        {
            var options = new DbContextOptionsBuilder<CarContext>().UseInMemoryDatabase(databaseName: "MalacarDB").Options;
            CarContext carContext = new CarContext(options);
            IRepositoryWrapper repositoryWrapper = new RepositoryWrapper(carContext);
            carService = new CarService(repositoryWrapper);
            populateDatabase();
        }
        private static void populateDatabase()
        {
            carService.AddCar(new Car
            {
                CarId = 1,
                Plate = "DJ 03 RDC",
                Brand = "Audi",
                Price = 80.00,
            });
            carService.AddCar(new Car
            {
                CarId = 2,
                Plate = "DJ 99 TBY",
                Brand = "Matiz",
                Price = 20.00,
            });
            carService.AddCar(new Car
            {
                CarId = 3,
                Plate = "DJ 03 RDC",
                Brand = "Audi",
                Price = 80.00,
            });
            carService.Save();
        }

        [TestMethod]
        public void TestGetCars_HappyFlow()
        {
            //arrange
            populateExpectedAllCars();

            //act
            List<Car> actualCars = carService.GetCars();

            //assert
            Assert.AreEqual(3, actualCars.Count);
            for(int index = 0; index < actualCars.Count; index++)
            {
                Car actualCar = actualCars[index];
                Car expectedCar = expectedAllCars[index];
                Assert.AreEqual(expectedCar, actualCar);
            }
        }

        [TestMethod]
        public void TestGetCarsByCondition_HappyFlow()
        {
            //arrange
            populateExpectedCarsByCondition();

            //act
            List<Car> actualCars = carService.GetCarsByCondition(car => car.Brand.Equals("Audi"));

            //assert
            Assert.AreEqual(2, actualCars.Count);
            for (int index = 0; index < actualCars.Count; index++)
            {
                Car actualCar = actualCars[index];
                Car expectedCar = expectedCarsByCondition[index];
                Assert.AreEqual(expectedCar, actualCar);
            }
        }

        [TestMethod]
        public void TestAddCar_HappyFlow()
        {
            Car newCar = new Car
            {
                CarId = 4,
                Plate = "DJ 03 RDC",
                Brand = "Opel",
                Price = 80.00,
            };
            //act
            carService.AddCar(newCar);

            carService.Save();
            List<Car> actualCars = carService.GetCars();
            Assert.AreEqual(4, actualCars.Count);
            carService.DeleteCar(newCar);
            carService.Save();
        }

        [TestMethod]
        public void TestDeleteCar_HappyFlow()
        {
            Car newCar = new Car
            {
                CarId = 5,
                Plate = "DJ 03 RDC",
                Brand = "Opel",
                Price = 80.00,
            };

            carService.AddCar(newCar);
            carService.Save();

            //act
            carService.DeleteCar(newCar);

            carService.Save();
            List<Car> actualCars = carService.GetCars();
            Assert.AreEqual(3, actualCars.Count);
        }

        [TestMethod]
        public void TestUpdateCar_HapyyFlow()
        {
            Car carToEdit = new Car
            {
                CarId = 4,
                Plate = "DJ 03 RDC",
                Brand = "Opel",
                Price = 80.00,
            };
            carService.AddCar(carToEdit);
            carService.Save();
            
            //modify car
            carToEdit.Plate = "B 01 WWW";

            //act
            carService.UpdateCar(carToEdit);

            carService.Save();
            List<Car> actualCars = carService.GetCarsByCondition(car => car.CarId == 4);
            Car updatedCar = actualCars[0];
            Assert.AreEqual("B 01 WWW", updatedCar.Plate);
            carService.DeleteCar(carToEdit);
            carService.Save();
        }

        private void populateExpectedCarsByCondition()
        {
            expectedCarsByCondition.Add(new Car
            {
                CarId = 1,
                Plate = "DJ 03 RDC",
                Brand = "Audi",
                Price = 80.00,
            });
            expectedCarsByCondition.Add(new Car
            {
                CarId = 3,
                Plate = "DJ 03 RDC",
                Brand = "Audi",
                Price = 80.00,
            });
        }

        private void populateExpectedAllCars()
        {
            expectedAllCars.Add(new Car
            {
                CarId = 1,
                Plate = "DJ 03 RDC",
                Brand = "Audi",
                Price = 80.00,
            });
            expectedAllCars.Add(new Car
            {
                CarId = 2,
                Plate = "DJ 99 TBY",
                Brand = "Matiz",
                Price = 20.00,
            });
            expectedAllCars.Add(new Car
            {
                CarId = 3,
                Plate = "DJ 03 RDC",
                Brand = "Audi",
                Price = 80.00,
            });
        }
    }
}
