﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Ripasso_Array
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Dichiarazioni
            int[] array = new int[100];                                                 // Dichiarazione matrice di tipo intero 'array'
            int c, p;                                                                   // Dichiarazione variabili di tipo intero 'c' e 'p'
            int dim;                                                                    // Dichiarazione variabile di tipo intero 'dim'
            int scelta;                                                                 // Dichiarazione variabile di tipo intero 'scelta'

            // Elaborazione
            // Ciclo controllo input variabile 'dim'
            do                                                                          // Esegui...
            {
                Console.Write("Inserire lunghezza iniziale dell'array (0 < x < 15): "); // Stampa 'Inserire lunghezza dell'array (0 < x < 100):'
                dim = Convert.ToInt32(Console.ReadLine());                              // Input variabile 'dim'
                if (dim > array.Length)                                                 // Se 'dim' maggiore della lunghezza dell'array
                {
                    Console.Clear();                                                    // Pulizia contenuto console
                    Console.Write("Input non valido!");                                 // Stampa 'Input non valido'
                    Thread.Sleep(1000);                                                 // Pausa 1 secondo
                    Console.Clear();                                                    // Pulizia contenuto console
                }
            } while (dim <= 0 || dim > 15);                                             // ...mentre 'dim' è minore-uguale a zero o maggiore lunghezza array
            // Ciclo inserimento valori inziali array
            for (int i = 0; i < dim; i++)                                               // Ciclo
            {
                Console.Write($"Inserire elemento in posizione {i}: ");                 // Stampa 'Inserire elemento in posizione {i}:'
                c = Convert.ToInt32(Console.ReadLine());                                // Input variabile 'c'
                array[i] = c;                                                           // Inserimento valori nell'array
            }
            // Struttura menù
            do                                                                          // Esegui...
            {
                // Stampa opzioni
                Console.Clear();                                                        // Pulizia contenuto console
                Console.WriteLine("1 - Aggiungi elemento\n2 - Stampa elementi caricati\n3 - Stampa stringa HTML\n4 - Ricerca elemento\n5 - Elimina elemento\n6 - Aggiungi elemento alla posizione desiderata\n0 - Uscita");         // Stampa messaggi selezione casi
                Console.WriteLine();                                                    // A capo
                Console.Write("Inserisci la scelta: ");                                 // Scelta opzione
                scelta = Convert.ToInt32(Console.ReadLine());                           // Input variabile 'scelta'
                // Esecuzione opzioni
                switch (scelta)                                                         // Selezione casi in base al valore della variabile 'scelta'
                {
                    default:                                                            // Se 'scelta' non corrisponde a nessun valore dei casi
                        Console.WriteLine("Opzione non valida!");                       // Stampa 'Opzione non valida!'
                        break;                                                          // Interrompi esecuzione
                    case 1:                                                             // Se 'scelta' uguale ad 1
                        Console.Write("Inserisci elemento da aggiungere in coda: ");    // Stampa 'Inserisci elemento da inserire in coda:'
                        c = Convert.ToInt32(Console.ReadLine());                        // Input variabile 'c'
                        if (Aggiunta(c, array, ref dim) == true)                        // Se chiamata funzione 'Aggiunta' restituisce 'true'
                        {
                            Console.WriteLine("Elemento inserito correttamente!");      // Stampa 'Elemento inserito correttamente!'
                        }
                        else                                                            // ...altrimenti...
                        {
                            Console.WriteLine("Array pieno!");                          // Stampa 'Array pieno!'
                        }
                        break;                                                          // Interrompere esecuzione
                    case 2:                                                             // Se 'scelta' uguale ad 2
                        for (int i = 0; i < dim; i++)                                   // Ciclo stampa array
                        {
                            Console.Write(array[i] + " ");                              // Stampa array
                        }
                        break;                                                          // Interrompere esecuzione
                    case 3:                                                             // Se 'scelta' uguale a 3
                        Console.WriteLine("");                                          // A capo
                        Console.WriteLine("<!DOCTYPE html>\r\n<html lang=\"it\">\r\n<head>\r\n    <title>Ripasso Array-21</title>\r\n</head>\r\n<body>");   // Stampa prima parte codice HTML
                        Console.WriteLine(HTML(array, ref dim));                        // Stampa stringa resituita dalla funzione
                        Console.WriteLine("</body>\r\n</html>");                        // Stampa parte finale del codice HTML
                        break;                                                          // Interrompere esecuzione
                    case 4:                                                             // Se 'scelta' uguale a 4
                        Console.Write("Inserire elemento da ricercare: ");              // Stampa 'Inserire elemento da ricercare:'
                        c = Convert.ToInt32(Console.ReadLine());                        // Input variabile 'c'
                        if (Ricerca(c, array) == -1)                                    // Se chiamata funzione 'Ricerca' restituisce '-1'
                        {
                            Console.WriteLine("Elemento non trovato!");                 // Stampa 'Elemento non trovato!'
                        }
                        else                                                            // Altrimenti
                        {
                            Console.WriteLine($"Elemento {c} trovato in posizione " + Ricerca(c, array));   // Stampa 'Elemento trovato in posizione ' + resituzione valore funzione 'Ricerca'
                        }
                        break;                                                                       // Interrompere esecuzione
                    case 5:                                                                          // Se 'scelta' uguale a 5
                        Console.Write("Inserire elemento che si desidera eliminare: ");              // Stampa 'Inserire elemento che si desidera eliminare:'
                        c = Convert.ToInt32(Console.ReadLine());                                     // Input variabile 'c'
                        if (Cancella(c, array, ref dim) == true)                                     // Se chiamata funzione 'Cancella' restituisce 'true'
                        {
                            Console.WriteLine("Elemento cancellato correttamente!");                 // Stampa 'Elemento cancellato correttamente!'
                        }
                        else                                                                         // Altrimenti
                        {
                            Console.WriteLine("Errore!\nElemento non eliminato correttamente.");     // Stampa 'Errore!\nElemento non eliminato correttamente.'
                        }
                        break;                                                                       // Interrompere esecuzione
                    case 6:                                                                          // Se 'scelta' uguale a 6
                        Console.Write("Inserire posizione nella quale inserire l'elemento: ");       // Stampa 'Inserire elemento da ricercare:'
                        p = Convert.ToInt32(Console.ReadLine());                                     // Input variabile 'p'
                        Console.Write("Inserire elemento: ");                                        // Stampa 'Inserire elemento:'
                        c = Convert.ToInt32(Console.ReadLine());                                     // Input variabile 'c'
                        if (InserimentoInPosizione(c, p, array) == true)                             // Se chiamata funzione 'InserimentoInPosizione' restituisce 'true'
                        {
                            Console.WriteLine($"Elemento {c} inserito correttamente in posizione {p}!");    // Stampa 'Elemento {c} inserito correttamente in posizione {p}!'
                        }
                        else                                                                         // Altrimenti
                        {
                            Console.Write("Errore!\nElemento non inserito correttamente.");          // Stampa 'Errore!\nElemento non inserito correttamente.'
                        }
                        break;                                                          // Interrompere esecuzione
                    case 0:                                                             // Se 'scelta' uguale a 0
                        Environment.Exit(1);                                            // Uscita programma
                        break;                                                          // Interrompere esecuzione
                }
                Console.ReadKey();                                                      // Attesa un'azione da parte dell'utente prima di continuare l'esecuzione
            } while (scelta != 0);                                                      // ...mentre variabile 'scelta' è diversa da 0
        }
        
        // Aggiungere in coda un elemento all'array (interi)
        static bool Aggiunta(int c, int[] array, ref int index)                         // Funzione 'Aggiunta' che va ad aggiungere elementi all'array
        {
            bool inserito = true;                                                       // Dichiarazione variabile di tipo booleano 'inserito'
            if (index < array.Length)                                                   // Se è stata raggiunta la dimensione massima dell'array           
            {
                array[index] = c;                                                       // Aggiungere l'elemento
                index++;                                                                // Incremento indice
            }
            else                                                                        // ...altrimenti...
            {
                inserito = false;                                                       // Assegnazione 'false' alla variabile 'inserito'
            }
            return inserito;                                                            // Restiruire 'inserito'
        }
        
        // Visualizzazione dell'array che restituisca la stringa in HTML
        static string HTML(int[] array, ref int dim)                                    // Funzione 'HTML' che stampa il codice in HTML
        {
            string codice = "   <table>\n";                                             // Dichiarazione variabile di tipo stringa 'codice'
            for (int i = 0; i < dim; i++)                                               // Ciclo
            {
                codice += "         <tr>\n";                                            // Concatenazione variabile 'codice'
                codice += "             <td>" + array[i] + "</td>\n";                   // Concatenazione variabile 'codice'
                codice += "         </tr>\n";                                           // Concatenazione variabile 'codice'
            }
            codice += "   </table>";                                                    // Concatenazione variabile 'codice'
            return codice;                                                              // Restituzione variabile 'codice'
        }
        
        // Ricerca un numero all'interno dell'array, la funzione deve restituire la posizione dell'elemento se lo trova, -1 se non lo trova
        static int Ricerca(int c, int[] array)                                          // Funzione 'Ricerca' che va a ricercare elementi nell'array
        {
            int risultatoricerca = 0;                                                   // Assegnazione variabile 'risultatoricerca'
            for (int i = 0; i < array.Length; i++)                                      // Ciclo
            {
                if (array[i] == c)                                                      // Se indice array uguale a 'c'
                {
                    risultatoricerca = i;                                               // Assegna alla variabile 'risultato ricerca' il valore dell' indice
                    break;                                                              // Interrompere esecuzione
                }
                else                                                                    // Altrimenti
                {
                    risultatoricerca = -1;                                              // Assegnazione variabile 'risultatoricerca' il valore '-1'
                }
            }
            return risultatoricerca;                                                    // Resituzione 'risultatoricerca'
        }
        
        // Cancellazione di un elemento dell'array
        static bool Cancella(int c, int[] array, ref int dim)                           // Funzione 'Cancella' che va a ricercare un elemento nell'array e lo elimina                               
        {
            bool cancellato = false;                                                    // Dichiarazione variabile di tipo booleano 'cancellato'
            for (int i = 0; i < array.Length; i++)                                      // Ciclo
            {
                if (array[i] == c)                                                      // Condizione per verificare che a 'i' sia presente 'c'
                {
                    dim--;                                                              // Diminuzione variabile 'dim'
                    for (int j = i; j < array.Length - 1; j++)                          // Ciclo per spostare di una posizione indietro tutti i valori dopo la posizione del valore eliminato
                    {
                        array[j] = array[j + 1];
                    }
                    cancellato = true;                                                  // Assegnazione alla variabile 'cancellato' il valore 'true'
                    break;                                                              // Interruzione esecuzione
                }
            }
            return cancellato;
        }
        
        // Inserimento di un valore in una posizione dell'array
        static bool InserimentoInPosizione(int c, int p, int[] array)                   // Funzione 'InserimentoInPosizione' che inserisce un elemento in una determinata posizione
        {
            bool inserito = false;                                                      // Dichiarazione variabile di tipo booleano 'inserito'
            if (p < array.Length)                                                       // Se 'p' minore della lunghezza dell'array
            {
                for (int i = array.Length -1; i > p; i--)                               // Ciclo per spostare di una posizione in avanti i valori dopo la posizione scelta
                {
                    array[i] = array[i - 1];
                }
                array[p] = c;                                                           // Inserimento variabile 'c' nell'array
                inserito = true;                                                        // Assegnazione 'true' alla variabile 'inserito'
            }
            return inserito;                                                            // Restituzione variabile 'inserito'
        }
    }
}
