using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Eplayers.Models;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace Eplayers.Controllers
{
    public class NoticiaController : Controller
    {
        Noticia noticiaModel = new Noticia();

        public IActionResult Index()
        {
            ViewBag.Noticias = noticiaModel.ReadAll();
            return View();

        }
        public IActionResult Cadastrar(IFormCollection form)
        {

            Noticia noticia = new Noticia();
            noticia.IdNoticia = Int32.Parse( form["idNoticia"]);
            noticia.Titulo = form["Titulo"];
            noticia.Texto = form["Texto"];
            // Upload Imagem
            var file    = form.Files[0];
            var folder  = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/Noticias");

            if(file != null)
            {
                if(!Directory.Exists(folder)){
                    Directory.CreateDirectory(folder);
                }

                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/", folder, file.FileName);
                using (var stream = new FileStream(path, FileMode.Create))  
                {  
                    file.CopyTo(stream);  
                }
                noticia.Imagem   = file.FileName;
            }
            else
            {
                noticia.Imagem   = "padrao.png";
            }
            // Upload Final

            noticiaModel.Create(noticia);

            ViewBag.Noticias = noticiaModel;
            return LocalRedirect("~/Noticia");
        }
    }
}
