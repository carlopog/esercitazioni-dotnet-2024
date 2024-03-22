## AUTENTICAZIONE

- [x] CREARE CLASSE UTENTE (NOME, PASSWORD E PUNTEGGIO)
- [x] CHIEDERE SE UTENTE SI DEVE REGISTRARE O E' GIA' REGISTRATO
- [x] SE SI DEVE REGISTRARE CHIEDE NOME E PASSWORD
- [x] CONTROLLA CHE NON ESISTA GIA' IL NOME
- [x] SALVARE NOME E PASSWORD NEL JSON
- [x] SE GIA' REGISTRATO CHIEDE NOME UTENTE E CONTROLLA CHE ESISTA
- [x] CHIEDE LA PASSWORD E CONTROLLA CHE CORRISPONDA

## QUIZ

- [x] SCEGLI DIFFICOLTA QUIZ
- [x] FACCIAMO DELLE DOMANDE:
- [x] APERTE
- [x] CHECKBOX
- [x] CREARE TASTO SUBMIT
- [ ] CAMBIARE LE DOMANDE CON COSE SENSATE
- [ ] CAMBIARE LE CLASSI CON NOMI SENSATI

## VALIDAZIONE

- [x] IL SERVER DEVE AVERE LE RISPOSTE GIUSTE
- [x] VALIDAZIONE QUANDO SCHIACCI SUBMIT
- [x] E RESTITUIRE IL RISULTATO
- [x] PARAGONARE VALUES A RISPOSTE
- [ ] ASSEGNAZIONE PUNTEGGIO IN BASE AL NUMERO DI RISPOSTE CORRETTE E ALLA DIFFICOLTA
- [ ] PUNTEGGIO ABBASSATO IN BASE ALLE RISPOSTE SBAGLIATE
- [ ] CAMBIARE RISPOSTA IN RISPOSTE STRING ARRAY (CON TUTTE LE POSSIBILI RISPOSTE PER DOMANDE APERTE)


## CLASSIFICHE 
- [ ] PAGINA TUE PARTITE CON TUTTI I RISULTATI DELLE VARIE PARTITE
- [ ] TENERE IL TUO PUNTEGGIO PIU ALTO COME RECORD
- [ ] POI CREARE UNA CLASSIFICA CON GLI ALTRI UTENTI
- [ ] FARE UNA TOP TEN


per ora la valutazione di una risposta è così
```c#
value 10opzioneA
if value == risposta 
{
  giusta
} 
risposta:a
```

potremmo farla diventare così
```c#
if value == id + "opzione" + risposta
{
  giusta
}


```

PER USARE RISPOSTE string[]
posso avere un array con una sola stringa ['a']
ma serve per paragonare la stringa value delle risposte aperte
con tutti gli elementi dell'array

quindi 


```c#
static bool Validazione(string rispostaAperta, string[] risposte)
{
   // string rispostaAperta = 'boh'
   // string[] risposteGiuste = ['a', 'A', 'boh']


   bool giusto = false
   int lunghezza = risposte.Length
   for (int i = 0; i < lunghezza; i++)
   {
     if (rispostaAperta == risposte[i])
     {
      giusto = true;
     }
   };
   return giusto;

}
```

```c#
 int lunghezza = values.Length; // questo sperando che mi arrivino risposta utente[0], risposta giusta[1]
       int lng = lunghezza/2;
       int ru = 0;
       int rg = 0;
       string[] risposteUtente = new string[lng];
       string[] risposteGiuste = new string[lng];
       for (int i = 0; i < lunghezza; i++)
       {
         if (i % 2 == 0) // se è pari
         {
           risposteUtente[ru] = values[i]; // aggiungi il valore a risposte dell'utente
           /* 
           [0] = [0]
           [1] = [2]
           [2] = [4]
           [3] = [6]

           ru++; // scala di una posizione
         }
         else
         {
           risposteGiuste[rg] = values[i]; // aggiungi il valore a risposte giuste
           /* 
           [0] = [1]
           [1] = [3]
           [2] = [5]
           [3] = [7]
           */
           rg++; // scala di una posizione
         }
       }

  ```


  ```c# inserire i booleani uguale confrontando le 2 liste

      List<bool> uguali = new List<bool>();

       for (int f = 0; f < 10; f++)
       {
        if (risposteUtente[f] == risposteGiuste[f])
          {
            uguali.Add(true)
          }
        else
          {
            uguali.Add(false)
          }
        }

  ```