using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Inventory.Data;
using Inventory.Models.Barang;
using Inventory.Models.Stesen;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Inventory.Controllers.Barang
{
    public class Barang : Controller
    {
        private readonly ApplicationDbContext _context;

        public Barang(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: Barnag
        public async Task<IActionResult> Index(string searchString)
        {
            var barangQuery = from m in _context.Barang
                select m;

            //foreach (var s in barangQuery)
            //{
            //    s.StesenName = getStesenName(s.IdStesen);
            //    s.DaerahName = getDaerahName(s.IdDaerah);
            //}


            if (!string.IsNullOrEmpty(searchString))
            {
                barangQuery = barangQuery.Where(s => s.Name.Contains(searchString));
            }

            var barangListModel = new BarangViewModel()
            {
                Barangs = await barangQuery.ToListAsync()
            };

            return View(barangListModel);
        }

        public string getStesenName(long IdStesen)
        {
            var getStesen = _context.Stesen.ToList();
            var stesenName = getStesen.Where(s => s.IdStesen.Equals(IdStesen)).Select(w => w.Name).FirstOrDefault();
            return stesenName;

        }

        public string getDaerahName(Guid IdDaerah)
        {
            var getDaerah = _context.Daerah.ToList();
            var daerahName = getDaerah.Where(s => s.IdDaerah.Equals(IdDaerah)).Select(w => w.Name).FirstOrDefault();
            return daerahName;

        }
        // GET: Barnag/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Barnag/Create
        public ActionResult Create()
        {
            ViewBag.daerahList = _context.Daerah.ToList();
            return View();
        }

        [HttpPost]
        public JsonResult GetStesenList(Guid IdDaerah)
        {

            List<Models.Stesen.Stesen> stesenList = new List<Stesen>();
            stesenList = _context.Stesen.ToList();
            var stesenFilter = stesenList.Where(s => s.IdDaerah.Equals(IdDaerah));
            return Json(JsonConvert.SerializeObject(stesenFilter));
        }

        // POST: Barnag/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Models.Barang.Barang barang)
        {

            ModelState.Remove(barang.IdDaerah.ToString());
            if (!ModelState.IsValid)
            {
                ViewBag.daerahList = _context.Daerah.ToList();
                return View(barang);
            }
            try
            {
                var add = _context.Barang.Add(barang);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ViewBag.daerahList = _context.Daerah.ToList();
                ViewBag.message = e;
                return View(barang);
            }
        }

        // GET: Barnag/Edit/5
        public ActionResult Edit(Guid id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            var barang =  _context.Barang.Find(id);
            if (barang == null)
            {
                return RedirectToAction("Index");
            }
            ViewBag.daerahList = _context.Daerah.ToList();
            var stesenFilter = _context.Stesen.Where(w => w.IdStesen.Equals(barang.IdStesen));
            ViewBag.stesenList = stesenFilter;
            return View(barang);
        } 

        // POST: Barnag/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var barang = await _context.Barang.FindAsync(id);
            _context.Barang.Remove(barang);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MovieExists(Guid id)
        {
            return _context.Barang.Any(e => e.IdBarang == id);
        }

        // GET: Barnag/Delete/5
        public ActionResult Delete(Guid id)
        {
            try
            {
                var barang = _context.Barang.Find(id);
                _context.Barang.Remove(barang);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // POST: Barnag/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                var barang = _context.Barang.Find(id);
                _context.Barang.Remove(barang);
                 _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
