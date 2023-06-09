﻿

namespace tabuleiro {
    abstract class Peca {
        public Posicao Posicao { get; set; }

        public Cor Cor { get; protected set; }

        public int QteMovimentos { get; protected set; }

        public Tabuleiro Tabuleiro { get; protected set; }

        public Peca(Cor cor, Tabuleiro tabuleiro) {
            Posicao = null;
            Cor = cor;
            Tabuleiro = tabuleiro;
            QteMovimentos = 0;
        }

        public void ImcrementarQteMovi() {

            QteMovimentos++;
        }

        public void DecrementarQteMovi() {

            QteMovimentos--;
        }

        public bool ExisteMovimentosPossiveis() {
            bool[,] mat = MovimentosPossiveis();
            for(int i = 0; i < Tabuleiro.NumLinhas; i++) {
                for(int j = 0; j < Tabuleiro.NumColunas; j++) {

                    if (mat[i,j] == true) {

                        return true;
                    }
                }
            }
            return false;
        }

        public bool PodeMoverPara(Posicao pos) {
            return MovimentosPossiveis()[pos.Linha, pos.Coluna];
        }
        public abstract bool[,] MovimentosPossiveis();


    }
}
