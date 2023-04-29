using tabuleiro;


namespace pecas {
    class Rei : Peca{
        public Rei(Cor cor, Tabuleiro Tabuleiro): base(cor, Tabuleiro) {

        }
          
        public override string ToString() {
            return "R";
        }

        private bool PodeMover(Posicao pos) {
            Peca p = Tabuleiro.Peca(pos);

            return p == null || p.Cor != Cor;
        }

        public override bool[,] MovimentosPossiveis() {
            bool[,] mat = new bool[Tabuleiro.NumLinhas, Tabuleiro.NumColunas];

            Posicao pos = new(0,0);

            //acima
            pos.DefinirValores(Posicao.Coluna, Posicao.Linha - 1);
            if(Tabuleiro.PosicaoValida(pos) && PodeMover(pos)) {
                mat[pos.Linha, pos.Coluna] = true;
            }
            //ne
            pos.DefinirValores(Posicao.Coluna + 1, Posicao.Linha - 1);
            if (Tabuleiro.PosicaoValida(pos) && PodeMover(pos)) {
                mat[pos.Linha, pos.Coluna] = true;
            }
            //no
            pos.DefinirValores(Posicao.Coluna - 1, Posicao.Linha - 1);
            if (Tabuleiro.PosicaoValida(pos) && PodeMover(pos)) {
                mat[pos.Linha, pos.Coluna] = true;
            }
            //direita
            pos.DefinirValores(Posicao.Coluna + 1, Posicao.Linha);
            if (Tabuleiro.PosicaoValida(pos) && PodeMover(pos)) {
                mat[pos.Linha, pos.Coluna] = true;
            }
            //esquerda
            pos.DefinirValores(Posicao.Coluna - 1, Posicao.Linha);
            if (Tabuleiro.PosicaoValida(pos) && PodeMover(pos)) {
                mat[pos.Linha, pos.Coluna] = true;
            }
            //baixo
            pos.DefinirValores(Posicao.Coluna, Posicao.Linha + 1);
            if (Tabuleiro.PosicaoValida(pos) && PodeMover(pos)) {
                mat[pos.Linha, pos.Coluna] = true;
            }   
            //S0
            pos.DefinirValores(Posicao.Coluna - 1, Posicao.Linha + 1);
            if (Tabuleiro.PosicaoValida(pos) && PodeMover(pos)) {
                mat[pos.Linha, pos.Coluna] = true;
            }
            //SE
            pos.DefinirValores(Posicao.Coluna + 1, Posicao.Linha + 1);
            if (Tabuleiro.PosicaoValida(pos) && PodeMover(pos)) {
                mat[pos.Linha, pos.Coluna] = true;
            }
            return mat;
        }
    }
}
