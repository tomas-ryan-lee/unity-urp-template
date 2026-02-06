using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public enum GameState
{
    gameMenu,
    gamePlay,
    gamePause,
    gameResume,
    gameVictory,
    gameOver,
}

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private GameState _state;

    private void OnEnable()
    {
        EventManager.OnGameMenu += GameMenu;
        EventManager.OnGamePlay += GamePlay;
        EventManager.OnGamePause += GamePause;
        EventManager.OnGameResume += GameResume;
        EventManager.OnGameVictory += GameVictory;
        EventManager.OnGameOver += GameOver;
        EventManager.OnGameQuit += GameQuit;
    }

    private void OnDisable()
    {
        EventManager.OnGameMenu -= GameMenu;
        EventManager.OnGamePlay -= GamePlay;
        EventManager.OnGamePause -= GamePause;
        EventManager.OnGameResume -= GameResume;
        EventManager.OnGameVictory -= GameVictory;
        EventManager.OnGameOver -= GameOver;
        EventManager.OnGameQuit += GameQuit;
    }

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

    private void Start()
    {
        MenuManager.Instance.OnGameMenu();
    }

    #region GameState
    void GameMenu()
    {
        _state = GameState.gameMenu;
        EventManager.OnMusicPlayedEvent(MusicManager.Instance.mainMenu);
    }

    void GamePlay()
    {
        _state = GameState.gamePlay;
    }

    void GamePause()
    {
        if (
            _state != GameState.gamePlay
            && _state != GameState.gamePause
            && _state != GameState.gameResume
        )
            return;

        if (_state == GameState.gamePlay || _state == GameState.gameResume)
        {
            MenuManager.Instance.OnGamePause();
            _state = GameState.gamePause;
            return;
        }

        MenuManager.Instance.OnGameResume();
    }

    void GameResume()
    {
        _state = GameState.gameResume;
    }

    void GameVictory()
    {
        _state = GameState.gameVictory;
    }

    void GameOver()
    {
        _state = GameState.gameOver;
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
