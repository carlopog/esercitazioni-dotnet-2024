## AUTENTICAZIONE

- [x] CREARE CLASSE UTENTE (NOME, PASSWORD E PUNTEGGIO)
- [x] CHIEDERE SE UTENTE SI DEVE REGISTRARE O E' GIA' REGISTRATO
- [x] SE SI DEVE REGISTRARE CHIEDE NOME E PASSWORD
- [x] AGGIUNGI PUNTEGGIO ALLA CLASSE UTENTE
- [x] CONTROLLA CHE NON ESISTA GIA' IL NOME
- [x] SALVARE NOME E PASSWORD NEL JSON
- [x] SE GIA' REGISTRATO CHIEDE NOME UTENTE E CONTROLLA CHE ESISTA
- [x] CHIEDE LA PASSWORD E CONTROLLA CHE CORRISPONDA

## QUIZ

- [x] SCEGLI DIFFICOLTA QUIZ
- [x] FACCIAMO DELLE DOMANDE:
- [x] APERTE
- [x] CREARE TASTO SUBMIT
- [x] CAMBIARE LE CLASSI CON NOMI SENSATI
- [ ] CREARE DOMANDEDOPPIE USANDO LE CHECKBOX 

## VALIDAZIONE

- [x] IL SERVER DEVE AVERE LE RISPOSTE GIUSTE
- [x] VALIDAZIONE QUANDO SCHIACCI SUBMIT
- [x] E RESTITUIRE IL RISULTATO
- [x] PARAGONARE VALUES A RISPOSTE
- [x] ASSEGNAZIONE PUNTEGGIO IN BASE AL NUMERO DI RISPOSTE CORRETTE
- [ ] PUNTEGGIO ABBASSATO IN BASE ALLE RISPOSTE SBAGLIATE
- [ ] CAMBIARE RISPOSTA IN RISPOSTA1 E RISPOSTA2 PER DOMANDEDOPPIE


## CLASSIFICHE 
- [x] PAGINA PUNTEGGI (PERSONALI) CON TUTTI I RISULTATI DELLE VARIE PARTITE
- [x] TENERE IL TUO PUNTEGGIO PIU ALTO COME RECORD
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