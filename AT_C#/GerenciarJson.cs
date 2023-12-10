using System.IO;
using System.Text.Json;

public class GerenciarJson
{
    public List<Artista> Artistas {get; set;} = new List<Artista>();
    public List<Musica> Musicas {get; set;} = new List<Musica>();

    public GerenciarJson()
    {
        this.IniciarListas();
    }

    public void IniciarListas()
    {
        if (File.Exists("artistas.json") == false)
            File.Create("artistas.json").Close();

        if (File.Exists("musicas.json") == false)
            File.Create("musicas.json").Close();

        using (StreamReader reader = new StreamReader(File.OpenRead("artistas.json")))
        {
            try
            {
                string conteudo = reader.ReadToEnd();
                this.Artistas = JsonSerializer.Deserialize<List<Artista>>(conteudo);
                reader.Close();
            }
            catch { }
        }

        using (StreamReader reader = new StreamReader(File.OpenRead("musicas.json")))
        {
            try
            {
                string conteudo = reader.ReadToEnd();
                this.Musicas = JsonSerializer.Deserialize<List<Musica>>(conteudo);
                reader.Close();
            }
            catch { }
        }
    }

    public void AdicionarArtista(Artista artista)
    {
        this.Artistas.Add(artista);  
    }

    public void RemoverArtista(Artista artista) {
        Artistas.Remove(artista);
    }
    public void RemoverMusica(Artista artista, Musica musica) {
        artista.ListaMusicas.Remove(musica);
        Musicas.Remove(musica);
    }

    public void AdicionarMusica(Musica musica)
    {
        this.Musicas.Add(musica);
    }

    public void ReescreverLista()
    {
        if (File.Exists("artistas.json"))
        {
            File.Delete("artistas.json");
        }

        using (
            StreamWriter writer = new StreamWriter(
                File.Open("artistas.json", FileMode.OpenOrCreate)
            )
        )
        {
            string json = JsonSerializer.Serialize<List<Artista>>(Artistas);
            writer.WriteLine(json);
            writer.Flush();
            writer.Close();
        }

        if (File.Exists("musicas.json"))
        {
            File.Delete("musicas.json");
        }

        using (
            StreamWriter writer = new StreamWriter(
                File.Open("musicas.json", FileMode.OpenOrCreate)
                )
        )
        {
            string json = JsonSerializer.Serialize<List<Musica>>(Musicas);
            writer.WriteLine(json);
            writer.Flush();
            writer.Close();
        }
    }
}
