
function storeProductID(productID) {
  localStorage.ProductID = productID;
  
}

let n=localStorage.getItem("CategoryIDChoosen");
// debugger
console.log("local",n);
async function getAllCategories() {
  // debugger
  let urlforall ="https://localhost:7187/getallproducts";
    let url=`https://localhost:7218/product/getAllProductsbyCategory/${n}`;
    let token=localStorage.getItem("jwtToken");
    console.log(token);
    
    if(n==null){
      if(token==null){
        alert("you need to login ");
      }
      else
        var response =await fetch(urlforall,{
          method:"GET",
          headers:{
            'Authorization':`Bearer ${token}`,
          },
        });
      
      
      
    }
   
    else {
      var response =await fetch(url);
    }
  
   
    var result=await response.json();
    console.log(response);
    

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
         
      
    });
    
}
getAllCategories();