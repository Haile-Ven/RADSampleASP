//Confirm User confirms deletion
function confirmDelete()
{
    var userInput = confirm("Do you want to delete this user?");
    var hiddenField = document.getElementById("delCon");
    hiddenField.value = userInput ? "Ok" : "Cancel";
}
//Remove response message
function removeResponse()
{
    var responseDiv = document.getElementById('responseDiv');
    if (responseDiv) {
        responseDiv.style.display = 'none';
    }
}