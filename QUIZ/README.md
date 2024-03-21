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