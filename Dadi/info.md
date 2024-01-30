# SUPER SIC BO 
## RULES:

  - si parte con 100 euro di bottino 
  - tira 3 dadi da 6 all'interno di un contenitore chiuso. // salvo il valore dei 3 dati singoli e della loro somma in 4 variabili a,b,c e tot
  - scommesse // si fa scegliere al giocatore che tipo di puntata vuole fare e da quanto var scommessa
  - segnalare le quote e dunque la vincita potenziale
  - quando le puntate sono terminate il croupier scopre i dadi // vengono mostrati i 3 numeri e la loro somma 
  - e i vincenti ricevono la vincita corrispondente, proporzionata alla difficoltà della scommessa. 

  prerequisiti e analisi
  definizione di strutture e convenzioni
  design e esperienza utente
  test e debugging

- [ ]  Creare un progetto console per l'applicazione
- [ ]  Creare un progetto di test per i test unitari
- [ ]  l'applicazione deve dare errore se il giocatore scrive input non validi.
- [ ]  l'applicazione deve salvare i valori dei dadi su un file .txt
- [ ]  l'applicazione deve salvare il bottino su un file .txt 
- [ ]  (volendo) l'applicazione deve salvare il tipo di scommessa su un file .txt .

### VALORE SINGOLO
- [ ]  Dado singolo: uno dei tre dadi mostra il valore prescelto. QUOTA 1:1
- [ ]  Doppia: due dei tre dadi avranno lo stesso valore selezionato. QUOTA 2:1
- [ ]  Tripla: il valore selezionato è su tutti e 3 i dadi. QUOTA 3:1

> Partirei con una versione Beta che prevede solo giocate di questo tipo

### COMBINAZIONE 
- [ ]  Combinazione: due dei tre dadi avranno i 2 valori selezionati dal giocatore.
 QUOTA 5:1


### DOPPIA (SEMPRE SPECIFICA)
- [ ]  Doppia: due dei tre dadi avranno lo stesso valore, di cui però è necessario indicare anche il valore (non è ammessa la Doppia generica).
 QUOTA 8:1

### TRIPLA
- [ ]  Tripla generica: i tre dadi avranno tutti lo stesso valore. QUOTA 30:1
- [ ]  Tripla specifica: i tre dadi avranno tutti lo stesso valore e viene indicato tale valore. QUOTA 200 x 

## TOTALE
### numeri
- [ ]  Totale: il giocatore punta sulla somma del valore dei tre dadi, si può puntare dal 4 al 17 compresi.
- case 4: case 17: QUOTA 50:1
- case 5: case 16: QUOTA 25:1
- case 6: case 15: QUOTA 20:1
- case 7: case 14: QUOTA 10:1
- case 8: case 13: QUOTA 8:1
- case 9: case 10: case 11: case 12: QUOTA 6:1 // quindi tutti gli altri
### gruppi
QUOTA 1:1
- [ ]  Big: il totale dei dadi è compreso tra 11 e 17.
- [ ]  Small: il totale dei dadi è compreso tra 4 e 11.
- [ ]  Pari: il totale dei dadi è un numero pari (il triplo 3 però non dà diritto alla vincita).
- [ ]  Dispari: il totale dei dadi è un numero dispari (il triplo 1 però non dà diritto alla vincita).



## Modalità estrema:
Le puntate devono essere sempre di un importo crescente e le scelte possono essere solo le seguenti:
Combinazione, Doppia, Tripla, Totale: numeri
se non hai più abbastanza soldi puoi, una volta sola (con un do while)
"chiedere un prestito" e rischiare tutto 
o uscire dal gioco 
