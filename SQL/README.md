# DATABASE RELAZIONALI

I database relazionali sono un tipo di database che utilizza il modello relazionale, ovvero un modello di dati basato sul concetto matematico di relazione.

Ad esempio, una tabella di un database relazionale può essere rappresentata come una matrice bidimensionale, dove ogni riga rappresenta una tupla e ogni colonna un attributo.

## SQL

SQL (Structured Query Language) è un linguaggio standardizzato per database basati sul modello relazionale (RDBMS).

SQL è un linguaggio dichiarativo, ovvero non è necessario specificare come ottenere i dati ad esempio tramite cicli o condizioni, ma è sufficiente specificare quali dati.

### SELECT

La clausola `SELECT` permette di selezionare i dati da una tabella.

```sql
SELECT * FROM table_name;
```

### WHERE

La clausola  `WHERE` permette di filtrare i dati in base a una condizione.

```sql
SELECT * FROM table_name WHERE condition;
```

### ORDER BY 

La clausola  `ORDER BY` permette di ordinare i dati in base a una colonna.

```sql
SELECT * FROM table_name WHERE condition;
```

### INSERT INTO

La clausola  `INSERT INTO` permette di inserire una tupla in una tabella.

```sql
SELECT * FROM table_name WHERE condition;
```

### UPDATE

La clausola  `UPDATE` permette di modificare i dati in una tabella.

```sql
UPDATE table_name SET column1 = value1, column2 = value2, ... WHERE condition;
```

### DELETE

La clausola  `DELETE` permette di eliminare i dati in una tabella.

```sql
DELETE FROM table_name WHERE condition;
```

### JOIN

La clausola  `JOIN` permette unire due o più tabelle.

```sql
SELECT * FROM table1 JOIN table2 ON condition;
```

### GROUP BY

La clausola  `GROUP BY` permette di raggruppare i dati in base a una colonna.

```sql
SELECT * FROM table_name GROUP BY column_name;
```

# SQLITE

Per utilizzare un database relazionale in C# è necessario istallare il pacchetto `System.Data.SQLite`.

Il comando dotnet per installare il pacchetto è il seguente:

```bash
dotnet add package System.Data.SQLite
```

Inoltre se vogliamo utilizzare il tool `sqlite3` per visualizzare il contenuto del database è necessario installare il pacchetto `sqlite3`

```bash
sudo apt install sqlite3
```

```bash
dotnet tool install --global dotnet-sqlite
```

oppure installarlo da [sito](https://www.sqlite.org/download.html).

Su windows bisogna impostare la variabile d'ambiente `PATH` con il percorso della cartella `bin` di `sqlite3`.

Per farlo `Pannello di controllo > Sistema e sicurezza > Sistema > Impostazioni di sistema avanzate > 


```bash
sqlite> .help
```


## COMANDI INIZIALI 

> nel git bash 
```bash 

sqlite3 
.open database.db
.exit (o ctrl+C)
sqlite3 database.db < script.sql
```

> per formattare la visualizzazione dei dati 

```bash
.mode column
.mode table
```

### per visualizzare solo quello che costa di piu'

SELECT * FROM prodotti ORDER BY prezzo DESC LIMIT 1;  