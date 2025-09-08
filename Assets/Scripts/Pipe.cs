using UnityEngine;

public class Pipe : MonoBehaviour
{
    [SerializeField] private Rigidbody2D m_Rigidbody2D;

    public Rigidbody2D Rigidbody2D => m_Rigidbody2D;
}
