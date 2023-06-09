﻿using tabuleiro;

namespace pecas {
    class Bispo : Peca {

        public Bispo(Cor cor, Tabuleiro Tabuleiro) : base(cor, Tabuleiro) {

        }

        private bool PodeMover(Posicao pos) {
            Peca p = Tabuleiro.Peca(pos);

            return p == null || p.Cor != Cor;
        }

        public override bool[,] MovimentosPossiveis() {
            bool[,] mat = new bool[Tabuleiro.NumLinhas, Tabuleiro.NumColunas];

            Posicao pos = new(0, 0);

            //Noroeste
            pos.DefinirValores(Posicao.Coluna - 1, Posicao.Linha - 1);
            while (Tabuleiro.PosicaoValida(pos) && PodeMover(pos)) {
                mat[pos.Linha, pos.Coluna] = true;
                if (Tabuleiro.Peca(pos) != null && Tabuleiro.Peca(pos).Cor != Cor) {
                    break;
                }
                pos.DefinirValores(pos.Coluna - 1, pos.Linha - 1);

            }

            //Nordeste
            pos.DefinirValores(Posicao.Coluna + 1, Posicao.Linha - 1);
            while (Tabuleiro.PosicaoValida(pos) && PodeMover(pos)) {
                mat[pos.Linha, pos.Coluna] = true;
                if (Tabuleiro.Peca(pos) != null && Tabuleiro.Peca(pos).Cor != Cor) {
                    break;
                }
                pos.DefinirValores(pos.Coluna + 1, pos.Linha - 1);
            }

            //Sudoeste
            pos.DefinirValores(Posicao.Coluna - 1, Posicao.Linha + 1);
            while (Tabuleiro.PosicaoValida(pos) && PodeMover(pos)) {
                mat[pos.Linha, pos.Coluna] = true;
                if (Tabuleiro.Peca(pos) != null && Tabuleiro.Peca(pos).Cor != Cor) {
                    break;
                }
                pos.DefinirValores(pos.Coluna - 1, pos.Linha + 1);
            }

            //Sudeste
            pos.DefinirValores(Posicao.Coluna + 1, Posicao.Linha + 1);
            while (Tabuleiro.PosicaoValida(pos) && PodeMover(pos)) {
                mat[pos.Linha, pos.Coluna] = true;
                if (Tabuleiro.Peca(pos) != null && Tabuleiro.Peca(pos).Cor != Cor) {
                    break;
                }
                pos.DefinirValores(pos.Coluna + 1, pos.Linha + 1);
            }

            return mat;
        }
        public override string ToString() {
            return "B";
        }
    }
}
