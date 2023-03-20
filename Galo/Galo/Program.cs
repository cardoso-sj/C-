namespace Galo;
class Program
{
    static char[,] tabuleiro;
    const int TAMANHO = 4;
    static void Main(string[] args)
    {
        InicializacaoTabuleiro();
        char simboloCorrente = 'X';
        bool jogoTerminado = false;

        while(jogoTerminado == false)
        {
            bool jogadaValida = FazerJogada(simboloCorrente);
            jogoTerminado = JogoAcabado();
            while(jogadaValida == false)
            {
                Console.WriteLine("Jogada Invalida, Jogue de novo!");
                jogadaValida = FazerJogada(simboloCorrente);

            }
            simboloCorrente = AlternarSimbolo(simboloCorrente);
            MostraTabuleiro();
        }
    }

    public static char AlternarSimbolo(char simbolo)
    {
        if (simbolo == 'X')
        {
            return 'O';
        }
        else
        {
            return 'X';
        }
    }

    public static void InicializacaoTabuleiro()
    {
        tabuleiro = new char[TAMANHO, TAMANHO];

        for (int linha = 0; linha < TAMANHO; linha++)
        {
            for(int coluna = 0; coluna < TAMANHO; coluna++)
            {
                tabuleiro[linha, coluna] = ' ';
            }
        }
    }

    public static void MostraTabuleiro()
    {
        for (int linha = 0; linha < TAMANHO; linha++)
        {
            Console.WriteLine("-----------------"); Console.Write("| ");
            for (int coluna = 0; coluna < TAMANHO; coluna++)
            {
                Console.Write(tabuleiro[linha, coluna] + " | ");
            }
            Console.WriteLine();
        }
        Console.WriteLine("-----------------");
    }

    public static bool FazerJogada(char simbolo)
    {
        Console.WriteLine("Insira a linha onde quer jogar:");
        int linha = int.Parse(Console.ReadLine());

        if ((linha < 1) || (linha > TAMANHO))
        {
            return false;
        }

        Console.WriteLine("Insira a coluna onde quer jogar:");
        int coluna = int.Parse(Console.ReadLine());

        if ((coluna < 1) || (coluna > TAMANHO))
        {
            return false;
        }

        if (tabuleiro[linha - 1, coluna -1] != ' ') //posiçao já preenchida
        {
            return false;
        } 

        tabuleiro[linha - 1, coluna - 1] = simbolo;
        return true;
    }

    public static bool JogoAcabado()
    {
        bool vitoria = false;

        // Verificar se há vitória nas linhas
        for (int linha = 0; linha < TAMANHO; linha++)
        {
            bool linhaCompleta = true;
            for (int coluna = 1; coluna < TAMANHO; coluna++)
            {
                if (tabuleiro[linha, coluna] != tabuleiro[linha, coluna - 1] || tabuleiro[linha, coluna] == ' ')
                {
                    linhaCompleta = false;
                    break;
                }
            }
            if (linhaCompleta)
            {
                vitoria = true;
                break;
            }
        }

        // Verificar se há vitória nas colunas
        for (int coluna = 0; coluna < TAMANHO; coluna++)
        {
            bool colunaCompleta = true;
            for (int linha = 1; linha < TAMANHO; linha++)
            {
                if (tabuleiro[linha, coluna] != tabuleiro[linha - 1, coluna] || tabuleiro[linha, coluna] == ' ')
                {
                    colunaCompleta = false;
                    break;
                }
            }
            if (colunaCompleta)
            {
                vitoria = true;
                break;
            }
        }

        // Verificar se há vitória na diagonal principal
        bool diagonalPrincipalCompleta = true;
        for (int i = 1; i < TAMANHO; i++)
        {
            if (tabuleiro[i, i] != tabuleiro[i - 1, i - 1] || tabuleiro[i, i] == ' ')
            {
                diagonalPrincipalCompleta = false;
                break;
            }
        }
        if (diagonalPrincipalCompleta)
        {
            vitoria = true;
        }

        // Verificar se há vitória na diagonal secundária
        bool diagonalSecundariaCompleta = true;
        for (int i = 1; i < TAMANHO; i++)
        {
            if (tabuleiro[i, TAMANHO - i - 1] != tabuleiro[i - 1, TAMANHO - i] || tabuleiro[i, TAMANHO - i - 1] == ' ')
            {
                diagonalSecundariaCompleta = false;
                break;
            }
        }
        if (diagonalSecundariaCompleta)
        {
            vitoria = true;
        }

        // Verificar se há empate
        bool empate = true;
        for (int linha = 0; linha < TAMANHO; linha++)
        {
            for (int coluna = 0; coluna < TAMANHO; coluna++)
            {
                if (tabuleiro[linha, coluna] == ' ')
                {
                    empate = false;
                    break;
                }
            }
            if (!empate)
            {
                break;
            }
        }

        // Mostra o estado atual do jogo
        Console.WriteLine("\nEstado atual do jogo:");
        Console.WriteLine("----------------------");
        for (int linha = 0; linha < TAMANHO; linha++)
        {
            for (int coluna = 0; coluna < TAMANHO; coluna++)
            {
                Console.Write(tabuleiro[linha, coluna] + " ");
            }
            Console.WriteLine();
        }

        // Retorna se o jogo acabou ou não
        return vitoria || empate;
    }
}

