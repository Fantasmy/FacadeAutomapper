using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace FacadeAutomapper
{
    [DataContract]
    class LibroDTO
    {
        [DataMember]
        public int Id { get; set; } // this.Id lo coge de aqui
        [DataMember]
        public string Titulo { get; set; }
        [DataMember]
        public string Autor { get; set; }
        /*[DataMember]
        public int Paginas { get; set; }*/
    }
}
