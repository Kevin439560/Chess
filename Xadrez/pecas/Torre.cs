using tabuleiro;

namespace pecas {
    class Torre : Peca {

        public Torre(Cor cor, Tabuleiro Tabuleiro) :base(cor, Tabuleiro) {

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
            while(Tabuleiro.PosicaoValida(pos) && PodeMover(pos)) {

                mat[pos.Linha, pos.Coluna] = true;
                if(Tabuleiro.Peca(pos) != null && Tabuleiro.Peca(pos).Cor != Cor) {

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



            return mat;
        }
        public override string ToString() {
            return "T";
        }

    }
}