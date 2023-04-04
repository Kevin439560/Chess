using pecas;
using System.Security.Cryptography.X509Certificates;
using tabuleiro;

namespace Xadrez {
    class Tela {

        public static void ImprimirTabuleiro(Tabuleiro tabuleiro) {

            Console.Write("  ");
            for (int i = 0; i < tabuleiro.NumLinhas; i++) {

                Console.Write((PosicaoXadrez)i + " ");
            }
            Console.WriteLine();
            for (int i = 0; i < tabuleiro.NumLinhas; i++) {

                Console.Write(i);
                for (int j = 0; j < tabuleiro.NumColunas; j++) {

                    if (tabuleiro.Peca(i, j) == null) {

                        Console.Write(" -");

                    } else {

                        ImprimirPeca(tabuleiro.Peca(i, j));

                    }

                }
                Console.WriteLine();
            }

        }

        public static Posicao LerPosicaoXadrez(string posicao) {

            PosicaoXadrez coluna = Enum.Parse<PosicaoXadrez>(posicao[0] + "");

            int linha = int.Parse(posicao[1] + "");

            Console.WriteLine(coluna + "" +   linha);

            return new Posicao((int)coluna, linha);

        }

        public static void ImprimirPeca(Peca peca) {

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

