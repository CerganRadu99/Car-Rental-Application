using Malacar.Interfaces;
using Malacar.Models;
using Malacar.Repositories;
using Malacar.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace MalacarUnitTesting
{
    static class StationNameComparer
    {
        public static void AssertAreEqual(Station expected, Station actual)
        {
            Assert.AreEqual(expected.Name, actual.Name);
        }
    }

    static class StationAllFieldsComparer
    {
        public static void AssertAreEqual(Station expected, Station actual)
        {
            Assert.AreEqual(expected.StationId, actual.StationId);
            Assert.AreEqual(expected.Name, actual.Name);
            Assert.AreEqual(expected.NumberOfEmployees, actual.NumberOfEmployees);
            Assert.AreEqual(expected.NumberOfVehicles, actual.NumberOfVehicles);
        }
    }
    [TestClass]
    public class StationServiceTest
    {
        private static StationService stationService;
        private List<Station> expectedAllStations = new List<Station>();
        private List<Station> expectedStationsByCondition = new List<Station>();

        [AssemblyInitialize]
        public static void AssemblyInit(TestContext testContext)
        {
            var options = new DbContextOptionsBuilder<CarContext>().UseInMemoryDatabase(databaseName: "MalacarDB").Options;
            CarContext carContext = new CarContext(options);
            IRepositoryWrapper repositoryWrapper = new RepositoryWrapper(carContext);
            stationService = new StationService(repositoryWrapper);
            populateDatabase();
        }
        private static void populateDatabase()
        {
            stationService.AddStation(new Station
            {
                StationId = 1,
                Name = "Craiova",
                NumberOfEmployees = 10,
                NumberOfVehicles = 5,
            });
            stationService.AddStation(new Station
            {
                StationId = 2,
                Name = "Bucuresti",
                NumberOfEmployees = 30,
                NumberOfVehicles = 20,
            });
            stationService.AddStation(new Station
            {
                StationId = 3,
                Name = "Craiova",
                NumberOfEmployees = 10,
                NumberOfVehicles = 5,
            });
            stationService.Save();
        }

        [TestMethod]
        public void TestGetStations_HappyFlow()
        {
            //arrange
            populateExpectedAllStations();

            //act
            List<Station> actualStations = stationService.GetStations();

            //assert
            Assert.AreEqual(3, actualStations.Count);
            for (int index = 0; index < actualStations.Count; index++)
            {
                Station actualStation = actualStations[index];
                Station expectedStation = expectedAllStations[index];
                StationAllFieldsComparer.AssertAreEqual(expectedStation, actualStation);
            }
        }

        [TestMethod]
        public void TestGetStationsByCondition_HappyFlow()
        {
            //arrange
            populateExpectedStationsByCondition();

            //act
            List<Station> actualStations = stationService.GetStationsByCondition(station => station.Name.Equals("Craiova"));

            //assert
            Assert.AreEqual(2, actualStations.Count);
            for (int index = 0; index < actualStations.Count; index++)
            {
                Station actualStation = actualStations[index];
                Station expectedStation = expectedStationsByCondition[index];
                StationNameComparer.AssertAreEqual(expectedStation, actualStation);
            }
        }

        [TestMethod]
        public void TestAddStation_HappyFlow()
        {
            Station newStation = new Station
            {
                StationId = 4,
                Name = "Craiova",
                NumberOfEmployees = 10,
                NumberOfVehicles = 5,
            };
            //act
            stationService.AddStation(newStation);

            stationService.Save();
            List<Station> actualStations = stationService.GetStations();
            Assert.AreEqual(4, actualStations.Count);
            stationService.DeleteStation(newStation);
            stationService.Save();
        }

        [TestMethod]
        public void TestDeleteStation_HappyFlow()
        {
            Station newStation = new Station
            {
                StationId = 5,
                Name = "Craiova",
                NumberOfEmployees = 10,
                NumberOfVehicles = 5,
            };

            stationService.AddStation(newStation);
            stationService.Save();

            //act
            stationService.DeleteStation(newStation);

            stationService.Save();
            List<Station> actualStations = stationService.GetStations();
            Assert.AreEqual(3, actualStations.Count);
        }

        [TestMethod]
        public void TestUpdateStation_HapyyFlow()
        {
            Station stationToEdit = new Station
            {
                StationId = 4,
                Name = "Craiova",
                NumberOfEmployees = 10,
                NumberOfVehicles = 5,
            };
            stationService.AddStation(stationToEdit);
            stationService.Save();

            //modify car
            stationToEdit.Name = "Sibiu";

            //act
            stationService.UpdateStation(stationToEdit);

            stationService.Save();
            List<Station> actualStations = stationService.GetStationsByCondition(station => station.StationId == 4);
            Station updatedStation = actualStations[0];
            Assert.AreEqual("Sibiu", updatedStation.Name);
            stationService.DeleteStation(stationToEdit);
            stationService.Save();
        }

        private void populateExpectedStationsByCondition()
        {
            expectedStationsByCondition.Add(new Station
            {
                StationId = 1,
                Name = "Craiova",
                NumberOfEmployees = 10,
                NumberOfVehicles = 5,
            });
            expectedStationsByCondition.Add(new Station
            {
                StationId = 3,
                Name = "Craiova",
                NumberOfEmployees= 10,
                NumberOfVehicles = 5,
            });
        }

        private void populateExpectedAllStations()
        {
            expectedAllStations.Add(new Station
            {
                StationId = 1,
                Name = "Craiova",
                NumberOfEmployees = 10,
                NumberOfVehicles = 5,
            });
            expectedAllStations.Add(new Station
            {
                StationId = 2,
                Name = "Bucuresti",
                NumberOfEmployees = 30,
                NumberOfVehicles = 20,
            });
            expectedAllStations.Add(new Station
            {
                StationId = 3,
                Name = "Craiova",
                NumberOfEmployees = 10,
                NumberOfVehicles = 5,
            });
        }
    }
}
