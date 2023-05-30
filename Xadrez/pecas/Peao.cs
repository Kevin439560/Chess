using tabuleiro;

namespace pecas {
    internal class Peao : Peca {
        public Peao(Cor cor, Tabuleiro Tabuleiro) : base(cor, Tabuleiro) {

        }

        private bool ExisteInimigo(Posicao pos) {

            Peca p = Tabuleiro.Peca(pos);

            return p != null && p.Cor != Cor;

        }

        private bool Livre(Posicao pos) {

            return Tabuleiro.Peca(pos) == null;

        }

        public override bool[,] MovimentosPossiveis() {
            bool[,] mat = new bool[Tabuleiro.NumLinhas, Tabuleiro.NumColunas];

            Posicao pos = new(0, 0);

            if(Cor == Cor.Branca) {

                pos.DefinirValores(Posicao.Coluna, Posicao.Linha - 1);
                if(Tabuleiro.PosicaoValida(pos) && Livre(pos)) {
                    mat[pos.Linha,pos.Coluna] = true;
                }

                pos.DefinirValores(Posicao.Coluna, Posicao.Linha - 2);
                if (Tabuleiro.PosicaoValida(pos) && Livre(pos)) {
                    mat[pos.Linha, pos.Coluna] = true;
                }
                pos.DefinirValores(Posicao.Coluna - 1, Posicao.Linha - 1);
                if (Tabuleiro.PosicaoValida(pos) && ExisteInimigo(pos)) {
                    mat[pos.Linha, pos.Coluna] = true;
                }
                pos.DefinirValores(Posicao.Coluna + 1, Posicao.Linha - 1);
                if (Tabuleiro.PosicaoValida(pos) && ExisteInimigo(pos)) {
                    mat[pos.Linha, pos.Coluna] = true;
                }

            } else {

                pos.DefinirValores(Posicao.Coluna, Posicao.Linha + 1);
                if (Tabuleiro.PosicaoValida(pos) && Livre(pos)) {
                    mat[pos.Linha, pos.Coluna] = true;
                }

                pos.DefinirValores(Posicao.Coluna, Posicao.Linha + 2);
                if (Tabuleiro.PosicaoValida(pos) && Livre(pos)) {
                    mat[pos.Linha, pos.Coluna] = true;
                }
                pos.DefinirValores(Posicao.Coluna - 1, Posicao.Linha + 1);
                if (Tabuleiro.PosicaoValida(pos) && ExisteInimigo(pos)) {
                    mat[pos.Linha, pos.Coluna] = true;
                }
                pos.DefinirValores(Posicao.Coluna + 1, Posicao.Linha + 1);
                if (Tabuleiro.PosicaoValida(pos) && ExisteInimigo(pos)) {
                    mat[pos.Linha, pos.Coluna] = true;
                }

            }

            return mat;
        }

        public override string ToString() {
            return "P";
        } 
    }
}
