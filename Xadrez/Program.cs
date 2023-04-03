using tabuleiro;
using pecas;
namespace Xadrez {

    class Program {

        static void Main(string[] args) {

            try {
                Tabuleiro tab = new(8, 8);

                tab.ColocarPeca(new Torre(Cor.Branca, tab), new Posicao(4, 0));
                tab.ColocarPeca(new Cavalo(Cor.Preta, tab), new Posicao(2, 6));
                tab.ColocarPeca(new Rei(Cor.Branca, tab), new Posicao(3, 7));
                tab.ColocarPeca(new Torre(Cor.Preta, tab), new Posicao(1, 5));

                Tela.ImprimirTabuleiro(tab);

                Console.ReadLine();
            } catch (TabuleiroException e) {

                Console.WriteLine(e.Message);
            }

            //PosicaoXadrez z = Enum.Parse<PosicaoXadrez>(Console.ReadLine());

            //Console.WriteLine(z);


        }
    }
}
