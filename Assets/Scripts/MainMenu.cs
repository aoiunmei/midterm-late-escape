using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] public GameObject _startScreen;
    [SerializeField] public GameObject _howToPlay;

    public void Start()
    {
    }
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync(1);
    }

    public void StartScreen()
    {
        _startScreen.SetActive(true);
        _howToPlay.SetActive(false);
    }
    public void HowToPlay()
    {
        _startScreen.SetActive(false);
        _howToPlay.SetActive(true);
    }
}
