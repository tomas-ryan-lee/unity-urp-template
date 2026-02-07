using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance { get; private set; }

    [Header("Key Codes")]
    [SerializeField]
    private KeyCode _pauseKey = KeyCode.Escape;

    [Header("Events Channels")]
    [SerializeField]
    private VoidEventChannel _gamePauseChannel;

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

    private void Update()
    {
        OnPressPauseKey();
    }

    void OnPressPauseKey()
    {
        if (Input.GetKeyDown(_pauseKey))
            _gamePauseChannel?.RaiseEvent();
    }
}
