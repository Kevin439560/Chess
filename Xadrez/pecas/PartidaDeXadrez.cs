using tabuleiro;

namespace pecas {
    class PartidaDeXadrez {

     

        public Tabuleiro Tab { get;private set; }

        private int turno;

        private Cor jogadorAtual;

        public PartidaDeXadrez() {

            Tab = new Tabuleiro(8,8);

            turno = 1;

            jogadorAtual = Cor.Branca;

            ColocarPeca();
        }

        public void ExecutaMovimento(Posicao origem, Posicao destino) {
            Peca p = Tab.RemoverPeca(origem);

            p.ImcrementarQteMovi();

            Peca pecaCapturada = Tab.RemoverPeca(destino);
            
            Tab.ColocarPeca(p, destino);

        }

        private void ColocarPeca() {
            Tab.ColocarPeca(new Torre(Cor.Preta, Tab), new Posicao((int)PosicaoXadrez.c, 1));
            Tab.ColocarPeca(new Cavalo(Cor.Branca, Tab), new Posicao((int)PosicaoXadrez.b, 1));
            Tab.ColocarPeca(new Torre(Cor.Branca, Tab), new Posicao((int)PosicaoXadrez.c, 3));
            Tab.ColocarPeca(new Cavalo(Cor.Preta, Tab), new Posicao((int)PosicaoXadrez.e, 1));
        }
    }
}
