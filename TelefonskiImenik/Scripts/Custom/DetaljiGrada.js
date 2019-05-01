$(document).ready(() => {
    var id = location.pathname.split('/')[3];

    (async () => {
        return await axios.get('/Grad/GetGrad/id', {
            params: {
                id
            }
        }).then(result => {
            $.each(result.data, function (i, item) {
                $("<dd>").html(item.Naziv).appendTo("#1");
                $("<dd>").html(item.Opis).appendTo("#2");
            });
        });
    })();
});