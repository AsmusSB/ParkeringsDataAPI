using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ParkeringsDataAPI.Managers;
using ParkeringsDataAPI.Models;

namespace RestTest
{
    [TestClass]
    public class LogTests
    {
        #region Add
        [TestMethod]
        [ExpectedException((typeof(ArgumentNullException)))]
        public void LogTestAddOmrådeNotNull()
        {
            Log log = new Log();
            log.Tidspunkt = DateTime.Now;
            log.Nedbør = 0;
            log.Retning = false;
            log.Temperatur = 0;
            log.Vindhastighed = 0;
            LogManager.Add(log);
        }
        [TestMethod]
        [ExpectedException((typeof(ArgumentNullException)))]
        public void LogTestAddDateTimeNotNull()
        {
            Log log = new Log();
            log.OmrådeId = GetOmrådeID();
            log.Nedbør = 0;
            log.Retning = false;
            log.Temperatur = 0;
            log.Vindhastighed = 0;
            LogManager.Add(log);
        }

        // There is no way to test if it hasn't been defined.
        /*
        [TestMethod]
        [ExpectedException((typeof(ArgumentException)))]
        public void LogTestAddRetningNotNull()
        {
            Log log = new Log();
            log.Tidspunkt = DateTime.Now;
            log.OmrådeId = GetOmrådeID();
            log.Nedbør = 0;
            log.Temperatur = 0;
            log.Vindhastighed = 0;
            LogManager.Add(log);
        }
        */

        [TestMethod]
        public void LogTestAddPositive()
        {
            Log log = new Log();
            log.Tidspunkt = DateTime.Now;
            log.OmrådeId = GetOmrådeID();
            log.Nedbør = 0;
            log.Temperatur = 0;
            log.Vindhastighed = 0;
            log.Retning = false;
            int i = LogManager.GetAll().Count();
            LogManager.Add(log);
            int j = LogManager.GetAll().Count();
            Assert.AreEqual(i + 1, j);
        }

        [TestMethod]
        [ExpectedException((typeof(ArgumentException)))]
        public void LogTestAddNedbørNotNegative()
        {
            Log log = new Log();
            log.Tidspunkt = DateTime.Now;
            log.OmrådeId = GetOmrådeID();
            log.Retning = false;
            log.Nedbør = -10;
            log.Temperatur = 0;
            log.Vindhastighed = 0;
            LogManager.Add(log);
        }
        [TestMethod]
        [ExpectedException((typeof(ArgumentException)))]
        public void LogTestAddVindhastighedNotNegative()
        {
            Log log = new Log();
            log.Tidspunkt = DateTime.Now;
            log.OmrådeId = GetOmrådeID();
            log.Retning = false;
            log.Nedbør = 0;
            log.Temperatur = 0;
            log.Vindhastighed = -10;
            LogManager.Add(log);
        }
        [TestMethod]
        [ExpectedException((typeof(ArgumentException)))]
        public void LogTestAddOmrådeIdNotNegative()
        {
            Log log = new Log();
            log.Tidspunkt = DateTime.Now;
            log.OmrådeId = -10;
            log.Retning = false;
            log.Nedbør = 0;
            log.Temperatur = 0;
            log.Vindhastighed = 0;
            LogManager.Add(log);
        }
        #endregion
        #region GetAll
        [TestMethod]
        public void LogTestGetAllPositive()
        {
            Assert.IsNotNull(LogManager.GetAll());
        }
        #endregion
        #region Get
        [TestMethod]
        public void LogTestGetPositive() {
            Log log = new Log();
            log.Tidspunkt = DateTime.Now;
            log.OmrådeId = GetOmrådeID();
            log.Nedbør = 0;
            log.Temperatur = 0;
            log.Vindhastighed = 0;
            log.Retning = false;
            int i = LogManager.GetAll().Count();
            LogManager.Add(log);
            Assert.AreEqual(LogManager.GetAll().Count, i + 1);
        }

        [TestMethod]
        [ExpectedException((typeof(ArgumentNullException)))]
        public void LogTestGetOmrådeNotNull()
        {
            LogManager.Get(default(int), DateTime.Now);
        }
        [TestMethod]
        [ExpectedException((typeof(ArgumentNullException)))]
        public void LogTestGetDateTimeNotNull() {
            LogManager.Get(GetOmrådeID(), default(DateTime));
        }
        [TestMethod]
        [ExpectedException((typeof(ArgumentException)))]
        public void LogTestGetOmrådeNotNegative() {
            LogManager.Get(-1, DateTime.Now);
        }
        [TestMethod]
        [ExpectedException((typeof(ArgumentException)))]
        public void LogTestGetDateTimeInRange() {
            LogManager.Get(GetOmrådeID(), DateTime.MinValue.AddYears(1));
        }
        [TestMethod]
        [ExpectedException((typeof(ArgumentException)))]
        public void LogTestGetOmrådeExists() {
            LogManager.Get(int.MaxValue, DateTime.Now);
        }
        #endregion
        #region GetStatistic
        [TestMethod]
        public void LogTestGetStatistic()
        {
            Assert.IsNotNull(LogManager.GetStatistic(DateTime.Now.Date, 1));
        }
        #endregion


        public static int GetOmrådeID() {
            return ParkeringsområdeManager.GetActiveIds()[0];
        }
    }
}
