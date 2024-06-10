using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]
public class Ship : MonoBehaviour, IMovement, IShoot, IDamageable
{
    private Rigidbody2D rb2d;
    private Weapon weapon;

    [SerializeField] private Health health;
    [SerializeField] private float speed;
    [SerializeField] private Vector2 direction;
    [SerializeField] public int scoreValue = 10;
    [SerializeField] private AudioClip damageAudio;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        weapon = GetComponentInChildren<Weapon>();
    }

    public void SetDirection(float x, float y)
    {
        direction.x = x;
        direction.y = y;
        rb2d.velocity = direction * speed;
    }

    public void Shoot()
    {
        weapon.Shoot();
    }

    public void TakeDamage(int damage)
    {
        health.Reduce(damage);

        AudioManager.instance.PlayAudioClip(damageAudio, transform, 1f);

        if (health.currentHealth <= 0)
        {
            ScoreManager.Instance.AddScore(scoreValue);
            Destroy(gameObject);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        TakeDamage(1);
    }

    public Vector2 GetDirection()
    {
        Debug.Log(rb2d.velocity.normalized);
        return rb2d.velocity.normalized;
    }
}