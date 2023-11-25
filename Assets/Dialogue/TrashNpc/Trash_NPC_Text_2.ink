#speaker npc
Welcome back friend, do you have the trash I asked for?

->trashEnd1

===trashEnd1===
#speaker player 
#option Optimistic. ~Inquisitive. ~Sarcastic.

+Got it right here! I didn’t realize how dirty the mountain was until I explored and did trash collection for you. 
It’s a mess. 
I’m sorry that you’re responsible for cleaning it all up but I hope I was able to help!
->OE1
+Three pieces, all accounted for. 
Happy to help. 
So what is it that you can offer me to help reach the summit?
->OE2
+Yeah, you’re welcome by the way. 
This was a pain in the butt so the reward better be worth it.
->OE3

===OE1===
#speaker npc
Thank you little panda. 
In another life and another time, maybe we could have been good friends. 
But for now, we both have our purposes on this mountain. 
And right now, mine is to help you with yours. 
Your body won’t be able to make it past a certain point on the mountain, but your spirit will. 
I can grant you the ability to have your spirit move from one body to the next. 
You’ll lose your memory, but not your purpose. 
If reaching the summit is really that important to you, 
then this is what I can offer you.
->trashEnd2

===OE2===
#speaker npc
You work fast little panda. 
Thank you for your help. 
And of course, I haven’t forgotten about your reward. 
Your body won’t be able to make it past a certain point on the mountain, but your spirit will. 
I can grant you the ability to have your spirit move from one body to the next. 
You’ll lose your memory, but not your purpose. 
If reaching the summit is really that important to you, 
then this is what I can offer you.
->trashEnd2

===OE3===
#speaker npc
The reward is what it is, its worth is entirely dependent on you. 
Your body won’t be able to make it past a certain point on the mountain, but your spirit will. 
I can grant you the ability to have your spirit move from one body to the next. 
You’ll lose your memory, but not your purpose. 
If reaching the summit is really that important to you, 
then this is what I can offer you.
->trashEnd2

===trashEnd2===
#speaker player
#option Optimistic. ~Inquisitive. ~Sarcastic.

+Well, losing my body and my memories is certainly not how I wanted to reach the top, 
but if it’s what I have to do then it’s what must be done. 
I’ll accept your help spirit
->IE1
+Nothing good comes without sacrifice. 
I accept the conditions, and your help. 
I have to reach the top, no matter the cost
->IE1
+Are you serious??? 
I have to die to reach the summit??? 
What a joke. 
It’s not how I saw this playing out, but it’s what must be done
I don’t like it, but I’ll do it. 
->IE1

===IE1===
#speaker npc
Very well. Stay still for a moment
#wait 5
There, your spirit should now be able to ascend the mountain. 
Thank you again for your help, little panda. 
I certainly won’t forget it, nor will the mountain. 
I hope your spirit finds what it’s looking for on Everest’s summit. 
Good luck. 
->END


