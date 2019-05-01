$(document).ready(function () {
    (async () => {
        return await axios.get('/Grad/GetGradovi')
            .then(result => {
                let tr;
                for (var i = 0; i < result.data.length; i++) {
                    tr = $('<tr/>');
                    tr.append("<td>" + result.data[i].Id + "</td>");
                    tr.append("<td>" + result.data[i].Naziv + "</td>");
                    tr.append("<td>" + result.data[i].Opis + "</td>");
                    tr.append("<td>" + result.data[i].Opcije + "</td>");
                    $('table').append(tr);
                }
                let oko = '<i class="fa fa-eye fa-2x" aria-hidden="true" id="oko"></i>';
                let kanta = '<i class="fa fa-trash-o fa-2x" aria-hidden="true" id="kanta"></i>';
                let table = $('#gradovi').DataTable({
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
                $('#gradovi tbody').on('click', '#oko', function () {
                    const id = table.row($(this).parents('tr')).data()[0]; // dohvaća vrijednost skrivene ćelije u tablici 
                    window.location.href = "/Grad/DetaljiGrada/" + id;
                });
                $('#gradovi tbody').on('click', '#kanta', function () {
                    const id = table.row($(this).parents('tr')).data()[0]; // dohvaća vrijednost skrivene ćelije u tablici
                    axios.delete('/Grad/IzbrisiGrad/id', {
                        params: { id }
                    }).then(response => {
                        console.log(response);
                        setTimeout(window.location.reload.bind(window.location), 300);
                    }).catch(response => {
                        console.log(response);
                    });
                });
            }).catch(error => {
                console.log(error);
            });
    })();
});