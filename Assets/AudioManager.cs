using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public AudioSource audioSource;
    public bool isPaused = false;

    void Start()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        audioSource = GetComponent<AudioSource>();
        Play();
    }

    public void PlayPause()
    {
        if (audioSource.isPlaying && !isPaused)
        {
            audioSource.Pause();
            isPaused = true;
        }
        else
        {
            audioSource.UnPause();
            isPaused = false;
        }
    }

    public void Play()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
            isPaused = false;
        }
    }

    public void Pause()
    {
        if (audioSource.isPlaying && !isPaused)
        {
            audioSource.Pause();
            isPaused = true;
        }
    }
}
