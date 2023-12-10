internal class Program
{
    private static GerenciarJson gJson;
    private static GerenciarArtistas gArtista;

    private static void Main(string[] args)
    {
        string sair = "0";
        var escolhaMenu = "";
        gJson = new GerenciarJson();
        gArtista = new GerenciarArtistas(gJson);

        while (sair != escolhaMenu)
        {
            Console.WriteLine("");
            Console.WriteLine("1 - Cadastrar Artista");
            Console.WriteLine("2 - Remover Artista");
            Console.WriteLine("3 - Cadastrar música");
            Console.WriteLine("4 - Remover música");
            Console.WriteLine("5 - Exibir informações do artista.");
            Console.WriteLine("0 - SAIR");
            Console.WriteLine("");

            escolhaMenu = Console.ReadLine();

            ExecEscolha(escolhaMenu);
        }
    }

    private static void ExecEscolha(string? escolhaMenu)
    {
        switch (escolhaMenu)
        {
            case "1":
                gArtista.CadastrarArtista();
                break;
            case "2":
                gArtista.RemoverArtista();
                break;
            case "3":
                gArtista.CadastrarMusica();
                break;
            case "4":
                gArtista.RemoverMusica();
                break;
            case "5":
                gArtista.ExibirInformacoes();
                break;
            case "0":
                gJson.ReescreverLista();
                Console.WriteLine("Você saiu do programa.");
                break;
            default:
                Console.WriteLine("Opção não disponível.");
                break;
        }
    }
}
