Save Bonnie! 












Ellyse Angus, Tyler Becker, Eric Goulet, Ethan Hohman, Joshua Robinson






















Game Overview 
Theme: 
Defend Bonnie and Blizzard from zombies on the MTU campus


Setting: 
MTU Campus
Going down the main stretch of campus, with the zombies coming from Walker and walking past iconic Tech buildings like Douglass Houghton Hall, Fisher Hall, Rekhi Hall, the Van Pelt and Opie Library, the Electrical Energy Resources Center, and ending at the Blizzard Statue and the Mechanical Engineering-Engineering Mechanics building, where Bonnie awaits.


Genre: 
Tower Defense


Core Gameplay Mechanics:  
When the user defeats zombies they are awarded with the in-game currency (Dining Dollars). These dining dollars are used to purchase and upgrade the various towers in the game. These towers are based around the majors of MTU and help to further protect the lose condition (Bonnie and Blizzard)


Targeted platforms:
PC exclusive


General Description: 
A zombie breakout has occurred! It's your job to organize students, faculty and staff at Michigan Tech to put forth a defensive force that will protect both Bonnie and Blizzard. A game of the tower defense genre, you will strategize and ensure that the students can hold off the zombies long enough for Bonnie and Blizzard to be evacuated safely.






Story (if applicable):
NMU has had an outbreak and the students there have turned into zombies. In their hunger for brains, they start heading towards MTU where they wish to turn Bonnie and Blizzard into zombies. The students at MTU take the skills they have been learning and apply them towards defending Blizzard and Bonnie. It is up to you, the player, to wisely use the skills of the students and manage your dining dollars to build up the defense and buy time for Bonnie and Blizzard to escape.


Gameplay:
Zombies will advance at wave intervals. Defeated zombies drop Dining Dollars that can be used to bribe students into cooperating with you. Keep zombies away from Bonnie, because unlike other tower defense games, you only have one chance! If even one slips by you, it's game over. This game is of the 2D format, with a top-down 3rd-person perspective. 


Development Time: 
1 semester / 14 weeks


Team Members and Roles:
Ellyse Angus- Art and programming
Tyler Becker - Programming
Eric Goulet - Programming and leader
Josh Robinson - Programming
Ethan Hohman - Art and programming


Game Specs 
What sets this project apart?:
This project is made by and for MTU students. It will include many different landmarks and culture references from around campus, and will provide a relatable and enjoyable experience for any and all Tech Students. The game does all of this while providing fun and recognizable gameplay similar to that of Bloons Tower Defense.


Rules of the Game:
You start with 200 Dining Dollars.
You have a total of 1 life.
You have to survive a total of 35 waves of increasing difficulty
Towers cost varying amounts, and all do different things. 


Interactions: 
Main menu, with game start and exit game options
Player places tower, tower hits zombie
Goals: Player upgrades towers, towers buff other towers


Core Gameplay Mechanics (in depth):
The zombies follow a set path from one side of the screen to the other side where Bonnie and Blizzard are located. As they travel down this path they come into range of the defenses that have been placed by the player. These towers will have their own stats and special abilities, with some dealing damage and some giving out passive effects to friends and enemies. This will be in the form of stat increases to friendly units (buffs) and stat decreases to opposing units (debuffs). As these zombies are killed they provide the player with more currency (Dining Dollars) which can then be spent to buy new ones. This process repeats in waves until the player either clears all 35 waves, or until the zombies reach Bonnie and Blizzard.


When towers attack zombies, they do so within a set range, performing hitscan attacks that immediately damage the enemy and remove a set amount of health. If a zombie reaches 0 health, they are “killed” and removed from the map. The towers that are only able attack one zombie at a time target the nearest zombie to the tower, while towers that perform damage in a certain area around them, or an Area-of-Effect attack, can hit multiple zombies at once.


Sound:  
Most of the sound will just be the background music and any sounds that towers would produce, or if they interact with the player. Zombie noises will also be made on a timer or possibly in reaction to a tower affecting them


Background Music 
It would be a simple track played on repeat that is quiet and just provides the atmosphere of a zombie invasion. Some eerie sounds every once in a while to add to the ambiance 


Gameplay Sounds 
Typical sounds for actions i.e. generic button sound when button is pressed, construction sound when towers are built, sound effect when zombie takes damage, etc.


User Interface:
Basic UI elements that can be created through Unity. (Button for shop, pause button, etc.). A main menu would also be used where a player can start and quit the game, as well as hopes of allowing saved games to be loaded back up if enough development time is allowed.


Technical Specs:
Really basic specs will be required. It will be a very light game, so most modern PCs will be able to run this with ease. 


Development Tools:
Unity will provide a way for the bulk of the work to be done in being our game engine. Photoshop or Illustrator may also be used to create assets and provide the look to our game.
Pixel Studio to design certain 8-bit style elements for the game.


Game Engine: 
Unity


Language: 
C#


Art:  
8-bit, created using Pixel Studio


Assets (Listed) 
2D  
○ Self-produced concept art and game visual assets
Sound  
○ Sound assets produced in part by team 9 assigned sound artist, along with some sound being taken from the HGD sound library
Code  
* A general layout for the perceived required script types.  
○ Most code will be written in Unity using C#
○ Visual Studio will be used as our IDE
General Timeline
Sprint 1
	Sprint 2
	Sprint 3 
	Future 
	Create the map for the game and rough UI
	Create the towers
	Add any debuff abilities to the towers
	Add more maps
	Create one Zombie and the path it walks
	Create the health for zombies
	Finish the UI and create the main menu
	Add more towers
	Create the grid map for the towers
	Allow the towers to be placed on the map
	Polish up the game with cleaner looks, sounds, and animations for the zombies and towers
	Add passive or active abilities
	

	Have the towers interact with/attack the zombies 
	

	Add different types of zombies
	

Sprint 1 
Description and Requirements: 
* Task 1 - Create the map for the game and the UI
   * Will just be a rough hand drawn sketch used as a placeholder for the final map. This will allow for the later tasks to be achieved as the path for the zombies can be started and the grid map finalized. The map would roughly be based off the path of walking from Walker to the MEEM. The UI would very basic to begin with in having to exit the game and placeholders for where available towers will be placed from
* Task 2 -  Add one zombie and create the path the zombies will walk
   * This will be the biggest task to be accomplished during the sprint. The goal is to add one zombie and then input the specifications required to have it walk along the path in the map on its own. The goal would be to be able to start the game and test with the one zombie of it walking the path without stopping or straying from the path.
* Task 3 -  Create the grid map for towers to be placed on
   * The towers for the game will be placed on a grid map, with one tower limited to each square. This will make it so players know where towers can be placed and help prevent collision between buildings. The goal would to have the square under the cursor be visible


Sprint 2 
Description and Requirements: 
* Task 1- Create the towers
   * This task would involve creating a rough look of the towers and inputting them into the UI that would in the future be dragged into the tilemap and be built 
* Task 2-Create health
   * We will create the health system for the zombies. Health will get depleted by the towers as they shoot the zombies




* Task 3- Allow the towers to be placed on the tile map
   * This task would make it so the UI could be interacted with in having a tower dragged from its square in the UI and placed on the tile map anywhere that it is allowed to be placed. A tower could be placed anywhere that is not the zombies walking path, and where a tower has not already been placed.
* Task 4 - Have the assets interact
   * We will develop the interactions between all units in the game, such as having the towers track and damage zombies, or the zombies attacking Bonnie and Blizzard if they are reached, or having the towers affect each other


Sprint 3 
Description and Requirements:
* Task 1 - Add any debuff abilities to the towers
   * At this point the towers would do basic damage, and so special abilities such as slowing down the zombies would now be added. Other abilities is temporary paralysis, poison and doing damage over time, and also building walls on the path
* Task 2 - Finish the UI and create the main menu
   * Add the final looks for the UI and add the main menu to allow the game to be more navigation friendly. Make sure all vital UI functionality is present and working as intended
* Task 3 - Polish 
   * Add cleaner looks, sounds, and animations for the zombies and towers
