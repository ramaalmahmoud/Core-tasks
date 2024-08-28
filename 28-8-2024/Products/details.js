










async function addToCart(productID){
    debugger
localStorage.productID=productID;
localStorage.cartID=2;



const url="https://localhost:7053/addtocart";
const product ={
  cartId:localStorage.getItem("cartID") ,
  productId: localStorage.getItem("productID"),
  quantity: document.getElementById("quantity").value
}
event.preventDefault();
let response=await fetch(url,{
  method:'POST',
  body:JSON.stringify(product),
  headers:{
     'Content-Type': 'application/json'
  }
})
window.alert("the item added sucssefuly");
window.location.href="http://127.0.0.1:5500/Cart/cart.html";

}


















//=====================================================================================================================================================================
let n2=localStorage.getItem("ProductID");
async function getAllCategories() {
    let urlbyID=`https://localhost:7053/product/getProductsbyID/${n2}`; 
      
    
        var response =await fetch(urlbyID);
      
     
      console.log(response);
      var result=await response.json();
  
      var container=document.getElementById("container");
      result.forEach(element => {
          container.innerHTML +=`
          <div id="card" class="card" style="width: 18rem;">
      <img id="image" class="card-img-top" src="../images/${element.productImage} "alt="Card image cap">
      <div id="card-body" class="card-body">
        <h5 id="card-title" class="card-title">${element.productName}</h5>
        <p class="card-text">${element.description}</p>
         <p class="card-text">${element.price} $</p>
       <input id="quantity" type="number">
        <a href="" class="btn btn-primary"  onclick="addToCart(${element.id})">add to cart</a>
      </div>
    </div> 
          `;
          localStorage.clear();
        
      });
      
  }
  getAllCategories();

  
