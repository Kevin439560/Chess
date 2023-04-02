

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

        public void ColocarPeca(Peca peca, Posicao posicao) {

            Pecas[posicao.Linha, posicao.Coluna] = peca;

            peca.Posicao = posicao;
                
        }
    }

}
