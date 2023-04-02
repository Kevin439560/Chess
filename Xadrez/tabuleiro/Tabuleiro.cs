

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

        public Peca peca(int linha, int coluna) {

            return Pecas[linha, coluna];
        
        }
    }

}
