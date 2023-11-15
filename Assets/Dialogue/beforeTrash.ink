#speaker player
player: hello

#speaker npc
npc: hello, go find me some trash!
->repeatableChoices

===repeatableChoices===
#speaker player
+player: ok
    ->goodBye
+player: no
    ->goodBye


    
===option1===
#speaker npc
npc: you are on mount everest
->repeatableChoices
===option2===
#speaker npc
npc: I am a fellow climber of the mountain
->repeatableChoices

===goodBye===
#speaker npc
npc: goodbye player
->END