using UnityEngine;

public class PlayerController : Singleton<PlayerController>
{
    [SerializeField] private Bird m_Bird;
    [SerializeField] private float m_JumpForce;
    
    private bool m_Jump;

    void Update()
    {
        handleJump();
        handleStartGame();
    }

    private void handleStartGame()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            
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
}
