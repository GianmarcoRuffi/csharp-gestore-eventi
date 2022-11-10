

using System;

// Creazione Evento

Console.WriteLine("Compilare i campi richiesti per creare l'evento");
Console.WriteLine("----------------------------------");

// titolo evento
Console.WriteLine("Inserisci il nome dell'evento: ");
string titolo = Console.ReadLine();
// data evento
Console.WriteLine("Inserisci la data dell'evento (in formato gg/mm/yyyy): ");
string dataEvento = Console.ReadLine();
DateOnly dataDateonly = DateOnly.Parse(dataEvento);
// capienza massima posti
Console.WriteLine("Inserisci il numero di posti totali (capienza massima): ");
int capienzaMassima = Convert.ToInt32(Console.ReadLine());

// Oggetto Evento
Evento evento = new Evento(titolo, dataDateonly, capienzaMassima);


int postiPrenotati = 0;
int postiDisdetti = 0;
bool disdiciPosti = true;


// Stampa dati evento
Console.WriteLine("E' stato creato il seguente evento: " + "'" + titolo +"'" + " da svolgersi in data " + dataDateonly + " con numero di posti totali: " + capienzaMassima);

// Richiesta prenotazione
Console.Write("Vuoi prenotare dei posti? (si / no) - ");
string inputUtente = Console.ReadLine();


if (inputUtente == "si" || inputUtente == "SI")

    InserisciPrenotazione(evento);

 else 

    Console.WriteLine("Nessun posto prenotato.");


// Disdetta prenotazione


while (disdiciPosti)

{
    Console.Write("Vuoi disdire dei posti? (si / no) - ");
    string inputDisdetta = Console.ReadLine();

    if (inputDisdetta == "si" || inputDisdetta == "SI")

    {
        DisdiciPrenotazione(evento);
        disdiciPosti = true;
    }


    else

    {
        Console.Write("Nessun posto disdetto");
        disdiciPosti = false;
    }
}



/////// Funzioni ///////////

// Funzione Prenotazione posti //

void InserisciPrenotazione(Evento evento)
{
    Console.Write("Quanti posti vuoi prenotare? ");
    {
        try
        {
            postiPrenotati = Convert.ToInt32(Console.ReadLine());
        }
        catch (FormatException)
        {
            Console.WriteLine("Errore - inserire un numero");
        }
        catch (Exception)
        {
            Console.WriteLine("Errore di inserimento");
        }
    }
    evento.PrenotaPosti(postiPrenotati);
    Console.WriteLine("Numero di posti prenotati: " + evento.PostiPrenotati);
    Console.WriteLine("Numero di posti disponibili: " + (evento.CapienzaMassimaEvento - evento.PostiPrenotati));
}


// Funzione Disdetta posti //

void DisdiciPrenotazione(Evento evento)
{
    
        Console.Write("Indica il numero dei posti da disdire: ");

    { try
            {
            postiDisdetti = Convert.ToInt32(Console.ReadLine());

        }
            catch (FormatException)
            {
                Console.WriteLine("Errore - inserire un numero");
            }
            catch (Exception)
            {
                Console.WriteLine("Errore di inserimento");
            }
        
         }

        evento.DisdiciPosti(postiDisdetti);
        Console.WriteLine("Numero di posti prenotati: " + evento.PostiPrenotati);
        Console.WriteLine("Numero di posti disponibili: " + (evento.CapienzaMassimaEvento - evento.PostiPrenotati));
    
 
}
