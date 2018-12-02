// @ts-nocheck
const fs = require('fs')
const csv = require('csv')

const output = []

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

            output[id] = output[id] ||
                {
                    id: parseInt(id),
                    ordem: parseInt(order),
                    imagem: imageTitle,
                    texto: description,
                    dialogoType: type,
                    dataHor: dateTimeHour,
                    layoutType: layout,
                    dialogoAnterior: parseInt(previous),
                    opcoes: options,
                    D,
                    A,
                    S
                }
        }

        output.map((o, index) => {
            Object.keys(o).map(k => {
                if (o[k] === "") delete o[k]
            });

            if (o.options.length < 1) delete o.options

            if (isNaN(o.previous)) delete o.previous

            if (o.D == undefined) return;
            output.find(out => out.order == o.order - 1).options[o.previous].status = {
                dinheiro: o.D,
                amor: o.A,
                saude: o.S
            }
            delete o.D
            delete o.A;
            delete o.S;
        });
        const json = JSON.stringify(output, null, '\t')

        fs.writeFile('Data.json', json, error => {
            console.log(error ? error : 'Written')
        })
    })
})