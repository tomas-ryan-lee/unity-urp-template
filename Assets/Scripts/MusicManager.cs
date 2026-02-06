using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager Instance { get; private set; }

    [SerializeField]
    private AudioSource _audioSource;

    [Header("Music Audio")]
    public AudioClip mainMenu;

    private void OnEnable()
    {
        EventManager.OnMusicPlayed += PlayMusic;
    }

    private void OnDisable()
    {
        EventManager.OnMusicPlayed -= PlayMusic;
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

        _audioSource ??= gameObject.AddComponent<AudioSource>();
    }

    void PlayMusic(AudioClip clip)
    {
        if (clip == null)
            return;

        _audioSource.clip = clip;
        _audioSource.Play();
    }
}
