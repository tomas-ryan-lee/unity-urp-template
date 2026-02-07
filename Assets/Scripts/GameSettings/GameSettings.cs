using UnityEngine;

[CreateAssetMenu(fileName = "GameSettings", menuName = "Template/Game Settings")]
public class GameSettings : ScriptableObject
{
    [Header("Performance")]
    public int targetFrameRate = 60;
    public bool vSync = false;

    [Header("Audio")]
    [Range(0f, 1f)]
    public float masterVolume = 1f;

    [Range(0f, 1f)]
    public float musicVolume = 0.8f;

    [Range(0f, 1f)]
    public float sfxVolume = 1f;

    [Header("Debug")]
    public bool enableDebugLogs = true;
    public bool godMode = false;

    [Header("Gameplay Defaults")]
    public int startingLives = 3;
}
