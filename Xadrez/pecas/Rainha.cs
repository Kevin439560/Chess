
using tabuleiro;

namespace pecas {
    class Rainha : Peca {

        public Rainha(Cor cor, Tabuleiro Tabuleiro) : base(cor, Tabuleiro) {

        }

        public override bool[,] MovimentosPossiveis() {
            bool[,] mat = new bool[Tabuleiro.NumLinhas, Tabuleiro.NumColunas];

            Posicao pos = new(0, 0);

            return mat;
        }

        public override string ToString() {
            return "Q";
        }
    }
}
