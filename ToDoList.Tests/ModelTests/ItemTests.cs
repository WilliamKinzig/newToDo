using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System;
using ToDoList.Models;

namespace ToDoList.Tests
{

    [TestClass]
    public class ItemTests : IDisposable
    {

        [TestMethod]
        public void GetAll_DbStartsEmpty_0()
        {
          //Arrange
          //Act
          int result = Item.GetAll().Count; //count the items

          //Assert
          Assert.AreEqual(0, result);
        }

//this method requires: ToDoList/Models/Item.cs - public override bool Equals(System.Object otherItem) .. to PASS
        [TestMethod]
        public void Equals_ReturnsTrueIfDescriptionsAreTheSame_Item()
        {
          // Arrange, Act
          Item firstItem = new Item("Mow the lawn");
          Item secondItem = new Item("Mow the lawn");

          // Assert
          Assert.AreEqual(firstItem, secondItem);
        }

        public void Dispose()
        {
            Item.DeleteAll();
        }
        public ItemTests()
        {
            DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=todo_test;";
        }


        [TestMethod]
        public void Save_SavesToDatabase_ItemList()
        {
          //Arrange
          Item testItem = new Item("Mow the lawn");

          //Act
          testItem.Save();

// GetAll is also confirming that a list is being returned. Note....
          List<Item> result = Item.GetAll();
          List<Item> testList = new List<Item>{testItem};

          //Assert
          CollectionAssert.AreEqual(testList, result);
        }

        [TestMethod]
        public void Save_AssignsIdToObject_Id()
        {
          //Arrange
          Item testItem = new Item("Mow the lawn");

          //Act
          testItem.Save();
          Item savedItem = Item.GetAll()[0];

          int result = savedItem.GetId();
          int testId = testItem.GetId();

          //Assert
          Assert.AreEqual(testId, result);
        }

        [TestMethod]
        public void Find_FindsItemInDatabase_Item()
        {
          //Arrange
          Item testItem = new Item("Mow the lawn");
          testItem.Save();

          //Act
          Item foundItem = Item.Find(testItem.GetId());

          //Assert
          Assert.AreEqual(testItem, foundItem);
        }

        [TestMethod]
        public void Edit_UpdatesItemInDatabase_String()
        {
          //Arrange
          string firstDescription = "Walk the Dog";
          Item testItem = new Item(firstDescription, 1);
          testItem.Save();
          string secondDescription = "Mow the lawn";

          //Act
          testItem.Edit(secondDescription);

          string result = Item.Find(testItem.GetId()).GetDescription();

          //Assert
          Assert.AreEqual(secondDescription , result);
        }

    }
}
































// using Microsoft.VisualStudio.TestTools.UnitTesting;
// using System.Collections.Generic;
// using ToDoList.Models;
// using System;
//
// // The first argument is what we expect the result of the test to be, and the second is the expression to be evaluated.
//
// namespace ToDoList.Tests
// {
//   [TestClass]
//   public class ItemTests : IDisposable
//   {
//
//     /////////////////////////////////////////////
//     // public void Dispose()
//     // {
//     //   Item.ClearAll();
//     // }
//     //whatsExpectedResult_expressionToBeEvaluated_
//
//     [TestMethod]
//     public void GetDescription_ReturnsDescription_String()
//     {
//       //Arrange
//       string description = "Walk the dog.";
//       Item newItem = new Item(description);
//
//       //Act
//       string result = newItem.GetDescription();
//
//       //Assert
//       Assert.AreEqual(description, result);
//     }
//
//     //THIS METHOD FAILS INTENTIONALLY
//     [TestMethod]
//     public void SetDescription_SetDescription_String()
//     {
//       //Arrange
//       string description = "Walk the dog.";
//       Item newItem = new Item(description);
//
//       //Act
//       newItem.SetDescription("Walk the dog.");
//       string result = newItem.GetDescription();
//
//       //Assert
//       Assert.AreEqual(description, result);
//     }
//
//     [TestMethod]
//     public void Save_ItemIsSavedToInstances_Item()
//     {
//       //Arrange
//       string description = "Walk the dog.";
//       Item newItem = new Item(description);
//       newItem.Save();
//
//       //Act
//       List<Item> instances = Item.GetAll();
//       Item savedItem = instances[0];
//
//       //Assert
//       Assert.AreEqual(newItem, savedItem);
//     }
//
//     [TestMethod]
//     public void GetAll_ReturnsItems_ItemList()
//     {
//       //Arrange
//       string description01 = "Walk the dog";
//       string description02 = "Wash the dishes";
//       Item newItem1 = new Item(description01);
//       newItem1.Save();
//       Item newItem2 = new Item(description02);
//       newItem2.Save();
//       List<Item> newList = new List<Item> { newItem1, newItem2 };
//
//       //Act
//       List<Item> result = Item.GetAll();
//       foreach (Item thisItem in result)
//       {
//         Console.WriteLine("Output: " + thisItem.GetDescription());
//       }
//
//       Console.WriteLine(result);
//       Console.WriteLine(newList);
//
//       //Assert
//       CollectionAssert.AreEqual(newList, result);
//     }
//
//
//     public void Dispose()
//     {
//       Item.ClearAll();
//     }
//
//   }
// }
