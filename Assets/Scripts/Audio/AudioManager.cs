using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    private Bus masterBus;
    private Bus musicBus;
    private Bus ambienceBus;
    private Bus sfxBus;

    public float masterVolume = 1;
    [Range(0, 1)]
    public float musicVolume = 1;
    [Range(0, 1)]
    public float ambienceVolume = 1;
    [Range(0, 1)]
    public float SFXVolume = 1;


    private List<EventInstance> eventInstances;
    private List<StudioEventEmitter> eventEmitters;

    //private EventInstance ambienceEventInstance;
    private EventInstance musicEventInstance;
    private EventInstance dialogueEventInstance;
    private EventInstance walkingInstance;
    private EventInstance walkingInstance2;
    private EventInstance pause;
    private EventInstance cave;
    private EventInstance wind;
    private EventInstance cavewind;
    private int instanceWalingNumber = 0;

    public static AudioManager instance { get; private set; }

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Found more than one Audio Manager in the scene.");
        }
        instance = this;
        eventInstances = new List<EventInstance>();
        eventEmitters = new List<StudioEventEmitter>();

        masterBus = RuntimeManager.GetBus("bus:/");
        musicBus = RuntimeManager.GetBus("bus:/Music");
        sfxBus = RuntimeManager.GetBus("bus:/SFX");

        DontDestroyOnLoad(gameObject);
        //ambienceBus = RuntimeManager.GetBus("bus:/Ambience");
        //
    }

    private void Start()
    {
        
        //InitializeMusic(FMODEvents.instance.Music);
    }
    private void Update()
    {
        masterBus.setVolume(masterVolume);
        musicBus.setVolume(musicVolume);
        sfxBus.setVolume(SFXVolume);
    }
    public void SetParamTemp(float paramValue)
    {
        wind.setParameterByName("Intensity", paramValue);
    }

    public void InitializeMusic(EventReference musicEventReference)
    {
        print("music playing");
        musicEventInstance = CreateInstance(musicEventReference);
        eventInstances.Add(musicEventInstance);
        musicEventInstance.start();
    }
    public void InitializeDialogue(EventReference dialogueEventReference)
    {
        dialogueEventInstance = CreateInstance(dialogueEventReference);
        eventInstances.Add(dialogueEventInstance);
        dialogueEventInstance.start();
    }
    public void InitializePauseCave(bool isCave)
    {
        pause = CreateInstance(FMODEvents.instance.Paused);
        eventInstances.Add(pause);
        if (isCave)
        {
            cavewind = CreateInstance(FMODEvents.instance.CaveWind);
            eventInstances.Add(cavewind);
            cavewind.start();

            cave = CreateInstance(FMODEvents.instance.Cave);
            eventInstances.Add(cave);
            cave.start(); 
            cave.setParameterByName("In Cave", 1.0f);
        }
        else
        {
            wind = CreateInstance(FMODEvents.instance.Temp);
            eventInstances.Add(wind);
            wind.start();
        }
    }
    public void FadeOut()
    {
        wind.setParameterByName("Apply Fade Out", 1);
        musicEventInstance.setParameterByName("Apply Fade Out", 1);
        cavewind.setParameterByName("Apply Fade Out", 1);
    }
    public void PausedGame()
    {
        pause.start();
    }
    public void UnPausedGame()
    {
        pause.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
    }
    public void InitializeFootsteps(EventReference footstepsEventReference)
    {
        walkingInstance = CreateInstance(footstepsEventReference);
        eventInstances.Add(walkingInstance);
        walkingInstance2 = CreateInstance(footstepsEventReference);
        eventInstances.Add(walkingInstance2);
    }
    public void StopDialogue()
    {
        dialogueEventInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
    }
    public EventInstance CreateInstance(EventReference eventReference)
    {
        EventInstance eventInstance = RuntimeManager.CreateInstance(eventReference);
        eventInstances.Add(eventInstance);
        return eventInstance;
    }
    public void SetParam(string paramName, float paramValue)
    {
        musicEventInstance.setParameterByName(paramName, paramValue);
    }
    public void SetParamWalking(float paramValue)
    {
        walkingInstance.setParameterByName("Material", paramValue);
        walkingInstance2.setParameterByName("Material", paramValue);
    }
    public void PlayOneShotFootstep(Vector3 worldPos)
    {  
        RuntimeManager.PlayOneShot(FMODEvents.instance.PikaFootSteps[Player.instance.currentFootsteps], worldPos);

        // RuntimeManager.PlayOneShot(sound, worldPos);
    }
    public void PlayOneShot(EventReference sound, Vector3 worldPos)
    {
        RuntimeManager.PlayOneShot(sound, worldPos);
    }


    public void CleanUp()
    {
        print("cleaning up");
        // stop and release any created instances
       foreach (EventInstance eventInstance in eventInstances)
       {
            eventInstance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
            eventInstance.release();
        }
        // stop all of the event emitters, because if we don't they may hang around in other scenes
        foreach (StudioEventEmitter emitter in eventEmitters)
        {
            emitter.Stop();
        }
      
    }
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        print("clean up");
        CleanUp();
    }

    private void OnDestroy()
    {
        CleanUp();
    }
}
