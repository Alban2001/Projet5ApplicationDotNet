using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Projet5ApplicationDotNet.Data;
using Projet5ApplicationDotNet.Models;

namespace Projet5ApplicationDotNet.Controllers
{
    public class VoituresController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VoituresController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Voitures
        public async Task<IActionResult> Index()
        {
            return _context.Voitures != null ?
                        View(await _context.Voitures.ToListAsync()) :
                        Problem("Entity set 'ApplicationDbContext.Voitures'  is null.");
        }

        // GET: Voitures/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Voitures == null)
            {
                return NotFound();
            }

            var voiture = await _context.Voitures
                .FirstOrDefaultAsync(m => m.Id == id);
            if (voiture == null)
            {
                return NotFound();
            }

            return View(voiture);
        }

        // GET: Voitures/Create
        public async Task<IActionResult> Create()
        {
            return View();
        }



        // POST: Voitures/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(VoitureViewModel model)
        {
            if (ModelState.IsValid)
            {
                var UneMarque = new Marque()
                {
                    Nom = model.Marque
                };
                var UnModele = new Modele()
                {
                    Annee = model.Annee,
                    Nom = model.Modele,
                    UneMarque = UneMarque
                };

                var marque = await _context.Marques
                    .Where(p => p.Nom.ToLower() == model.Marque.ToLower())
                    .FirstOrDefaultAsync();
                if (marque == null)
                {
                    _context.Add(UneMarque);
                }

                var modele = await _context.Modeles
                    .Where(p => p.Annee == model.Annee && p.Nom.ToLower() == model.Modele.ToLower() && p.UneMarque == UneMarque)
                    .FirstOrDefaultAsync();
                if (modele == null)
                {
                    _context.Add(UnModele);
                }

                await _context.SaveChangesAsync();

                // Définir le dossier de stockage (wwwroot/uploads)
                string uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads");

                // Vérifier si le dossier existe, sinon le créer
                if (!Directory.Exists(uploadPath))
                {
                    Directory.CreateDirectory(uploadPath);
                }

                // Générer un nom unique pour l'image
                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(model.Photo.FileName);
                string filePath = Path.Combine(uploadPath, fileName);

                // Enregistrer l'image sur le serveur
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await model.Photo.CopyToAsync(stream);
                }
                var UneVoiture = new Voiture()
                {
                    PrixVente = model.PrixVente,
                    Finition = model.Finition,
                    Photo = fileName,
                    UnModele = UnModele
                };
                _context.Add(UneVoiture);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        // GET: Voitures/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Voitures == null)
            {
                return NotFound();
            }

            var voiture = await _context.Voitures.FindAsync(id);
            if (voiture == null)
            {
                return NotFound();
            }
            return View(voiture);
        }

        // POST: Voitures/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CodeVIN,Finition,DateAchat,PrixAchat,Disponible,DateVente,Photo,Description,PrixVente")] Voiture voiture)
        {
            if (id != voiture.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(voiture);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VoitureExists(voiture.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(voiture);
        }

        // GET: Voitures/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Voitures == null)
            {
                return NotFound();
            }

            var voiture = await _context.Voitures
                .FirstOrDefaultAsync(m => m.Id == id);
            if (voiture == null)
            {
                return NotFound();
            }

            return View(voiture);
        }

        // POST: Voitures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Voitures == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Voitures'  is null.");
            }
            var voiture = await _context.Voitures.FindAsync(id);
            if (voiture != null)
            {
                _context.Voitures.Remove(voiture);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VoitureExists(int id)
        {
            return (_context.Voitures?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
