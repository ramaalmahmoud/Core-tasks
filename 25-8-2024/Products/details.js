
debugger
async function addToCart(){
    debugger
localStorage.productID=1;
localStorage.cartID=2;


const url="https://localhost:7010/addtocart";
const product ={
  cartId: 2,
  productId: 3,
  quantity: 3
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

}

















//=====================================================================================================================================================================
let n2=localStorage.getItem("ProductID");
async function getAllCategories() {
    let urlbyID=`https://localhost:7218/product/getProductsbyID/${n2}`; 
      
    
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
        <a href="" class="btn btn-primary"  onclick="addToCart()">add to cart</a>
      </div>
    </div> 
          `;
          localStorage.clear();
        
      });
      
  }
  getAllCategories();

  
