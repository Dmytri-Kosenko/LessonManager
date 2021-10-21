using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models.DataProviders.SqlServer.Repositories;
using Models.Entities;
using System.Linq;
using Models.DataProviders.SqlServer;

namespace ModelsTests.DataProviders.SqlServer.Repositories
{
    [TestClass()]
    public class SqlServerCoursesTests
    {
        private static SqlServerCourses course; 
        public TestContext TestContext { get; set; }

         [ClassInitialize]
        public static void ClassInit(TestContext context)
        {
            course = new SqlServerCourses(new SqlSerDbContext());
        }

        [TestMethod()]
        public void Add_Petya_CountPlus1()
        {
            //arrange
            int expCount = course.Items.Count();
            TestContext.WriteLine("************ " + expCount.ToString());
            
            //act
            course.Add(new Course { Name = "1 курс" });
            int actCount = course.Items.Count();
            TestContext.WriteLine("************ " + actCount.ToString());
            //assert
            Assert.AreEqual(expCount + 1, actCount);
        }
        [TestMethod()]
        public void DeleteTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetCourseByIdTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void RenameTest()
        {
            Assert.Fail();
        }
    }
}