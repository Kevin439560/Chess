using tabuleiro;
using pecas;
namespace Xadrez {

    class Program {

        static void Main(string[] args) {
            
            try {

                
                PartidaDeXadrez partida = new PartidaDeXadrez();

                while (!partida.Terminada) {

                    Console.Clear();

                    Tela.ImprimirTabuleiro(partida.Tab);

                    Console.Write("Escolha uma Peca digitando sua posicao(letra/numero): ");

                    string posicao = Console.ReadLine();

                    Posicao origem = Tela.LerPosicaoXadrez(posicao);

                    Console.Write("Agora escolha um destino digitando sua posicao(letra/numero): ");

                    posicao = Console.ReadLine();

                    Posicao destino = Tela.LerPosicaoXadrez(posicao);

                    partida.ExecutaMovimento(origem, destino);
                }

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
