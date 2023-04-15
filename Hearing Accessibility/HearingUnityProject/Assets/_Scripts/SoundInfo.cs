using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SoundInfo
{
    //The string that will show up to the user as a closed caption
    public string closedCaption;

    //The clip that will correspond to the clip being sent to Sound Manager
    public AudioClip audioClip;

    //The volume that the clip should play at 100% volume
    public float initialVolume;

    //The type of sound it is
    public SoundType musicType;

    //Whether or not the sound is played as music
    public bool isMusic;
}


