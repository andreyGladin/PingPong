using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private InputListener _inputListener;

    private Vector3 _targetPosition;
    private float _followSpeed = 10f;
    
    private void Start()
    {
        _inputListener.OnStartDragGraphic += OnStartDrag;
        _inputListener.OnStopDragGraphic += OnStopDrag;
        _inputListener.OnPointerUnderGraphic += OnContinueDrag;

        _targetPosition = transform.position;
    }

    private void OnStartDrag(PointerEventData data) => SetTargetPosition(data);

    private void OnContinueDrag(PointerEventData data) => SetTargetPosition(data);

    private void OnStopDrag(PointerEventData data) => SetTargetPosition(data);

    private void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, _targetPosition, Time.deltaTime * _followSpeed);
    }

    private void SetTargetPosition(PointerEventData data)
    {
        if (data.pointerCurrentRaycast.isValid)
        {
            _targetPosition = new Vector3(data.pointerCurrentRaycast.worldPosition.x, transform.position.y, transform.position.z);
        }
    }
}
