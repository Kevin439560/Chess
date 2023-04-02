using tabuleiro;

namespace pecas {
    class Bispo : Peca {

        public Bispo(Cor cor, Tabuleiro tabuleiro) : base(cor, tabuleiro) {

        }

        public override string ToString() {
            return "B";
        }
    }
}
