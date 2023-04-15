using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManagerSound : MonoBehaviour
{
    [SerializeField]
    private SoundType soundType;

    public void ToggleCC(bool value)
    {
        SoundManager.Instance.ChangeClosedCaptions(value, soundType);
    }

    public void ChangeVolume(float volume)
    {
        SoundManager.Instance.ChangeVolume(volume, soundType);
    }
}
