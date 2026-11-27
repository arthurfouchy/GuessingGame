using System;

// Representa um no da arvore binaria de decisao
class NoDecisao
{
    // Guarda a pergunta (no interno) ou o palpite (no folha)
    public string Texto { get; set; }

    // Filho esquerdo representa a resposta "Nao"
    public NoDecisao Nao { get; set; }

    // Filho direito representa a resposta "Sim"
    public NoDecisao Sim { get; set; }

    // Construtor do no
    public NoDecisao(string texto)
    {
        Texto = texto;
        Nao = null;
        Sim = null;
    }

    // Retorna true quando o no nao possui filhos (no folha)
    public bool EhFolha()
    {
        return Nao == null && Sim == null;
    }
}

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        // Monta a arvore binaria de decisao com perguntas unicas e palpites nas folhas
        NoDecisao raiz = CriarArvoreAnimais();

        bool jogarNovamente = true;

        Console.WriteLine("=== JOGO DA ADIVINHACAO (ARVORE BINARIA) ===");
        Console.WriteLine("Pense em um animal e responda com 's' (Sim) ou 'n' (Nao)!");

        while (jogarNovamente)
        {
            bool acertouNaRodada = false;

            // Permite continuar tentando na mesma rodada caso o palpite esteja errado
            while (!acertouNaRodada)
            {
                Console.WriteLine("\nPense no animal... vamos filtrar!");
                acertouNaRodada = PercorrerArvore(raiz);

                if (!acertouNaRodada)
                {
                    bool tentarNovamente = LerSimOuNao("Deseja tentar outro palpite agora? (s/n): ");
                    if (!tentarNovamente)
                    {
                        break;
                    }
                }
            }

            jogarNovamente = LerSimOuNao("\nDeseja jogar uma nova partida? (s/n): ");
        }

        Console.WriteLine("\nJogo encerrado! Ate a proxima.");
    }

    // Constroi a arvore com perguntas unicas nos nos internos e animais nas folhas
    static NoDecisao CriarArvoreAnimais()
    {
        // Raiz
        NoDecisao raiz = new NoDecisao("E um mamifero?");

        // Ramo SIM (direita) -> Mamiferos
        NoDecisao mamiferoVoa = new NoDecisao("Ele voa?");
        mamiferoVoa.Sim = new NoDecisao("Morcego");
        mamiferoVoa.Nao = new NoDecisao("Ele vive na agua?");

        NoDecisao mamiferoAgua = mamiferoVoa.Nao;
        mamiferoAgua.Sim = new NoDecisao("Golfinho");
        mamiferoAgua.Nao = new NoDecisao("Ele mia?");

        NoDecisao mamiferoMia = mamiferoAgua.Nao;
        mamiferoMia.Sim = new NoDecisao("Gato");
        mamiferoMia.Nao = new NoDecisao("Ele late?");

        NoDecisao mamiferoLate = mamiferoMia.Nao;
        mamiferoLate.Sim = new NoDecisao("Cachorro");
        mamiferoLate.Nao = new NoDecisao("Cavalo");

        raiz.Sim = mamiferoVoa;

        // Ramo NAO (esquerda) -> Nao mamiferos com perguntas unicas
        NoDecisao temPenas = new NoDecisao("Ele tem penas?");
        NoDecisao aveVoa = new NoDecisao("Ele voa?");
        aveVoa.Sim = new NoDecisao("Aguia");
        aveVoa.Nao = new NoDecisao("Pinguim");

        temPenas.Sim = aveVoa;
        temPenas.Nao = new NoDecisao("Ele vive na agua?");

        NoDecisao naoAveAgua = temPenas.Nao;
        NoDecisao temGuelras = new NoDecisao("Ele tem guelras?");
        temGuelras.Sim = new NoDecisao("Tubarao");
        temGuelras.Nao = new NoDecisao("Jacare");

        naoAveAgua.Sim = temGuelras;
        naoAveAgua.Nao = new NoDecisao("Ele rasteja sem patas?");

        NoDecisao rasteja = naoAveAgua.Nao;
        rasteja.Sim = new NoDecisao("Cobra");
        rasteja.Nao = new NoDecisao("Tartaruga");

        raiz.Nao = temPenas;

        return raiz;
    }

    // Le apenas 's' ou 'n' com retorno amigavel
    static bool LerSimOuNao(string mensagem)
    {
        while (true)
        {
            Console.Write(mensagem);
            string entrada = (Console.ReadLine() ?? "").Trim().ToLowerInvariant();

            if (entrada == "s")
            {
                return true;
            }

            if (entrada == "n")
            {
                return false;
            }

            Console.WriteLine("Opção inválida! Digite apenas 's' para Sim ou 'n' para Nao.");
        }
    }

    // Percorre a arvore recursivamente ate chegar a um no folha e retorna se acertou
    static bool PercorrerArvore(NoDecisao atual)
    {
        // Caso base: chegou a um no folha (palpite final)
        if (atual.EhFolha())
        {
            bool acertou = LerSimOuNao($"Meu palpite e: {atual.Texto}. Acertei? (s/n): ");

            if (acertou)
            {
                Console.WriteLine("Boa! Acertei o animal!");
                return true;
            }

            Console.WriteLine("Puxa, errei esse palpite!");
            return false;
        }

        // Passo recursivo: no interno faz a pergunta e desce pela aresta correspondente
        bool respostaSim = LerSimOuNao($"{atual.Texto} (s/n): ");

        if (respostaSim)
        {
            return PercorrerArvore(atual.Sim); // Aresta direita ("Sim")
        }

        return PercorrerArvore(atual.Nao); // Aresta esquerda ("Nao")
    }
}