using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private Pipe m_PipePrefab;
    [SerializeField] private float m_PipeSpeed;
    
    private List<int> m_LeaderBoard;
    private int m_Score;

    public GameState m_GameState { get; private set; } = GameState.NotStarted;

    private int m_ActivePipes;

    private BestObjectPool<Pipe> m_PipePool;

    private void Awake()
    {   
        m_LeaderBoard = new List<int>(Constants.LeaderBoardSize);
        for(int i = 0; i < m_LeaderBoard.Capacity; i++)
        {
            m_LeaderBoard.Add(0);
        }
        
        m_PipePool = new BestObjectPool<Pipe>(m_PipePrefab, Constants.NumOfPipes,Constants.NumOfPipes);
        m_Score = 0;
    }

    private void Update()
    {
        if(m_GameState != GameState.InProgress)
        {
            return;
        }

        if (m_ActivePipes == 0)
        {
            m_ActivePipes++;
            SpawnPipe();
        }
    }

    public void RemoveOffscreenPipes(Pipe pipe)
    {
        pipe.Deactivate();
        m_PipePool.ReleaseObject(pipe);
    }

    public void SpawnPipe()
    {
        var newPipe = m_PipePool.GetObject();
        newPipe.transform.position = new Vector3(Constants.ScreenEdgeX, Random.Range(-1, 3), 0);
        newPipe.Activate(m_PipeSpeed);
    }

    public void UpdateScore()
    {
        m_Score++;
        CanvasManager.Instance.UpdateScore(m_Score);
    }

    public void HandleCrash()
    {
        m_GameState = GameState.GameOver;
        stopPipes();
        PlayerController.Instance.DeactivateController();
        updateLeaderBoard();
        CanvasManager.Instance.ShowMenuScreen(m_Score, m_LeaderBoard);
    }

    private void updateLeaderBoard()
    {
        var newLeaderboard = new List<int>(m_LeaderBoard.Capacity + 1);
        foreach(var score in m_LeaderBoard)
        {
            newLeaderboard.Add(score);
        }
        
        newLeaderboard.Add(m_Score);
        newLeaderboard.Sort((a, b) => b.CompareTo(a));
        
        for(int i = 0; i < m_LeaderBoard.Capacity; i++)
        {
            m_LeaderBoard[i] = newLeaderboard[i];
        }
    }

    private void stopPipes()
    {
        var activePipes = FindObjectsByType<Pipe>(FindObjectsSortMode.None);
        foreach (var pipe in activePipes)
        {
            if (pipe.gameObject.activeInHierarchy)
            {
                pipe.Deactivate();
            }
        }
    }

    public void OnStartGameClicked()
    {
        m_Score = 0;
        m_GameState = GameState.InProgress;
        removeRemainingPipes();
        m_ActivePipes = 0;
    }

    private void removeRemainingPipes()
    {
        var activePipes = FindObjectsByType<Pipe>(FindObjectsSortMode.None);
        foreach (var pipe in activePipes)
        {
            if (pipe.gameObject.activeInHierarchy)
            {
                m_PipePool.ReleaseObject(pipe);
            }
        }
    }
}
