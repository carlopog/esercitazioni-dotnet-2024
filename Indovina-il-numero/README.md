
# BETA TEST

## COMMENTI DI ALE


### BUG:

	int giri = 10 - tentativi;  -->  questo fa partire i tentativi da 0 invece che da 1 dando problemi anche col punteggio


### NOTE:

 - Prima lo chiami numero e dopo numero segreto
 - Se so già che è maggiore di 65 non ha senso dirmi che è maggiore di 60 poichè è un suggerimento non utile
 - _Hai indovinato in 6 tentativi_ --> i tentativi effettuati in realtà sono 7
 - _il tuo punteggio e' 4_ --> doveva essere di 3


### USER EXPERIENCE:

- "il numero è maggiore di 50? True" avrebbe senso se fossi io a chiederlo. 

   Trovo sia meglio dire qualcosa tipo "suggerimento 1: il numero è maggiore di 50"


## POST BETA TEST:

- [x] Fixato il bug dei tentativi aggiungendo +1
- [x] Fixato il punteggio grazie al punto precedente
- [x] Numero segreto è ora il nome ufficiale in tutti i casi
- [x] Ho cambiato l'ordine dei suggerimenti in modo da dare per ultimi quelli più specifici
