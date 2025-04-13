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
            var voitures = await _context.Voitures
                .Include(v => v.UnModele)
                .Include(v => v.UnModele.UneMarque)
                .ToListAsync();
            var VoitureViewModel = voitures.Select(v => new VoitureViewModel
            {
                IdVoiture = v.Id,
                CodeVIN = v.CodeVIN,
                DateAchat = v.DateAchat,
                Disponible = v.Disponible,
                DateVente = v.DateVente,
                PrixVente = v.PrixVente,
                Description = v.Description,
                Annee = v.UnModele.Annee,
                Marque = v.UnModele.UneMarque.Nom,
                Modele = v.UnModele.Nom,
                Finition = v.Finition,
                PhotoS = v.Photo
            }).ToList();

            return VoitureViewModel != null ?
                        View(VoitureViewModel) :
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
                .Include(v => v.UnModele)
                .Include(v => v.UnModele.UneMarque)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (voiture == null)
            {
                return NotFound();
            }

            var VoitureViewModel = new VoitureViewModel
            {
                IdVoiture = voiture.Id,
                CodeVIN = voiture.CodeVIN,
                DateAchat = voiture.DateAchat,
                Disponible = voiture.Disponible,
                DateVente = voiture.DateVente,
                PrixVente = voiture.PrixVente,
                Description = voiture.Description,
                Annee = voiture.UnModele.Annee,
                Marque = voiture.UnModele.UneMarque.Nom,
                Modele = voiture.UnModele.Nom,
                Finition = voiture.Finition,
                PhotoS = voiture.Photo
            };

            return View(VoitureViewModel);
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
        public async Task<IActionResult> Create(CreateVoitureViewModel model)
        {
            if (ModelState.IsValid)
            {
                var marque = await _context.Marques
                    .Where(p => p.Nom.ToLower() == model.Marque.ToLower())
                    .FirstOrDefaultAsync();
                if (marque == null)
                {
                    marque = new Marque()
                    {
                        Nom = model.Marque
                    };
                    _context.Add(marque);
                }

                var modele = await _context.Modeles
                    .Where(p => p.Annee == model.Annee && p.Nom.ToLower() == model.Modele.ToLower() && p.UneMarque == marque)
                    .FirstOrDefaultAsync();
                if (modele == null)
                {
                    modele = new Modele()
                    {
                        Annee = model.Annee,
                        Nom = model.Modele,
                        UneMarque = marque
                    };
                    _context.Add(modele);
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
                    UnModele = modele
                };

                _context.Add(UneVoiture);
                await _context.SaveChangesAsync();

                ViewData["Titre"] = "Merci !";
                ViewData["p"] = "votre voiture a été bien publiée";

                return View("Confirmation");
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

            var voiture = await _context.Voitures
                .Include(v => v.UnModele)
                .Include(v => v.UnModele.UneMarque)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (voiture == null)
            {
                return NotFound();
            }

            var VoitureViewModel = new EditVoitureViewModel
            {
                IdVoiture = voiture.Id,
                CodeVIN = voiture.CodeVIN,
                DateAchat = voiture.DateAchat,
                Disponible = voiture.Disponible,
                DateVente = voiture.DateVente,
                PrixVente = voiture.PrixVente,
                PrixAchat = voiture.PrixAchat,
                Description = voiture.Description,
                Annee = voiture.UnModele.Annee,
                Marque = voiture.UnModele.UneMarque.Nom,
                Modele = voiture.UnModele.Nom,
                Finition = voiture.Finition,
                PhotoS = voiture.Photo
            };

            return View(VoitureViewModel);
        }

        // POST: Voitures/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditVoitureViewModel model, int id)
        {
            if (id != model.IdVoiture)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var marque = await _context.Marques
                        .Where(p => p.Nom.ToLower() == model.Marque.ToLower())
                        .FirstOrDefaultAsync();
                    if (marque == null)
                    {
                        marque = new Marque()
                        {
                            Nom = model.Marque
                        };
                        _context.Add(marque);
                    }

                    var modele = await _context.Modeles
                        .Where(p => p.Annee == model.Annee && p.Nom.ToLower() == model.Modele.ToLower() && p.UneMarque == marque)
                        .FirstOrDefaultAsync();
                    if (modele == null)
                    {
                        modele = new Modele()
                        {
                            Annee = model.Annee,
                            Nom = model.Modele,
                            UneMarque = marque
                        };
                        _context.Add(modele);
                    }

                    await _context.SaveChangesAsync();
                    string fileName = "";
                    if (model.Photo != null)
                    {
                        // Définir le dossier de stockage (wwwroot/uploads)
                        string uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads");

                        // Vérifier si le dossier existe, sinon le créer
                        if (!Directory.Exists(uploadPath))
                        {
                            Directory.CreateDirectory(uploadPath);
                        }

                        // Générer un nom unique pour l'image
                        fileName = Guid.NewGuid().ToString() + Path.GetExtension(model.Photo.FileName);
                        string filePath = Path.Combine(uploadPath, fileName);

                        // Enregistrer l'image sur le serveur
                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await model.Photo.CopyToAsync(stream);
                        }
                        model.PhotoS = fileName;
                    }
                    else
                    {
                        var UneVoiture = _context.Voitures.AsNoTracking().FirstOrDefault(v => v.Id == id);
                        model.PhotoS = UneVoiture.Photo;
                    }

                    var voiture = new Voiture()
                    {
                        Id = model.IdVoiture,
                        CodeVIN = model.CodeVIN,
                        Finition = model.Finition,
                        DateAchat = model.DateAchat,
                        PrixAchat = model.PrixAchat,
                        Disponible = model.Disponible,
                        DateVente = model.DateVente,
                        Photo = model.PhotoS,
                        Description = model.Description,
                        PrixVente = model.PrixVente,
                        UnModele = modele
                    };

                    _context.Update(voiture);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VoitureExists(model.IdVoiture))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                ViewData["Titre"] = model.Annee + " " + model.Marque + " " + model.Modele;
                ViewData["p"] = "a bien été mis à jour";

                return View("Confirmation");
            }
            return View(model);
        }

        // GET: Voitures/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Voitures == null)
            {
                return NotFound();
            }

            var voiture = await _context.Voitures
                .Include(v => v.UnModele)
                .Include(v => v.UnModele.UneMarque)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (voiture == null)
            {
                return NotFound();
            }

            var VoitureViewModel = new VoitureViewModel
            {
                IdVoiture = voiture.Id,
                PrixVente = voiture.PrixVente,
                Annee = voiture.UnModele.Annee,
                Marque = voiture.UnModele.UneMarque.Nom,
                Modele = voiture.UnModele.Nom,
                Finition = voiture.Finition,
                PhotoS = voiture.Photo
            };

            return View(VoitureViewModel);
        }

        // POST: Voitures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int IdVoiture)
        {
            if (_context.Voitures == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Voitures'  is null.");
            }
            var voiture = await _context.Voitures
                .Include(v => v.UnModele)
                .Include(v => v.UnModele.UneMarque)
                .FirstOrDefaultAsync(m => m.Id == IdVoiture);
            if (voiture != null)
            {
                _context.Voitures.Remove(voiture);
            }

            await _context.SaveChangesAsync();

            ViewData["Titre"] = voiture.UnModele.Annee + " " + voiture.UnModele.UneMarque.Nom + " " + voiture.UnModele.Nom;
            ViewData["p"] = "a bien été supprimée";

            return View("Confirmation");
        }

        private bool VoitureExists(int id)
        {
            return (_context.Voitures?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
