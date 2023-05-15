
using tabuleiro;

namespace pecas {
    class Horse : Peca {
        public Horse(Cor cor, Tabuleiro Tabuleiro) : base(cor, Tabuleiro) {

        }

        private bool PodeMover(Posicao pos) {
            Peca p = Tabuleiro.Peca(pos);

            return p == null || p.Cor != Cor;
        }

        public override bool[,] MovimentosPossiveis() {
            bool[,] mat = new bool[Tabuleiro.NumLinhas, Tabuleiro.NumColunas];

            Posicao pos = new(0, 0);


            //acima esquerda acima
            pos.DefinirValores(Posicao.Coluna - 1, Posicao.Linha - 2);
            if (Tabuleiro.PosicaoValida(pos) && PodeMover(pos)) {
                mat[pos.Linha, pos.Coluna] = true;
            }

            //acima esquerda abaixo
            pos.DefinirValores(Posicao.Coluna - 2, Posicao.Linha - 1);
            if (Tabuleiro.PosicaoValida(pos) && PodeMover(pos)) {
                mat[pos.Linha, pos.Coluna] = true;
            }

            //acima direita acima
            pos.DefinirValores(Posicao.Coluna + 1, Posicao.Linha - 2);
            if (Tabuleiro.PosicaoValida(pos) && PodeMover(pos)) {
                mat[pos.Linha, pos.Coluna] = true;
            }

            //acima direita abaixo
            pos.DefinirValores(Posicao.Coluna + 2, Posicao.Linha - 1);
            if (Tabuleiro.PosicaoValida(pos) && PodeMover(pos)) {
                mat[pos.Linha, pos.Coluna] = true;
            }

            //abaixo esquerda acima
            pos.DefinirValores(Posicao.Coluna - 2, Posicao.Linha + 1);
            if (Tabuleiro.PosicaoValida(pos) && PodeMover(pos)) {
                mat[pos.Linha, pos.Coluna] = true;
            }

            //abaixo esquerda abaixo
            pos.DefinirValores(Posicao.Coluna - 1, Posicao.Linha + 2);
            if (Tabuleiro.PosicaoValida(pos) && PodeMover(pos)) {
                mat[pos.Linha, pos.Coluna] = true;
            }

            //abaixo direita acima
            pos.DefinirValores(Posicao.Coluna + 2, Posicao.Linha + 1);
            if (Tabuleiro.PosicaoValida(pos) && PodeMover(pos)) {
                mat[pos.Linha, pos.Coluna] = true;
            }

            //abaixo direita abaixo
            pos.DefinirValores(Posicao.Coluna + 1, Posicao.Linha + 2);
            if (Tabuleiro.PosicaoValida(pos) && PodeMover(pos)) {
                mat[pos.Linha, pos.Coluna] = true;
            }
            mat[2, 2] = true;
            return mat;
        }

        public override string ToString() {
            return "C";
        }
    }
}
