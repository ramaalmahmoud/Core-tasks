async function login(params) {
    debugger
    const url ="https://localhost:7257/login";
    var form=document.getElementById("form");
    event.preventDefault();
   
   
    var formData=new FormData(form);
    let response=await fetch(url,{
        method:'POST',
        body:formData,
    })
if(response.ok){
    window.alert("User logged in successfully ");

}
else{
    window.alert("email or password wrong"); 
}
    


   
    
}