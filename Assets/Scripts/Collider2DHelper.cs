using System;
using UnityEngine;

public class Collider2DHelper : MonoBehaviour
{
    public event Action<Collision2D> OnCollisionEnterEvent;
    private void OnCollisionEnter2D(Collision2D other) => OnCollisionEnterEvent?.Invoke(other);
}

