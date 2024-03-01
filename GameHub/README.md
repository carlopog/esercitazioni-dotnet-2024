# CLASSE GIOCATORE 
## (nome, punteggio, crediti, partite giocate, partite vinte)

# CLASSI ESTESE: 

- ## GIOCATORE FABIO: (eta)

- ## GIOCATORE GIADA : (eta, cognome)

- ## GIOCATORE SIMO : (coloreArmata, territori)

- ## GIOCATORE CARLO: (eta, bottino, lastbet, prestito)


# ARGOMENTI NELLO SPECIFICO

### NOME (string)

- è il tuo nome

### ETA (int)

- è la tua età

### PUNTEGGIO (int)

- parte da 0
- se vinci + 1 
- se perdi - 1

### CREDITI (int)

- parte da 20
- diminuisce di 1 a ogni partita (gestito dal Program.cs) 

### PARTITE GIOCATE (int)

- parte da 0
- aumenta di 1 per ogni partita

### PARTITE VINTE (int)

- parte da 0
- aumenta di 1 per ogni partita vinta

### COLORE ARMATA (string)

- indica il colore dei carrarmati del giocatore

### TERRITORI (List di string)

- lista di territori appartenenti al giocatore

### BOTTINO (int)

- soldi del giocatore

### LASTBET (int)

- valore dell'ultima scommessa del giocatore

### PRESTITO (int)

- soldi prestati al giocatore (debito del giocatore)


# METODI 

### STAMPA()

- scrive tutti gli argomenti del giocatore una riga alla volta

### VINCITA(bool win)
```c#
  public virtual void Vincita(bool win)
  {
    if (win)
    {
      partiteVinte++;
      punteggio++;
    }
    else
    {
      punteggio--;
    }
      partiteGiocate++;
  }
  ```

- prende come argomento il booleano win (Hai vinto? si/no)
- aumenta di 1 partite giocate 
- se (win == true) <br/>
  {aumenta di 1 partite vinte e punteggio}
  else 
  {punteggio - 1}


