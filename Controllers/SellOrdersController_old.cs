namespace Safoa.Controllers
{
    using Safoa.DAL;
    using Safoa.Models;
    using System.Data.Entity;
    using System.Linq;
    using System.Net;
    using System.Web.Mvc;

    /// <summary>
    /// Defines the <see cref="SellOrdersController_old" />
    /// </summary>
    public class SellOrdersController_old : Controller
    {
        /// <summary>
        /// Defines the db
        /// </summary>
        private SafoaContext db = new SafoaContext();

        // GET: SellOrders
        /// <summary>
        /// The Index
        /// </summary>
        /// <returns>The <see cref="ActionResult"/></returns>
        public ActionResult Index()
        {
            return View(db.SellOrders.ToList());
        }

        // GET: SellOrders/Details/5
        /// <summary>
        /// The Details
        /// </summary>
        /// <param name="id">The id<see cref="int?"/></param>
        /// <returns>The <see cref="ActionResult"/></returns>
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
        /// <summary>
        /// The Create
        /// </summary>
        /// <returns>The <see cref="ActionResult"/></returns>
        public ActionResult Create()
        {
            return View();
        }

        // POST: SellOrders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// The Create
        /// </summary>
        /// <param name="sellOrder">The sellOrder<see cref="SellOrder"/></param>
        /// <returns>The <see cref="ActionResult"/></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Items,Price,Date")] SellOrder sellOrder)
        {
            if (ModelState.IsValid)
            {
                db.SellOrders.Add(sellOrder);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sellOrder);
        }

        // GET: SellOrders/Edit/5
        /// <summary>
        /// The Edit
        /// </summary>
        /// <param name="id">The id<see cref="int?"/></param>
        /// <returns>The <see cref="ActionResult"/></returns>
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
            return View(sellOrder);
        }

        // POST: SellOrders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// The Edit
        /// </summary>
        /// <param name="sellOrder">The sellOrder<see cref="SellOrder"/></param>
        /// <returns>The <see cref="ActionResult"/></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Items,Price,Date")] SellOrder sellOrder)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sellOrder).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sellOrder);
        }

        // GET: SellOrders/Delete/5
        /// <summary>
        /// The Delete
        /// </summary>
        /// <param name="id">The id<see cref="int?"/></param>
        /// <returns>The <see cref="ActionResult"/></returns>
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
        /// <summary>
        /// The DeleteConfirmed
        /// </summary>
        /// <param name="id">The id<see cref="int"/></param>
        /// <returns>The <see cref="ActionResult"/></returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SellOrder sellOrder = db.SellOrders.Find(id);
            db.SellOrders.Remove(sellOrder);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        /// <summary>
        /// The Dispose
        /// </summary>
        /// <param name="disposing">The disposing<see cref="bool"/></param>
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
