using Microsoft.VisualStudio.TestTools.UnitTesting;
using QualityMonitoringSystem;
using QualityMonitoringSystem.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace QualityMonitoringSystem.Tests.Controllers
{
    /// <summary>
    /// Summary description for StaffsControllerTest
    /// </summary>
    [TestClass]
    public class StaffsControllerTest
    {
        #region Clutter
        public StaffsControllerTest()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion
        #endregion

        //Test method template to use.
        [TestMethod]
        public void TestMethod1()
        {
            //
            // TODO: Add test logic here
            //
        }

        //Unit test for testing the view returned by the StaffsController.Details() action.
        [TestMethod]
        public void TestDetailsView()
        {
            //Creates a new instance of the StaffsController class.
            StaffsController controller = new StaffsController();

            //Invokes the controller's Details() action method.
            ViewResult result = controller.Details(2) as ViewResult;

            //Checks whether or not the view returned by the Details() action is the Details view.
            Assert.AreEqual("Details", result.ViewName); 
        }
    }
}
