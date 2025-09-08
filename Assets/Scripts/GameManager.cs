using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private Pipe m_PipePrefab;
    [SerializeField] private float m_PipeSpeed;

    private readonly int NUM_OF_PIPES = 1;
    private readonly float PIPE_SPAWN_X_POSITION_TRIGGER = -3.5f;
    private readonly float SCREEN_EDGE_X_POSITION = 3.5f;
    private bool m_GameOn;
    private int m_ActivePipes;
    private int m_MostRecentPipeIndex;
    private List<Pipe> m_Pipes;

    private BestObjectPool<Pipe> m_PipePool;

    private void Awake()
    {   
        m_PipePool = new BestObjectPool<Pipe>(m_PipePrefab, NUM_OF_PIPES,NUM_OF_PIPES);
        m_Pipes = new List<Pipe>(NUM_OF_PIPES);
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

        if (m_Pipes.Count == 0 || m_Pipes[m_MostRecentPipeIndex].transform.position.x <= PIPE_SPAWN_X_POSITION_TRIGGER)
        {
             spawnPipe();
        }

        movePipes();
        removeOffscreenPipes();
    }

    private void removeOffscreenPipes()
    {
        foreach(var pipe in m_Pipes)
        {
            if(pipe.transform.position.x <= -SCREEN_EDGE_X_POSITION)
            {
                m_PipePool.ReleaseObject(pipe);
            }
        }
    }

    private void movePipes()
    {
        foreach(var pipe in m_Pipes)
        {
            var pipePosition = pipe.transform.position;
            pipePosition += Vector3.left * Time.deltaTime * m_PipeSpeed;
            pipe.transform.position = pipePosition;
        }
    }

    private void spawnPipe()
    {
        var newPipe = m_PipePool.GetObject();
        newPipe.transform.position = new Vector3(SCREEN_EDGE_X_POSITION, Random.Range(-1, 3), 0);
        if(m_Pipes.Count < NUM_OF_PIPES)
        {
            m_Pipes.Add(newPipe);
            m_MostRecentPipeIndex = m_Pipes.Count - 1;
            return;
        }
        
        m_MostRecentPipeIndex = (m_MostRecentPipeIndex + 1) % NUM_OF_PIPES;
        m_Pipes[m_MostRecentPipeIndex] = newPipe;
        
        if(m_MostRecentPipeIndex >= m_Pipes.Count)
        {
            m_MostRecentPipeIndex = 0;
        }
    }
}
