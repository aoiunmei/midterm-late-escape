using UnityEngine;
using UnityEngine.SceneManagement;

public class BGMManager : MonoBehaviour
{
    public static BGMManager Instance;

    [Header("Audio")]
    [SerializeField] public AudioSource bgmSource;

    [Header("Scene Music")]
    [SerializeField] public AudioClip menuMusic;
    [SerializeField] public AudioClip gameMusic;
    [SerializeField] public AudioClip winMusic;
    [SerializeField] public AudioClip gameoverMusic;

    void Awake()
    {
        // Singleton protection
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        SwitchMusic(scene.name);
    }
    public void StopBGM()
    {
        bgmSource.Stop();
    }
    public void SwitchMusic(string sceneName)
    {
        AudioClip newClip = null;

        switch (sceneName)
        {
            case "MainMenu":
                newClip = menuMusic;
                break;
            case "Game":
                newClip = gameMusic;
                break;
            case "Win":
                newClip = winMusic;
                break;
            case "GameOver":
                newClip = gameoverMusic;
                break;

        }

        if (newClip != null && bgmSource.clip != newClip)
        {
            bgmSource.clip = newClip;
            bgmSource.Play();
        }
    }
}