using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Eplayers.Models;
using Microsoft.AspNetCore.Http;

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
            noticia.Imagem = form["Imagem"];

            noticiaModel.Create(noticia);

            ViewBag.Noticias = noticiaModel;
            return LocalRedirect("~/Noticia");
        }
    }
}
