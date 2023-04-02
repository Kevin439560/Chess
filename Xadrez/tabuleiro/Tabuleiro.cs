

namespace tabuleiro {
    class Tabuleiro {

        public int NumLinhas { get; set; }

        public int NumColunas { get; set; }

        private Peca[,] Pecas;

        public Tabuleiro(int numLinhas, int numColunas) {

            NumLinhas = numLinhas;

            NumColunas = numColunas;

            Pecas = new Peca[NumLinhas, NumColunas];

        }

        public Peca Peca(int linha, int coluna) {

            return Pecas[linha, coluna];
        
        }

        public Peca Peca(Posicao pos) {
            
            return Pecas[pos.Linha, pos.Coluna];

        }

        public bool ExistePeca(Posicao pos) {

            ValidarPosicao(pos);

            return Peca(pos) != null;

        }

        public void ColocarPeca(Peca peca, Posicao posicao) {

            ValidarPosicao(posicao);

            Console.WriteLine( "passou da verificacao");
            Pecas[posicao.Linha, posicao.Coluna] = peca;

            peca.Posicao = posicao;
                
        }

        public bool PosicaoValida(Posicao pos) {

            if(pos.Linha < 0 || pos.Linha >= NumLinhas || pos.Coluna < 0 || pos.Coluna >= NumColunas) {

                return false;

            }
            return true;
        }

        public void ValidarPosicao(Posicao pos) {

            if(!PosicaoValida(pos)) {

                throw new TabuleiroException("Posicao Inválida!");

            }
        }
    }

}
