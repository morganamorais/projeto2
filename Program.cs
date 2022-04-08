using System.Data;
using System;
using System.Collections.Generic;

//Minhas classes
using Series.Interfaces;
using Series.Repositorios;
using Series.Classes;

namespace Series
{
    class Program
    {
        //Polimorfismo
        //É quando uma tipo de classe pode ser instanciada por outra 
        static IRepositorio<Serie> repositorio = new SerieRepositorio();
        static IRepositorio<Filme> repositorioFilme = new FilmeRepositorio();
        static void Main(string[] args)
        {
            string OpcaoUsuario = ObterOpcaoUsuario();

            while (OpcaoUsuario.ToUpper() != "x")
            {
                switch (OpcaoUsuario)
                {
                    case "1":
                    ListarSeries();
                    break;
                    case "2":
                    InserirSerie();
                    break;
                    case "3":
                    AtualizarSerie();
                    break;
                    case "4":
                    ExcluirSerie();
                    break;
                    case "5":
                    VizualizarSerie();
                    break;
                    case "C":
                    Console.Clear();
                    break;

                    default: 
                    throw new ArgumentOutOfRangeException();                  
                    
                }
                OpcaoUsuario = ObterOpcaoUsuario();
            }
            System.Console.WriteLine("Obrigado por utilizar nossos serviços. ");
            Console.ReadLine();
        }
        private static void ListarSeries()
        {
            Console.WriteLine("Listar séries");
            var lista = repositorio.Lista();
            
            if(lista.Count == 0)
            {
                Console.WriteLine("Nenhuma série cadastrada.");
                return;
            }
            foreach (var serie in lista)
            {
                var excluido = serie.retornaExcluido();

                Console.WriteLine("#ID {0}: - {1} {2}" , serie.retornaId(), serie.retornaTitulo(), (excluido ? "-Excluido-" : ""));
            }
        }
           private static void InserirSerie()
        {
            System.Console.WriteLine("Inserir nova série");

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} -{1}", i, Enum.GetName(typeof(Genero), i));
            }
            System.Console.Write("Digite o genêro entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            System.Console.Write("Digite o título da série: ");
            String entradaTitulo = Console.ReadLine();

            System.Console.Write("Digite o Ano de Início da série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            System.Console.Write("Digite a descrição da série: ");
            String entradaDescrição = Console.ReadLine();

            Serie novaSerie = new Serie(id: repositorio.ProximoId(),
                                         genero: (Genero)entradaGenero,
                                          titulo: entradaTitulo,
                                          ano: entradaAno,
                                          descricao:entradaDescrição);

            repositorio.Insere(novaSerie);
        }
        private static string ObterOpcaoUsuario()
        {
            System.Console.WriteLine();
            System.Console.WriteLine("Séries a seu dispor!!!");
            System.Console.WriteLine("Informe a opção desejada:");

            System.Console.WriteLine("1- Listar Séries");
            System.Console.WriteLine("2- Inserir nova série");
            System.Console.WriteLine("3- Atualizar série");
            System.Console.WriteLine("4- Excluir série");
            System.Console.WriteLine("5- Vizualizar série");
            System.Console.WriteLine("C- Limpar Tela");
            System.Console.WriteLine("X - Sair");
            System.Console.WriteLine();
           

            string ObterOpcaoUsuario = Console.ReadLine().ToUpper();
            System.Console.WriteLine();
            return ObterOpcaoUsuario;
        }
           
        private static void AtualizarSerie () 
        {
            System.Console.WriteLine("Digite o id da série");
             int indiceSerie = int.Parse(Console.ReadLine());

             foreach (int i in Enum.GetValues(typeof(Genero)))
             {
                 Console.WriteLine("{0} -{1}", i, Enum.GetName(typeof(Genero), i));
             }
             Console.Write("Digite o genêro entre as oções acima: ");
             int entradaGenero = int.Parse(Console.ReadLine());

              Console.Write("Digite o titulo  da série: ");
             string entradaTitulo = Console.ReadLine();

              Console.Write("Digite o Ano de Inicio da série: ");
             int entradaAno = int.Parse(Console.ReadLine());  

               Console.Write("Digite a decrição da série: ");
             string entradaDescrição = Console.ReadLine(); 
            
             
            Serie atualizaSerie = new Serie(id: indiceSerie,
                                         genero: (Genero)entradaGenero,
                                          titulo: entradaTitulo,
                                          ano: entradaAno,
                                          descricao:entradaDescrição);

            repositorio.Atualiza(indiceSerie, atualizaSerie);
                   
        }
           private static void ExcluirSerie() 
         {
             System.Console.WriteLine("Digite o id da séria: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            repositorio.Exclui(indiceSerie);
         }    
        private static void VizualizarSerie() 
        {
            System.Console.WriteLine("Digite o id da séria: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            var serie = repositorio.RetornaPorId(indiceSerie);

            System.Console.WriteLine(serie);

        }
        
    }
}
