using System;
using System.Collections.Generic;
using System.IO;
using Eplayers.Interfaces;

namespace Eplayers.Models {

    public class Noticia : EplayersBase, INoticia {

        public Noticia (int idNoticia, string titulo, string texto, string imagem) {
            this.IdNoticia = idNoticia;
            this.Titulo = titulo;
            this.Texto = texto;
            this.Imagem = imagem;

        }
        public int IdNoticia { get; set; }
        public string Titulo { get; set; }
        public string Texto { get; set; }
        public string Imagem { get; set; }
        private const string PATH = "Database/noticia.csv";

        public Noticia () {
            CreateFolderAndFile (PATH);
        }

        public void Create (Noticia e) {
            string[] linha = { Prepare (e) };
            File.AppendAllLines (PATH, linha);
        }

        private string Prepare (Noticia e) {
            return $"{e.IdNoticia};{e.Titulo};{e.Texto};{e.Imagem}";
        }
        public void Delete (int IdNoticia) {
            List<string> linhas = ReadAllLinesCSV (PATH);
            linhas.RemoveAll (y => y.Split (";") [0] == IdNoticia.ToString ());
            RewriteCSV (PATH, linhas);
        }

        public List<Noticia> ReadAll () {
            List<Noticia> noticias = new List<Noticia> ();
            string[] linhas = File.ReadAllLines (PATH);
            foreach (var item in linhas) {
                string[] linha = item.Split (";");
                Noticia noticia = new Noticia ();
                noticia.IdNoticia = Int32.Parse (linha[0]);
                noticia.Titulo = linha[1];
                noticia.Texto = linha[2];
                noticia.Imagem = linha[3];

                noticias.Add (noticia);
            }
            return noticias;
        }

        public void Update (Noticia e) {
            List<string> linhas = ReadAllLinesCSV (PATH);
            linhas.RemoveAll (y => y.Split (";") [0] == e.IdNoticia.ToString ());
            linhas.Add (Prepare (e));
            RewriteCSV (PATH, linhas);
        }
    }
}