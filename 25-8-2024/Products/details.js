
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
       
        <a href="../Products/edit-product.html" class="btn btn-primary"  onclick="storeProductID(${element.id})">edit this product</a>
      </div>
    </div> 
          `;
          localStorage.clear();
        
      });
      
  }
  getAllCategories();
