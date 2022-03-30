using TMPro;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private Collider2DHelper _loseCollider;
    [SerializeField] private Collider2DHelper _winCollider;
    
    [SerializeField] private TextMeshProUGUI _scorePlayerOneLabel; 
    [SerializeField] private TextMeshProUGUI _scorePlayerTwoLabel;
    
    [SerializeField] private BallMover _ball;

    [SerializeField] private Collider2DHelper _playerOneTable;
    [SerializeField] private Collider2DHelper _playerTwoTable;
    
    private int _playerOneScoreValue = 0;
    private int _playerTwoScoreValue = 0;
    private float _lastTimeTouched = 0;

    private const float STUCK_TIME = 5f;
    
    private void Start()
    {
        _loseCollider.OnCollisionEnterEvent += OnLoseColliderTouch;
        _winCollider.OnCollisionEnterEvent += OnWinColliderTouch;

        _playerOneTable.OnCollisionEnterEvent += UpdateTouchTime;
        _playerTwoTable.OnCollisionEnterEvent += UpdateTouchTime;
    }

    private void OnLoseColliderTouch(Collision2D collision)
    {
        _scorePlayerTwoLabel.SetText((++_playerTwoScoreValue).ToString()); 
        _ball.Reset();
    }
    
    private void OnWinColliderTouch(Collision2D collision)
    {
        _scorePlayerOneLabel.SetText((++_playerOneScoreValue).ToString());
        _ball.Reset();
    }

    private void UpdateTouchTime(Collision2D collision2D) => _lastTimeTouched = Time.realtimeSinceStartup;

    private void Update()
    {
        if (Time.realtimeSinceStartup - _lastTimeTouched > STUCK_TIME)
        {
            _ball.Reset();
            _lastTimeTouched = Time.realtimeSinceStartup;
        }
    }
}
