localStorage.userID=4;
let userID=localStorage.getItem("userID");
const url=`https://localhost:7053/cart/GetCartItemsForUser/${userID}`;

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

        </tr>`
      
        body.innerHTML+=`
      
        <tr>
          <th scope="row"> <h5>${element.cartItemId}</h5></th>
          <td><h5 id="card-title" class="card-title">${element.product.productName}</h5></td>
          <td><h5 id="card-title" class="card-title">${element.quantity}</h5></td>
          <td><h5 id="card-title" class="card-title">${element.product.price*element.quantity}$</h5></td>
         
          <td> <a onclick="storeID(${element.id})" class="btn btn-primary" href="../Admin/edit-product.html">edit</a> </td>
         
        </tr>
        
     `;
        
    });
    
}
CartItems();