using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;
using System.IO;
using System.Text;

namespace ApiBiblioteca.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LivroController : ControllerBase
    {
        [HttpGet]
        public List<Livro> Get()
        {
            return Program.livros;
        }

        [HttpGet("{id}", Name = "Get")]
        public Livro Get(int id)
        {

            Livro livro = Program.livros.Find(l => l.isbn == id);
            return livro;
        }

        [HttpPost]
        public List<Livro> Post([FromBody] Livro livro)
        {
            Program.livros.Add(livro);
            return Program.livros;
        }

        [HttpPut("{id}")]
        public List<Livro> Put(int id, [FromBody] Livro livro)
        {
            Livro livroToUpdate = Program.livros.Find(l => l.isbn == id);
            int index = Program.livros.IndexOf(livroToUpdate);

            Program.livros[index].Titulo = livro.Titulo;
            Program.livros[index].Descricao = livro.Descricao;
            Program.livros[index].Genero = livro.Genero;

            return Program.livros;
        }

        [HttpDelete("{id}")]
        public List<Livro> Delete(int id)
        {

            Livro livro = Program.livros.Find(l => l.isbn == id);
            Program.livros.Remove(livro);
            return Program.livros;
        }
    }
}
