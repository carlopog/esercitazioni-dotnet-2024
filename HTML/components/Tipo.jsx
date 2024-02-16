const Tipo = (tipo, imgSrc, array) => {
  return (
    <>
      <div id={tipo} class="link">
      </div>

      <section>
        <img src={imgSrc} alt={tipo} />
        <div>
          <h2>{tipo}</h2>
          <ol>
            {array}
            {/* {array}.forEach(element => {
              <li><Piatto nome={element.name} prezzo={element.price} id={element.number}/></li>
            }); */}
          </ol>
        </div>
      </section>
    </>
  )
}

/*

array be like

[
  {
    "number": 1,
    "name": "quadro",
    "price": 30
  },
  {
    "number": 2,
    "name": "caprese",
    "price": 10
  },
  {
    "number": 3,
    "name": "prosciutto",
    "price": 25
  },

]

*/