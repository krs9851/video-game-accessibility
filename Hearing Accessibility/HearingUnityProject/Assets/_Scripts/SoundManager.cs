using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SoundManager : MonoBehaviour
{
    //These fields must be populated before running the script
    [SerializeField]
    private SO_SoundInfo so_SoundInfo;
    //This is the audio source for all music
    [SerializeField]
    private AudioSource audioSource;
    //These are the closed captions text fields
    [SerializeField]
    private TextMeshProUGUI[] closedCaptions;

    //Dictionary for whether closed captions are on or off for different options
    private Dictionary<SoundType, bool> closedCaptionsOn;

    //Dictionary for all volumes the user chooses
    private Dictionary<SoundType, float> volumeChosen;

    private List<string>[] closedCaptionStrings;

    //Replace with your own Singleton method
    public static SoundManager Instance { get; private set; }

    private void Awake()
    {
        //Replace with your own Singleton method
        Instance = this;
         
        //Keep this code. It sets up the dictionaries
        closedCaptionsOn = new Dictionary<SoundType, bool>();
        volumeChosen = new Dictionary<SoundType, float>();
        foreach (SoundType i in Enum.GetValues(typeof(SoundType)))
        {
            closedCaptionsOn[i] = true;
            volumeChosen[i] = 1;
        }

        //Keep this code. It sets up the list of all closed captions
        closedCaptionStrings = new List<string>[(int)SoundType.count];

        for(int i = 0; i < (int)SoundType.count; i++)
        {
            closedCaptionStrings[i] = new List<string>();
        }

        //Turn off all the closed captions initially
        foreach (TextMeshProUGUI text in closedCaptions)
        {
            text.gameObject.transform.parent.gameObject.SetActive(false);
        }
    }

    //Changes the dictionary values for closed captions
    public void ChangeClosedCaptions(bool value, SoundType soundType)
    {
        closedCaptionsOn[soundType] = value;
    }

    //Changes the dictionary values for volume
    public void ChangeVolume(float value, SoundType soundType)
    {
        volumeChosen[soundType] = value;
    }

    //Return the volume a clip should play at and create closed captions
    public float PlaySound(AudioClip audioClip)
    {
        SoundInfo soundInfo = so_SoundInfo.GetSoundInfo(audioClip);
        AddClosedCaption(soundInfo);
        return soundInfo.initialVolume * volumeChosen[SoundType.allSound] * volumeChosen[soundInfo.musicType];
    }

    //Play music and create closed captions
    public void PlayMusic(AudioClip audioClip)
    {
        SoundInfo soundInfo = so_SoundInfo.GetSoundInfo(audioClip);
        AddClosedCaption(soundInfo);
        audioSource.volume = soundInfo.initialVolume * volumeChosen[SoundType.allSound] * volumeChosen[soundInfo.musicType];
        audioSource.clip = audioClip;
        audioSource.Play();
    }

    //Start the coroutine to add closed captions, if those captions are enabled
    private void AddClosedCaption(SoundInfo soundInfo)
    {
        if (closedCaptionsOn[soundInfo.musicType])
        {
            StartCoroutine(AddClosedCaptionRoutine(soundInfo));
        }
    }

    //Add the closed captions, and then wait.
    //If it is music, the caption will appear for one second, otherwise it will last as long as the audio clip plus 0.5 seconds.
    private IEnumerator AddClosedCaptionRoutine(SoundInfo soundInfo)
    {
        closedCaptionStrings[(int)soundInfo.musicType].Add(soundInfo.closedCaption);
        ShowClosedCaptions(soundInfo);
        if(soundInfo.isMusic)
        {
            yield return new WaitForSeconds(1f);
        }
        else
        {
            yield return new WaitForSeconds(soundInfo.audioClip.length + 0.5f);
        }
        
        closedCaptionStrings[(int)soundInfo.musicType].Remove(soundInfo.closedCaption);
        ShowClosedCaptions(soundInfo);
    }

    //Show the closed captions.
    //If no closed captions exist, turn off the related closed caption gameobject
    private void ShowClosedCaptions(SoundInfo soundInfo)
    {
        closedCaptions[(int)soundInfo.musicType - 1].text = String.Join(", ", closedCaptionStrings[(int)soundInfo.musicType]);
        if(closedCaptionStrings[(int)soundInfo.musicType].Count == 0)
        {
            closedCaptions[(int)soundInfo.musicType - 1].gameObject.transform.parent.gameObject.SetActive(false);
        }
        else
        {
            closedCaptions[(int)soundInfo.musicType - 1].gameObject.transform.parent.gameObject.SetActive(false);
        }
    }
}

//Enum of all sound types
//Change this to reflect your sound types
public enum SoundType
{
    allSound = 0,
    critialSoundEffects = 1,
    ambientSound = 2,
    criticalMusic = 3,
    ambientMusic = 4,
    count = 5
}