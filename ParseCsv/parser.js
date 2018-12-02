// @ts-nocheck
const fs = require('fs')
const csv = require('csv')

const Dialogos = []

fs.readFile('data.csv', (error, file) => {
    csv.parse(file.toString(), (error, data) => {
        for (const [id, order, imageTitle, description, type, dateTimeHour, layoutType, previous, option0, option1, option2, D, A, S] of data) {
            let layout = layoutType == 'FIRST' ? 0 : 1
            let options = option0.length > 0 ? [
                { id: 0, description: option0 },
                { id: 1, description: option1 },
                { id: 2, description: option2 },
            ] : [];

            options = options.filter(o => o.description !== "empty")
            console.log(new Date(dateTimeHour).toUTCString());
            Dialogos[id] = Dialogos[id] ||
                {
                    id: parseInt(id),
                    ordem: parseInt(order),
                    imagem: imageTitle,
                    texto: description,
                    dialogoType: type,
                    dataHora: new Date(dateTimeHour).toUTCString(),
                    layoutType: layout,
                    dialogoAnterior: parseInt(previous),
                    opcoes: options,
                    D,
                    A,
                    S
                }
        }

        Dialogos.map((o, index) => {
            Object.keys(o).map(k => {
                if (o[k] === "") delete o[k]
            });

            if (o.opcoes.length < 1) delete o.opcoes

            if (isNaN(o.dialogoAnterior)) delete o.dialogoAnterior

            if (o.D == undefined) return;
            Dialogos.find(out => out.ordem == o.ordem - 1).opcoes[o.dialogoAnterior].Tipo = {
                dinheiro: o.D,
                amor: o.A,
                saude: o.S
            }
            delete o.D
            delete o.A;
            delete o.S;
        });
        let d = {Dialogos}
        const json = JSON.stringify(d, null, '\t')

        fs.writeFile('Data.json', json, error => {
            console.log(error ? error : 'Written')
        })
    })
})