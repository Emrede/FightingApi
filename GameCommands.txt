### Game Commands ###

1. Start a new game or reset an existing game.

[HttpGet]
https://localhost:5001/api/players/NewGame

2. Make a move 

[HttpPost]
https://localhost:5001/api/attack

3. Check game state

[HttpGet]
https://localhost:5001/api/Attack/GameState

4. Check a particular player by id

[HttpGet("{id}")]
https://localhost:5001/api/players/1

5. Create new players from body
[HttpPost]
Ex:
    {
        "id": 1,
        "name": "Scorpion",
        "hitPoint": 100,
        "armor": 100
    },
    {
        "id": 2,
        "name": "Sub-Zero",
        "hitPoint": 100,
        "armor": 100
    }

6. Delete a player by id

[HttpDelete("{id}")]
https://localhost:5001/api/players/2

7. Change a player feature

[HttpPut("{id}")]
https://localhost:5001/api/players/2
Ex: {
        "id": 2,
        "name": "Raiden",
        "hitPoint": 100,
        "armor": 100
    }
