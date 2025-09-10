using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private Pipe m_PipePrefab;
    [SerializeField] private float m_PipeSpeed;

    private int m_Score;
    private bool m_GameOn;
    private int m_ActivePipes;

    private BestObjectPool<Pipe> m_PipePool;

    private void Awake()
    {   
        m_PipePool = new BestObjectPool<Pipe>(m_PipePrefab, Constants.NumOfPipes,Constants.NumOfPipes);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            m_GameOn = true;
        }

        if(!m_GameOn)
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
        Debug.Log("Score: " + m_Score);
    }

    public void HandleCrash()
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
}
