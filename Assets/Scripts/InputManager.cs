using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance { get; private set; }

    [SerializeField]
    private KeyCode _pauseKey = KeyCode.Escape;

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
        {
            EventManager.OnGamePauseEvent();
        }
    }
}
