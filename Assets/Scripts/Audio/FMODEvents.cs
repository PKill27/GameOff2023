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
    [field: SerializeField] public EventReference PikaFootSteps;

    [field: Header("Survival Meters")]
    [field: SerializeField] public EventReference Health;
    [field: SerializeField] public EventReference Hunger;
    [field: SerializeField] public EventReference Temp;

    [field: Header("Voices")]
    [field: SerializeField] public EventReference Nathalie;
    [field: SerializeField] public EventReference Ambition;
    [field: SerializeField] public EventReference Player;

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
