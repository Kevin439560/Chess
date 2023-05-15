
using tabuleiro;

namespace pecas {
    class Rainha : Peca {

        public Rainha(Cor cor, Tabuleiro Tabuleiro) : base(cor, Tabuleiro) {

        }

        private bool PodeMover(Posicao pos) {
            Peca p = Tabuleiro.Peca(pos);

            return p == null || p.Cor != Cor;
        }

        public override bool[,] MovimentosPossiveis() {
            bool[,] mat = new bool[Tabuleiro.NumLinhas, Tabuleiro.NumColunas];

            Posicao pos = new(0, 0);


            //ACIMA
            pos.DefinirValores(Posicao.Coluna, Posicao.Linha - 1);
            while (Tabuleiro.PosicaoValida(pos) && PodeMover(pos)) {

                mat[pos.Linha, pos.Coluna] = true;
                if (Tabuleiro.Peca(pos) != null && Tabuleiro.Peca(pos).Cor != Cor) {

                    break;
                }
                pos.Linha -= 1;
            }


            //ABAIXO
            pos.DefinirValores(Posicao.Coluna, Posicao.Linha + 1);
            while (Tabuleiro.PosicaoValida(pos) && PodeMover(pos)) {

                mat[pos.Linha, pos.Coluna] = true;
                if (Tabuleiro.Peca(pos) != null && Tabuleiro.Peca(pos).Cor != Cor) {

                    break;
                }
                pos.Linha += 1;
            }

            //DIREITA
            pos.DefinirValores(Posicao.Coluna + 1, Posicao.Linha);
            while (Tabuleiro.PosicaoValida(pos) && PodeMover(pos)) {

                mat[pos.Linha, pos.Coluna] = true;
                if (Tabuleiro.Peca(pos) != null && Tabuleiro.Peca(pos).Cor != Cor) {

                    break;
                }
                pos.Coluna += 1;
            }

            //ESQUERDA
            pos.DefinirValores(Posicao.Coluna - 1, Posicao.Linha);
            while (Tabuleiro.PosicaoValida(pos) && PodeMover(pos)) {

                mat[pos.Linha, pos.Coluna] = true;
                if (Tabuleiro.Peca(pos) != null && Tabuleiro.Peca(pos).Cor != Cor) {

                    break;
                }
                pos.Coluna -= 1;
            }


            //Noroeste
            pos.DefinirValores(Posicao.Coluna - 1, Posicao.Linha - 1);
            while (Tabuleiro.PosicaoValida(pos) && PodeMover(pos)) {
                mat[pos.Linha, pos.Coluna] = true;
                if (Tabuleiro.Peca(pos) != null && Tabuleiro.Peca(pos).Cor != Cor) {
                    break;
                }
                pos.Linha -= 1;
                pos.Coluna -= 1;
            }

            //Nordeste
            pos.DefinirValores(Posicao.Coluna + 1, Posicao.Linha - 1);
            while (Tabuleiro.PosicaoValida(pos) && PodeMover(pos)) {
                mat[pos.Linha, pos.Coluna] = true;
                if (Tabuleiro.Peca(pos) != null && Tabuleiro.Peca(pos).Cor != Cor) {
                    break;
                }
                pos.Linha -= 1;
                pos.Coluna += 1;
            }

            //Sudoeste
            pos.DefinirValores(Posicao.Coluna - 1, Posicao.Linha + 1);
            while (Tabuleiro.PosicaoValida(pos) && PodeMover(pos)) {
                mat[pos.Linha, pos.Coluna] = true;
                if (Tabuleiro.Peca(pos) != null && Tabuleiro.Peca(pos).Cor != Cor) {
                    break;
                }
                pos.Linha += 1;
                pos.Coluna -= 1;
            }

            //Sudoeste
            pos.DefinirValores(Posicao.Coluna + 1, Posicao.Linha + 1);
            while (Tabuleiro.PosicaoValida(pos) && PodeMover(pos)) {
                mat[pos.Linha, pos.Coluna] = true;
                if (Tabuleiro.Peca(pos) != null && Tabuleiro.Peca(pos).Cor != Cor) {
                    break;
                }
                pos.Linha += 1;
                pos.Coluna += 1;
            }


            return mat;
        }

        public override string ToString() {
            return "Q";
        }
    }
}
