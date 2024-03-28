using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;


namespace QUIZ.Pages;

public class ValidazioneDoppiaModel : PageModel
{
  public Utente Utente { get; set; }
  public IEnumerable<VerificaDoppia> Giuste { get; set; }

  public int Punteggio;

    public void OnGet(string nome, List<string> ru, List<string> rg1, List<string> rg2, int punteggio)
    {
      var json = System.IO.File.ReadAllText("wwwroot/json/utenti.json");
      var utenti = JsonConvert.DeserializeObject<List<Utente>>(json);
      Utente = utenti.FirstOrDefault(u => u.Nome == nome);
      int salto = 0;
      string runo;
      string rdue;
      string risposta;


      int posizione = 0;
      string[] rispUtente = new string[9];

      foreach (string r in ru)
      {

        switch (r)
        {
          case "1opzioneA": 
          {
            rispUtente[0] = r;
            posizione = 1;
            break;
          };
          case "1opzioneB": 
          {
            rispUtente[1] = r;
            posizione = 2;
            break;
          };
          case "1opzioneC": 
          {
            rispUtente[2] = r;
            posizione = 3;
            break;
          };
          case "2opzioneA": 
          {
            rispUtente[3] = r;
            posizione = 4;
            break;
          };
          case "2opzioneB": 
          {
            rispUtente[4] = r;
            posizione = 5;
            break;
          };
          case "2opzioneC": 
          {
            rispUtente[5] = r;
            posizione = 6;
            break;
          };
          case "3opzioneA": 
          {
            rispUtente[6] = r;
            posizione = 7;
            break;
          };
          case "3opzioneB": 
          {
            rispUtente[7] = r;
            posizione = 8;
            break;
          };
          case "3opzioneC": 
          {
            rispUtente[8] = r;
            posizione = 9;
            break;
          };
          default: 
          {
            rispUtente[posizione] = r;
            break;
          }
        }
      
        /* 
          io metto il 2 
          quindi posizione = 3 
          quindi a = 7
          posizione massima 8
        */

        if (posizione < 9)
        {
          for (int v = posizione; v < 9; v++)
          {
            rispUtente[v] = "Nada";
          }
        }

      } 


      var verificas = new List<VerificaDoppia>();

      for (int i = 0; i < 3; i++)
      {
        runo = rg1[i];
        rdue = rg2[i];
      {
        for (int e = salto; e < salto+3; e++) 
        {
          risposta = rispUtente[e]; 

          if (risposta != null)
          {
            if (risposta == runo || risposta == rdue)
            {
             var giusta = new VerificaDoppia{ Id = e+1, RispostaGiusta1= runo, RispostaGiusta2 = rdue, RispostaUtente = risposta, Uguali = true };
              verificas.Add(giusta);
            }
            else
            {
              var giusta = new VerificaDoppia{ Id = e+1, RispostaGiusta1= runo, RispostaGiusta2 = rdue, RispostaUtente = risposta, Uguali = false };
              verificas.Add(giusta);
            }
          }
        }
          salto = salto + 3;
      }
      }

      /* 
          salto = 0
          0,1,2 
          e < 3 
          salto = 3
          3,4,5 
          e < 6
          salto = 6
          6,7,8
          e < 9
       */ 

      Giuste = verificas;
      int record = Utente.Record;
      if (punteggio > record)
      {
        record = punteggio;
      }

      int vecchiPunteggi = Utente.Punteggi.Length;
      int[] scores = new int[vecchiPunteggi + 1];
      
      for (int s = 0; s < vecchiPunteggi; s++)
      {
        scores[s] = Utente.Punteggi[s];
      }

      Punteggio = punteggio;

      scores[vecchiPunteggi] = punteggio;
      Utente.Punteggi = scores;
      Utente.Record = record;
      System.IO.File.WriteAllText("wwwroot/json/utenti.json", JsonConvert.SerializeObject(utenti, Formatting.Indented));
    }

}




