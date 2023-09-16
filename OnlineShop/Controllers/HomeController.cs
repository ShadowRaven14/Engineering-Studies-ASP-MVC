using OnlineShop.DAL;
using OnlineShop.Models.Home;
using Projekt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Controllers
{
    public class HomeController : Controller
    {
        dbMyOnlineShoppingEntities context = new dbMyOnlineShoppingEntities();
        public ActionResult Index(string search, int? page, int? pagesize)
        {
            ViewBag.search = search;
            ViewBag.page = page;
            ViewBag.pagesize = pagesize;
            int pagesizepom = pagesize == null ? 4 : pagesize.Value;
            HomeIndexViewModel model = new HomeIndexViewModel();
            return View(model.CreateModel(search, page, pagesizepom));
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult AddToCart(int productId)
        {
            if(Session["cart"]==null)
            {
                List<Item> cart = new List<Item>();
                var product = context.Tbl_Product.Find(productId);
                cart.Add(new Item()
                {
                    Product = product,
                    Quantity = 1
                });
                Session["cart"] = cart;
            }
            else
            {

                List<Item> cart = (List<Item>)Session["cart"];
                var count = cart.Count();
                var product = context.Tbl_Product.Find(productId);
                for (int i = 0; i < count; i++)
                {
                    if (cart[i].Product.ProductId == productId)
                    {
                        int prevQty = cart[i].Quantity;
                        cart.Remove(cart[i]);
                        cart.Add(new Item()
                        {
                            Product = product,
                            Quantity = prevQty + 1
                        });
                        break;
                    }
                    else
                    {
                        var prod = cart.Where(x => x.Product.ProductId == productId).SingleOrDefault();
                        if (prod == null)
                        {
                            cart.Add(new Item()
                            {
                                Product = product,
                                Quantity = 1
                            });
                        }
                    }
                }
                Session["cart"] = cart;
            }
            return Redirect("Index");
        }

        public ActionResult DecreaseQty(int productId)
        {
            if (Session["cart"] != null)
            {
                List<Item> cart = (List<Item>)Session["cart"];
                var product = context.Tbl_Product.Find(productId);
                foreach (var item in cart)
                {
                    if (item.Product.ProductId == productId)
                    {
                        int prevQty = item.Quantity;
                        if (prevQty > 0)
                        {
                            cart.Remove(item);
                            cart.Add(new Item()
                            {
                                Product = product,
                                Quantity = prevQty - 1
                            });
                        }
                        break;
                    }
                }
                Session["cart"] = cart;
            }
            return Redirect("Checkout");
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult RemoveFromCart(int productId)
        {
            List<Item> cart = (List<Item>)Session["cart"];
            foreach(var item in cart)
            {
                if(item.Product.ProductId==productId)
                {
                    cart.Remove(item);
                    break;
                }
            }
            Session["cart"] = cart;
            return Redirect("Index");
        }
        public ActionResult Checkout()
        {
            return View();
        }
        public ActionResult CheckoutDetails()
        {
            return View();
        }

        public ActionResult Payment()
        {
            /*Dictionary<int, int> cart = new Dictionary<int, int>();
            ((List<Item>)Session["cart"]).ForEach(i => cart.Add(i.Product.ProductId, i.Quantity));
            //List<Tbl_Product> pom = context.Tbl_Product.Where(p => cart.ContainsKey(p.ProductId)).ToList();
            List<Tbl_Product> pom = context.Tbl_Product.Where(p => cart.Any(cart_ => cart_.Equals(p.ProductId))).ToList();
            pom.ForEach(i => i.Quantify -= cart[i.ProductId]);*/
            return View();
        }

        [HttpPost]
        public ActionResult Contact(Contact e)
        {
            if (ModelState.IsValid)
            {

                /*StringBuilder message = new StringBuilder();
                MailAddress from = new MailAddress(e.ContactEmail.ToString());
                message.Append("Name: " + e.ContactName + "\n");
                message.Append("Email: " + e.ContactEmail + "\n");
                message.Append(e.ContactMessage);

                MailMessage mail = new MailMessage();

                SmtpClient smtp = new SmtpClient();

                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;

                System.Net.NetworkCredential credentials = new System.Net.NetworkCredential("kacper0854@gmail.com", "Maltanczyk11223344");

                smtp.Credentials = credentials;
                smtp.EnableSsl = true;

                mail.From = from;
                mail.To.Add("kacper0854@gmail.com");
                mail.Subject = "Test enquiry from " + e.ContactName;
                mail.Body = message.ToString();

                //smtp.Send(mail);*/

                StringBuilder message = new StringBuilder();
                MailAddress from = new MailAddress(e.ContactEmail.ToString());
                message.Append("Name: " + e.ContactName + "\n");
                message.Append("Email: " + e.ContactEmail + "\n");
                message.Append(e.ContactMessage);

                MailMessage mail = new MailMessage();

                SmtpClient smtp = new SmtpClient();

                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;

                System.Net.NetworkCredential credentials = new System.Net.NetworkCredential("kacper0854@gmail.com", "");

                smtp.Credentials = credentials;
                smtp.EnableSsl = true;

                mail.From = from;
                mail.To.Add("kacper0854@gmail.com");
                mail.Subject = "Test enquiry from " + e.ContactName;
                mail.Body = message.ToString();

                //smtp.Send(mail);


            }
            return View();
        }
    }
}