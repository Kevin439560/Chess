using tabuleiro;


namespace pecas {
    class Rei : Peca{

        private PartidaDeXadrez partida;
        public Rei(Cor cor, Tabuleiro Tabuleiro, PartidaDeXadrez partida): base(cor, Tabuleiro) {

            this.partida = partida;

        }
          
        public override string ToString() {
            return "K";
        }

        private bool PodeMover(Posicao pos) {
            Peca p = Tabuleiro.Peca(pos);

            return p == null || p.Cor != Cor;
        }

        private bool TesteTorreRoque(Posicao pos) {

            Peca p = Tabuleiro.Peca(pos);

            return p != null && p is Torre && p.Cor == Cor && p.QteMovimentos == 0;

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
            
            // jogada especial
            if(QteMovimentos == 0 && !partida.xeque) {
                //roque pequeno,
                Posicao posT1 = new Posicao(Posicao.Coluna + 3, Posicao.Linha);
                if(TesteTorreRoque(posT1)) {

                    Posicao p1 = new Posicao(Posicao.Coluna + 1, Posicao.Linha);
                    Posicao p2 = new Posicao(Posicao.Coluna + 2, Posicao.Linha);
                    if(Tabuleiro.Peca(p1) == null && Tabuleiro.Peca(p2) == null) {

                        mat[Posicao.Linha, Posicao.Coluna + 2] = true;

                    }
                }

                //roque Grande,
                Posicao posT2 = new Posicao(Posicao.Coluna - 4, Posicao.Linha);
                if (TesteTorreRoque(posT2)) {

                    Posicao p1 = new Posicao(Posicao.Coluna - 1, Posicao.Linha);
                    Posicao p2 = new Posicao(Posicao.Coluna - 2, Posicao.Linha);
                    Posicao p3 = new Posicao(Posicao.Coluna - 3, Posicao.Linha);
                    if (Tabuleiro.Peca(p1) == null && Tabuleiro.Peca(p2) == null && Tabuleiro.Peca(p3) == null) {

                        mat[Posicao.Linha, Posicao.Coluna - 2] = true;

                    }
                }

            }

            return mat;
        }
    }
}
