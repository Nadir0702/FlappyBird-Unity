using UnityEngine;

public class Pipe : MonoBehaviour
{
    [SerializeField] private Rigidbody2D m_Rigidbody2D;

    private float m_Speed;

    public Rigidbody2D Rigidbody2D => m_Rigidbody2D;

    private bool m_Active;

    public void Activate(float i_Speed)
    {
        m_Active = true;
        m_Speed = i_Speed;
    }

    public void Deactivate()
    {
        m_Active = false;
    }


    private void Update()
    {
        if(!m_Active)
        {
            return;
        }

        var pipePosition = transform.position;
        pipePosition += m_Speed * Time.deltaTime * Vector3.left;
        transform.position = pipePosition;

        if(pipePosition.x < -Constants.ScreenEdgeX)
        {
            GameManager.Instance.RemoveOffscreenPipes(this);
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("PipeSpawnPoint"))
        {
            GameManager.Instance.SpawnPipe();
        }
        else if (other.CompareTag("IncreaseScorePoint"))
        {
            GameManager.Instance.UpdateScore();
        }
        else if(other.CompareTag("Bird"))
        {
            GameManager.Instance.HandleCrash();
        }
    }
}
