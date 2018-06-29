using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace FacadeAutomapper
{
    class Program
    {
        static void Main(string[] args)
        {
            // Leer el XML
            // https://stackoverflow.com/questions/642293/how-do-i-read-and-parse-an-xml-file-in-c

            XmlDocument doc = new XmlDocument();
            doc.Load("book.xml");
            // variables string recogidas de los nodos del xml
            string id = doc.DocumentElement.SelectSingleNode("/book/id").InnerText;
            string title = doc.DocumentElement.SelectSingleNode("/book/title").InnerText;
            string author = doc.DocumentElement.SelectSingleNode("/book/author").InnerText;
            string pages = doc.DocumentElement.SelectSingleNode("/book/pages").InnerText;

            // Crear instancia de Libro usando datos del XML
            Assembly myAssembly = typeof(Program).Assembly;
            // obtenemos un Type libro usando reflection
            Type libroType = myAssembly.GetType("FacadeAutomapper.Libro");

            if (libroType != null)  // solo continua por aqui si encuentra un tipo llamado Libro
            {
                int idEntero = Convert.ToInt32(id);
                int pagesEntero = Convert.ToInt32(pages);

                // esta linea falla porque no encuentra un constructor con string, string, string, string
                //object libro = Activator.CreateInstance(libroType, id, title, author, pages);

                // esta si que va porque existe constructor int, string, string, int
                object libro = Activator.CreateInstance(libroType, idEntero, title, author, pagesEntero);

                Libro libroAux = (Libro)libro; // Hace un cast -> variable libroAux del tipo Libro, lo coge a partir del object libro
                Console.WriteLine(libroAux.Titulo);


                // usamos automapper para pasar el tipo Libro (origen) a LibroDTO(destino)
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<Libro, LibroDTO>();
                });
                IMapper iMapper = config.CreateMapper(); // variable del tipo IMapper que es una interface
                LibroDTO destination = iMapper.Map<Libro, LibroDTO>(libroAux);
                Console.WriteLine(destination.Titulo);


            }
            

            //var libro2 = new Libro(id, title, author, pages); <-- peta en tiempo de compilación porque busca un constructor de Libro string string string string (aqui le dices que quieres crear un tipo libro)

        }
    }
}
