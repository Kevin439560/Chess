using tabuleiro;
namespace Xadrez {

    class Program {

        static void Main(string[] args) {

            Tabuleiro tab = new(8, 8);

            Tela.ImprimirTabuleiro(tab);

            Console.ReadLine();
             
        }
    }
}
