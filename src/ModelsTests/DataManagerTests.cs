using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;
using Models.DataProviders.SqlServer;
using Models.DataProviders.SqlServer.Repositories;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Tests
{

    [TestClass()]
    public class DataManagerTests
    {
        public TestContext TestContext { get; set; }

        [TestMethod()]
        public void DataManager_CrudSqlServer_SuccessAllOperations()
        {
            //arrange
            SqlSerDbContext context = new SqlSerDbContext();
            DataManager data = new DataManager(new SqlServerStudents(context), new SqlServerCourses(context));
            //act
            data.StudentsRep.Add(new Student() { Name = "Vasya" });
            data.CoursesRep.Add(new Course() { Name = "2 курс" });
            data.StudentsRep.SetCourse(
                data.StudentsRep.Items.FirstOrDefault(s => s.Name == "Vasya"),
                data.CoursesRep.Items.FirstOrDefault(s => s.Name == "2 курс"));
            //assert
            Assert.IsNotNull(data.StudentsRep.Items.FirstOrDefault(s => s.Name == "Vasya")?.
                Courses.FirstOrDefault(s => s.Name == "2 курс"));
        }
    }
}