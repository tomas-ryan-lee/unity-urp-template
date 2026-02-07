using UnityEngine;

public class SFXManager : MonoBehaviour
{
    public static SFXManager Instance { get; private set; }

    [Header("Events Channels")]
    [SerializeField]
    private AudioEventChannel _SFXChannel;

    [Header("SFX Audio")]
    [SerializeField]
    private AudioSource _audioSource;
    public AudioClip buttonSfx;

    private void OnEnable()
    {
        if (_SFXChannel != null)
            _SFXChannel.OnEventRaised += PlaySFX;
    }

    private void OnDisable()
    {
        if (_SFXChannel != null)
            _SFXChannel.OnEventRaised -= PlaySFX;
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

    void PlaySFX(AudioClip clip)
    {
        if (clip == null)
            return;

        _audioSource.PlayOneShot(clip);
    }
}
