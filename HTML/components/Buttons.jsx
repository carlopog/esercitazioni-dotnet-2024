function Buttons(id, n) {
  return(
    <div class="inline">
       <button type="button" class="add" onclick={Add(id,n)}>+</button>
       <p id={id}>0</p>
       <button type="button" class="remove" onclick={Remove(id,n)}>-</button>
    </div>
  )
}