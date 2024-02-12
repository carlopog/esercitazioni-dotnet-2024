# Obiettivo

creare un'applicazione per un ristorante

con il menu diviso per sezioni

che permetta ai camerieri di prendere gli ordini dei diversi tavoli

e al cassiere di fare il conto totale in tempo reale

## Beta Test di Natalya

- [x] Limitare il numero dei tavoli selezionabili (quanti tavoli ci sono? e poi controllo con quel numero)
- [x] Si potrebbe fare un menu con i sottomenu per i tipi (antipasti primi ecc) cosi' da non avere piu' i 2 seguenti problemi
- inserendo il numero che non e' nel tipo ma presente nel menu la scelta viene inserita comunque (es. antipasti arriva fino a 6 e io dico 15)
- Se volessi saltare un tipo (non ordinare nulla) non posso


## Prerequisiti (cosa devo avere prima di iniziare)

- [x] un file .json con il trio di tipo, piatti e prezzi 

## Requisiti (cosa deve fare il programma)

- [x] fare in modo di elencare la lista di antipasti al cliente
- [x] ricevere la sua ordinazione (scelta col Console.ReadLine)
- [x] chiedere il numero del tavolo
- [x] scrivere e salvare la sua ordinazione in due file .txt diversi chiamati Ordine e Cassa (con il numero del tavolo) il piatto e il prezzo
- [x] ripetere l'operazione con i vini
- [x] ripetere l'operazione con i primi
- [x] ripetere l'operazione con i vini
- [x] ripetere l'operazione con i secondi
- [x] ripetere l'operazione con i dolci
- [x] prendere il file Cassa (giusto) e sommare i valori dei piatti ordinati per far pagare il conto
- [x] svuotare il file del tavolo che ha pagato
- [x] ringraziare e salutare

## Nice to have

- [x] un file .txt con il Menu scritto per bene, diviso in sezioni (o diversi file per antipasti, primi, secondi, dolci e vini)
- [x] piatti ordinabili tramite numeri o codici cosi da non dover scrivere tutta la parola
- [x] foreach tipi
- [x] il prezzo dei piatti a fianco ai nomi nel resoconto (?) 