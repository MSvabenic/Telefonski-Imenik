$(document).ready(() => {

    $("#slika").change(function () {                //funkcija koja ispisuje naziv slike
        $("#slikaTekst").text(this.files[0].name);
    });

    $("#forma1").submit(e => {
        const osoba = {};
        osoba.Ime = $("#ime").val();
        osoba.Prezime = $("#prezime").val();
        osoba.GradId = $("#gradId").val();
        osoba.Opis = $("#opis").val();
        osoba.Slika = slikaBin;
        osoba.UserId = $("#userId").val();

        let isValid = true;
        if (osoba.Ime === "" || osoba.Ime === undefined) {
            return isValid = false;
        }
        if (osoba.Prezime === "" || osoba.Prezime === undefined) {
            return isValid = false;
        }
        if (osoba.GradId === "" || osoba.GradId === undefined) {
            return isValid = false;
        }

        if (isValid) {
            axios({
                method: 'post',
                url: '/Osoba/DodajOsobu',
                data: osoba
            }).then(response => {
                console.log(response);
                window.location.href = "/Kontakt/DodajBroj";
            }).catch(response => {
                console.log(response);
            });
        }
        e.preventDefault();
    });

    (async () => {
        return await axios.get('/Grad/GetGradovi')
            .then(result => {
                var lista = $('#gradId');
                lista.empty();
                $(function () {
                    $("#gradId").prepend("<option value='' selected='selected'></option>");
                });

                $(result.data).each(function () {
                    lista.append(
                        $('<option>',
                            {
                                value: this.Id
                            }).html(this.Naziv)
                    );
                });
            }).catch(error => {
                console.log(error);
            });
    })();

    var slikaBin;

    const uploadSlike = function (data) {
        var files = data.target.files;
        var file = files[0];

        if (files && file) {
            var reader = new FileReader();

            reader.onload = function (dataReader) {
                var binaryString = dataReader.target.result;
                slikaBin = btoa(binaryString);
            };

            reader.readAsBinaryString(file);
        }
    };

    if (window.File && window.FileReader && window.FileList && window.Blob) {
        document.getElementById('slika').addEventListener('change', uploadSlike, false);
    }
});