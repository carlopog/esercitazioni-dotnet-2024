class Scommessa 
{
  public int Id { get; set; } // numero identificativo della scommessa, assegnato in automatico in ordine crescente
  public string Nome { get; set; } // nome del giocatore che ha effettuato la scommessa, non deve essere unico ma corrispondere a un giocatore esistente
  public int Prezzo { get; set; } // valore in euro della puntata, questo valore viene trasmesso a Giocatori.Lastbet
  public int Vincita { get; set; } // risultato esito della scommessa in euro (puo' essere sia positivo che negativo) questo valore viene sommato a Giocatori.Bottino

}