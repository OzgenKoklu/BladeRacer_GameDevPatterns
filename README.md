# Contents of this repo
This repo will include the example racing game from the book "Game Development Patterns with Unity 2021 - Second edition"

It is a complete tutorial that teaches design patterns step by step, focusing on core concepts for beginner developers. 

You can check the official repo here: https://github.com/PacktPublishing/Game-Development-Patterns-with-Unity-2021-Second-Edition

Or buy a hard copy of the book here: https://www.amazon.com/Game-Development-Patterns-Unity-2021/dp/1800200811


# Design Patterns covered so far

- **Singleton** , for game manager. Related scripts: Singleton.cs, gameManager.cs

Singleton is used to be sure that there's only one instance of gameManager across the scenes, throughout the game session, in this case, it keeps track of playtime and other game metrics.

- **State Pattern** , for player character (state) control. Related scripts: IBikeState.cs, ClientState.cs, BikeController.cs, BikeStopState.cs, BikeStartState.cs, BikeTurnState.cs, Direction.cs

The state pattern is utilized to avoid spaghetti code on the character controller, where dozens of boolean values define the possibility of each state, such as isGameActive, isGrounded, isAttacking, isCrouched, isDamagedandFelldown, isPoisoned, superAttackReady, isReadyToAttack and much much more. State pattern simplifies things by encapsulating the expected finite behaviors of a character. For this game, its motorcycles states are STOP, START, TURN, CRASH. 

About this implementation, from the book, (page 60): 

"Here's a shortlist of potential limitations:
**Blending**: In its native form, the State pattern doesn't offer a solution to blend
animations. This limitation can become an issue when you want to achieve a
smooth visual transition between the animated states of a character.
**Transitioning**: In our implementation of the pattern, we can easily switch
between states, but we are not defining the relation between them. Therefore, if
we wish to define transitions between states based on relationships and
conditions, we will have to write a lot more code; for instance, if I want the idle
state to transition to the walk state, and then the walk state to transition to the
run state. And this happens automatically and smoothly, back and forth,
depending on a trigger or condition. This could be time-consuming to do in code."

Book also mentions these shortcomings can be overcome by implementing the state pattern onto Unity's animation trees. 

