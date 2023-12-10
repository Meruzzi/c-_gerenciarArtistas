public class Artista
{
    public String Nome { get; set; }
    public int Idade { get; set; }
    public int QntMusicas { get; set; }
    public List<Musica> ListaMusicas {get; set;} = new List<Musica>();

    public void adicionarMusica(Musica musica)
    {
        ListaMusicas.Add(musica);
        atualizarQntMusicas();
    }

    public void atualizarQntMusicas()
    {
        QntMusicas = ListaMusicas.Count;
    }
}
