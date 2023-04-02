using tabuleiro;
using pecas;
namespace Xadrez {

    class Program {

        static void Main(string[] args) {

            Tabuleiro tab = new(8, 8);

            tab.ColocarPeca(new Torre(Cor.Preta, tab ), new Posicao(4, 6));

            Tela.ImprimirTabuleiro(tab);

            Console.ReadLine();
              
        }
    }
}
