$(document).ready(() => {
    $("#forma1").submit(e => {
        const grad = {};
        grad.Naziv = $("#nazivGrada").val();
        grad.Opis = $("#opisGrada").val();

        axios({
            method: 'post',
            url: '/Grad/DodajNoviGrad',
            data: grad
        }).then(response => {
            console.log(response);
            setTimeout(window.location.reload.bind(window.location), 300);
        }).catch(response => {
            console.log(response);
        });

        e.preventDefault();
    });
});