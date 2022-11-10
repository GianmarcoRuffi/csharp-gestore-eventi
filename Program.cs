

using System;

// Creazione Programma di Eventi

Console.WriteLine("Compilare i campi richiesti per creare il tuo programma di eventi");
Console.WriteLine("----------------------------------------------");


Console.WriteLine("Inserisci il nome del tuo programma Eventi:");
string nomeProgramma = Console.ReadLine();
Console.WriteLine("inserisci il numero di eventi da inserire:");
int numeroEventi = Convert.ToInt32(Console.ReadLine());
ProgrammaEventi programma = new ProgrammaEventi(nomeProgramma);

//

for (int i = 1; i <= numeroEventi; i++)
{
    Console.WriteLine("----------------------------------------------");
    CreaEvento(i);
}

int postiPrenotati = 0;
int postiDisdetti = 0;
bool disdiciPosti = true;
Evento evento = null;
bool continua = true;


do

{
    Console.WriteLine("----------------------------------------------");
    Console.WriteLine("Premi 1 - Stampa il numero di eventi presenti nel vostro programma eventi e visualizza la lista di eventi inseriti nel vostro programma");
    Console.WriteLine("Premi 2 - Inserisci una data e stampa tutti gli eventi presenti in quella data");
    Console.WriteLine("Premi 3 - Aggiungi prenotazione ad un evento");
    Console.WriteLine("Premi 4 - Disdici prenotazione ad un evento");
    Console.WriteLine("Premi 5 - Eliminate tutti gli eventi dal vostro programma");
    Console.WriteLine("----------------------------------------------");

    int sceltaUtente = Convert.ToInt32(Console.ReadLine());

    switch (sceltaUtente)

    {
        case 1:
            Console.WriteLine("");
            Console.WriteLine("Il numero di eventi in programma è: " + programma.NumeroEventi());
            Console.WriteLine("");
            Console.WriteLine("Ecco il tuo programma eventi:");
            Console.WriteLine("");
            Console.WriteLine(programma.ToString());
            Console.WriteLine("----------------------------------------------");
            break;

        case 2:

            try
            {
                Console.WriteLine("");
                Console.WriteLine("Inserisci una data per sapere gli eventi in programma nella data specificata (gg/mm/yyyy)");
                string dataStringa = Console.ReadLine();
                DateOnly data = DateOnly.Parse(dataStringa);
                List<Evento> eventi = programma.CercaDataEventi(data);
                Console.WriteLine("");
                Console.WriteLine("Gli eventi in programma sono: ");
                Console.WriteLine(ProgrammaEventi.StampaListaEventi(eventi));
         
            }
            catch (Exception)
            {
                Console.WriteLine("Errore di inserimento");
            }

            break;

        case 3:
            try
            {
                Console.WriteLine("");
                Console.WriteLine("Inserisci il nome dell'evento per la prenotazione dei posti:");
                string nomeEvento1 = Console.ReadLine();
                Evento evento1 = programma.CercaEvento(nomeEvento1);
                InserisciPrenotazione(evento1);
                Console.WriteLine("----------------------------------------------");
            }
            catch (Exception)
            {
                Console.WriteLine("Errore di inserimento");
            }

            break;


        case 4:
            try
            {
                Console.WriteLine("");
                Console.WriteLine("Inserisci il nome dell'evento per la cancellazione delle prenotazioni:");
                string nomeEvento2 = Console.ReadLine();
                Evento evento2 = programma.CercaEvento(nomeEvento2);
                DisdiciPrenotazione(evento2);
                Console.WriteLine("----------------------------------------------");
            }
            catch (Exception)
            {
                Console.WriteLine("Errore di inserimento");
            }
            break;

        case 5:
            programma.SvuotaListaEventi();
            Console.WriteLine("Tutti gli eventi sono stati cancellati!");
            continua = false;
            break;
    }
} while (continua);


/////// Funzioni ///////////


// Funzione Crea evento
void CreaEvento(int numeroEvento)

{
    try
    {// titolo evento
        Console.WriteLine("Inserisci il nome dell'evento numero {0} : ");
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
        programma.AggiungiEvento(evento);

        // Stampa dati evento
        Console.WriteLine("E' stato creato il seguente evento: " + "'" + titolo + "'" + " da svolgersi in data " + dataDateonly + " con numero di posti totali: " + capienzaMassima);

    }

    catch (Exception)
    {
        Console.WriteLine("Errore");
    }
}

// Funzione Prenotazione posti //

void InserisciPrenotazione(Evento evento)
{
    Console.WriteLine("Numero di posti disponibili: " + (evento.CapienzaMassimaEvento - evento.PostiPrenotati));
    Console.Write("Quanti posti vuoi prenotare? ");
    {
        try
        {
            int postiPrenotati = Convert.ToInt32(Console.ReadLine());
            evento.PrenotaPosti(postiPrenotati);
            Console.WriteLine("Numero di posti prenotati: " + evento.PostiPrenotati);
            Console.WriteLine("Numero di posti disponibili: " + (evento.CapienzaMassimaEvento - evento.PostiPrenotati));
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

}

// Funzione Disdetta posti //

void DisdiciPrenotazione(Evento evento)
{
    Console.WriteLine("Numero di posti prenotati: " + evento.PostiPrenotati);
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
