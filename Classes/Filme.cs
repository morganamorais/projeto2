using System;

namespace Series.Classes
{
    public class Filme : Serie
    {
        private string AtorPrincipal { get; set; }
        
        private string MusicaPrincipal { get; set; }

        public Filme (int id, Genero genero, string titulo, string descricao, int ano, 
            string atorPrincipal, string musicaFilme) 
        : base(id, genero, titulo, descricao, ano)
        {  
            this.AtorPrincipal = atorPrincipal;
            this.MusicaPrincipal = musicaFilme;
          
        }
         public override string ToString()
        {
            string retorno = "";
            retorno += "AtorPrincipal: " + this.AtorPrincipal + Environment.NewLine;
            retorno +=  "MúsicaPrincipal: " + this.MusicaPrincipal + Environment.NewLine;
            return retorno;
        }
        public string retornaAtorPrincipal()
        {
            return this.AtorPrincipal;
        }
        public string retornaMusicaPrincipal()
        {
            return this.MusicaPrincipal;
        }


    }

}