# Bowling Rules

The game consists of 10 frames. In each frame the player has two rolls to knock down 10 pins. The score for the frame is the total number of pins knocked down, plus bonuses for strikes and spares.

A spare is when the player knocks down all 10 pins in two rolls. The bonus for that frame is the number of pins knocked down by the next roll.

A strike is when the player knocks down all 10 pins on his first roll. The frame is then completed with a single roll. The bonus for that frame is the value of the next two rolls.

In the tenth frame a player who rolls a spare or strike is allowed to roll the extra balls to complete the frame. However no more than three balls can be rolled in tenth frame.

## Requirements

Write a class **Game** that has two methods

* `void roll(int)` is called each time the player rolls a ball. The argument is the number of pins knocked down.
* `int score()` returns the total score for that game.

## Symbol meanings
* ```X``` indicates a strike
* ```/``` indicates a spare
* ```-``` indicates a miss
*  ```|``` indicates a frame boundary
* The characters after the ```||``` indicate bonus balls

## Aceptance Criteria

* ```X|X|X|X|X|X|X|X|X|X||XX``` Ten strikes on the first ball of all ten frames. Two bonus balls, both strikes. Score for each frame = 10 + score for next two balls = 10 + 10 + 10 = 30 Total score = 10 frames x 30 = ```300```
* ```9-|9-|9-|9-|9-|9-|9-|9-|9-|9-||``` Nine pins hit on the first ball of all ten frames. Second ball of each frame misses last remaining pin. No bonus balls. Score for each frame = 9 Total score = 10 frames x 9 = ```90```
* ```5/|5/|5/|5/|5/|5/|5/|5/|5/|5/||5``` Five pins on the first ball of all ten frames. Second ball of each frame hits all five remaining pins, a spare. One bonus ball, hits five pins. Score for each frame = 10 + score for next one ball = 10 + 5 = 15 Total score = 10 frames x 15 = ```150```
* ```X|7/|9-|X|-8|8/|-6|X|X|X||81``` Total score = ```167```
