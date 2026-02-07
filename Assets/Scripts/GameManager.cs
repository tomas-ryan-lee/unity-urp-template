using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public enum GameState
{
    GameMenu,
    GamePlay,
    GamePause,
    GameResume,
    GameVictory,
    GameOver,
}

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField]
    private GameState _state;

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
    private AudioEventChannel _musicChannel;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        var settings = GameSettingsProvider.Instance;
        Application.targetFrameRate = settings.targetFrameRate;
        QualitySettings.vSyncCount = settings.vSync ? 1 : 0;
    }

    private void OnEnable()
    {
        if (_gameMenuChannel != null)
            _gameMenuChannel.OnEventRaised += GameMenu;

        if (_gamePlayChannel != null)
            _gamePlayChannel.OnEventRaised += GamePlay;

        if (_gamePauseChannel != null)
            _gamePauseChannel.OnEventRaised += GamePause;

        if (_gameResumeChannel != null)
            _gameResumeChannel.OnEventRaised += GameResume;

        if (_gameVictoryChannel != null)
            _gameVictoryChannel.OnEventRaised += GameVictory;

        if (_gameOverChannel != null)
            _gameOverChannel.OnEventRaised += GameOver;

        if (_gameOverChannel != null)
            _gameQuitChannel.OnEventRaised += GameQuit;
    }

    private void OnDisable()
    {
        if (_gameMenuChannel != null)
            _gameMenuChannel.OnEventRaised -= GameMenu;

        if (_gamePlayChannel != null)
            _gamePlayChannel.OnEventRaised -= GamePlay;

        if (_gamePauseChannel != null)
            _gamePauseChannel.OnEventRaised -= GamePause;

        if (_gameResumeChannel != null)
            _gameResumeChannel.OnEventRaised -= GameResume;

        if (_gameVictoryChannel != null)
            _gameVictoryChannel.OnEventRaised -= GameVictory;

        if (_gameOverChannel != null)
            _gameOverChannel.OnEventRaised -= GameOver;
    }

    private void Start()
    {
        MenuManager.Instance.OnGameMenu();
    }

    #region GameState
    void GameMenu()
    {
        _state = GameState.GameMenu;
        _musicChannel?.RaiseEvent(MusicManager.Instance.mainMenu);
    }

    void GamePlay()
    {
        _state = GameState.GamePlay;
    }

    void GamePause()
    {
        if (
            _state != GameState.GamePlay
            && _state != GameState.GamePause
            && _state != GameState.GameResume
        )
            return;

        if (_state == GameState.GamePlay || _state == GameState.GameResume)
        {
            MenuManager.Instance.OnGamePause();
            _state = GameState.GamePause;
            return;
        }

        MenuManager.Instance.OnGameResume();
    }

    void GameResume()
    {
        _state = GameState.GameResume;
    }

    void GameVictory()
    {
        _state = GameState.GameVictory;
    }

    void GameOver()
    {
        _state = GameState.GameOver;
    }

    public void GameQuit()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
    #endregion GameState
}
