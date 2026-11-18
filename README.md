
GED In-Lab Assignment 2
-----------------------
**Ashley Klahm 100963908**

**Title and brief description of 'gameplay loop'**

This game is called "24 Hour Love Story" and it was made for a Gavin GDW game second!
Its a 3D/2D visual novel where you find out that your parents have been kidnapped! and the only way to 
save them is too.. get a date?!! Funny short game used to experiment with Ink for scripting, very buggy and unoptimized.

I originally tried 2 other games first for this assignment but neither had any spikes in the profiler so I ended up on this one. 

**Before Implementing A Design Pattern:**
<img width="959" height="187" alt="Screenshot 2026-11-17 114524" src="https://github.com/user-attachments/assets/72531fef-2cbc-4d60-85e0-99191fba5ae3" />
<img width="955" height="272" alt="Screenshot 2026-11-17 114550" src="https://github.com/user-attachments/assets/454aed75-801c-4818-8631-249093d559f2" />
<img width="397" height="68" alt="Screenshot 2026-11-17 114621" src="https://github.com/user-attachments/assets/9d39414d-af80-40c7-947d-1fe4d6343252" />

These screenshots are from an initial run of the game, I noticed a spike where the CPU was exceeding the target frame rate and with the Deep Profile
option saw it was due to the update function in the dialogue manager. There was only things being checked in Update but I figured this would be a good place
to try implementing an Observer pattern as I've yet to do that. 

**After Implementation of the Observer pattern: **

<img width="959" height="355" alt="test2runprofilerwith" src="https://github.com/user-attachments/assets/03e99dde-61cf-41b7-bd46-b2c72ba48b9f" />

Now I will say I disabled my observer and still had a fairly similar graph as an end result so I don't think my design pattern effected the game as
much as it looks like it from the before and after. However I do think there is a good amount of margin for error when it comes to diagnosing an issue, esspecially in unity 
when you can close it, reopen the project and seemingly get a differed result in the profiler regardless of any changes. 

**Scripts for Observer: **

<img width="277" height="305" alt="Screenshot 2026-11-17 210750" src="https://github.com/user-attachments/assets/28e89b8b-7f07-4bbb-b504-b0a6ae33292a" />
<img width="251" height="116" alt="Screenshot 2026-11-17 210801" src="https://github.com/user-attachments/assets/a9d5da6a-d12b-46c7-a029-4e7efc7fe777" />
<img width="223" height="496" alt="Screenshot 2026-11-17 210823" src="https://github.com/user-attachments/assets/dea4cf24-b288-44b0-abac-a14814857284" />
<img width="194" height="44" alt="Screenshot 2026-11-17 211021" src="https://github.com/user-attachments/assets/525c1445-2c5f-440e-b335-afa905c352a1" />
<img width="197" height="143" alt="Screenshot 2026-11-17 212204" src="https://github.com/user-attachments/assets/07b6d291-39e6-4272-a326-0ce3e7950d35" />
<img width="262" height="140" alt="Screenshot 2026-11-17 211255" src="https://github.com/user-attachments/assets/e161ceca-a880-4520-a9a0-888876538abd" />

I cut up the dialogue manager to make it easier to read (the og script is very long) ^

**Reflection Questions:**
-----------------------
1. From the screenshots of the profiler in unity I noticed that the Dialogue Manager script, specifically the update function it was calling,
was impacting the performance to exceed the targeted frame rate. When playing I did notice
there was some lag from the main menu to the first scene where the scene manager is loaded in.

2. I implemented in the Observer Pattern. This pattern is used too lower the amount of checks per frame in update(). It is a very simple implementation;
when something is true the observer (dialogue manager in this case) alerts the subject (dialogue manager controller) which marks it as true and does what it needs to do,
in my case it than checks if the dialogue isn't playing or if there is an input of E to continue the dialogue.

3. Looking at my profiler results i would have to say maybe. I did the same things I did in the first test but I cant ensure I did everything the exact same. It couldve
been a weird error that occured rather then something actually needing to be fixed. In my couple runs I didn't get the spike again but comparing the rest of the graph they
are almost identical. I would say it may have ever so slightly improved performance but not substantially.

4. The profilling processed revealed to me where a lot of the the cpus memory is being used. The top of the thread being the most and it gradually decreasing, PlayerLoop, UpdateScene, Update.ScriptRunBehaviour are the top 3
 however these aren't just scripts I could modify they are samples from the applications main loop. I figured that finding and changing the diagoue managers update method was a lot easier and faster to do at the time as it gives me the specfic location
 of the issue/ where CPU memory is being taken and comparing it to the PlayerLoop it is only 0.51ms smaller meaning focusing on it was my easiest thing to change and also will likely have the same effect as if I modified things in relation to PlayerLoop.
















