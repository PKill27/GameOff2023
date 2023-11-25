#speaker npc 
Everywhere! It’s still EVERYWHERE!!!! 
Fifteen years I’ve been cleaning the trash out of his pit 
and no matter what I do it keeps coming back!
Oh
A red panda
You’re a rare sight on this mountain nowadays. 
Here, 
I usually don’t give food to the animals that wander through this part of Everest, 
but for something as endangered as you, 
I’ll make an exception.

->trashChoice1 
 
===trashChoice1===
#speaker player 
#option Optimistic. ~Inquisitive. ~Sarcarcatic. 
+Thank you so much! I was starving, I didn’t know if I was going to make it much longer
    ->O1
+I can’t tell if this is a pity hand out or if you’re just trying to be nice but I’m certainly not going to turn down a handout. 
    ->I1
+Thanks sucker. Now why are you whining?
    ->S1

===O1===
#speaker npc
Of course, friend. 
The last thing I want to have happen is to watch another species of the mountain go extinct. 
That’s why I’m still here, picking up trash. 
I don’t think my spirit will be allowed to leave this place until I completely clean Everest. 
But I’ve been here fifteen years, and I don’t feel like I’ve even scratched the surface.
->trashChoice2

===I1===
#speaker npc
It’s not pity, it’s out of perseverance. 
Your species is dying. 
My spirit may be stuck here to clean the trash off the mountain, 
but my purpose is to preserve the ecosystem of this mountain. 
And that includes you little panda. 
->trashChoice2

===S1===
#speaker npc
I’m going to pretend you didn’t just insult me for giving you food when you were starving. 
You spend fifteen years cleaning a mountain so animals like you can continue to thrive and this is what I’m rewarded with.  
Ascension better be worth this trouble. 
->trashChoice2

===trashChoice2===
#speaker player 
#option Optimistic. ~Inquisitive. ~Sarcarcatic. 
+I’m sorry to hear that you’ve been stuck for so long. 
If there’s anything I can do to help before I continue to the mountain's summit
then I’d love to do what I can.
    ->O2
+Well, thank you then. True kindness is rare on this mountain, 
and I won’t forget it. 
But for now, 
I have to continue to the summit. 
    ->I2
+Sounds like a problem for you, not for me. 
Thanks for the food but I’m gonna be on my way now. 
Still have a long way to go until I reach the summit. 
    ->S2

===O2===
#speaker npc
Your thanks are appreciated. 
Normally I’d be happy to do it without anything in return 
but I’m simply not able to clean up this mountain on my own. 
If you could collect some trash and bring it to me then I would be most appreciative. 
Three pieces would be more than enough. 
I may even be able to help you summit the mountain if that’s something you wish to do.
->trashChoice3

===I2===
#speaker npc
Hold on a second small friend, 
you're trying to summit the mountain? It’s extremely dangerous 
and I’m not even sure if you’re kind enough to make it that far without dying due to the lack of oxygen. 
However, I'm not one to hinder one’s ambitions. 
If that's what you wish to do, then I won’t stop you. 
However, I may be able to help, but this time, not for free. 
I can’t clean this mountain on my own, 
and the amount of trash that keeps piling up here only seems to grow, 
no matter how much of it I remove. 
If you can bring me three pieces of trash, 
then I’ll help you on your journey to the top.
->trashChoice3

===S2===
#speaker npc
You’re a snarky one, aren’t you? 
Wouldn’t know how to be thankful if your life depended on it. 
No matter, you’ll learn sooner or later that actions have consequences. 
But not today. 
Unfortunately, I need your help. 
I heard you saying you’re trying to reach the top of the mountain, right? 
I can’t clean this mountain on my own, and the amount of trash that keeps piling up here only seems to grow, 
no matter how much of it I remove. 
If you can bring me three pieces of trash, then I’ll help you on your journey to the top. 
I promise you, you won't make it much farther without what I have to offer.
->trashChoice3

===trashChoice3===
#speaker player 
#option Optimistic. ~Inquisitive. ~Sarcarcatic. 
+Of course! It’s only fair I return the favor. 
I’ll be back once I’ve collected the three pieces of trash you’ve asked for. 
    ->END
+I told myself I wouldn’t stop until I’ve reached the top, 
but you’ve been kind to me so it’s only fair I be kind to you. 
Plus I am certainly not going to turn down help in reaching the summit. 
    ->END
+Umm, no? 
Well that’s what I'd like to say. 
But you seem like a genuine but gullible spirit so I’m sure I will actually need your help. 
I’ll find your trash for you, but the reward better not be a waste of my time.
    ->END



