using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public Transform sceneParent;

    public static GameState state = GameState.Stopped;

    public Cannon cannon;
    public Projectile projectile;

    public ScoreManager scoreManager;

    public CameraFollow followCamera;

    private void Awake()
    {
        Instance = this;
        state = GameState.Starting;
    }

    private void Start()
    {
        scoreManager = new ScoreManager();
        MenuManager.Instance.ShowMenu(Menu.Main);
        //TerrainGenerator.Instance.Generate();
    }

    private void Update()
    {
        DebugUI.Instance.text.text += "GameState: " + state.ToString() + "\n";
        DebugUI.Instance.text.text += "HighScore: " + scoreManager.highscore + "\n";
        MenuManager.Instance.highscoreTextUI.text = "HIGHSCORE: " + scoreManager.highscore;

        if (Input.GetButtonDown("Fire1")) {
            if (state == GameState.MainMenu) {
                cannon.NextState();
                state = GameState.LaunchProcess;
                MenuManager.Instance.ShowMenu(Menu.None);
            } else if (state == GameState.LaunchProcess) {
                cannon.NextState();
            } else if (state == GameState.EndOfRound) {
                ResetMap();
            }
        }
    }

    public void EndRound()
    {
        projectile.Stop();
        state = GameState.EndOfRound;
        MenuManager.Instance.ShowMenu(Menu.EndOfRound);
    }

    public void ResetMap()
    {
        cannon.Reset();
        projectile.Reset();
        followCamera.Reset();
        Reset();
    }

    public void Reset()
    {
        state = GameState.MainMenu;
        MenuManager.Instance.ShowMenu(Menu.Main);
    }

    public void setCameraTarget(GameObject go)
    {
        followCamera.target = go;
    }
}

public enum GameState
{
    Stopped,
    Starting,
    MainMenu,
    Pivoting,
    Flying,
    EndOfRound,
    LaunchProcess
}