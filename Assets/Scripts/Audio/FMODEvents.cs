using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class FMODEvents : MonoBehaviour
{
    

    [field: Header("Music")]
    [field: SerializeField] public EventReference MusicMenu;
    [field: SerializeField] public EventReference Music1;
    [field: SerializeField] public EventReference Music2;
    [field: SerializeField] public EventReference Music3;
    
    [field: Header("Player SFX")]
    [field: SerializeField] public EventReference RedPandaFootSteps;
    [field: SerializeField] public EventReference LeopardFootSteps;
    [field: SerializeField] public EventReference[] PikaFootSteps;
   
    [field: SerializeField] public EventReference Eat;
    [field: SerializeField] public EventReference Jump;
    [field: SerializeField] public EventReference FallDmg;

    [field: Header("Survival Meters")]
    [field: SerializeField] public EventReference Health;
    [field: SerializeField] public EventReference Hunger;
    [field: SerializeField] public EventReference Temp;
    [field: SerializeField] public EventReference CaveWind;

    [field: Header("Voices")]
    [field: SerializeField] public EventReference Nathalie;
    [field: SerializeField] public EventReference Ambition;
    [field: SerializeField] public EventReference Player;

    [field: Header("autenuated")]
    [field: SerializeField] public EventReference Fire;
    [field: SerializeField] public EventReference Rolling;

    [field: Header("UI")]
    [field: SerializeField] public EventReference Back;
    [field: SerializeField] public EventReference Highlighted;
    [field: SerializeField] public EventReference Select;
    [field: SerializeField] public EventReference TextBoxPopUp;
    [field: SerializeField] public EventReference TextBoxPopDisapear;

    [field: Header("misc")]
    [field: SerializeField] public EventReference Paused;
    [field: SerializeField] public EventReference Cave;

    public static FMODEvents instance { get; private set; }

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Found more than one FMOD Events instance in the scene.");
        }
        instance = this;
    }
}
