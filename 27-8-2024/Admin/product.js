function storeID(pId){
    localStorage.productId=pId;
}

const url="https://localhost:7280/api/Products";
async function getAllProducts(params) {
    var response=await fetch(url);
    var result=await response.json();
    var body=document.getElementById("body")
    var head=document.getElementById("head");
    debugger
    result.forEach(element => {
        head.innerHTML=`
              <tr id="table-row">
                <th scope="col">${Object.keys(element)[0]}</th>
                <th scope="col">${Object.keys(element)[1]}</th>
                <th scope="col">${Object.keys(element)[2]}</th>
                <th scope="col">${Object.keys(element)[3]}</th>
                 <th scope="col">${Object.keys(element)[4]}</th>
                 <th scope="col">${Object.keys(element)[5]}</th>

              </tr>`
            
              body.innerHTML+=`
            
              <tr>
                <th scope="row"> <h5>${element.id}</h5></th>
                <td><h5 id="card-title" class="card-title">${element.productName}</h5></td>
                <td><h5 id="card-title" class="card-title">${element.description}</h5></td>
                <td><h5 id="card-title" class="card-title">${element.price}</h5></td>
                <td><img id="image" class="card-img-top" src="../images/${element.Image} "alt="Card image cap"></td>
                <td><h5 id="card-title" class="card-title">${element.categoryId}</h5></td>
                <td> <a onclick="storeID(${element.id})" class="btn btn-primary" href="../Admin/edit-product.html">edit</a> </td>
               
              </tr>
              
           `;
        
    }); 
    
}
getAllProducts();

async function populateDropdown() {
    const response = await fetch('https://localhost:7280/category/getallCategories');
    const categories = await response.json();
        
        var select=document.getElementById("select");

        categories.forEach(category => {
            const option = document.createElement('option');
            option.value = category.id; 
            option.textContent = category.name; 
            select.appendChild(option);
        });
    }

    
    populateDropdown();
let urlProduct='https://localhost:7280/api/Products/product/createProduct';
var form=document.getElementById("form");

async function createProduct(productData) {
    debugger
    event.preventDefault();
    const CategoryId = document.getElementById('select').value;
   
    var formData=new FormData(form);
    
    

    // productData.categoryId=CategoryId;
   


  
    
    let response=await fetch(urlProduct,{
        method:'POST',
        body:formData,
    })
    let data=await response.json();

    // console.log(data);
    // data.categoryId=parseInt(CategoryId);
    // console.log(data);
    // console.log(data.categoryId+2);
    
   


window.alert("product created sucssefuly");
window.location.href="http://127.0.0.1:5502/Admin/product.html";
}
