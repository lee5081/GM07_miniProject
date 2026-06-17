using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] private float damage = 10.0f;
    [SerializeField] private float moveSpeed = 5.0f;
    [SerializeField] private float lifeTime = 3.0f;
    private Vector3 dir;
    private void Start()
    {
        dir = (Player.Instance.transform.position - transform.position).normalized;
        Destroy(gameObject, lifeTime);
    }
    private void Update()
    {
        transform.Translate(dir * moveSpeed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
    }
}
