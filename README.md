# cozyhome-actor
 A standalone repository for the Cozy Actor Controller.
![Logo](https://user-images.githubusercontent.com/70460173/114629508-b586e780-9c86-11eb-84e0-d318de938c9f.png)

Installation Guide:

1. Either create or open up your own Unity project. 

2. Download the cozy-actor-controller repository and unzip it into a temporary folder.

3. Drag the "ActorScripts" folder into your currently existing Unity workspace.

Actor Scripting Guide:

To simply get your actor moving, do the following:

1. Attach the corresponding actor script type to your character object (Box, Capsule, Sphere)
(You'll notice that your Actor script
depends on a Collider component).

Feel free to change how the actor scripts are initialized. They are designed like this out of the box for easy
extension.

2. Assign the applicable properties to your character object after attaching the script.

If you're simply replacing this with Unity's default Character Controller, do the following:

1. Replace your Character Controller's Move() func with ActorHeader.Move() passing in the required parameters.
2. Implement the ActorHeader.IActorReceiver interface and its callbacks.
3. Find the method that you are running CharacterController.Move() (this is usually your FixedUpdate() method) and do the following:

Before the move call, you'll need to set: 
1. The Actor's Velocity to a given Vector 
2. The Actor's Orientation to a given Quaternion 
3. The Actor's Position to a given Vector 

If you're representing your character with Unity's default Transform component like the Character Controller does, simply refer to the following boilerplate: 

/* BEGINNING OF YOUR SCRIPT'S UPDATE METHOD */

actor.SetVelocity(/* your velocity goes here */);
actor.SetPosition(transform.position); 
actor.SetOrientation(transform.rotation); 

/* Your actor's move call should go AFTER your initial assignment */ 
ActorHeader.Move(receiver, actor, Time.fixedDeltaTime); 

/* After your actor's movement has been executed, you'll want to update the character's transform values accordingly */ 

transform.SetPositionAndRotation(actor._position, actor._orientation); 

/* ENDING OF YOUR SCRIPT'S UPDATE METHOD */

However, if you're starting from scratch you'll need to follow these instructions:

3. Create or use an already existing C# script that implements the ActorHeader.IActorReceiver interface. This is where your actor
will relay any callbacks throughout your movement executions (it is required in order to call your move func).

4. We'll be using FixedUpdate() for our movement as its the preferred choice when handling physics calculations.

Before your move call, you'll need to set: 
1. The Actor's Velocity to a given Vector
2. The Actor's Orientation to a given Quaternion
3. The Actor's Position to a given Vector

If you're representing your character with Unity's default Transform component like the Character Controller does, simply refer to the following boilerplate:

/* BEGINNING OF YOUR SCRIPT'S UPDATE METHOD */

actor.SetVelocity(/* your velocity goes here */);
actor.SetPosition(transform.position);
actor.SetOrientation(transform.rotation);

/* Your actor's move call should go AFTER your initial assignment */
ActorHeader.Move(receiver, actor, Time.fixedDeltaTime);

/* After your actor's movement has been executed, you'll want to update the character's transform values accordingly */
transform.SetPositionAndRotation(actor._position, actor._orientation);

/* ENDING OF YOUR SCRIPT'S UPDATE METHOD */

With this established, you'll be able to start writing out your own Character Controller within minutes. Happy coding :)
