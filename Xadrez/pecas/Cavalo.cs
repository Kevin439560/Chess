
using tabuleiro;

namespace pecas {
    internal class Cavalo : Peca {
        public Cavalo(Cor cor, Tabuleiro Tabuleiro) : base(cor, Tabuleiro) {

        }
        public override bool[,] MovimentosPossiveis() {
            bool[,] mat = new bool[Tabuleiro.NumLinhas, Tabuleiro.NumColunas];

            Posicao pos = new(0, 0);

            return mat;
        }

        public override string ToString() {
            return "C";
        }
    }
}
