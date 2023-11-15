#speaker player
player: hello

#speaker npc
npc: good job finding that trash!
->repeatableChoices

===repeatableChoices===
#speaker player
+player: goodbye.
    ->goodBye
+player: why clean up the mountain?
    ->option1


    
===option1===
#speaker npc
npc: becuase
->repeatableChoices
===option2===
#speaker npc
npc: I am a fellow climber of the mountain
->repeatableChoices

===goodBye===
#speaker npc
npc: goodbye player
->END