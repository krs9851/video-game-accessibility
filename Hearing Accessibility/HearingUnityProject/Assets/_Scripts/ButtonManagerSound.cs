using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManagerSound : MonoBehaviour
{
    //The sound type that is being changed. Set in the editor
    [SerializeField]
    private SoundType soundType;

    //Change the closed captions for the sound type above
    public void ToggleCC(bool value)
    {
        SoundManager.Instance.ChangeClosedCaptions(value, soundType);
    }

    //Change the volume for the sound type above
    public void ChangeVolume(float volume)
    {
        SoundManager.Instance.ChangeVolume(volume, soundType);
    }
}
