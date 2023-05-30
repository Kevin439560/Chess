﻿using System.Collections.Generic;
using tabuleiro;

namespace pecas {
    class PartidaDeXadrez {



        public Tabuleiro Tab { get; private set; }

        public int Turno { get; private set; }

        public Cor JogadorAtual { get; private set; }

        public bool Terminada { get; private set; }

        public bool xeque { get; private set; }

        private HashSet<Peca> pecas;
        private HashSet<Peca> capturadas;


        public PartidaDeXadrez() {

            Tab = new Tabuleiro(8, 8);

            Turno = 1;

            JogadorAtual = Cor.Branca;

            Terminada = false;

            xeque = false;

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
        }

        public void RealizaJogada(Posicao origem, Posicao destino) {

            Peca pecaCapturada = ExecutaMovimento(origem, destino);
            if (Xeque(JogadorAtual)) {
                DesfazMovimento(origem, destino, pecaCapturada);
                throw new TabuleiroException("Você não pode se colocar em Xeque!");
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
            ColocarNovaPeca(0, 3, new Rei(Cor.Preta, Tab));
            ColocarNovaPeca(0, 4, new Rainha(Cor.Preta, Tab));




            for (int i = 0; i < 8; i++) {

                ColocarNovaPeca(1, i, new Peao(Cor.Preta, Tab));
                ColocarNovaPeca(6, i, new Peao(Cor.Branca, Tab));

            }



            ColocarNovaPeca(7, 0, new Torre(Cor.Branca, Tab));
            ColocarNovaPeca(7, 7, new Torre(Cor.Branca, Tab));
            ColocarNovaPeca(7, 6, new Cavalo(Cor.Branca, Tab));
            ColocarNovaPeca(7, 5, new Bispo(Cor.Branca, Tab));
            ColocarNovaPeca(7, 1, new Cavalo(Cor.Branca, Tab));
            ColocarNovaPeca(7, 2, new Bispo(Cor.Branca, Tab));
            ColocarNovaPeca(7, 3, new Rei(Cor.Branca, Tab));
            ColocarNovaPeca(7, 4, new Rainha(Cor.Branca, Tab));




        }
    }
}
