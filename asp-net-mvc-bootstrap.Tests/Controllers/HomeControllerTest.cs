using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using asp_net_mvc_bootstrap;
using asp_net_mvc_bootstrap.Controllers;
using asp_net_mvc_bootstrap.Infrastructure.UnitOfWork;
using asp_net_mvc_bootstrap.Infrastructure.Repository;
using Moq;
using asp_net_mvc_bootstrap.Models;
using asp_net_mvc_bootstrap.Models.Concrete;

namespace asp_net_mvc_bootstrap.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        IQueryable<Item> itens = new List<Item>{
                new Item{ Id = 1, Name = "Item 1" },
                new Item{ Id = 2, Name = "Item 2" },
                new Item{ Id = 3, Name = "Item 3" },
                new Item{ Id = 4, Name = "Item 4" }
            }.AsQueryable();

        private IUnitOfWork GetUnitOfWorkMock()
        {
            var repository_mock = new Mock<IRepository<Item>>();
            repository_mock.Setup(x => x.All()).Returns(itens);

            var unitOfWork_mock = new Mock<IUnitOfWork>();

            unitOfWork_mock.Setup(x => x.Commit());
            unitOfWork_mock.Setup(x => x.Rollback()).Throws<Exception>();
            unitOfWork_mock.Setup(x => x.GetRepository<Item>()).Returns(repository_mock.Object);

            return unitOfWork_mock.Object;
        }

        [TestMethod]
        public void Index()
        {
            var unitofwork = this.GetUnitOfWorkMock();
            // Arrange
            HomeController controller = new HomeController(unitofwork);

            // Act
            ViewResult result = controller.Index() as ViewResult;

            var expected = 4;

            Assert.AreEqual(expected, (result.Model as IList<Item>).Count);
        }

    }
}
