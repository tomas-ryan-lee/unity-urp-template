using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager Instance { get; private set; }

    [Header("Events Channels")]
    [SerializeField]
    private AudioEventChannel _musicChannel;

    [Header("Music Audio")]
    [SerializeField]
    private AudioSource _audioSource;
    public AudioClip mainMenu;

    private void OnEnable()
    {
        if (_musicChannel != null)
            _musicChannel.OnEventRaised += PlayMusic;
    }

    private void OnDisable()
    {
        if (_musicChannel != null)
            _musicChannel.OnEventRaised -= PlayMusic;
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
