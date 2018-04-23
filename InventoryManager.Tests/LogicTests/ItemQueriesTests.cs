using InventoryManager.Domain.Models;
using InventoryManager.Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManager.Tests.LogicTests
{
    [TestClass]
    public class ItemQueriesTests
    {
        [TestMethod]
        public void Should_return_empty_list_of_items()
        {
            //Arrange
            var itemQueries = new ItemQueries();
            var expected = new List<Item>();

            //Act
            var actual = itemQueries.GetItemsAsync();
            
            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
