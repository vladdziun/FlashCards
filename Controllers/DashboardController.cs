using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LoginReg.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace LoginReg.Controllers
{
    public class DashboardController : Controller
    {
        private LoginRegContext dbContext;

        public DashboardController(LoginRegContext context)
        {
            dbContext = context;
        }

        [Route("dashboard")]
        [HttpGet]
        public IActionResult Dashboard(int categoryID)
        {
            int? userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null)
                return RedirectToAction("Index", "Home");

            User user = dbContext.Users.FirstOrDefault(u => u.UserId == (int)userId);
            ViewBag.User = user;

            List<Category> categories = dbContext.Categories
            .Where(category => category.CreatorId == userId).ToList();
            ViewBag.categories = categories;

            return View("Dashboard");
        }
        [Route("create/category")]
        [HttpGet]
        public IActionResult CreateCategory()
        {
            int? userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null)
                return RedirectToAction("Index", "Home");
                
            List<Category> categories= dbContext.Categories
            .Where(category => category.CreatorId == userId).ToList();
            ViewBag.Categories = categories;

            return View("CreateCategory");
        }
        [Route("add/category")]
        [HttpPost]
        public IActionResult AddCategory(Category newCategory)
        {
            int? userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null)
                return RedirectToAction("Index", "Home");

            if(ModelState.IsValid)
            {
                newCategory.CreatorId = (int)userId;
                dbContext.Add(newCategory);
                dbContext.SaveChanges();
                return RedirectToAction("Dashboard");
            }
            else
                return View("CreateWedding");
        }
        [Route("create/card")]
        [HttpGet]
        public IActionResult CreateCard()
        {
            int? userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null)
                return RedirectToAction("Index", "Home");

            List<Category> categories= dbContext.Categories
            .Where(category => category.CreatorId == userId).ToList();
            ViewBag.Categories = categories;

            List<Card> cards= dbContext.Cards
                            .Where(card => card.UserId == userId).ToList();
            ViewBag.Cards = cards;

            return View("CreateCard");
        }
        [Route("add/card")]
        [HttpPost]
        public IActionResult AddCard(Card newCard)
        {
            int? userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null)
                return RedirectToAction("Index", "Home");

            if(ModelState.IsValid)
            {
                newCard.UserId = (int)userId;
                dbContext.Add(newCard);
                dbContext.SaveChanges();
                return RedirectToAction("Dashboard");
            }
            else
                return View("CreateCard");
        }
        [Route("practice/{id}")]
        [HttpGet]
        public IActionResult Practice(int id)
        {
            int? userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null)
                return RedirectToAction("Index", "Home");

            if(id == 0)
            {
                List<Card> cards= dbContext.Cards
                .Where(card => card.UserId == userId).ToList();
                if(cards.Count() < 1)
                    return View("EmptyPractice");  

                Random random = new Random();
                int randomCard = random.Next(0, cards.Count());
                ViewBag.Card = cards[randomCard];
                ViewBag.Id = id;
            }
            else
            {
                List<Card> cards= dbContext.Cards
                .Where(card => card.UserId == userId && card.CategoryId == id).ToList();
                if(cards.Count() < 1)
                    return View("EmptyPractice"); 
                Random random = new Random();
                int randomCard = random.Next(0, cards.Count());
                ViewBag.Card = cards[randomCard];
                ViewBag.Id = id;
            }

            return View("Practice");
        }
        [Route("delete/card/{id}")]
        [HttpGet]
        public IActionResult DeleteCard(int id)
        {
            int? userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null)
                return RedirectToAction("Index", "Home");
            
            Card oneCard = dbContext.Cards.FirstOrDefault(c => c.CardId ==id);
            dbContext.Remove(oneCard);
            dbContext.SaveChanges();
            return RedirectToAction("CreateCard");
        }
        [Route("delete/category/{id}")]
        [HttpGet]
        public IActionResult DeleteCategory(int id)
        {
            int? userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null)
                return RedirectToAction("Index", "Home");
            
            Category oneCategory= dbContext.Categories.FirstOrDefault(c => c.CategoryId ==id);
            dbContext.Remove(oneCategory);
            dbContext.SaveChanges();
            return RedirectToAction("CreateCategory");
        }
        [Route("edit/card/{id}")]
        [HttpGet]
        public IActionResult EditCard(int id)
        {
            int? userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null)
                return RedirectToAction("Index", "Home");
            Card oneCard = dbContext.Cards.FirstOrDefault(c => c.CardId ==id);
            List<Category> categories= dbContext.Categories.ToList();
            ViewBag.Categories = categories;
            return View("EditCard", oneCard);
        }
        [Route("update/card/{id}")]
        [HttpPost]
        public IActionResult UpdateCard(int id, Card updatedCard)
        {
            int? userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null)
                return RedirectToAction("Index", "Home");
            
            Card oneCard = dbContext.Cards.FirstOrDefault(c => c.CardId ==id);
            oneCard.FrontText = updatedCard.FrontText;
            oneCard.BackText = updatedCard.BackText;
            oneCard.CategoryId = updatedCard.CategoryId;
            dbContext.SaveChanges();
            return RedirectToAction("CreateCard");
        }

        [Route("edit/category/{id}")]
        [HttpGet]
        public IActionResult EditCategory(int id)
        {
            int? userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null)
                return RedirectToAction("Index", "Home");
            
            Category oneCategory = dbContext.Categories.FirstOrDefault(c => c.CategoryId ==id);

            return View("EditCategory", oneCategory);
        }
        [Route("update/category/{id}")]
        [HttpPost]
        public IActionResult UpdateCategory(int id, Category updatedCategory)
        {
            int? userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null)
                return RedirectToAction("Index", "Home");
            
            Category oneCategory = dbContext.Categories.FirstOrDefault(c => c.CategoryId ==id);
            oneCategory.CategoryName = updatedCategory.CategoryName;
            dbContext.SaveChanges();
            return RedirectToAction("CreateCategory");
        }
    }
}
