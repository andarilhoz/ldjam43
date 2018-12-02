// @ts-nocheck
const fs = require('fs')
const csv = require('csv')

const output = []

fs.readFile('data.csv', (error, file) => 
{
	csv.parse(file.toString(), (error, data) =>
	{
		for (const [id, order, imageTitle, description, type,  dateTimeHour, layoutType, previous, option0, option1, option2, D, A, S] of data)
		{			
            let layout = layoutType == 'FIRST' ? 0 : 1
            let options = option0.length > 0 ?  [
                {id: 0, description: option0},
                {id: 1, description: option1},
                {id: 2, description: option2},
            ] : "";

			output[id] = output[id] ||
			{
				id,
                order,
                imageTitle,
                description,
                type,
                dateTimeHour,
                layoutType : layout,
                previous,
                options,
				D,
				A,
				S
            }
        }
        
        output.map(o => {
            Object.keys(o).map(k => {
                if(o[k] == "") delete o[k]
            });
        });
		const json = JSON.stringify(output, null, '\t')

		fs.writeFile('Data.json', json, error => 
		{
			console.log(error ? error : 'Written')
		})
	})
})