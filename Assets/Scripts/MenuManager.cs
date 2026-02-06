using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance { get; private set; }

    [Header("Ui Screens")]
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

    public void OnGameMenu(bool isSFXPlayed = false)
    {
        DisableAllScreen();
        _gameMenuScreen.enabled = true;

        if (isSFXPlayed)
            EventManager.OnSFXPlayedEvent(SFXManager.Instance.buttonSfx);

        EventManager.OnGameMenuEvent();
    }

    public void OnGamePlay()
    {
        DisableAllScreen();
        _gamePlayScreen.enabled = true;
        EventManager.OnSFXPlayedEvent(SFXManager.Instance.buttonSfx);

        EventManager.OnGamePlayEvent();
    }

    public void OnGamePause()
    {
        DisableAllScreen();
        _gamePauseScreen.enabled = true;
        EventManager.OnSFXPlayedEvent(SFXManager.Instance.buttonSfx);
    }

    public void OnGameResume()
    {
        DisableAllScreen();
        _gamePlayScreen.enabled = true;
        EventManager.OnSFXPlayedEvent(SFXManager.Instance.buttonSfx);

        EventManager.OnGameResumeEvent();
    }

    public void OnGameVictory()
    {
        DisableAllScreen();
        _gameVictoryScreen.enabled = true;

        EventManager.OnGameVictoryEvent();
    }

    public void OnGameOver()
    {
        DisableAllScreen();
        _gameOverScreen.enabled = true;

        EventManager.OnGameOverEvent();
    }

    public void OnGameQuit() => EventManager.OnGameQuitEvent();

    private void DisableAllScreen()
    {
        _gameMenuScreen.enabled = false;
        _gamePlayScreen.enabled = false;
        _gamePauseScreen.enabled = false;
        _gameVictoryScreen.enabled = false;
        _gameOverScreen.enabled = false;
    }
}
