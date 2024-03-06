class Giocatore 
{
  public int Id { get; set; } // numero identificativo del giocatore, assegnato in automatico in ordine crescente
  public string Nome { get; set; } // nome del giocatore (deve essere unico)
  public int Eta { get; set; } // eta del giocatore (serve per controllo maggiorenni)
  public int Bottino { get; set; } // totale euro a disposizione del giocatore
  public int Lastbet { get; set; } // prezzo dell'ultima scommessa effettuata dal giocatore (la prossima dovra' essere maggiore)
  public int Prestito { get; set; } // debito del giocatore verso "il banco" (se da 0 passa a x => Bottino += x, se da x passa a 0 Bottino -= x)

}