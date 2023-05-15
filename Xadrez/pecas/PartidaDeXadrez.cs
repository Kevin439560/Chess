using tabuleiro;

namespace pecas {
    class PartidaDeXadrez {

     

        public Tabuleiro Tab { get;private set; }

        public int Turno { get; private set; }

        public Cor JogadorAtual { get; private set; }

        public bool Terminada { get;private set; }

        public PartidaDeXadrez() {

            Tab = new Tabuleiro(8,8);

            Turno = 1;

            JogadorAtual = Cor.Branca;

            Terminada = false;

            ColocarPeca();
        }

        public void ExecutaMovimento(Posicao origem, Posicao destino) {

            Peca p = Tab.RemoverPeca(origem);

            p.ImcrementarQteMovi();

            Peca pecaCapturada = Tab.RemoverPeca(destino);
            
            Tab.ColocarPeca(p, destino);

        }

        public void RealizaJogada(Posicao origem, Posicao destino) {

            ExecutaMovimento(origem, destino);
            Turno++;
            MudaJogador();

        }
        public void ValidarLetra(string posicao) {
            posicao = posicao.ToLower();
            bool verify;
            switch (posicao[0]) {
                case 'a':
                    verify = true;
                    break;
                case 'b':
                    verify = true;
                    break;
                case 'c':
                    verify = true;
                    break;
                case 'd':
                    verify = true;
                    break;
                case 'e':
                    verify = true;
                    break;
                case 'f':
                    verify = true;
                    break;
                case 'g':
                    verify = true;
                    break;
                case 'h':
                    verify = true;
                    break;
                default:
                    verify = false;
                    break;
            }
            if (verify == false) {
                throw new TabuleiroException("A posição está fora dos limites do Tabuleiro!");
            }

        }

        public void ValidarPosOrigem(Posicao pos) {

            if(Tab.Peca(pos) == null) {

                throw new TabuleiroException("Não existe peça na posição de origem escolhida!");

            }
            if(JogadorAtual != Tab.Peca(pos).Cor) {

                throw new TabuleiroException("A peça de origem escolhida não é sua!");

            }
            if (!Tab.Peca(pos).ExisteMovimentosPossiveis()) {

                throw new TabuleiroException("Não ha movimentos possíveis para a peça escolhida!");
            }
        }

        public void ValidarPosDestino(Posicao orig, Posicao dest) {

            if (!Tab.Peca(orig).PodeMoverPara(dest)) {
                throw new TabuleiroException("Posicao de destino inválida!");
            }
        }

        private void MudaJogador() {

            if(JogadorAtual == Cor.Branca) {

                JogadorAtual = Cor.Preta;

            } else {

                JogadorAtual = Cor.Branca;

            }
        }

        private void ColocarPeca() {
            Tab.ColocarPeca(new Torre(Cor.Preta, Tab), new Posicao((int)PosicaoXadrez.a, 0));
            Tab.ColocarPeca(new Torre(Cor.Preta, Tab), new Posicao((int)PosicaoXadrez.h, 0));
            Tab.ColocarPeca(new Horse(Cor.Preta, Tab), new Posicao((int)PosicaoXadrez.b, 0));
            Tab.ColocarPeca(new Cavalo(Cor.Preta, Tab), new Posicao((int)PosicaoXadrez.g, 0));
            Tab.ColocarPeca(new Bispo(Cor.Preta, Tab), new Posicao((int)PosicaoXadrez.c, 0));
            Tab.ColocarPeca(new Bispo(Cor.Preta, Tab), new Posicao((int)PosicaoXadrez.f, 0));
            Tab.ColocarPeca(new Rei(Cor.Preta, Tab), new Posicao((int)PosicaoXadrez.d, 0));
            Tab.ColocarPeca(new Rainha(Cor.Preta, Tab), new Posicao((int)PosicaoXadrez.e, 0));
            
            /*
            for(int i = 0; i < 8; i++) {

                Tab.ColocarPeca(new Peao(Cor.Preta, Tab), new Posicao(i, 1));
                Tab.ColocarPeca(new Peao(Cor.Branca, Tab), new Posicao(i, 6));
            }
            */

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
