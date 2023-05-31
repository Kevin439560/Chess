using tabuleiro;

namespace pecas {
    internal class Peao : Peca {

        private PartidaDeXadrez partida;
        public Peao(Cor cor, Tabuleiro Tabuleiro, PartidaDeXadrez partida) : base(cor, Tabuleiro) {

            this.partida = partida;

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

            if (Cor == Cor.Branca) {

                pos.DefinirValores(Posicao.Coluna, Posicao.Linha - 1);
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
                if (QteMovimentos == 0) {
                    pos.DefinirValores(Posicao.Coluna, Posicao.Linha - 2);
                    if (Tabuleiro.PosicaoValida(pos) && Livre(pos)) {
                        mat[pos.Linha, pos.Coluna] = true;
                    }
                } else {

                    pos.DefinirValores(Posicao.Coluna, Posicao.Linha - 1);
                    if (Tabuleiro.PosicaoValida(pos) && Livre(pos)) {
                        mat[pos.Linha, pos.Coluna] = true;
                    }

                }

                //jogada especial en passant
                if (Posicao.Linha == 3) {

                    Posicao esquerda = new(Posicao.Coluna - 1, Posicao.Linha);

                    if (Tabuleiro.PosicaoValida(esquerda) && ExisteInimigo(esquerda) && Tabuleiro.Peca(esquerda) == partida.VulneravelEnPassant) {

                        mat[esquerda.Linha - 1, esquerda.Coluna] = true;

                    }

                    Posicao direita = new(Posicao.Coluna + 1, Posicao.Linha);

                    if (Tabuleiro.PosicaoValida(direita) && ExisteInimigo(direita) && Tabuleiro.Peca(direita) == partida.VulneravelEnPassant) {

                        mat[direita.Linha - 1, direita.Coluna] = true;

                    }
                }

            } else {

                pos.DefinirValores(Posicao.Coluna, Posicao.Linha + 1);
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

                if (QteMovimentos == 0) {
                    pos.DefinirValores(Posicao.Coluna, Posicao.Linha + 2);
                    if (Tabuleiro.PosicaoValida(pos) && Livre(pos)) {
                        mat[pos.Linha, pos.Coluna] = true;
                    }
                } else {

                    pos.DefinirValores(Posicao.Coluna, Posicao.Linha + 1);
                    if (Tabuleiro.PosicaoValida(pos) && Livre(pos)) {
                        mat[pos.Linha, pos.Coluna] = true;
                    }

                }

                //Jogada especial en passant
                if (Posicao.Linha == 4) {

                    Posicao esquerda = new(Posicao.Coluna - 1, Posicao.Linha);

                    if (Tabuleiro.PosicaoValida(esquerda) && ExisteInimigo(esquerda) && Tabuleiro.Peca(esquerda) == partida.VulneravelEnPassant) {

                        mat[esquerda.Linha + 1, esquerda.Coluna] = true;

                    }

                    Posicao direita = new(Posicao.Coluna + 1, Posicao.Linha);

                    if (Tabuleiro.PosicaoValida(direita) && ExisteInimigo(direita) && Tabuleiro.Peca(direita) == partida.VulneravelEnPassant) {

                        mat[direita.Linha + 1, direita.Coluna] = true;

                    }
                }
            }

            return mat;
        }

        public override string ToString() {
            return "P";
        }
    }
}
