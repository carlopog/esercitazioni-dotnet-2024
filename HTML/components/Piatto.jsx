const Piatto = (id, nome, prezzo) => {
  <li>{nome} {prezzo}€
  <div class="inline">
     <Buttons id={id} n={0}/>
  </div>
</li>
}

export default Piatto;