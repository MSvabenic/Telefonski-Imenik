$(document).ready(function () {
    (async () => {
        return await axios.get('/Osoba/GetOsobe')
            .then(result => {
                let tr;
                for (var i = 0; i < result.data.length; i++) {
                    tr = $('<tr/>');
                    tr.append("<td>" + result.data[i].OsobaId + "</td>");
                    tr.append("<td>" + result.data[i].Ime + "</td>");
                    tr.append("<td>" + result.data[i].Prezime + "</td>");
                    tr.append("<td>" + result.data[i].Grad + "</td>");
                    tr.append("<td>" + result.data[i].Broj + "</td>");
                    tr.append("<td>" + result.data[i].Opcije + "</td>");
                    $('table').append(tr);
                }
                let oko = '<i class="fa fa-eye fa-2x" aria-hidden="true" id="oko"></i>';
                let kanta = '<i class="fa fa-trash-o fa-2x" aria-hidden="true" id="kanta"></i>';
                let table = $('#osobe').DataTable({
                    "autoWidth": true,
                    "oLanguage": {
                        "sUrl": "https://cdn.datatables.net/plug-ins/1.10.16/i18n/Croatian.json"
                    },
                    "columnDefs": [
                        {
                            "className": "dt-center", "targets": "_all"
                        },
                        {
                            "targets": -1,
                            "data": null,
                            "render": function () {

                                return oko + ' ' + kanta;
                            }
                        },
                        {
                            "targets": [0],
                            "visible": false
                        }
                    ]

                });
                $('#osobe tbody').on('click', '#oko', function () {
                    const id = table.row($(this).parents('tr')).data()[0]; // dohvaća vrijednost skrivene ćelije u tablici 
                    window.location.href = "/Kontakt/DetaljiKontakta/" + id;
                });
                $('#osobe tbody').on('click', '#kanta', function () {
                    const id = table.row($(this).parents('tr')).data()[0]; // dohvaća vrijednost skrivene ćelije u tablici 
                    $.ajax({
                        url: "/Osoba/IzbrisiOsobu/" + id,
                        type: "DELETE"
                    }).done(function () {
                        alert('Uspješno Izbrisano!'),
                            setTimeout(window.location.reload.bind(window.location), 300);
                    }).fail(function () {
                        alert('Nešto je pošlo po krivu, molim pokušaj ponovno!'),
                            setTimeout(window.location.reload.bind(window.location), 300);
                    });
                });
            }).catch(error => {
                console.log(error);
            });
    })();
});