using UnityEngine;
using Random = UnityEngine.Random;

public class BallMover : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rb;
    
    private const float BALL_SPEED = 7f;

    private void Start() => Reset();

    public void Reset()
    {
        transform.position = Vector3.zero;
        _rb.velocity = RandomInsideArc() * (RandomSign() * BALL_SPEED);
    }

    private void FixedUpdate()
    {
        _rb.velocity = _rb.velocity.normalized * BALL_SPEED;
    }
    
    private Vector2 RandomInsideArc() 
    {
        float angle = Random.Range(Mathf.PI / 4, Mathf.PI * 3 / 4);
        return new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
    }
    
    private int RandomSign() => Random.value < .5? 1 : -1;
}
