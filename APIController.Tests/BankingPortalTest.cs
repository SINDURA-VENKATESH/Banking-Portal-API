using BankingPortal.Models;
using BankingPortal;
using System.Collections.Generic;
using NUnit.Framework;
using NSubstitute;
using System.Linq;
using System.Data.EntityClient;
using BankingPortal.Controllers;

namespace APIController.Tests
{
    [TestFixture]
    public class BankingPortalTest
    {
        [Test]
        public void Get_ShouldReturnAllCustomers()
        {
            //arrange
            var customers = new List<customers_table>
{ new customers_table{ cusid = 100, cusname = "TestNane1", cusaddress = "TestAddress1", cusstatus = "TestStatus1" },
        new customers_table{ cusid = 101, cusname = "TestNane2", cusaddress = "TestAddress2", cusstatus = "TestStatus2" },
        new customers_table{ cusid = 102, cusname = "TestNane3", cusaddress = "TestAddress3", cusstatus = "TestStatus3" },
        new customers_table{ cusid = 103, cusname = "TestNane4", cusaddress = "TestAddress4", cusstatus = "TestStatus4" },
}.AsQueryable();

            var mockSet = Substitute.For<DbSet<customers_table>, IQueryable<customers_table>>();
            ((IQueryable<customers_table>)mockSet).Provider.Returns(customers.Provider);
            ((IQueryable<customers_table>)mockSet).Expression.Returns(customers.Expression);
            ((IQueryable<customers_table>)mockSet).ElementType.Returns(customers.ElementType);
            ((IQueryable<customers_table>)mockSet).GetEnumerator().Returns(customers.GetEnumerator());

            var mockContext = Substitute.For<ImasterEntities>();
            mockContext.customers_table.Returns(mockSet);
            var controller = new ValuesController(mockContext);

            //act
            var result = controller.get();

            //assert
            Assert.Equals(result.Count(), customers.Count());
        }

        //[Test]
        //public void GetCustomer_ShouldReturnCorrectCustomer()
        //{
        //    var testCustomers = GetTestCustomers();
        //    var controller = new ValuesController(entitysubstitute);

        //    var result = controller.get(4) as OkNegotiatedContentResult<Customers>;
        //    Assert.IsNotNull(result);
        //    Assert.AreEqual(testCustomers[3].cusname, result.Content.cusname);
        //}

        //[Test]
        //public void GetCustomer_ShouldNotFindCustomert()
        //{
        //    var controller = new ValuesController(entitysubstitute);

        //    var result = controller.get(999);
        //    //Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        //}





    }
    }


