# CLASSE GIOCATORE
## Argomenti: 
### nome, punteggio, crediti, partite giocate, partite vinte
 
# Sottoclasse GiocatoreProva 
## Argomenti:
### livello, esperienza

### NOME (string)

- è il tuo nome

### PUNTEGGIO (int)

- parte da 0
- dipende dal gioco

### CREDITI (int)

- parte da 3
- aumenta di 1 se vinci
- diminuisce di 1 se perdi (gestito dal Program.cs) 

### PARTITE GIOCATE (int)

- parte da 0
- aumenta di 1 per ogni partita

### PARTITE VINTE (int)

- parte da 0
- aumenta di 1 per ogni partita vinta

## GIOCATORE PROVA :

### ESPERIENZA (int)

- parte da 0
- aumenta di 10 per ogni partita vinta
- può aumentare in altri modi in base al gioco

### LIVELLO (int)

- parte da 1
- aumenta di 1 ogni 50 punti esperienza

## GIOCATORE GIADA :

### COGNOME (string)

- il cognome del giocatore

### ETA (int)

- l'eta' del giocatore
- serve per controllo maggiorenni

# METODI 

### STAMPA()

- scrive tutti gli argomenti del giocatore una riga alla volta

### VINCITA(bool win)

- prende come argomento il booleano win (Hai vinto? si/no)
- aumenta di 1 partite giocate 
- se (win = true) <br/>
  aumenta di 1 partite vinte e crediti


### VINCITA override GiocatoreProva 

- se (win = true) <br/>
 aumenta di 10 esperienza
- se (esperienza >= 50) <br/>
 aumenta di 1 livello  


TODO:

chiedere se eta e' in tutti i programmi 