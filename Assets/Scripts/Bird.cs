using UnityEngine;

public class Bird : MonoBehaviour
{
    [SerializeField] private Rigidbody2D m_Rigidbody2D;

    public Rigidbody2D Rigidbody2D => m_Rigidbody2D;
}
