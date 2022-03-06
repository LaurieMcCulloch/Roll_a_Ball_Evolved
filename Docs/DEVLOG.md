# Devlog #

A record of the development sessions taking the classic Unity [Roll a Ball](https://learn.unity.com/project/roll-a-ball) tutorial to a new level with Unity Gaming Services. 

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

## 23 Feb 2022
* Create Game Manager Instance and Game State. 
Inspired by [Tarodev's excellent example](https://www.youtube.com/watch?v=4I0vonyqMi8)
* Seperate Game Manager from Levels
* Add Second Level

## 3rd March
* Level progression logic added
* Pickup countdown text code updated

## 5th March
* Gaming Services Manager Added
Added as a staic instance and initialized with the 'development' environment for 
* Analytics added and initialized to capture basic events

## 6th March
* Seperated configuration into a single file 
* Implement CCD to load levels, based on [YouTube tutorial by Dilmer Valecillos](https://www.youtube.com/watch?v=BXdwcSLWXK4)

    1. Started by installing the Addressables package with the Unity Package Manager
    2. Opened the Addressable Groups window and dragged the two levels intoa new Group called StarterLevel



## Todo
* Add to Google Play Store
* Gyroscopic ball control