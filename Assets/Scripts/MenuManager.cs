using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance { get; private set; }

    [Header("UI Screens")]
    [SerializeField]
    private Canvas _gameMenuScreen;

    [SerializeField]
    private Canvas _gamePlayScreen;

    [SerializeField]
    private Canvas _gamePauseScreen;

    [SerializeField]
    private Canvas _gameVictoryScreen;

    [SerializeField]
    private Canvas _gameOverScreen;

    [Header("Events Channels")]
    [SerializeField]
    private VoidEventChannel _gameMenuChannel;

    [SerializeField]
    private VoidEventChannel _gamePlayChannel;

    [SerializeField]
    private VoidEventChannel _gamePauseChannel;

    [SerializeField]
    private VoidEventChannel _gameResumeChannel;

    [SerializeField]
    private VoidEventChannel _gameVictoryChannel;

    [SerializeField]
    private VoidEventChannel _gameOverChannel;

    [SerializeField]
    private VoidEventChannel _gameQuitChannel;

    [SerializeField]
    private AudioEventChannel _SFXManager;

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

    public void OnGameMenu()
    {
        DisableAllScreen();
        _gameMenuScreen.enabled = true;
        _gameMenuChannel?.RaiseEvent();
    }

    public void OnGamePlay()
    {
        DisableAllScreen();
        _gamePlayScreen.enabled = true;
        _gamePlayChannel?.RaiseEvent();
        _SFXManager?.RaiseEvent(SFXManager.Instance.buttonSfx);
    }

    public void OnGamePause()
    {
        DisableAllScreen();
        _gamePauseScreen.enabled = true;
        _SFXManager?.RaiseEvent(SFXManager.Instance.buttonSfx);
    }

    public void OnGameResume()
    {
        DisableAllScreen();
        _gamePlayScreen.enabled = true;
        _gameResumeChannel?.RaiseEvent();
        _SFXManager?.RaiseEvent(SFXManager.Instance.buttonSfx);
    }

    public void OnGameVictory()
    {
        DisableAllScreen();
        _gameVictoryScreen.enabled = true;
        _gameVictoryChannel?.RaiseEvent();
    }

    public void OnGameOver()
    {
        DisableAllScreen();
        _gameOverScreen.enabled = true;
        _gameOverChannel?.RaiseEvent();
    }

    public void OnGameQuit() => _gameQuitChannel?.RaiseEvent();

    private void DisableAllScreen()
    {
        _gameMenuScreen.enabled = false;
        _gamePlayScreen.enabled = false;
        _gamePauseScreen.enabled = false;
        _gameVictoryScreen.enabled = false;
        _gameOverScreen.enabled = false;
    }
}
