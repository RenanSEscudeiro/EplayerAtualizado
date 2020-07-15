using System;
using System.Collections.Generic;
using System.IO;
using Eplayers.Interfaces;

namespace Eplayers.Models {
    public class Equipe : EplayersBase , IEquipe {
        public int IdEquipe { get; set; }
        public string Nome { get; set; }
        public string Imagem { get; set; }
        //string para chamar imagem 
        private const string PATH = "Database/equipe.csv";

        /// <summary>
        /// Cria Folder e File Equipe
        /// </summary>
        public Equipe () {
            CreateFolderAndFile (PATH);
        }

        /// <summary>
        /// Criar Equipe
        /// </summary>
        /// <param name="Create Equipe"></param>
        public void Create (Equipe e) {
            string[] linha = { Prepare (e) };
            File.AppendAllLines (PATH, linha);
        }

        /// <summary>
        /// Preparar estrutura id;nome;imagem
        /// </summary>
        /// <param name="Estrutura"></param>
        private string Prepare (Equipe e) {
            return $"{e.IdEquipe};{e.Nome};{e.Imagem}";
        }



        /// <summary>
        /// Deleta uma equipe
        /// </summary>
        /// <param name="Delete Equipe"></param>
        public void Delete (int idEquipe) {
            List<string> linhas = ReadAllLinesCSV (PATH);
            linhas.RemoveAll (y => y.Split (";") [0] == IdEquipe.ToString ());
            RewriteCSV (PATH, linhas);
        }


        /// <summary>
        /// Read Equipe
        /// </summary>
        /// <returns>Return Equipes</returns>
        public List<Equipe> ReadAll () {
            List<Equipe> equipes = new List<Equipe> ();
            string[] linhas = File.ReadAllLines (PATH);
            foreach (var item in linhas) {
                string[] linha = item.Split (";");
                Equipe equipe = new Equipe ();
                equipe.IdEquipe = Int32.Parse (linha[0]);
                equipe.Nome = linha[1];
                equipe.Imagem = linha[2];

                equipes.Add (equipe);
            }
            return equipes;
        }

        /// <summary>
        /// Update Equipes
        /// </summary>
        /// <param name="Update Equipes"></param>
        public void Update (Equipe e) {
            List<string> linhas = ReadAllLinesCSV (PATH);
            linhas.RemoveAll (y => y.Split (";") [0] == e.IdEquipe.ToString ());
            linhas.Add (Prepare (e));
            RewriteCSV (PATH, linhas);
            //update equipe
        }
    }
}