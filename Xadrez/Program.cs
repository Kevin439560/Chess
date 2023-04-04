using tabuleiro;
using pecas;
namespace Xadrez {

    class Program {

        static void Main(string[] args) {
            
            try {

                PartidaDeXadrez partida = new PartidaDeXadrez();

                Tela.ImprimirTabuleiro(partida.Tab);

                Console.ReadLine();
            } catch (TabuleiroException e) {

                Console.WriteLine(e.Message);
            }
            
            /*

            string[] vetro = Console.ReadLine().Split(" ");

            PosicaoXadrez z = Enum.Parse<PosicaoXadrez>(vetro[0]);

            Console.WriteLine((int)z);

            */
        }
    }
}
