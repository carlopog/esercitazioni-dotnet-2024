# HTML

HTML e' un linguaggio di markup per la strutturazione delle pagine web, pubblicato come W3C Recommendation da ottobre 2014. Il suo sviluppo e' stato affidato all'HTML Working Group, un gruppo di lavoro specifico composto da rappresentanti di aziende, produttori di software, esperti di linguaggi markup e browser.

> La differenza principale rispetto alle versioni precedenti di HTML e' che HTML e' un linguaggio basato su un insieme di regole ben definite, chiamate parsing rules, che permettono di interpretare correttamente il codice HTML anche se non e' stato scritto correttamente. Questo permette di scrivere codice HTML piu' semplice e di correggere gli errori di sintassi piu' facilmente.

### Struttura di un documento HTML

un documento HTML e' composto da due parti principali: il doctype e il body. Il doctype e' la dichiarazione che indica al browser che il documento e' scritto in HTML. Il doctype di HTML e' <!DOCTYPE html>. Il body e' la parte del documento che contiene il contenuto della pagina web.

### Tag HTML

I tag HTML sono i seguenti:

- ```<html>```: indica l'inizio e la fine del documento HTML
- ```<head>```: contiene le informazioni sul documento HTML
- ```<title>```: contiene il titolo del documento HTML
- ```<body>```: contiene il contenuto del documento HTML
- ```<h1>,<h2>,<h3>,<h4>,<h5>,<h6>```: contengono i titoli di primo, secondo, terzo, quarto, quinto e sesto livello
- ```<p>```: contiene un paragrafo
- ```<br>```: vai a capo
- ```<hr>```: inserisce una riga orizzontale
- ```<a>```: contiene un link (con href)
- ```<img>```: contiene un'immagine (con src e alt)
- ```<ul>```: contiene una lista non ordinata
- ```<ol>```: contiene una lista ordinata
- ```<li>```: contiene un elemento di una lista
- ```<div>```: contiene un blocco di contenuto
- `<table>`: contiene una tabella formata da `<tr>` che e' una riga e `<th>` cella di intestazione e `<td>` una cella qualsiasi

### Attributi HTML

Gli attributi HTML sono i seguenti

- id: identifica un elemento
- class: identifica un gruppo di elementi
- style: contiene le regole CSS per formattare un elemento
- href: contiene l'indirizzo di un link
- src: contiene l'indirizzo di un'immagine
- alt: contiene il testo alternativo di un'immagine
- title: contiene il testo che appare quando si passa il mouse sopra un elemento
- width: contiene la larghezza di un elemento
- height: contiene l'altezza di un elemento
- target: contiene il nome della finestra in cui apre il link

### Formattazione del testo

Per formattare il testo si possono usare i seguenti tag:

- `<b>`: testo in grassetto
- `<strong>`: testo in grassetto
- `<i>`: testo in corsivo
- `<em>`: testo in corsivo
- `<mark>`: testo evidenziato 
- `<small>`: testo piccolo 
- `<del>`: testo barrato
- `<ins>`: testo sottolineato
- `<sub>`: testo in pedice
- `<sup>`: testo in apice

### Formattazione del testo con CSS

Per formattare il testo con CSS si possono usare le seguenti proprieta':

- `color`: colore del testo es:  `color: red;`
- `font-family`: tipo di carattere es: `font-family: Arial;`
- `font-size`: dimensione del testo es: `font-size: 12px;`
- `font-weight`: spessore del testo es: `font-weight: bold;`
- `font-style`: stile del testo es: `font-style: italic;`
- `text-decoration`: decorazione del testo es: `text-decoration: none;`
- `text-`: tipo di carattere es: `text-: Arial;`
- `text-`: tipo di carattere es: `text-: Arial;`
- `text-`: tipo di carattere es: `text-: Arial;`
- `line-height`: altezza dello spazio di scrittura es: `line-height: 15px;`

### Tipi di input

- `text`: input di testo
- `password`: input di testo con i caratteri nascosti
- `email`: input di testo per email con @
- `number`: input di testo per i numeri
- `date`: input di testo per la data
- `time`: per l'ora
- `radio`: input con il radio button `<input type="radio" name="radio"`
- `file`: `<input type="file" name="file"`
- `submit`: bottone di invio `<input type="submit" name="invia"`
- `reset`: bottone di reset `<input type="reset" name="reset"`
- `button`: bottone generico