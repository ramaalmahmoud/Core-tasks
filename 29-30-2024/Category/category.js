function storeCategoryID(CategoryID) {
  localStorage.CategoryIDChoosen = CategoryID;

}

async function getAllCategories() {
  let url = "https://localhost:7251/category/getAllCategories";
  var response = await fetch(url);
  console.log(response);
  var result = await response.json();

  var container = document.getElementById("container");
  
  result.forEach(element => {
      // Append the card HTML to the container
      container.innerHTML += `
      <div id="card" class="card" style="width: 18rem;">
          <img id="image" class="card-img-top" src="../images/${element.image}" alt="Card image cap">
          <div id="card-body" class="card-body">
              <h5 id="card-title" class="card-title">${element.name}</h5>
               <a href="../Products/product.html" class="btn btn-primary"  border-color: #3C5B6F;" onclick="storeCategoryID(${element.id})">shop now</a>
          </div>
      </div>
      `;

   
  });
}

getAllCategories();