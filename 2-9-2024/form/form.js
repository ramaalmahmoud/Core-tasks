async function getUserInfo(params) {
    debugger
    let email=document.getElementById("email").value;
    const url=`https://localhost:7257/get/getUserByEmail${email}`;
    event.preventDefault();
    let response=await fetch(url);
    var result=await response.json();
    document.getElementById("ID").value=result.id;
    document.getElementById("Email").value=result.email;
    document.getElementById("Name").value=result.username;
}