$(document).ready(() => {

    $("#forma1").submit(e => {
        const broj = {};
        broj.OsobaId = $("#osobaId").val();
        broj.BrojTipId = $("#brojTipId").val();
        broj.Broj = $("#broj").val();
        broj.Opis = $("#opis").val();

        let isValid = true;
        if (broj.OsobaId === "" || broj.OsobaId === undefined) {
            return isValid = false;
        }
        if (broj.BrojTipId === "" || broj.BrojTipId === undefined) {
            return isValid = false;
        }
        if (broj.Broj === "" || broj.Broj === undefined) {
            return isValid = false;
        }

        if (isValid) {
            axios({
                method: 'post',
                url: '/Broj/DodajBroj',
                data: broj
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
        return await axios.get('/Broj/GetTipBroj')
            .then(result => {
                var lista = $('#brojTipId');
                lista.empty();
                $(function () {
                    $("#brojTipId").prepend("<option value='' selected='selected'></option>");
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

    (async () => {
        return await axios.get('/Osoba/GetOsoba')
            .then(result => {
                var lista = $('#osobaId');
                lista.empty();
                $(function () {
                    $("#osobaId").prepend("<option value='' selected='selected'></option>");
                });
                $(result.data).each(function () {
                    lista.append(
                        $('<option>',
                            {
                                value: this.Id
                            }).html(this.Ime + " " + this.Prezime)
                    );
                });
            }).catch(error => {
                console.log(error);
            });
    })();
});