# RAZOR 

Razor è un motore di template di sintassi C# che consente di scrivere codice C# all'interno di un file HTML.
è stato introdotto con ASP.NET MVC 3 e da allora è diventato sempre più popolare per la sua semplicità e flessibilità.

per vedere in diretta i cambiamenti bisogna scrivere 
`dotnet watch run`

## Sintassi 

La sintassi di Razor è molto simile a quella di ASP.NET 
è possibile scrivere codice C# all'interno di blocchi di codice `@...`

I files creati con Razor hanno l'estensione `.cshtml`

I blocchi di codice C# iniziano con @{ e terminano con `}`

è possibile scrivere espressioni ed utilizzare le variabili C# all'interno di blocchi di codice @...`

```bash

dotnet new razor -n WebAppProdotti

```

## Index.cshtml.cs

Index.cshtml.cs è una classe che eredita da PageModel e fornisce i dati alla pagina Index.cshtml
è possibile utilizzare IndexModel per fornire i dati alla pagina Index.cshtml

```c#
using Microsoft.AspNetCore.Mvc; // IActionResult e Controller
using Microsoft.AspNetCore.Mvc.RazorPages; // PageModel

public void OnGet() // possiamo far fare qualcosa all'applicazione aggiungendolo al metodo OnGet()
{
  ViewData["Message"] = "Hello from Razor";
}
```

In questo modo stiamo assegnando un valore alla chiave Message del dizionario ViewData
Il messaggio verrà visualizzato nella pagina Index.cshtml tramite la sintassi @ViewData ["Message"]
File: `index.cshtml`

```c#

@page
@model IndexModel
@{
    ViewData["Title"] = "Home page";
    ViewData["Message"] = "Hello from Razor"; // se non gliela passiamo dalla classe (file.cs) possiamo metterla direttamente qui
}


<div class="text-center">
    <h1 class="display-4">Welcome</h1>
    <p>Learn about <a href="https://learn.microsoft.com/aspnet/core">building Web apps with ASP.NET Core</a>.</p>
    <p>@ViewData["Message"]</p>
</div>

```

```c#

@page
@model IndexModel
@{
  var versione = 3;    
}


<div class="text-center">
    <h1 class="display-4">Welcome</h1>
    <p>Versione: @versione</p>
</div>

```

## Layout 

Razor consente di creare layout per le pagine web. 
Un layout è un file che contiene la struttura di una pagina web.
è possibile definire un layout e utilizzarlo in tutte le pagine web.

Di default viene utilizzato il layout `_Layout.cshtml` che si trova nella cartella `Views/Shared`

@RenderBody() è un metodo che consente di visualizzare il contenuto della pagina web all'interno del layout

```csharp
<!DOCTYPE html>
<html>
<head>
  <title>@ViewBag.Title</title>
</head>
<body>
  @RenderBody()
</body>
</html>

```

## Partials

Razor consente di creare viste parziali. Una vista parziale è un file 


## Tabella prodotti

dentro il file Prodotto.cshtml.cs

```c#

<table class="table">
  <thead>
    <tr>
      <th>Nome</th>
      <th>Prezzo</th>
    </tr>
  </thead>
  <tbody>
    @foreach (var prodotto in Model.Prodotti)
    {
      <tr>
        <td>@prodotto.Nome</td>
        <td>@prodotto.Prezzo</td>
      </tr>
    }
  </tbody>
</table>

```
