public class GerenciarArtistas
{
    private GerenciarJson gJson;

    public GerenciarArtistas(GerenciarJson gJson)
    {
        this.gJson = gJson;
    }

    public void CadastrarArtista()
    {
        Artista artista = new Artista();

        Console.WriteLine("Digite o nome do artista:");
        artista.Nome = Console.ReadLine();

        Console.WriteLine("Digite a idade do artista:");
        artista.Idade = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine($"Artista {artista.Nome} cadastrado.");

        gJson.AdicionarArtista(artista);
    }

    public void RemoverArtista()
    {
        ExibirArtistasDisp();

        Console.WriteLine("Digite o nome do artista");
        string nomeArtista = Console.ReadLine();
        Artista artista = gJson.Artistas.FirstOrDefault(x => x.Nome == nomeArtista);

        if (artista == null)
        {
            Console.WriteLine($"Não foi possivel encontrar o artista {nomeArtista}");
            return;
        }

        Console.WriteLine($"Artista {nomeArtista} removido.");

        gJson.RemoverArtista(artista);
    }

    public void CadastrarMusica()
    {
        Musica musica = new Musica();

        Console.WriteLine("Digite o nome da música:");
        musica.Nome = Console.ReadLine();

        Console.WriteLine("Digite a duração da música:");
        musica.Duracao = TimeOnly.Parse(Console.ReadLine());

        gJson.AdicionarMusica(musica);

        ExibirArtistasDisp();

        Console.WriteLine("Digite o nome do artista que deseja vincular a música:");
        string nomeArtista = Console.ReadLine();
        Artista artista = gJson.Artistas.FirstOrDefault(x => x.Nome == nomeArtista);

        if (artista == null)
        {
            Console.WriteLine($"Não foi possivel encontrar o artista {nomeArtista}");
            return;
        }

        Console.WriteLine($"Música {musica.Nome} adicionada ao cantor {nomeArtista}.");

        artista.adicionarMusica(musica);
    }

    public void RemoverMusica()
    {
        ExibirArtistasDisp();

        Console.WriteLine("Digite o nome do artista");
        string nomeArtista = Console.ReadLine();
        Artista artista = gJson.Artistas.FirstOrDefault(x => x.Nome == nomeArtista);

        if (artista == null)
        {
            Console.WriteLine($"Não foi possivel encontrar o artista {nomeArtista}");
            return;
        }

        if (artista.ListaMusicas == null || artista.ListaMusicas.Count == 0)
        {
            Console.WriteLine("O artista {nomeArtista} não possui músicas cadastradas.");
            return;
        }
        else
        {
            Console.WriteLine($"Músicas do artista {nomeArtista}:");
            foreach (var item in artista.ListaMusicas)
            {
                Console.WriteLine(item.Nome);
            }
        }
        Console.WriteLine("");

        Console.WriteLine("Digite o nome da música");
        string nomeMusica = Console.ReadLine();
        Musica musica = gJson.Musicas.FirstOrDefault(x => x.Nome == nomeMusica);

        if (musica == null)
        {
            Console.WriteLine($"Não foi possivel encontrar a música {nomeMusica}");
            return;
        }

        Console.WriteLine($"Música {nomeMusica} removida do cantor {nomeArtista}.");

        gJson.RemoverMusica(artista, musica);
    }

    public void ExibirInformacoes()
    {
        ExibirArtistasDisp();

        Console.WriteLine("Digite o nome do artista");
        string nomeArtista = Console.ReadLine();
        Artista artista = gJson.Artistas.FirstOrDefault(x => x.Nome == nomeArtista);

        if (artista == null)
        {
            Console.WriteLine($"Não foi possivel encontrar o artista {nomeArtista}");
            return;
        }

        Console.WriteLine($"Nome do artista: {artista.Nome}");
        Console.WriteLine($"Idade do artista: {artista.Idade}");
        Console.WriteLine($"Quantidade de músicas do artista: {artista.QntMusicas}");

        if (artista.ListaMusicas == null || artista.ListaMusicas.Count == 0)
        {
            Console.WriteLine("Esse artista não possui músicas.");
        }
        else
        {
            Console.WriteLine($"Músicas do artista:");
            foreach (var musica in artista.ListaMusicas)
            {
                Console.WriteLine("");
                Console.WriteLine($"Música: {musica.Nome}");
                Console.WriteLine($"Duração: {musica.Duracao}");
            }
        }
    }

    public bool ExibirArtistasDisp()
    {
        List<Artista> artistasDisp = gJson.Artistas;

        if (artistasDisp == null)
        {
            Console.WriteLine("Não foi possivel encontrar artistas cadastradas.");
            return false;
        }
        else
        {
            Console.WriteLine("Artistas cadastrados:");
            foreach (var artistas in artistasDisp)
            {
                Console.WriteLine(artistas.Nome);
            }
            Console.WriteLine("");
            return true;
        }
    }

    public void ExibirMusicasDisp()
    {
        List<Musica> musicasDisp = gJson.Musicas;

        if (musicasDisp == null || musicasDisp.Count == 0)
        {
            Console.WriteLine("Não foi possivel encontrar músicas cadastradas.");
        }
        else
        {
            Console.WriteLine("Músicas cadastrados:");
            foreach (var musicas in musicasDisp)
            {
                Console.WriteLine(gJson.Musicas);
            }
            Console.WriteLine("");
        }
    }
}
