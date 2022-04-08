
using System.Collections.Generic;
using System;

using Series.Interfaces;
using Series.Classes;

namespace Series.Repositorios
{
    public class FilmeRepositorio : IRepositorio<Filme>
    {
       
         private List<Filme> listaFilme = new List<Filme>();

          public void Atualiza(int id, Filme filme)
         {
             listaFilme[id] = filme;
         }
           public void Exclui(int id)
         {
            listaFilme[id].Excluir();
         }
           public void Insere(Filme filme)
         {
           listaFilme.Add(filme);
         }
          public List<Filme> Lista()
          {
            return listaFilme;
          }
          public int ProximoId()
          {
           return listaFilme.Count;
          }
         public Filme RetornaPorId(int id)
          {
            return listaFilme[id];
          }
  }
  
        
} 