public class Conferenza : Evento
{
    private string _relatore;
    public string Relatore
    {
        get
        {
            return _relatore;
        }
        set
        {
            if (value == null || value == "")
                throw new GestoreEventiException("Il campo del relatore non può essere vuoto");
            _relatore = value;
        }
    }

    private double _prezzo;
    public double Prezzo
    {
        get
        {
            return _prezzo;
        }
        private set
        {
            if (value < 0)
                throw new GestoreEventiException("Il prezzo non può essere minore di 0.");
            _prezzo = value;
        }
    }

    public Conferenza(string titolo, DateOnly data, int capienzaMassimaEvento, string relatore, double prezzo) : base(titolo, data, capienzaMassimaEvento)
    {
        Relatore = relatore;
        Prezzo = prezzo;
    }
}
