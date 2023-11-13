#speaker player
player: hello

#speaker npc
npc: hello
->repeatableChoices

===repeatableChoices===
#speaker player
+player: where am I
    ->option1
#speaker player
+player: who are you?
    ->option2
#speaker player
+player: goodBye
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


