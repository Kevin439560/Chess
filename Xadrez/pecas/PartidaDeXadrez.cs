using System.Collections.Generic;
using tabuleiro;

namespace pecas {
    class PartidaDeXadrez {



        public Tabuleiro Tab { get; private set; }

        public int Turno { get; private set; }

        public Cor JogadorAtual { get; private set; }

        public bool Terminada { get; private set; }

        public bool xeque { get; private set; }

        public Peca VulneravelEnPassant { get; private set; }

        private HashSet<Peca> pecas;
        private HashSet<Peca> capturadas;


        public PartidaDeXadrez() {

            Tab = new Tabuleiro(8, 8);

            Turno = 1;

            JogadorAtual = Cor.Branca;

            Terminada = false;

            xeque = false;

            VulneravelEnPassant = null;

            pecas = new HashSet<Peca>();

            capturadas = new HashSet<Peca>();

            ColocarPeca();
        }

        public Peca ExecutaMovimento(Posicao origem, Posicao destino) {

            Peca p = Tab.RemoverPeca(origem);

            p.ImcrementarQteMovi();

            Peca pecaCapturada = Tab.RemoverPeca(destino);

            Tab.ColocarPeca(p, destino);

            if (pecaCapturada != null) {

                capturadas.Add(pecaCapturada);

            }

            //Jogada especial roque pequeno
            if (p is Rei && destino.Coluna == origem.Coluna + 2) {

                Posicao origemTorre = new Posicao(origem.Coluna + 3, origem.Linha);
                Posicao destinoTorre = new Posicao(origem.Coluna + 1, origem.Linha);

                Peca T = Tab.RemoverPeca(origemTorre);

                T.ImcrementarQteMovi();

                Tab.ColocarPeca(T, destinoTorre);
            }

            //Jogada especial roque grande
            if (p is Rei && destino.Coluna == origem.Coluna - 2) {

                Posicao origemTorre = new Posicao(origem.Coluna - 4, origem.Linha);

                Posicao destinoTorre = new Posicao(origem.Coluna - 1, origem.Linha);

                Peca T = Tab.RemoverPeca(origemTorre);

                T.ImcrementarQteMovi();

                Tab.ColocarPeca(T, destinoTorre);
            }

            //Jogada especial En Passant

            if(p is Peao) {
                if(origem.Coluna != destino.Coluna && pecaCapturada == null) {

                    Posicao posP;

                    if(p.Cor == Cor.Branca) {

                        posP = new Posicao(destino.Coluna, destino.Linha + 1);

                    } else {

                        posP = new Posicao(destino.Coluna, destino.Linha - 1);

                    }
                    pecaCapturada = Tab.RemoverPeca(posP);

                    capturadas.Add(pecaCapturada);
                        
                }
            }
            return pecaCapturada;

        }

        public void DesfazMovimento(Posicao origem, Posicao destino, Peca pecaCapturada) {
            Peca p = Tab.RemoverPeca(destino);

            p.DecrementarQteMovi();

            if (pecaCapturada != null) {

                Tab.ColocarPeca(pecaCapturada, destino);

                capturadas.Remove(pecaCapturada);

            }

            Tab.ColocarPeca(p, origem);

            //Desfaz Jogada especial roque pequeno
            if (p is Rei && destino.Coluna == origem.Coluna + 2) {

                Posicao origemTorre = new Posicao(origem.Coluna + 3, origem.Linha);
                Posicao destinoTorre = new Posicao(origem.Coluna + 1, origem.Linha);

                Peca T = Tab.RemoverPeca(destinoTorre);

                T.DecrementarQteMovi();

                Tab.ColocarPeca(T, origemTorre);
            }

            //Desfaz Jogada especial roque pequeno
            if (p is Rei && destino.Coluna == origem.Coluna - 2) {

                Posicao origemTorre = new Posicao(origem.Coluna - 4, origem.Linha);
                Posicao destinoTorre = new Posicao(origem.Coluna - 1, origem.Linha);

                Peca T = Tab.RemoverPeca(destinoTorre);

                T.DecrementarQteMovi();

                Tab.ColocarPeca(T, origemTorre);
            }

            //Jogada especial En Passant
            if(p is Peao) {

                if(origem.Coluna != destino.Coluna && pecaCapturada == VulneravelEnPassant) {

                    Peca peao = Tab.RemoverPeca(destino);

                    Posicao posP;

                    if(p.Cor == Cor.Branca) {

                        posP = new(destino.Coluna, 3);

                    } else {

                        posP = new(destino.Coluna, 4);

                    }

                    Tab.ColocarPeca(peao, posP);    

                }
            }

        }

        public void RealizaJogada(Posicao origem, Posicao destino) {

            Peca pecaCapturada = ExecutaMovimento(origem, destino);
            if (Xeque(JogadorAtual)) {
                DesfazMovimento(origem, destino, pecaCapturada);
                throw new TabuleiroException("Você não pode se colocar em Xeque!");
            }

            Peca p = Tab.Peca(destino);

            //jogada especial promocao
            if(p is Peao) {

                if((p.Cor == Cor.Branca && destino.Linha == 0) || (p.Cor == Cor.Preta && destino.Linha == 7)) {

                    p = Tab.RemoverPeca(destino);
                    
                    pecas.Remove(p);

                    Peca dama = new Rainha(p.Cor, Tab);

                    Tab.ColocarPeca(dama, destino);

                    pecas.Add(dama);

                }
            }

            if (Xeque(Adversario(JogadorAtual))) {

                xeque = true;
            } else {

                xeque = false;
            }

            if (TesteXequeMate(Adversario(JogadorAtual))) {

                Terminada = true;

            } else {

                Turno++;

                MudaJogador();

            }


            //Jogada especial en passant
            if (p is Peao && (destino.Linha == origem.Linha - 2 || destino.Linha == origem.Linha + 2)) {

                VulneravelEnPassant = p;

            } else {

                VulneravelEnPassant = null;

            }


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

        private Cor Adversario(Cor cor) {

            if (cor == Cor.Branca) {
                return Cor.Preta;
            }
            return Cor.Branca;
        }

        private Peca rei(Cor cor) {
            foreach (Peca x in PecasEmJogo(cor)) {
                if (x is Rei) {
                    return x;
                }
            }
            return null;
        }

        public bool Xeque(Cor cor) {

            Peca p = rei(cor);

            if (p == null) {

                throw new TabuleiroException("Não tem rei da cor " + cor + " no tabuleiro!");

            }
            foreach (Peca x in PecasEmJogo(Adversario(cor))) {

                bool[,] mat = x.MovimentosPossiveis();

                if (mat[p.Posicao.Linha, p.Posicao.Coluna]) {

                    return true;

                }

            }

            return false;
        }

        public bool TesteXequeMate(Cor cor) {

            if (!Xeque(cor)) {

                return false;

            }

            foreach (Peca x in PecasEmJogo(cor)) {

                bool[,] mat = x.MovimentosPossiveis();

                for (int i = 0; i < Tab.NumLinhas; i++) {

                    for (int j = 0; j < Tab.NumColunas; j++) {

                        if (mat[i, j]) {

                            Posicao origem = x.Posicao;

                            Posicao destino = new Posicao(j, i);

                            Peca pecaCapturada = ExecutaMovimento(origem, destino);

                            bool testeXeque = Xeque(cor);

                            DesfazMovimento(origem, destino, pecaCapturada);

                            if (!testeXeque) {

                                return false;

                            }
                        }
                    }
                }

            }
            return true;
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

            
            ColocarNovaPeca(0, 0, new Torre(Cor.Preta, Tab));
            ColocarNovaPeca(0, 7, new Torre(Cor.Preta, Tab));
            ColocarNovaPeca(0, 1, new Cavalo(Cor.Preta, Tab));
            ColocarNovaPeca(0, 2, new Bispo(Cor.Preta, Tab));
            ColocarNovaPeca(0, 6, new Cavalo(Cor.Preta, Tab));
            ColocarNovaPeca(0, 5, new Bispo(Cor.Preta, Tab));
            ColocarNovaPeca(0, 4, new Rei(Cor.Preta, Tab, this));
            ColocarNovaPeca(0, 3, new Rainha(Cor.Preta, Tab));

            

            
            for (int i = 0; i < 8; i++) {

                ColocarNovaPeca(1, i, new Peao(Cor.Preta, Tab, this));
                ColocarNovaPeca(6, i, new Peao(Cor.Branca, Tab, this));

            }
            


            ColocarNovaPeca(7, 0, new Torre(Cor.Branca, Tab));
            ColocarNovaPeca(7, 7, new Torre(Cor.Branca, Tab));
            ColocarNovaPeca(7, 6, new Cavalo(Cor.Branca, Tab));
            ColocarNovaPeca(7, 5, new Bispo(Cor.Branca, Tab));
            ColocarNovaPeca(7, 1, new Cavalo(Cor.Branca, Tab));
            ColocarNovaPeca(7, 2, new Bispo(Cor.Branca, Tab));
            ColocarNovaPeca(7, 4, new Rei(Cor.Branca, Tab, this));
            ColocarNovaPeca(7, 3, new Rainha(Cor.Branca, Tab));




        }
    }
}
