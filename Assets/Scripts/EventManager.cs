using System;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static EventManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    #region GameManager
    public static event Action OnGameMenu;
    public static event Action OnGamePlay;
    public static event Action OnGamePause;
    public static event Action OnGameResume;
    public static event Action OnGameVictory;
    public static event Action OnGameOver;
    public static event Action OnGameQuit;

    public static void OnGameMenuEvent() => OnGameMenu.Invoke();

    public static void OnGamePlayEvent() => OnGamePlay.Invoke();

    public static void OnGamePauseEvent() => OnGamePause.Invoke();

    public static void OnGameResumeEvent() => OnGameResume.Invoke();

    public static void OnGameVictoryEvent() => OnGameVictory.Invoke();

    public static void OnGameOverEvent() => OnGameOver.Invoke();

    public static void OnGameQuitEvent() => OnGameQuit.Invoke();
    #endregion GameManager

    #region SFXManager
    public static event Action<AudioClip> OnSFXPlayed;

    public static void OnSFXPlayedEvent(AudioClip clip) => OnSFXPlayed.Invoke(clip);
    #endregion SFXManager

    #region MusicManager
    public static event Action<AudioClip> OnMusicPlayed;

    public static void OnMusicPlayedEvent(AudioClip clip) => OnMusicPlayed.Invoke(clip);
    #endregion MusicManager
}
