using System.Collections;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public abstract class EnemyBase : MonoBehaviour, IDamageable
{
    protected EnemyData enemyData;
    private Sprite enemySprite;
    protected int currentHp;
    protected int attack;
    protected float moveSpeed;
    protected float attackDelay;
    protected ItemBase[] rewards;
    protected float itemDropRadius;

    protected float damageDelay;
    private WaitForSeconds DamageDelay;
    public bool IsDamageable { get; private set; } = true;

    private void Awake()
    {
        enemySprite = GetComponent<Sprite>();

        damageDelay = 0.1f;
        DamageDelay = new WaitForSeconds(damageDelay);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("PlayerBullet"))
        {
            if (!IsDamageable) return;
            PlayerBullet bullet = collision.gameObject.GetComponent<PlayerBullet>();
            if(bullet != null)
            {
                Debug.Log("공격 감지");
                TakeDamage(bullet.damage);
                Destroy(collision.gameObject);                
            }
        }
    }
    public void Initialize(EnemyData data)
    {
        if (data == null) return;

        enemyData = data;

        currentHp = enemyData.MaxHp;
        attack = enemyData.Attack;
        moveSpeed = enemyData.MoveSpeed;
        gameObject.name = enemyData.EnemyName;
        rewards = enemyData.Rewards;
        itemDropRadius = enemyData.ItemDropRadius;
        if(enemySprite != null)
        {
            enemySprite = enemyData.EnemySprite;
        }
    }
    public void TakeDamage(int damage)
    {
        if (!IsDamageable) return;
        IsDamageable = false;
        currentHp -= damage;
        Debug.Log($"{gameObject.name} 데미지 받음 ({damage}");
        Debug.Log($"{gameObject.name} 현재 체력 : {currentHp}");
        if (currentHp <= 0)
        {
            EnemyDie();
        }
        else
        {
            StartCoroutine(DamageDelayCo());
        }
    }
    protected void EnemyDie()
    {
        Debug.Log($"{gameObject.name} 사망");
        Destroy(gameObject);
        DropRewards();
    }
    protected void DropRewards()
    {
        for (int i = 0; i < rewards.Length; i++)
        {
            int rate = Random.Range(0, 100);
            if (rate <= 30) return;
            Vector2 itemDropOffset = Random.insideUnitCircle * itemDropRadius;
            Vector2 itemSpawnPos = (Vector2)transform.position + itemDropOffset;

            Instantiate(rewards[i], itemSpawnPos, Quaternion.identity);
            Debug.Log($"{rewards[i].name} 드랍");
        }
    }
    private IEnumerator DamageDelayCo()
    {
        yield return DamageDelay;
        IsDamageable = true;
    }
    protected abstract void Move();
    protected abstract void Attack();
}
