
using BankingPortal.Models;
using BankingPortal;
using System.Collections.Generic;
using NUnit.Framework;
using NSubstitute;
using System.Linq;
using BankingPortal.Controllers;
using System.Data.Entity;

namespace APIController.Tests
{
    
    public class UnitTest2
    {

        [SetUp]
        public void Setup()
        {
             var customers = new List<customers_table>
{ new customers_table{ cusid = 100, cusname = "TestNane1", cusaddress = "TestAddress1", cusstatus = "TestStatus1" },
        new customers_table{ cusid = 101, cusname = "TestNane2", cusaddress = "TestAddress2", cusstatus = "TestStatus2" },
        new customers_table{ cusid = 102, cusname = "TestNane3", cusaddress = "TestAddress3", cusstatus = "TestStatus3" },
        new customers_table{ cusid = 103, cusname = "TestNane4", cusaddress = "TestAddress4", cusstatus = "TestStatus4" },
}.AsQueryable();

            //create a Mock DBSet 
            var mockSet = Substitute.For<DbSet<customers_table>, IQueryable<customers_table>>();
            ((IQueryable<customers_table>)mockSet).Provider.Returns(customers.Provider);
            ((IQueryable<customers_table>)mockSet).Expression.Returns(customers.Expression);
            ((IQueryable<customers_table>)mockSet).ElementType.Returns(customers.ElementType);
            ((IQueryable<customers_table>)mockSet).GetEnumerator().Returns(customers.GetEnumerator());

            //Create a Mock DBContext Class
            var mockContext = Substitute.For<ImasterEntities>();
            //Wiring Context and DBSet
            mockContext.customers_table.Returns(mockSet);

        }
        [Test]
        public void Get_ShouldReturnAllCustomers()
        {
            //arrange

            //creating Mock data
            var customers = new List<customers_table>
{ new customers_table{ cusid = 100, cusname = "TestNane1", cusaddress = "TestAddress1", cusstatus = "TestStatus1" },
        new customers_table{ cusid = 101, cusname = "TestNane2", cusaddress = "TestAddress2", cusstatus = "TestStatus2" },
        new customers_table{ cusid = 102, cusname = "TestNane3", cusaddress = "TestAddress3", cusstatus = "TestStatus3" },
        new customers_table{ cusid = 103, cusname = "TestNane4", cusaddress = "TestAddress4", cusstatus = "TestStatus4" },
}.AsQueryable();

            //create a Mock DBSet 
            var mockSet = Substitute.For<DbSet<customers_table>, IQueryable<customers_table>>();
            ((IQueryable<customers_table>)mockSet).Provider.Returns(customers.Provider);
            ((IQueryable<customers_table>)mockSet).Expression.Returns(customers.Expression);
            ((IQueryable<customers_table>)mockSet).ElementType.Returns(customers.ElementType);
            ((IQueryable<customers_table>)mockSet).GetEnumerator().Returns(customers.GetEnumerator());

            //Create a Mock DBContext Class
            var mockContext = Substitute.For<ImasterEntities>();
            //Wiring Context and DBSet
            mockContext.customers_table.Returns(mockSet);

            //Calling Controller Constructor with new DBContext Object
            var controller = new ValuesController(mockContext);

            //act
            var result = controller.get();

            //assert
            Assert.AreEqual(result.Count(), customers.Count());
        }

        [Test]
        public void GetCustomer_ShouldReturnCorrectCustomer()
        {
        var customers = new List<customers_table>
{ new customers_table{ cusid = 100, cusname = "TestNane1", cusaddress = "TestAddress1", cusstatus = "TestStatus1" },
        new customers_table{ cusid = 101, cusname = "TestNane2", cusaddress = "TestAddress2", cusstatus = "TestStatus2" },
        new customers_table{ cusid = 102, cusname = "TestNane3", cusaddress = "TestAddress3", cusstatus = "TestStatus3" },
        new customers_table{ cusid = 103, cusname = "TestNane4", cusaddress = "TestAddress4", cusstatus = "TestStatus4" },
}.AsQueryable();

        //create a Mock DBSet 
        var mockSet = Substitute.For<DbSet<customers_table>, IQueryable<customers_table>>();
            ((IQueryable<customers_table>)mockSet).Provider.Returns(customers.Provider);
            ((IQueryable<customers_table>)mockSet).Expression.Returns(customers.Expression);
            ((IQueryable<customers_table>)mockSet).ElementType.Returns(customers.ElementType);
            ((IQueryable<customers_table>)mockSet).GetEnumerator().Returns(customers.GetEnumerator());

            //Create a Mock DBContext Class
            var mockContext = Substitute.For<ImasterEntities>();
        //Wiring Context and DBSet
        mockContext.customers_table.Returns(mockSet);

            //Calling Controller Constructor with new DBContext Object
            var controller = new ValuesController(mockContext);


            var result = controller.get(101);
          Assert.IsNotNull(result);
            Assert.AreEqual(result.cusname, customers.ElementAt(1).cusname);
        }

        [Test]
        public void GetCustomer_ShouldNotFindCustomert()
        {
            var customers = new List<customers_table>
{ new customers_table{ cusid = 100, cusname = "TestNane1", cusaddress = "TestAddress1", cusstatus = "TestStatus1" },
        new customers_table{ cusid = 101, cusname = "TestNane2", cusaddress = "TestAddress2", cusstatus = "TestStatus2" },
        new customers_table{ cusid = 102, cusname = "TestNane3", cusaddress = "TestAddress3", cusstatus = "TestStatus3" },
        new customers_table{ cusid = 103, cusname = "TestNane4", cusaddress = "TestAddress4", cusstatus = "TestStatus4" },
}.AsQueryable();

            //create a Mock DBSet 
            var mockSet = Substitute.For<DbSet<customers_table>, IQueryable<customers_table>>();
            ((IQueryable<customers_table>)mockSet).Provider.Returns(customers.Provider);
            ((IQueryable<customers_table>)mockSet).Expression.Returns(customers.Expression);
            ((IQueryable<customers_table>)mockSet).ElementType.Returns(customers.ElementType);
            ((IQueryable<customers_table>)mockSet).GetEnumerator().Returns(customers.GetEnumerator());

            //Create a Mock DBContext Class
            var mockContext = Substitute.For<ImasterEntities>();
            //Wiring Context and DBSet
            mockContext.customers_table.Returns(mockSet);
            var controller = new ValuesController(mockContext);

               var result = controller.get(999);
            Assert.Null(result);
            //Assert.(result, typeof(NotFoundResult));
           }




        
        }
    }


