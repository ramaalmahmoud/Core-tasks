async function register(params) {
    debugger
    
    const url="https://localhost:7257/register";
    var form=document.getElementById("form");
    event.preventDefault();
   
   
    var formData=new FormData(form);
    let repeatPass=document.getElementById("repeatPass").value;
    let password=document.getElementById("password").value
    if(repeatPass!=password){
        window.alert("the paswwords doesnot mache")
        return;
    }
    let response=await fetch(url,{
        method:'POST',
        body:formData,
    })
    if(!response.ok){
window.alert("this email is already exist");
    }
    let data=await response.json();
   
   
    window.location.href = "http://127.0.0.1:5501/Login/login.html";
   
    window.alert("you are register ");
}