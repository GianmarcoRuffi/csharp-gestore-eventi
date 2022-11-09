

using System;

Console.WriteLine("Compilare i campi richiesti per creare l'evento");
Console.WriteLine("----------------------------------");

// titolo evento
Console.WriteLine("Titolo Evento:");
string titolo = Console.ReadLine();
// data evento
Console.WriteLine("Data dell'evento (in formato gg/mm/yyyy)");
string dataEvento = Console.ReadLine();
DateOnly dataDateonly = DateOnly.Parse(dataEvento);
// capienza massima posti
Console.WriteLine("Inserisci la capienza massima");
int capienzaMassima = Convert.ToInt32(Console.ReadLine());

Evento evento = new Evento(titolo, dataDateonly, capienzaMassima);

Console.WriteLine("Dati eventi: " + titolo + " " + dataDateonly + " " + capienzaMassima);