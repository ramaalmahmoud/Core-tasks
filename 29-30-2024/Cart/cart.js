localStorage.userID=4;
let userID=localStorage.getItem("userID");
const url=`https://localhost:7251/cart/GetCartItemsForUser/${userID}`;

async function CartItems(params) {
debugger
    var response =await fetch(url);
    var result=await response.json();
    var body=document.getElementById("body")
    var head=document.getElementById("head");
    result.forEach(element => {

        head.innerHTML=`
        <tr id="table-row">
          <th scope="col">${Object.keys(element)[0]}</th>
    
          <th scope="col">${Object.keys(element.product)[1]}</th>
          <th scope="col">${Object.keys(element)[2]}</th>
           
           <th scope="col">${Object.keys(element.product)[2]}</th>
           <th scope="col"></th>
           
           <th scope="col"></th>

        </tr>`
      
        body.innerHTML+=`
      
        <tr>
          <th scope="row"> <h5>${element.cartItemId}</h5></th>
          <td><h5 id="card-title" class="card-title">${element.product.productName}</h5></td>
        
          <td>  <input id="quantity-cart" type="number" value="${element.quantity}"></td>
          <td><h5 id="card-title" class="card-title">${element.product.price*element.quantity}$</h5></td>
         
          <td> <a onclick="editCartItem(${element.cartItemId})" class="btn btn-primary" href="l">edit</a> </td>
          <td> <a onclick="deleteItem(${element.cartItemId})" class="btn btn-primary" href="">delete</a> </td>
         
        </tr>
        
     `;
        
    });
    
}
CartItems();














async function editCartItem(id) {
  debugger
  localStorage.cartItemId=id;
  let n=localStorage.getItem("cartItemId");
  const urlcart=`https://localhost:7251/update/updateCart/${n}`;

debugger
event.preventDefault();


let carItem={
  quantity:document.getElementById("quantity-cart").value
}


let response=await fetch(urlcart,{
    method:'PUT',
    body:JSON.stringify(carItem),
    headers:{
      'Content-Type': 'application/json'
   }
})
var data=response;
localStorage.clear();
window.alert("item modified sucssefuly");
location.reload();

}




async function deleteItem(id) {
  debugger
  localStorage.cartItemId=id;
  let n=localStorage.getItem("cartItemId");
  const url=`https://localhost:7251/delete/deleteItem/${n}`;
  event.preventDefault();
  let response=await fetch(url,{
    method: "DELETE",
    headers: {"Content-Type":"application/json"}

  })
  var data=response;
window.alert("item removed sucssefuly");
location.reload();
}
  