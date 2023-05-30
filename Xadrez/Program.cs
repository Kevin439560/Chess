using tabuleiro;
using pecas;
namespace Xadrez {

    class Program {

        static void Main(string[] args) {

            try {


                PartidaDeXadrez partida = new PartidaDeXadrez();

                while (!partida.Terminada) {
                    try {


                        Console.Clear();

                        Tela.ImprimirPartida(partida);

                        Console.Write("Escolha uma Peca digitando sua posicao(letra/numero): ");

                        string posicao = Console.ReadLine();

                        partida.ValidarLetra(posicao);

                        Posicao origem = Tela.LerPosicaoXadrez(posicao);

                        partida.ValidarPosOrigem(origem);

                        bool[,] posicoesPossiveis = partida.Tab.Peca(origem).MovimentosPossiveis();

                        Console.Clear();

                        Tela.ImprimirTabuleiro(partida.Tab, posicoesPossiveis);

                        Console.Write("Agora escolha um destino digitando sua posicao(letra/numero): ");

                        posicao = Console.ReadLine();

                        partida.ValidarLetra(posicao);

                        Posicao destino = Tela.LerPosicaoXadrez(posicao);

                        partida.ValidarPosDestino(origem, destino);

                        partida.RealizaJogada(origem, destino);

                    } catch (TabuleiroException e){

                        Console.WriteLine(e.Message);

                        Console.ReadLine();

                    }

                }
                Console.Clear();

                Tela.ImprimirPartida(partida);

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
