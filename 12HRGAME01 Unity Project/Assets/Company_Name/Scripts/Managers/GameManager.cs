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

    private void Start()
    {
        Instance = this;
        state = GameState.Starting;
        scoreManager = new ScoreManager();
        //TerrainGenerator.Instance.Generate();
    }

    private void Update()
    {
        DebugUI.Instance.text.text += "GameState: " + state.ToString() + "\n";
        DebugUI.Instance.text.text += "HighScore: " + scoreManager.highscore + "\n";

        if (Input.GetButtonDown("Fire1")) {
            if (state == GameState.Ready) {
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
        state = GameState.Ready;
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
    Ready
}