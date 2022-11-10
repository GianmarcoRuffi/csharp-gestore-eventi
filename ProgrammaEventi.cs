public class ProgrammaEventi
{
    public string Titolo;
    private string _titolo;
    public List<Evento> eventi;
    // valorizzo il titolo e inizializzo la lista di eventi
    public ProgrammaEventi(string titolo)
    {
        Titolo = titolo;
        eventi = new List<Evento>();
    }

    // metodi
    public void AggiungiEvento(Evento evento)
    {
        eventi.Add(evento);
    }
    public List<Evento> CercaDataEventi(DateOnly data)
    {
        List<Evento> eventiData = new List<Evento>();
        foreach (Evento evento in eventi)
        {
            if (evento.Data == data)
            {
                eventiData.Add(evento);
            }
        }
        return eventiData;
    }

    public Evento CercaEvento(string titolo)
    {
        foreach (Evento evento in eventi)
        {
            if (evento.Titolo == titolo)
                return evento;
        }
        return null;
    }

    public static string StampaListaEventi(List<Evento> eventi)
    {
        string stampa = "";

        foreach (Evento evento in eventi)
        {
            stampa += evento + "\n";
        }
        return stampa;
    }

    public int NumeroEventi()
    {
        return eventi.Count;
    }

    public void SvuotaListaEventi()
    {
        eventi.Clear();
    }

    public override string ToString()
    {
        string stringa = Titolo + "\n";

        foreach (Evento evento in eventi)
        {
            stringa = stringa + "\t" + evento + "\n";
        }
        return stringa;
    }
}