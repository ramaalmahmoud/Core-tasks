async function login(params) {
    debugger
    const url ="https://localhost:7187/login";
    var form=document.getElementById("form");
    event.preventDefault();
   
   
    var formData=new FormData(form);
    let response=await fetch(url,{
        method:'POST',
        body:formData,
    })
    var result= await response.json();

  let token= localStorage.jwtToken=result.token;
   console.log("token",token)

if(response.ok){
    window.alert("User logged in successfully ");
    location.href="http://127.0.0.1:5500/Products/product.html";

}
else{
    window.alert("email or password wrong"); 
}
    


   
    
}