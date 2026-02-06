using UnityEngine;

public class SFXManager : MonoBehaviour
{
    public static SFXManager Instance { get; private set; }

    [SerializeField]
    private AudioSource _audioSource;

    [Header("SFX Audio")]
    public AudioClip buttonSfx;

    private void OnEnable()
    {
        EventManager.OnSFXPlayed += PlaySFX;
    }

    private void OnDisable()
    {
        EventManager.OnSFXPlayed -= PlaySFX;
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
