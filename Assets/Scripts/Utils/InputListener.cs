using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputListener : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private bool _ForcePointerDownDragStart;
    public event Action<PointerEventData> OnPointerUnderGraphic;
    public event Action<PointerEventData> OnStartDragGraphic;
    public event Action<PointerEventData> OnStopDragGraphic;

    public void OnDrag(PointerEventData eventData)=> OnPointerUnderGraphic?.Invoke(eventData);
    public void OnBeginDrag(PointerEventData eventData)
    {
        if (!_ForcePointerDownDragStart)
        {
            OnStartDragGraphic?.Invoke(eventData);
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (!_ForcePointerDownDragStart)
        {
            OnStopDragGraphic?.Invoke(eventData);
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (_ForcePointerDownDragStart)
        {
            OnStartDragGraphic?.Invoke(eventData);
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (_ForcePointerDownDragStart)
        {
            OnStopDragGraphic?.Invoke(eventData);
        }
    }
}