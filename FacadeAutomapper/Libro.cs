using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacadeAutomapper
{
    class Libro
    {
        public int Id { get; set; } // this.Id lo coge de aqui
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public int Paginas { get; set; }

        public Libro()
        {

        }
        public Libro( int Id, string Titulo, string Autor, int Paginas)
        {
            this.Id = Id;
            this.Titulo = Titulo;
            this.Autor = Autor;
            this.Paginas = Paginas;

        }
    }
}
