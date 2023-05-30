using pecas;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using tabuleiro;

namespace Xadrez {
    class Tela {

        public static void ImprimirTabuleiro(Tabuleiro tabuleiro) {

            Console.Write("  ");
            for (int i = 0; i < tabuleiro.NumLinhas; i++) {

                Console.Write(i + " ");
            }
            Console.WriteLine();
            for (int i = 0; i < tabuleiro.NumLinhas; i++) {

                Console.Write((PosicaoXadrez)i);
                for (int j = 0; j < tabuleiro.NumColunas; j++) {

                    ImprimirPeca(tabuleiro.Peca(i, j));

                }
                Console.WriteLine();
            }

        }

        public static void ImprimirPartida(PartidaDeXadrez partida){

            ImprimirTabuleiro(partida.Tab);

            Console.WriteLine("\n");

            ImprimirPecasCapturadas(partida); 

            Console.WriteLine("\nTurno: " + partida.Turno);

            if (!partida.Terminada) {

                Console.WriteLine("Cor Atual: " + partida.JogadorAtual);

                if (partida.xeque) {

                    Console.WriteLine("XEQUE!");

                }
            } else {
                Console.WriteLine("XEQUE-MATE!");

                Console.WriteLine("Vencedor: " + partida.JogadorAtual);

            }

        }

        public static void ImprimirPecasCapturadas(PartidaDeXadrez partida) {

            Console.WriteLine("Peças Capturadas: ");

            Console.WriteLine("Brancas: " + ImprimirConjunto(partida.PecasCapturadas(Cor.Branca)));

            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Pretas: " + ImprimirConjunto(partida.PecasCapturadas(Cor.Preta)));
            Console.ForegroundColor = aux;
        }

        public static StringBuilder ImprimirConjunto(HashSet<Peca> conjunto) {

            StringBuilder sb = new StringBuilder();
            sb.Append("[");

            foreach(Peca x in conjunto) { 
                
                sb.Append(x + " ");
            
            }

            sb.Append("]");

            return sb;

        }


        public static void ImprimirTabuleiro(Tabuleiro tabuleiro, bool[,] moviPossiveis) {

            ConsoleColor fundoOriginal = Console.BackgroundColor;

            ConsoleColor fundoAlterado = ConsoleColor.DarkGray;

            Console.Write("  ");
            for (int i = 0; i < tabuleiro.NumLinhas; i++) {

                Console.Write(i + " ");
            }
            Console.WriteLine();
            for (int i = 0; i < tabuleiro.NumLinhas; i++) {

                Console.Write((PosicaoXadrez)i);
                for (int j = 0; j < tabuleiro.NumColunas; j++) {

                    if (moviPossiveis[i, j]) {

                        Console.BackgroundColor = fundoAlterado;
                    } else {

                        Console.BackgroundColor = fundoOriginal;

                    }

                    ImprimirPeca(tabuleiro.Peca(i, j));

                }

                Console.BackgroundColor = fundoOriginal;
                Console.WriteLine();
            }

        }




        public static Posicao LerPosicaoXadrez(string posicao) {
            posicao = posicao.ToLower();
            PosicaoXadrez linha;

            try {

                linha = Enum.Parse<PosicaoXadrez>(posicao[0] + "");

                int coluna = int.Parse(posicao[1] + "");

                Console.WriteLine(linha + "" + coluna);

                return new Posicao(coluna, (int)linha);

            } catch(Exception e) {

                throw new TabuleiroException("Posicao Inválida\n\n" + e.Message);

            }
            

        }

        public static void ImprimirPeca(Peca peca) {

            if (peca == null) {
                Console.Write(" -");

            } else {

                if (peca.Cor == Cor.Branca) {

                    Console.Write(" " + peca);
                } else {
                    ConsoleColor aux = Console.ForegroundColor;

                    Console.ForegroundColor = ConsoleColor.DarkYellow;

                    Console.Write(" " + peca);

                    Console.ForegroundColor = aux;

                }

            }
        }
    }
}

