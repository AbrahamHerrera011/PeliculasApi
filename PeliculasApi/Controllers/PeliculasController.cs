using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PeliculasApi.Models;
using PeliculasApi.Controllers;
using Microsoft.EntityFrameworkCore;

namespace PeliculasApi.Controllers
{
    [Route("api")]
    [ApiController]
    public class PeliculasController : ControllerBase
    {
        private readonly PeliculasContext contexto;
        

        public PeliculasController(PeliculasContext _contexto)
        {
            contexto = _contexto;
        }

        [HttpGet]
        [Route("films")]
        public async Task<IQueryable<Pelicula>> GetAll()
        {
            var query = await contexto.Peliculas.AsQueryable<Pelicula>().AsNoTracking().ToListAsync();
            return query.AsQueryable();
        }


        [HttpGet]
        [Route("films/{id:int}")]
        public async Task<Pelicula> ObtenerporID(int id)
        {
            var query = await contexto.Peliculas.FirstOrDefaultAsync(x => x.Idpeliculas == id);
            return query;
        }

        [HttpPost]
        [Route("films")]
        public async Task<int> crear(Pelicula Nuevapelicula)
        {
            var query = Nuevapelicula;
            await contexto.AddAsync(query);
            var guardar = await contexto.SaveChangesAsync();
            return query.Idpeliculas;

        }

        [HttpPut]
        [Route("films/{id:int}")]
        public async Task<bool> actualizar(int id, Pelicula NuevaPelicula)
        {
            var query = await ObtenerporID(id);
            query.Titulo = NuevaPelicula.Titulo;
            query.Director = NuevaPelicula.Director;
            query.Genero = NuevaPelicula.Genero;
            query.Puntacion = NuevaPelicula.Puntacion;
            query.Rating = NuevaPelicula.Rating;
            query.AnioDePublicacion = NuevaPelicula.AnioDePublicacion;
            contexto.Update(query);
            var guardar = await contexto.SaveChangesAsync();
            return guardar > 0;

        }
        [HttpDelete]
        [Route("films/{id:int}")]
        public async Task<bool> borrar(int id)
        {
            var query = await ObtenerporID(id);
            contexto.Remove(query);
            var guardar = await contexto.SaveChangesAsync();
            return guardar > 0;
        }


        [HttpGet]
        [Route("films/filters")]
        public async Task<IQueryable<Pelicula>> ObtenerporFiltro([FromBody] Pelicula buscarPeliculaNombre)
        {
            if (buscarPeliculaNombre == null)
            {
                return new List<Pelicula>().AsQueryable();
            }
            var query = contexto.Peliculas.AsQueryable();


            if (!string.IsNullOrEmpty(buscarPeliculaNombre.Titulo))
            {
                query = query.Where(x => x.Titulo.Contains(buscarPeliculaNombre.Titulo));
            }

            if (!string.IsNullOrEmpty(buscarPeliculaNombre.Director))
            {
                query = query.Where(x => x.Director.Contains(buscarPeliculaNombre.Director));
            }
            if (!string.IsNullOrEmpty(buscarPeliculaNombre.Genero))
            {
                query = query.Where(x => x.Genero.Contains(buscarPeliculaNombre.Genero));
            }

            if (!string.IsNullOrEmpty(buscarPeliculaNombre.Rating))
            {
                query = query.Where(x => x.Rating.Contains(buscarPeliculaNombre.Rating));
            }

            var resultado = await query.ToListAsync();
            return resultado.AsQueryable().AsNoTracking();
        }






    }

}
