using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]
[RequireComponent(typeof(LineRenderer))]
public class Projectile : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private LineRenderer lineRenderer;

    [SerializeField] private float speed;
    [SerializeField] private float lifetime;
    private float duration;

    [SerializeField] private string sortingLayerName = "Foreground";  // Default sorting layer
    [SerializeField] private int sortingOrder = 1;  // Default order in layer

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        lineRenderer = GetComponent<LineRenderer>();

        duration = 0;

        // Initialize the LineRenderer
        lineRenderer.positionCount = 2;

        // Set the sorting layer and order
        lineRenderer.sortingLayerName = sortingLayerName;
        lineRenderer.sortingOrder = sortingOrder;
    }

    private void Start()
    {
        rb2d.velocity = transform.up * speed;
        // Set the initial position of the tracer
        lineRenderer.SetPosition(0, transform.position);
    }

    private void Update()
    {
        duration += Time.deltaTime;

        // Update the position of the tracer
        lineRenderer.SetPosition(1, transform.position);

        if (duration >= lifetime)
        {
            DestroyProjectile();
        }
    }

    private void DestroyProjectile()
    {
        Destroy(gameObject);
    }
}
