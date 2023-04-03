using tabuleiro;

namespace Xadrez {
    class Tela {

        public static void ImprimirTabuleiro(Tabuleiro tabuleiro) {

            Console.Write("  ");
            for(int i = 0; i < tabuleiro.NumLinhas; i++) {

                Console.Write((PosicaoXadrez)i + " ");
            }
            Console.WriteLine();
            for (int i = 0; i < tabuleiro.NumLinhas; i++) {

                Console.Write(i);
                for (int j = 0; j < tabuleiro.NumColunas; j++) {

                    if (tabuleiro.Peca(i, j) == null) {

                        Console.Write(" -");

                    } else {

                        Console.Write(" " + tabuleiro.Peca(i, j));

                    }

                }
                Console.WriteLine();
            }
        }
    }
}
