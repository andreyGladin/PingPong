using UnityEngine;

public class ObjectsPositioner : MonoBehaviour
{
    [SerializeField] private Collider2D _leftWall;
    [SerializeField] private Collider2D _rightWall;
    [SerializeField] private Collider2D _topWall;
    [SerializeField] private Collider2D _botWall;

    [SerializeField] private GameObject _playerOne;
    [SerializeField] private GameObject _playerTwo;

    [SerializeField] private RectTransform _rect;
    [SerializeField] private Camera _gameCamera;
    
    private const float PLAYER_OFFSET = 1f;
    
    private void Start()
    {
        PlaceObjects();
    }

    private void PlaceObjects()
    {
        var safeArea = _rect.GetWorldRect().size;
        _topWall.transform.position = new Vector3(_topWall.transform.position.x, safeArea.y / 2 + _topWall.bounds.extents.y, _topWall.transform.position.z);
        _botWall.transform.position = new Vector3(_botWall.transform.position.x, -safeArea.y / 2 - _botWall.bounds.extents.y, _botWall.transform.position.z);
        
        _rightWall.transform.position = new Vector3(safeArea.x / 2 + _rightWall.bounds.extents.x, _rightWall.transform.position.y, _rightWall.transform.position.z);
        _leftWall.transform.position = new Vector3(-safeArea.x / 2 - _leftWall.bounds.extents.x, _leftWall.transform.position.y, _leftWall.transform.position.z);

        
        _playerOne.transform.position = new Vector3(_playerOne.transform.position.x, -safeArea.y / 2 + PLAYER_OFFSET, _playerOne.transform.position.z);
        _playerTwo.transform.position = new Vector3(_playerTwo.transform.position.x, safeArea.y / 2 - PLAYER_OFFSET, _playerTwo.transform.position.z);
    }
}
