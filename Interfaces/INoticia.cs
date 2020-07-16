using System.Collections.Generic;
using Eplayers.Models;


namespace Eplayers.Interfaces {

    public interface INoticia {

        void Create (Noticia e);

        List<Noticia> ReadAll();

        void Update(Noticia e);

        void Delete(int IdNoticia);
    }
}