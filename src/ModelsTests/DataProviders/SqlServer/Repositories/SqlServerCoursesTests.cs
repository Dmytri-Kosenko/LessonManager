using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models.DataProviders.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DataProviders.Repositories.Tests
{
    [TestClass()]
    public class SqlServerCoursesTests
    {
        private static SqlServerCourses course; 
        public TestContext TestContext { get; set; }

         [ClassInitialize]
        public static void ClassInit(TestContext context)
        {
            course = new SqlServerCourses(new SqlServer.SqlSerDbContext());
        }

        [TestMethod()]
        public void Add_Petya_CountPlus1()
        {
            //arrange
            int expCount = course.Items.Count();
            TestContext.WriteLine("************ " + expCount.ToString());
            
            //act
            course.Add(new Entities.Course { Name = "1 курс" });
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