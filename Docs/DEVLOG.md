# Devlog #

A record of the development sessions taking the classic Unity [Roll a Ball](https://learn.unity.com/project/roll-a-ball) tutorial to a new level with Unity Gaming Services. 

## Todo
- [x] Analytics
- [ ] Cloud Save for player progress saving
- [ ] Game Overrides for levels
- [ ] Validate class structure
- [ ] Add to Google Play Store
- [ ] Add to Apple Store
- [ ] Add Ads
- [ ] Authentication
- [ ] Gyroscopic ball control
- [ ] Virtual Joystick ball control
- [ ] Gamepad ball control
- [ ] Moving walls
- [ ] critters
- [ ] pinball style bumpers, flippers, light sequences

## 4 May
The force was strong today, so I re-ordered the DevLog, the most recent content is now at the top.

I've also been looking at scriptable objects for the level editor. They are serializable so it should be possible to run with a single scene and load serialized level data at runtime from local resources, CCD and perhaps use them with UserGeneratedContent and have players share their levels (or at least publish them to the cloud)

**Resources:**  
* [Unite 2017 - Game Architecture with Scriptable Objects](https://www.youtube.com/watch?v=raQ3iHhE_Kk) with Ryan Hipple of Schell Games. Also goes further with great examples of using Scriptable Objects as variables and using decoupled event systems. Makes everything very MODULAR, EDITABLE, DEBUGGABLE [Sample Project](https://github.com/roboryantron/Unite2017)
* [Unite 2016 - Overthrowing the MonoBehaviour Tyranny in a Glorious Scriptable Object Revolution](https://www.youtube.com/watch?v=6vmRwLYWNRo) with Richard Fine. Contains an example of level loading and serialization.
* [Code Monkey](https://www.youtube.com/watch?v=7jxS8HIny3Q) talks about Scriptable Objects in Inventory example
* [Brakeys](https://www.youtube.com/watch?v=aPXvoWVabPY) talks about Scriptable Objects in Battle Card example

So, we might have various scriptable objects that are static level construction components, others that are enemies, or interactibles.

A level might therfore contain a list of static, interactible, enemy and task objects. And the Level might itself be a scriptable objects that can be serialized. The Level Scriptable Object contains the data for a Level and the Level Game Object knows how to load and instantiate all its elements. Need to think about how to connect all this up with events to allow the level design / tasks etc to reside in level and keep the logic in the level game object very decoupled. 

> ***Mad idea*** not entirely related, but could Ryan Hipple's methodology used to drive analytics events (could the event schema be scriptable objects) recorded from a single Game Object and triggered by events wired up in Inspector (or visual script??) could be an intyeresting side project 


## 29 April
Having proved remote level loading with CCD and addressables, it has been parked on the ``ccd-levels`` branch for now so I can focus on some other services and mechanics. 

The next things I want to look at is :
- Built in level editor
- Some more mechanics (critters, flippers, warp tiles)
- Tasks and objectives
- User Generated content
- Then maybe back to CCD, but not for scene loading like before, perhaps for swithcing in and out the UGS store (or store pages) 

creating ```level-editor``` branch for this
## 12th April 
* Cleaned up some level loading stuff
* Added UGS Analytics and levelCompleted event.
* The next thing to try is to make the ball more lively, more like a pinblall or table tennis ball. Quicker to react to player inputs and potentially flippers and speed boosters. 
The currect settings on the player ball are:
  - Mass : 1 
  - Drag : 0 
  - Angular Drag : 0.05
  - Gravity : true
  - Kinematic : true
  - Interpolate : None
  - Collision Detection : Discrete

  - Player Controller : Speed = 10

  Adding a physics material to the player ball 
- Dynamic Friction : 0.2
- Static Friction : 0.6
- Bouncyness : 0.5
- Friction Combine : Average
- Bounce Combine : Maximum
And updated the Rigid Body settings on the player ball to 
  - Mass : 50 
  - Drag : 0.05 
  - Angular Drag : 0.01
  - Gravity : true
  - Kinematic : true
  - Interpolate : None
  - Collision Detection : Discrete

    - Player Controller : Speed = 1000

Now the ball is much more frisky, can bounce and jump, but has enough mass to to go too high. A glass table top will likely be needed to stop the ball escaping though.
## 6th March
* Seperated configuration into a single file 
* Implement CCD to load levels, based on [YouTube tutorial by Dilmer Valecillos](https://www.youtube.com/watch?v=BXdwcSLWXK4)

    1. Started by installing the Addressables package with the Unity Package Manager
    2. Opened the Windows > Asset Management > Addressable Groups window docked it to the top of the UI
    3. Created a new Packed Assets Group called 'Stage_001' set it as the Default group and deleted the previously default group
    and dragged the two levels intoa new Group 4. Put the things you want to change after the game has been built into the group, e.g. Level scenes, they will be flagged as addressibles in the Inspector.
    4. Updated the Load Scene code to load the scene from the Addressable  ```Addressables.LoadSceneAsync(scene, UnityEngine.SceneManagement.LoadSceneMode.Additive, true);``` and removed the 2 scenes from the Build Settings panel.
    ![Addressable Levels](/Docs/Images/addressable_levels.png)
## 5th March
* Gaming Services Manager Added
Added as a staic instance and initialized with the 'development' environment for 
* Analytics added and initialized to capture basic events
## 3rd March
* Level progression logic added
* Pickup countdown text code updated
## 23 Feb 2022
* Create Game Manager Instance and Game State. 
Inspired by [Tarodev's excellent example](https://www.youtube.com/watch?v=4I0vonyqMi8)
* Seperate Game Manager from Levels
* Add Second Level
## 21 Feb 2022
Created a new empty 3D URP project in Unity 2021.2.9f1
Followed the Basic [Roll a Ball](https://learn.unity.com/project/roll-a-ball) tutorial to:
* Setup the game
* Move the player
* Move the camera
* Setup the play area
* Created collectables
* Detected collisions with colllectables
* Display score and text
* Build the game

















