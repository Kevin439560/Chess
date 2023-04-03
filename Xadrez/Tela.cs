using pecas;
using tabuleiro;

namespace Xadrez {
    class Tela {

        public static void ImprimirTabuleiro(Tabuleiro tabuleiro) {

            Console.Write("  ");
            for (int i = 1; i <= tabuleiro.NumLinhas; i++) {

                Console.Write((PosicaoXadrez)i - 1 + " ");
            }
            Console.WriteLine();
            for (int i = 1; i <= tabuleiro.NumLinhas; i++) {

                Console.Write(i);
                for (int j = 1; j <= tabuleiro.NumColunas; j++) {

                    if (tabuleiro.Peca(i - 1, j - 1) == null) {

                        Console.Write(" -");

                    } else {

                        ImprimirPeca(tabuleiro.Peca(i - 1, j - 1));
                         
                    }

                }
                Console.WriteLine();
            }

            static void ImprimirPeca(Peca peca) {

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
