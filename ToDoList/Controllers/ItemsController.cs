using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Models;
using System;

namespace ToDoList.Controllers
{
    public class ItemsController : Controller
    {
        [HttpGet("/categories/{categoryId}/items/new")]
        public ActionResult CreateForm(int categoryId)
        {
            Dictionary<string, object> model = new Dictionary<string, object>();
            Category category = Category.Find(categoryId);
            return View(category);
        }
        [HttpGet("/categories/{categoryId}/items/{itemId}")]
        public ActionResult Details(int categoryId, int itemId)
        {
            Item item = Item.Find(itemId);
            Dictionary<string, object> model = new Dictionary<string, object>();
            Category category = Category.Find(categoryId);
            model.Add("item", item);
            model.Add("category", category);
            return View(item);
        }

        [HttpGet("/items")]
        public ActionResult Index()
        {
            List<Item> allItems = Item.GetAll();
            return View(allItems);
        }
        // [HttpPost("/items")]
        // public ActionResult Create()
        // {
        //     Item newItem = new Item (Request.Form["new-item"]);
        //     newItem.Save();
        //     List<Item> allItems = Item.GetAll();
        //     return RedirectToAction("Index");
        // }
        [HttpGet("/items/new")]
        public ActionResult CreateForm()
        {
            return View();
        }

        [HttpPost("/items/delete")]
        public ActionResult DeleteAll()
        {
            //Item.ClearAll();
            return View();
        }

        [HttpGet("/items/{id}")]
        public ActionResult Details(int id)
        {
            Item item = Item.Find(id);
            return View(item);
        }

        //Makeing a new route to a page where we can edit one particular tiem.
        [HttpGet("/items/{id}/update")]
        public ActionResult UpdateForm(int id)
        {
            Item thisItem = Item.Find(id);
            return View(thisItem);
        }

        [HttpPost("/items/{id}/update")]
        public ActionResult Update(int id)
        {
            Item thisItem = Item.Find(id);
            thisItem.Edit(Request.Form["newname"]);
            return RedirectToAction("Index");
        }




    }
}
// [HttpPost("/items")]
// public ActionResult Create()
// {
//     Item newItem = new Item(Request.Form["new-item"]);
//     List<Item> allItems = Item.GetAll();
//     return View("Index", allItems);
// }



// using [HttpGet()] [HttpPost()] [Route()]

//returns a view that shows the 'to do list'

// [HttpGet("/items")]
// public ActionResult Index()
// {
//     Item newItem = new Item(Request.Query["new-item"]); //takes input from form
//     return View(newItem);
// }

// [HttpGet("/items")]
// public ActionResult Index()
// {
//     List<Item> allItems = Item.GetAll();
//     return View(allItems);
// }
//
// //returns a veiw that shows a form for creating a new item
// [HttpGet("/items/new")]
// public ActionResult CreateForm()
// {
//     return View();
// }
//
// [HttpPost("/items")]
// public ActionResult Create()
// {
//   Item newItem = new Item (Request.Form["new-item"]);
//   newItem.Save();
//   // return View("Index", newItem);
//   List<Item> allItems = Item.GetAll();
//   return View("Index", allItems);
// }
//
// [HttpPost("/items/delete")]
// public ActionResult DeleteAll()
// {
//     Item.ClearAll();
//     return View();
// }
