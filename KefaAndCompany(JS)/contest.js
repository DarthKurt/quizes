// Get process.stdin as the standard input object.
const stdInput = process.stdin;

// Set input character encoding.
stdInput.setEncoding('utf-8');

inputString = '';
process.stdin
    .on('data', inputStdin => {
        inputString += inputStdin;
    })
    .on('end', _ => {
        let res = program.processInput.do(inputString);
        let friendship = program.main.do(res.threshold, res.people);

        console.log(friendship);
    });


let program = {
    processInput: {
        do: function(input) {
            let lines = input.trim().split('\n');

            let td = this._processFirstLine(lines);
            let p = this._processOtherLines(lines, td);

            return {
                threshold: td,
                people: p,
            };
        },
        _processFirstLine: function(linesArray) {
            let inputs = linesArray[0].split(' ');
            linesArray.shift();

            return Number(inputs[1]);
        },
        _processOtherLines: function(linesArray, td) {
            let p = [];

            for(let i = 0; i < linesArray.length; i++) {
                let inputs = linesArray[i].split(' ');

                p.push({
                    money: Number(inputs[0]),
                    friendship: Number(inputs[1])
                });
            };

            let sorted = p.sort((a, b) => {
                return b.money - a.money;
            });

            if (td > sorted[0].money) {
                let sum = sorted.reduce((a, b) => a + b.friendship, 0);
                console.log(sum);
                process.exit();
            }

            return sorted;
        },
    },
    main: {
        do: function(threshold, people) {
            let friendship = 0;
            let group = [];
            let groupFriendship = 0;

            while (people.length !== 0) {
                let topFriend = people.pop();

                group.push(topFriend);
                groupFriendship += topFriend.friendship;

                while(group.length > 0){
                    if (!this._check(group[group.length - 1].money, group[0].money, threshold)){
                        groupFriendship -= group[0].friendship;
                        group.shift();
                    } else {
                        friendship = friendship > groupFriendship
                            ? friendship
                            : groupFriendship;
                        break;
                    }
                }
            }

            return friendship;
        },
        _check: function(a, b, t) {
            return (a - b) < t;
        }
    },
};