const btnDeleteRep = document.querySelectorAll(".btn-delete-rep");
const inputHDelete = document.querySelectorAll(".inputH-delete");
const lienDelete = document.getElementById("lienDelete");

for (let index in btnDeleteRep) {
    btnDeleteRep[index].onclick = () => {
        lienDelete.href = lienDelete.href + '/' + inputHDelete[index].value
    }
}
