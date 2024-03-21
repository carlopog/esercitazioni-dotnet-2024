## AUTENTICAZIONE

- [x] CREARE classe UTENTE (NOME, PASSWORD E PUNTEGGIO)
- [x] chiedere se utente si deve registrare o è già registrato
- [x] se si deve registrare chiede nome e password 
- [x] controlla che non esista gia' il nome
- [x] salvare la password nel json
- [x] se gia' registrato chiede nome utente controlla esista
- [x] CHIEDE LA PASSWORD E LA CONTROLLA

## QUIZ

- [x] SCEGLI DIFFICOLTA QUIZ
- [x] FACCIAMO DELLE DOMANDE:
- [x] APERTE
- [x] CHECKBOX
- [ ] CREARE TASTO SUBMIT
- [ ] CAMBIARE LE DOMANDE CON COSE SENSATE

## VALIDAZIONE

- [x] IL SERVER DEVE AVERE LE RISPOSTE GIUSTE
- [ ] VALIDAZIONE QUANDO SCHIACCI SUBMIT
- [ ] E RESTITUIRE IL RISULTATO
- [ ] PARAGONARE VALUES A RISPOSTE
- [ ] ASSEGNAZIONE PUNTEGGIO IN BASE AL NUMERO DI RISPOSTE CORRETTE E ALLA DIFFICOLTA
- [ ] CAMBIARE RISPOSTA IN RISPOSTE STRING ARRAY (CON TUTTE LE POSSIBILI RISPOSTE PER DOMANDE APERTE)


## CLASSIFICHE 

- [ ] pagina tue partite tutti i risultati delle varie partite
- [ ] POI CREARE UNA CLASSIFICA 
- [ ] pagina classifica, punteggio delle diverse partite, tenere il più alto come record



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
   // string[] risposte = ['a', 'A', 'boh']


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

  ```