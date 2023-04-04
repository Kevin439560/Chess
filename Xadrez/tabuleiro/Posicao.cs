namespace tabuleiro {
    class Posicao {

        public int Linha { get; set; }

        public int Coluna { get; set; }

        public Posicao(int coluna, int linha ) {

            Linha = linha;

            Coluna = coluna;

        }

        public override string ToString() {
            return "Posicao:\nLinha: "
                + Linha + ", Coluna: " + Coluna;
                
        }
    }
}
