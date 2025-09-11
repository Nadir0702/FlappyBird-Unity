using UnityEngine;

public class Bird : MonoBehaviour
{
    [SerializeField] private Rigidbody2D m_Rigidbody2D;

    public Rigidbody2D Rigidbody2D => m_Rigidbody2D;

    public void OnCollisionEnter2D(Collision2D i_Collision)
    {
        if(i_Collision.collider.CompareTag("Ground"))
        {
            GameManager.Instance.HandleCrash();
        }
    }

    public void MoveToStartPosition()
    {
        transform.position = new Vector3(-0.5f, 0, 0);
    }
}
