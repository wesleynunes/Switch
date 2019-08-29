using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Switch.Domain.Entities;
using Switch.Domain.Services;
using Switch.Infra.Data.Context;

namespace SwitchMVC.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly SwitchContext _context;
        private readonly IHostingEnvironment _hostingEnv;

        public UsuariosController(SwitchContext context, IHostingEnvironment hostingEnv)
        {
            _context = context;
            _hostingEnv = hostingEnv;
        }

        // GET: Usuarios
        public async Task<IActionResult> Index()
        {
            return View(await _context.Usuarios.ToListAsync());
        }

        // GET: Usuarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuarios
                .FirstOrDefaultAsync(m => m.Id == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // GET: Usuarios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Usuarios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Usuario usuario)
        {
            string uploadPath = "uploads/images/";
            if (ModelState.IsValid)
            {
                var files = HttpContext.Request.Form.Files;
                foreach (var file in files)
                {
                    if (file != null && file.Length > 0)
                    {
                        var fileName = Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(file.FileName);
                        var uploadPathWithfileName = Path.Combine(uploadPath, fileName);

                        var uploadAbsolutePath = Path.Combine(_hostingEnv.WebRootPath, uploadPathWithfileName);

                        using (var fileStream = new FileStream(uploadAbsolutePath, FileMode.Create))
                        {
                            await file.CopyToAsync(fileStream);
                            usuario.UrlFoto = uploadPathWithfileName;

                        }
                    }
                }

                usuario.Senha = Hash.GenerateHash(usuario.Senha);
                _context.Add(usuario);
                TempData["MessagemOk"] = "Usuário registrado com sucesso";
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors);
            }
            return View(usuario);
         
        }

        // GET: Usuarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }
            return View(usuario);
        }

        // POST: Usuarios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Usuario usuario)
        {

            if (id != usuario.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {

                try
                {
                    var files = HttpContext.Request.Form.Files;
                    string uploadPath = "uploads/images/";

                    foreach (var file in files)
                    {
                        if (file != null && file.Length > 0)
                        {
                            var fileName = Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(file.FileName);                           
                            var uploadPathWithfileName = Path.Combine(uploadPath, fileName);

                            var uploadAbsolutePath = Path.Combine(_hostingEnv.WebRootPath, uploadPathWithfileName);

                            using (var fileStream = new FileStream(uploadAbsolutePath, FileMode.Create))
                            {
                                await file.CopyToAsync(fileStream);
                                usuario.UrlFoto = uploadPathWithfileName;
                            }
                        }
                    }

                    usuario.Senha = Hash.GenerateHash(usuario.Senha);
                    _context.Update(usuario);
                    TempData["MessagemOk"] = "Usuário atualizado com sucesso";
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsuarioExists(usuario.Id))
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
            return View(usuario);
        }


        // GET: Usuarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuarios
                .FirstOrDefaultAsync(m => m.Id == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            _context.Usuarios.Remove(usuario);
            TempData["MessagemOk"] = "Usuário deletado";
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UsuarioExists(int id)
        {
            return _context.Usuarios.Any(e => e.Id == id);
        }

    }
}
