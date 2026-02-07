using System;
using UnityEngine;

[CreateAssetMenu(fileName = "AudioEventChannel", menuName = "Template/AudioEventChannel")]
public class AudioEventChannel : ScriptableObject
{
    public event Action<AudioClip> OnEventRaised;

    public void RaiseEvent(AudioClip clip)
    {
        OnEventRaised?.Invoke(clip);
    }
}
