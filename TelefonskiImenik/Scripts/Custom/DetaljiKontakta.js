$(document).ready(() => {
    var id = location.pathname.split('/')[3]; // uzima id iz URL-a da ga može proslijediti u getJSON kao varijablu.

    (async () => {
        return await axios.get('/Osoba/GetOsoba/id', {
            params: {
                id
            }
        }).then(result => {
            $.each(result.data, function (i, item) {
                $("<dd>").html(item.Ime).appendTo("#1");
                $("<dd>").html(item.Prezime).appendTo("#2");
                $("<dd>").html(item.Naziv).appendTo("#3");
                $("<dd>").html(item.Opis).appendTo("#4");
            });
        });
    })();

    (async () => {
        return await axios.get('/Broj/GetBroj/id', {
            params: {
                id
            }
        }).then(result => {
            var tr;
            for (var i = 0; i < result.data.length; i++) {
                tr = $('<tr/>');
                tr.append("<td>" + result.data[i].Broj + "</td>");
                tr.append("<td>" + result.data[i].BrojTip + "</td>");
                tr.append("<td>" + result.data[i].OpisBroja + "</td>");
                $('#tab1').append(tr);
            }
        }).catch(error => {
            console.log(error);
        });
    })();

    (async () => {
        return await axios.get('/Osoba/GetOsobaSlika/id', {
            params: {
                id
            }
        }).then(result => {
            slika = result.data[0].Slika;
            $('#slika').html('<img src="data:image/jpeg;base64,' + slika + '" class="img-thumbnail" width="250" />');
        }).catch(error => {
            console.log(error);
        });
    })();
});