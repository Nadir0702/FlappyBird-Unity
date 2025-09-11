using UnityEngine;

public class PlayerController : Singleton<PlayerController>
{
    [SerializeField] private Bird m_Bird;
    [SerializeField] private float m_JumpForce;
    
    private bool m_Jump;
    private bool m_Active;
    
    private void Start()
    {
        m_Jump = false;
        m_Active = false;
        m_Bird.Rigidbody2D.gravityScale = 0;
    }

    private void Update()
    {
        if(m_Active)
        {
            handleJump();
        }
    }

    private void FixedUpdate()
    {
        if (m_Jump)
        {
            m_Bird.Rigidbody2D.linearVelocity = Vector2.zero;
            var forceVector = Vector2.up * m_JumpForce;
            m_Bird.Rigidbody2D.AddForce(forceVector, ForceMode2D.Force);
            m_Jump = false;
        }
    }

    private void handleJump()
    {
        if (Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0))
        {
            m_Jump = true;
        }
    }

    public void ActivateController()
    {
        m_Active = true;
        m_Bird.MoveToStartPosition();
        m_Bird.Rigidbody2D.gravityScale = Constants.GravityScale;
    }

    public void DeactivateController()
    {
        m_Active = false;
        m_Bird.Rigidbody2D.linearVelocity = Vector2.zero;
        m_Bird.Rigidbody2D.angularVelocity = 0.0f;
        m_Bird.Rigidbody2D.gravityScale = 0;
    }
}
