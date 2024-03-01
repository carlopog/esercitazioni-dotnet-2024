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
- se vinci + 1 
- se perdi - 1

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

## GIOCATORE SIMO :

### coloreArmata (string)
### territori (List di string)

## GIOCATORE CARLO:

### eta (int)
### bottino (int)
### lastbet (int)
### prestito (int)

## GIOCATORE FABIO:

### eta (int)


## GIOCATORE GIADA :

### COGNOME (string)

### ETA (int)


# METODI 

### STAMPA()

- scrive tutti gli argomenti del giocatore una riga alla volta

### VINCITA(bool win)

- prende come argomento il booleano win (Hai vinto? si/no)
- aumenta di 1 partite giocate 
- se (win == true) <br/>
  {aumenta di 1 partite vinte e punteggio}
  else 
  {punteggio - 1}


