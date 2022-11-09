public class Evento
{
    private string _titolo;
    private DateOnly _data;
    private int _capienzaMassimaEvento;
    private int _postiPrenotati;
    public DateOnly dataAttuale = DateOnly.FromDateTime(DateTime.Now);

    public string Titolo
    {
        get
        {
            return _titolo;
        }
        set
        {
            if (value == null || value == "")
                throw new GestoreEventiException("Inserire un nome.");
            _titolo = value;
        }
    }
    public DateOnly Data
    {
        get
        {
            return _data;
        }
        set
        {
            if (value == null || value < dataAttuale)
                throw new GestoreEventiException("La data inserita è precedente a quella di oggi.");
            _data = value;
        }
    }
    public int CapienzaMassimaEvento
    {
        get
        {
            return _capienzaMassimaEvento;
        }
        private set
        {
            if (value == null || value <= 0)
                throw new GestoreEventiException("La capienza massima deve essere maggiore di 0.");
            _capienzaMassimaEvento = value;
        }

    }
    public int PostiPrenotati
    {
        get
        {
            return _postiPrenotati;
        }
        private set
        {
            _postiPrenotati = value;

        }
    }

    public Evento(string titolo, DateOnly data, int capienzaMassimaEvento)
    {
        Titolo = titolo;
        Data = data;
        CapienzaMassimaEvento = capienzaMassimaEvento;
        PostiPrenotati = 0;
    }

    public void PrenotaPosti(int numeroPostiInserito)
    {
        if (CapienzaMassimaEvento < PostiPrenotati + numeroPostiInserito)
            throw new GestoreEventiException("Non ci sono abbastanza posti rimanenti a disposizione.");
        else if (Data < dataAttuale) 
            throw new GestoreEventiException("L'evento è terminato.");
        _postiPrenotati += numeroPostiInserito;

    }
    public void DisdiciPosti(int numeroPostiInserito)
    {
        if (PostiPrenotati < numeroPostiInserito)
            throw new GestoreEventiException("Non ci sono abbastanza posti da disdire.");
        else if (Data < dataAttuale)
            throw new GestoreEventiException("L'evento è terminato.");
        _postiPrenotati = _postiPrenotati - numeroPostiInserito;
    }

    public override string ToString()
    {
        return _data.ToString("dd/MM/yyyy") + " - " + Titolo;
    }
}