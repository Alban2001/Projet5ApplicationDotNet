using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Projet5ApplicationDotNet.Data;
using Projet5ApplicationDotNet.Models;

namespace Projet5ApplicationDotNet.Controllers
{
    [Authorize(Roles = "ADMIN")]
    public class ReparationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReparationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Reparations
        public async Task<IActionResult> Liste(int id)
        {
            var reparations = await _context.Reparations.Where(r => r.UneVoiture.Id == id).ToListAsync();

            var ReparationViewModel = new ReparationViewModel();
            HttpContext.Session.SetInt32("IdVoiture", id);

            ReparationViewModel.IdVoiture = id;
            ReparationViewModel.ListeReparation = reparations;

            return ReparationViewModel != null ?
                          View(nameof(Index), ReparationViewModel) :
                          Problem("Entity set 'ApplicationDbContext.Reparations'  is null.");
        }

        // POST: Reparations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ReparationViewModel reparation)
        {
            int? IdVoiture = HttpContext.Session.GetInt32("IdVoiture");

            var voiture = await _context.Voitures.FindAsync(IdVoiture);

            var UneReparation = new Reparation()
            {
                Cout = reparation.Cout,
                Commentaire = reparation.Commentaire,
                UneVoiture = voiture
            };

            if (ModelState.IsValid)
            {
                _context.Add(UneReparation);

                voiture.PrixVente = (Convert.ToDouble(voiture.PrixVente) + Convert.ToDouble(reparation.Cout)).ToString();
                _context.Update(voiture);

                await _context.SaveChangesAsync();
                return RedirectToAction("Liste", new {id = IdVoiture });
            }

            var reparations = await _context.Reparations.Where(r => r.UneVoiture.Id == IdVoiture).ToListAsync();

            var ReparationViewModel = new ReparationViewModel()
            {
                Cout = reparation.Cout,
                Commentaire = reparation.Commentaire,
                ListeReparation = reparations,
                IdVoiture = (int)IdVoiture
            };

            return View("Index", ReparationViewModel);
        }

        // GET: Reparations/Delete/5
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            int? IdVoiture = HttpContext.Session.GetInt32("IdVoiture");

            var voiture = await _context.Voitures.FindAsync(IdVoiture);

            if (_context.Reparations == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Reparations'  is null.");
            }

            var reparation = await _context.Reparations.FindAsync(id);
            if (reparation != null)
            {
                voiture.PrixVente = (Convert.ToDouble(voiture.PrixVente) - Convert.ToDouble(reparation.Cout)).ToString();
                _context.Reparations.Remove(reparation);
                _context.Update(voiture);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction("Liste", new {id = IdVoiture });
        }

        private bool ReparationExists(int id)
        {
          return (_context.Reparations?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
