function storeID(cId){
    localStorage.categoryId=cId;
}
const url="https://localhost:7280/category/getallCategories";
debugger
async function getAllCategory(params) {
    var response=await fetch(url)
    var result=await response.json()

    var table=document.getElementById("table")
    var body=document.getElementById("body")
    var head=document.getElementById("head");
    result.forEach(element => {
        head.innerHTML=`
              <tr id="table-row">
                <th scope="col">${Object.keys(element)[0]}</th>
                <th scope="col">${Object.keys(element)[1]}</th>
                <th scope="col">${Object.keys(element)[2]}</th>
               
              </tr>`
            
              body.innerHTML+=`
            
              <tr>
                <th scope="row"> <h5>${element.id}</h5></th>
                <td><h5 id="card-title" class="card-title">${element.name}</h5></td>
                <td><img id="image" class="card-img-top" src="../images/${element.Image} "alt="Card image cap"></td>
                <td> <a onclick="storeID(${element.id})" class="btn btn-primary"  href="../Admin/edit-category.html">edit</a> </td>
               
              </tr>
              
           `;
        
    }); 
    
}
getAllCategory();
let urlProduct='https://localhost:7280/category/createCategory';
var form=document.getElementById("form");

async function createCategory(productData) {
    debugger
    event.preventDefault();
   
   
    var formData=new FormData(form);
    
    

   
   


  
    
    let response=await fetch(urlProduct,{
        method:'POST',
        body:formData,
    })
    let data=await response.json();

    // console.log(data);
    // data.categoryId=parseInt(CategoryId);
    // console.log(data);
    // console.log(data.categoryId+2);
    
   


window.alert("category created sucssefuly");
window.location.href="http://127.0.0.1:5502/Admin/category.html";
}



