using pecas;
using System.Security.Cryptography.X509Certificates;
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

            PosicaoXadrez linha = Enum.Parse<PosicaoXadrez>(posicao[0] + "");

            int coluna = int.Parse(posicao[1] + "");

            Console.WriteLine(linha + "" + coluna);

            return new Posicao(coluna, (int)linha);

        }

        public static void ImprimirPeca(Peca peca) {

            if (peca == null) {
                Console.Write(" -");

            } else {

                if (peca.Cor == Cor.Branca) {

                    Console.Write(" " + peca);
                } else {
                    ConsoleColor aux = Console.ForegroundColor;

                    Console.ForegroundColor = ConsoleColor.Yellow;

                    Console.Write(" " + peca);

                    Console.ForegroundColor = aux;

                }
                
            }
        }
    }
}

