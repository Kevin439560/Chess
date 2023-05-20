using System.Collections.Generic;
using tabuleiro;

namespace pecas {
    class PartidaDeXadrez {



        public Tabuleiro Tab { get; private set; }

        public int Turno { get; private set; }

        public Cor JogadorAtual { get; private set; }

        public bool Terminada { get; private set; }

        private HashSet<Peca> pecas;
        private HashSet<Peca> capturadas;

        public PartidaDeXadrez() {

            Tab = new Tabuleiro(8, 8);

            Turno = 1;

            JogadorAtual = Cor.Branca;

            Terminada = false;

            pecas = new HashSet<Peca>();

            capturadas = new HashSet<Peca>();

            ColocarPeca();
        }

        public void ExecutaMovimento(Posicao origem, Posicao destino) {

            Peca p = Tab.RemoverPeca(origem);

            p.ImcrementarQteMovi();

            Peca pecaCapturada = Tab.RemoverPeca(destino);

            Tab.ColocarPeca(p, destino);

            if (pecaCapturada != null) {

                capturadas.Add(pecaCapturada);

            }

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

            if (Tab.Peca(pos) == null) {

                throw new TabuleiroException("Não existe peça na posição de origem escolhida!");

            }
            if (JogadorAtual != Tab.Peca(pos).Cor) {

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

            if (JogadorAtual == Cor.Branca) {

                JogadorAtual = Cor.Preta;

            } else {

                JogadorAtual = Cor.Branca;

            }
        }

        public HashSet<Peca> PecasCapturadas(Cor cor) {

            HashSet<Peca> aux = new HashSet<Peca>();

            foreach (Peca x in capturadas) {

                if (x.Cor == cor) {

                    aux.Add(x);

                }
            }

            return aux;
        }

        public HashSet<Peca> PecasEmJogo(Cor cor) {

            HashSet<Peca> aux = new HashSet<Peca>();

            foreach (Peca x in pecas) {

                if (x.Cor == cor) {

                    aux.Add(x);
                    

                }
            }

            aux.ExceptWith(PecasCapturadas(cor));

            return aux;

        }

        public void ColocarNovaPeca(int linha, int coluna, Peca peca) {

            Posicao pos = new Posicao(coluna, linha);

            Tab.ColocarPeca(peca, pos);

            pecas.Add(peca);

        }

        private void ColocarPeca() {

            ColocarNovaPeca(0,0, new Torre(Cor.Preta, Tab));
            ColocarNovaPeca(0,7, new Torre(Cor.Preta, Tab));
            ColocarNovaPeca(0,1, new Cavalo(Cor.Preta, Tab));
            ColocarNovaPeca(0,2, new Bispo(Cor.Preta, Tab));
            ColocarNovaPeca(0,6, new Cavalo(Cor.Preta, Tab));
            ColocarNovaPeca(0,5, new Bispo(Cor.Preta, Tab));
            ColocarNovaPeca(0,3, new Rei(Cor.Preta, Tab));
            ColocarNovaPeca(0,4, new Rainha(Cor.Preta, Tab));



            /*
            for(int i = 0; i < 8; i++) {
                
                Tab.ColocarPeca(new Peao(Cor.Preta, Tab), new Posicao(i, 1));
                Tab.ColocarPeca(new Peao(Cor.Branca, Tab), new Posicao(i, 6));
            }
            */

            ColocarNovaPeca(7,0, new Torre(Cor.Branca, Tab));
            ColocarNovaPeca(7,7, new Torre(Cor.Branca, Tab));
            ColocarNovaPeca(7,6, new Cavalo(Cor.Branca, Tab));
            ColocarNovaPeca(7,5, new Bispo(Cor.Branca, Tab));
            ColocarNovaPeca(7,1, new Cavalo(Cor.Branca, Tab));
            ColocarNovaPeca(7,2, new Bispo(Cor.Branca, Tab));
            ColocarNovaPeca(7,3, new Rei(Cor.Branca, Tab));
            ColocarNovaPeca(7,4, new Rainha(Cor.Branca, Tab));

        }
    }
}
