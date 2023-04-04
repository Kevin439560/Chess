using tabuleiro;

namespace pecas {
    class PartidaDeXadrez {

     

        public Tabuleiro Tab { get;private set; }

        private int turno;

        private Cor jogadorAtual;

        public bool Terminada { get;private set; }

        public PartidaDeXadrez() {

            Tab = new Tabuleiro(8,8);

            turno = 1;

            jogadorAtual = Cor.Branca;

            Terminada = false;

            ColocarPeca();
        }

        public void ExecutaMovimento(Posicao origem, Posicao destino) {

            Peca p = Tab.RemoverPeca(origem);

            p.ImcrementarQteMovi();

            Peca pecaCapturada = Tab.RemoverPeca(destino);
            
            Tab.ColocarPeca(p, destino);

        }

        private void ColocarPeca() {
            Tab.ColocarPeca(new Torre(Cor.Preta, Tab), new Posicao((int)PosicaoXadrez.a, 0));
            Tab.ColocarPeca(new Torre(Cor.Preta, Tab), new Posicao((int)PosicaoXadrez.h, 0));
            Tab.ColocarPeca(new Cavalo(Cor.Preta, Tab), new Posicao((int)PosicaoXadrez.b, 0));
            Tab.ColocarPeca(new Cavalo(Cor.Preta, Tab), new Posicao((int)PosicaoXadrez.g, 0));
            Tab.ColocarPeca(new Bispo(Cor.Preta, Tab), new Posicao((int)PosicaoXadrez.c, 0));
            Tab.ColocarPeca(new Bispo(Cor.Preta, Tab), new Posicao((int)PosicaoXadrez.f, 0));
            Tab.ColocarPeca(new Rei(Cor.Preta, Tab), new Posicao((int)PosicaoXadrez.d, 0));
            Tab.ColocarPeca(new Rainha(Cor.Preta, Tab), new Posicao((int)PosicaoXadrez.e, 0));
            for(int i = 0; i < 8; i++) {

                Tab.ColocarPeca(new Peao(Cor.Preta, Tab), new Posicao(i, 1));
                Tab.ColocarPeca(new Peao(Cor.Branca, Tab), new Posicao(i, 6));
            }

            Tab.ColocarPeca(new Torre(Cor.Branca, Tab), new Posicao((int)PosicaoXadrez.a, 7));
            Tab.ColocarPeca(new Torre(Cor.Branca, Tab), new Posicao((int)PosicaoXadrez.h, 7));
            Tab.ColocarPeca(new Cavalo(Cor.Branca, Tab), new Posicao((int)PosicaoXadrez.b, 7));
            Tab.ColocarPeca(new Cavalo(Cor.Branca, Tab), new Posicao((int)PosicaoXadrez.g, 7));
            Tab.ColocarPeca(new Bispo(Cor.Branca, Tab), new Posicao((int)PosicaoXadrez.c, 7));
            Tab.ColocarPeca(new Bispo(Cor.Branca, Tab), new Posicao((int)PosicaoXadrez.f, 7));
            Tab.ColocarPeca(new Rei(Cor.Branca, Tab), new Posicao((int)PosicaoXadrez.d, 7));
            Tab.ColocarPeca(new Rainha(Cor.Branca, Tab), new Posicao((int)PosicaoXadrez.e, 7));

        }
    }
}
