using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Make this scriptable object to add in all of the sound infos
[CreateAssetMenu(fileName ="so_SoundInfo", menuName = "ScriptableObjects/Sound/Info")]
public class SO_SoundInfo : ScriptableObject
{
    public List<SoundInfo> soundInfo;

    //Return the sound info that corresponds to the audioClip
    public SoundInfo GetSoundInfo(AudioClip audioClip)
    {
        return soundInfo.Find(x => x.audioClip == audioClip);
    }
}


