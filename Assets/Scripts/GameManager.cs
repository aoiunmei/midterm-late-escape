using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Game Entities")]
    [SerializeField]
    private static GameManager _instance;

    [Header("Game Variables")]
    [SerializeField] public UIManager UIManager;
    //[SerializeField] public ScoreManager scoreManager;

    public enum GameState
    {
        IntroCutscene,
        LevelStart,
        LevelInProgress,
        LevelClear,
        GameOver,
        GameEnd
    }

    private GameState _currentState;
    private bool _isInputActive = true;

    public static GameManager GetInstance()
    {
        return _instance;
    }

    public void SetSingleton()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
        }

        _instance = this;
    }

    private void Awake()
    {
        SetSingleton();
    }
    private void Start()
    {
        if(_isInputActive){
            
        }
        ChangeState(GameState.IntroCutscene);
    }
    private void Update()
    {
    }
    public void MainMenu()
    {
        SceneManager.LoadSceneAsync(0);
    }
    public void Restart()
    {
        SceneManager.LoadSceneAsync(1);
    }
    public void WinScreen()
    {
        SceneManager.LoadSceneAsync(2);
    }
    public void GameOverScreen()
    {
        SceneManager.LoadSceneAsync(3);
    }
    public void ChangeState(GameState state){
        _currentState = state;
        switch (_currentState){
            case GameState.IntroCutscene:
                IntroCutscene();
                break;
            case GameState.LevelStart:
                LevelStart();
                break;
            case GameState.LevelInProgress:
                LevelInProgress();
                break;
            case GameState.GameOver:
                GameOver();
                break;
            case GameState.GameEnd:
                GameEnd();
                break;
            default:
                break;
        }
    }
    private void IntroCutscene(){
        Debug.Log("Intro cutscene began!");
        _isInputActive = false;
        ChangeState(GameState.LevelStart);
    }
    private void LevelStart(){
        _isInputActive = true;

        //level manager setup called here

        ChangeState(GameState.LevelInProgress);
    }
    private void LevelInProgress(){
        Debug.Log("Level is now in progress!");
    }

    private void LevelClear(){
        Debug.Log("Level has been cleared!");
    }
    private void GameOver() {
        Debug.Log("You have lost (the game)");
    }
    private void GameEnd() {
        Debug.Log("Game has ended");
    }
}
