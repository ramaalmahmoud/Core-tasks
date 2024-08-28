
function storeProductID(productID) {
  localStorage.ProductID = productID;
  
}

let n=localStorage.getItem("CategoryIDChoosen");

console.log("local",n);
async function getAllCategories() {
  let urlforall="https://localhost:7218/product/getAllProducts";
    let url=`https://localhost:7218/product/getAllProductsbyCategory/${n}`;
    
    if(n!=null){
      var response =await fetch(url);
    }
  
    else{
      var response =await fetch(urlforall);
    }
   
    console.log(response);
    var result=await response.json();

    var container=document.getElementById("container");
    result.forEach(element => {
        container.innerHTML +=`
        <div id="card" class="card" style="width: 18rem;">
    <img id="
    
    " class="card-img-top" src="../images/${element.productImage} "alt="Card image cap">
    <div id="card-body" class="card-body">
      <h5 id="card-title" class="card-title">${element.productName}</h5>
      <p class="card-text">${element.description}</p>
       <p class="card-text">${element.price} $</p>
     
      <a href="../Products/product_details.html" class="btn btn-primary"  onclick="storeProductID(${element.id})">show details</a>
    </div>
  </div> 
        `;
        localStorage.clear();
      
    });
    
}
getAllCategories();