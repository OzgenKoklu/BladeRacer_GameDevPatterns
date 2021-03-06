# Contents of this repo
This repo will include the example racing game from the book "Game Development Patterns with Unity 2021 - Second edition"

It is a complete tutorial that teaches design patterns step by step, focusing on core concepts for beginner developers. 

You can check the official repo here: https://github.com/PacktPublishing/Game-Development-Patterns-with-Unity-2021-Second-Edition

Or buy a hard copy of the book here: https://www.amazon.com/Game-Development-Patterns-Unity-2021/dp/1800200811


# Design Patterns and techniques covered so far

# **1) Singleton** 
- For game manager. Related scripts: Singleton.cs, gameManager.cs (Scene: Init)

Singleton is used to be sure that there's only one instance of gameManager across the scenes, throughout the game session, in this case, it keeps track of playtime and other game metrics.

**Benefits:** Globally Accesible, Control Concurrency - Drawbacks: Unit Testing, Laziness

# **2) State Pattern** 
- For player character (state) control. Related scripts: IBikeState.cs, ClientState.cs, BikeController.cs, BikeStopState.cs, BikeStartState.cs, BikeTurnState.cs, Direction.cs (Scene: test1)

The state pattern is utilized to avoid spaghetti code on the character controller, where dozens of boolean values define the possibility of each state, such as isGameActive, isGrounded, isAttacking, isCrouched, isDamagedandFelldown, isPoisoned, superAttackReady, isReadyToAttack and much much more. State pattern simplifies things by encapsulating the expected finite behaviors of a character. For this game, its motorcycles states are STOP, START, TURN, CRASH. 

About this implementation, from the book, (page 60): 

*"Here's a shortlist of potential limitations:
Blending: In its native form, the State pattern doesn't offer a solution to blend
animations. This limitation can become an issue when you want to achieve a
smooth visual transition between the animated states of a character.
Transitioning: In our implementation of the pattern, we can easily switch
between states, but we are not defining the relation between them. Therefore, if
we wish to define transitions between states based on relationships and
conditions, we will have to write a lot more code; for instance, if I want the idle
state to transition to the walk state, and then the walk state to transition to the
run state. And this happens automatically and smoothly, back and forth,
depending on a trigger or condition. This could be time-consuming to do in code."*

Book also mentions these shortcomings can be overcome by implementing the state pattern onto Unity's animation trees. 

**Benefits:** Encapsulation, Maintinence - Drawbacks: blending and transition of states

**Alternative solutions according to the book:** Blackboard/behaviour threes, FSM, Memento
# **3) Event Bus** 
- Publishers, subscribers and the event bus. Related Scripts: RaceEventType.cs, RaceEventBus.cs, CountdownTimer.cs, bikeController.cs, HUDController.cs (Scene: test1 2)

In the event bus method, there are gameObjects that are publishers and/or subscribers, publishers send messages to subscribers to trigger state changes. (using events, delegates, actions in c#) Similar to Observer method.  Event bus script takes the role as a middleman between publishers and subscribers.

From the book on observer vs event bus pattern: (page 67)

*"I would avoid using a globally accessible Event Bus like the one presented in this chapter to
manage events that don't have a "global scope." For instance, if I have a UI component in
the HUD that displays a damage alert when the player collides with an obstacle, it would
be inefficient to publish a collision event through the Event Bus as it's a localized
interaction between the bike and an object on the track. Instead, I would use something like
an Observer pattern because, in that scenario, I only need one UI component to observe a
specific change in the state of an object, in this case, the bike. As a rule of thumb, every time
you have to implement a system that uses events, go through the list of known patterns,
choose one suitable for your use case, but don't always fall back to the easiest one, which, in
my opinion, is the Event Bus."*

Racing game stages: Countdown, Race start, race finish - State Changers: Race Pause, Race quit, race stop - Components thata get effected from state changes: Hud, race timer, bike controller, input recorder

**Benefits:** Decoupling, Simplicity - Drawbacks: Performance, Global 

**Alternative solutions according to the book:** Observer, Event Queue, ScriptableObjects

# **4) Command Pattern** 
- For ghost replay systems(racing games), undo systems, macro (multiple button recording for shortcut purposes), automation (control automation). A scalable and modular way to record input data. Related Scripts: 

In a behavioral pattern, closest cousins are Memento, observer, and visitor. (related to how objects communicate with each other)
Class types in command pattern: Invoker; Object that knows how to execute a command and can also do the bookkeeping of executed commands. CommandBase; an abstract class to be inherited by the concreate command, is an execute method by itself. Receiver; Object that receives and executes the orders. ConcreteCommand; Client; 

**Benefits:** Decoupling, Sequencing - Drawbacks: Complexity.

