using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Safoa.DAL;
using Safoa.Models;

namespace Safoa.Controllers
{
    public class SellOrdersController : BaseController
    {
        private SafoaContext db = new SafoaContext();

        // GET: SellOrders
        public ActionResult Index()
        {
            var sellOrders = db.SellOrders;
            var ids = (from sellOrder in sellOrders select sellOrder.Id).ToList();
            ViewBag.SellItems = db.SellOrderItems.Where(p => p.SellOrderId > 0 && ids.Contains(p.SellOrderId)).ToList();
            return View(sellOrders.OrderByDescending(p => p.Date).ToList());
        }

        // GET: SellOrders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SellOrder sellOrder = db.SellOrders.Find(id);
            if (sellOrder == null)
            {
                return HttpNotFound();
            }
            return View(sellOrder);
        }

        // GET: SellOrders/Create
        public ActionResult Create()
        {
            ViewBag.ItemId = new SelectList(db.Items, "Id", "Name");
            return View();
        }

        // POST: SellOrders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,TotalPrice,Date,Notes")] SellOrder sellOrder, List<int> ItemId, List<decimal> Price)
        {
            if (ModelState.IsValid)
            {
                sellOrder.Date = DateTime.Now;
                db.SellOrders.Add(sellOrder);
                db.SaveChanges();
                for (int i = 0; i < ItemId.Count(); i++)
                {
                    db = new SafoaContext();
                    SellOrderItem sellItem = new SellOrderItem();
                    sellItem.SellOrderId = sellOrder.Id;
                    sellItem.Price = Price[i];
                    sellItem.ItemId = ItemId[i];
                    db.SellOrderItems.Add(sellItem);
                    db.SaveChanges();

                }
                return RedirectToAction("Edit", sellOrder.Id);
            }
            else
            {
                Dictionary<string, string> data = new Dictionary<string, string>();
                data["success"] = "false";
                //return JsonResult(data, al);
            }

            ViewBag.ItemId = new SelectList(db.Items, "Id", "Name");
            return View(sellOrder);
        }

        // GET: SellOrders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SellOrder sellOrder = db.SellOrders.Find(id);
            if (sellOrder == null)
            {
                return HttpNotFound();
            }
            ViewBag.SellItems = db.SellOrderItems.Where(p => p.SellOrderId == id).ToList();

            return View("Create", sellOrder);
        }

        // POST: SellOrders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,TotalPrice,Notes")] SellOrder sellOrder)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sellOrder).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ItemId = new SelectList(db.Items, "Id", "Name");
            return View(sellOrder);
        }

        // GET: SellOrders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SellOrder sellOrder = db.SellOrders.Find(id);
            if (sellOrder == null)
            {
                return HttpNotFound();
            }
            return View(sellOrder);
        }

        // POST: SellOrders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SellOrder sellOrder = db.SellOrders.Find(id);
            db.SellOrders.Remove(sellOrder);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // POST: SellOrdersItem/Delete/5
        [HttpPost, ActionName("DeleteItem")]
        [ValidateAntiForgeryToken]
        public JsonResult DeleteItemConfirmed(int id)
        {
            SellOrderItem sellOrderItem = db.SellOrderItems.Find(id);
            db.SellOrderItems.Remove(sellOrderItem);
            db.SaveChanges();
            return Json(true, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetItems()
        {
            string name = this.Request.QueryString["name"];
            string id = "";
            if (name == null)
            {
                id = this.Request.QueryString["id"];
            }
            if (name != null)
            {
                var items = db.Items.Where(p => p.Name.StartsWith(name));
                return Json(items.ToList(), JsonRequestBehavior.AllowGet);
            }
            else if (id != null)
            {
                var itemId = Convert.ToInt32(id);
                var items = db.Items.Where(p => p.Id == itemId);
                return Json(items.ToList(), JsonRequestBehavior.AllowGet);
            }
            return Json(null, JsonRequestBehavior.AllowGet);


        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
