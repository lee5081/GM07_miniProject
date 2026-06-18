using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class BasicEnemy : EnemyBase
{
    [Header("공격 설정")]
    [SerializeField] private Transform firePoint;
    [SerializeField] private EnemyBullet enemyBulletPrefab;
    [SerializeField] private float StraightAttackDelay = 1.0f;

    [Header("이동 설정")]
    [SerializeField] private float toDistance = 5;

    private Coroutine attackRoutine;

    private Vector3 dir;
    private void Update()
    {
        float dis = Vector3.Distance(Player.Instance.transform.position, transform.position);

        dir = (Player.Instance.transform.position - transform.position).normalized;
        if (dis > toDistance)
        {
            Move();
        }

        Attack();
    }
    private void Move()
    {
        transform.position += dir * moveSpeed * Time.deltaTime;
    }
    protected void Attack()
    {
        if (attackRoutine == null)
        {
            attackRoutine = StartCoroutine(AttackCo());
        }
    }
    private IEnumerator AttackCo()
    {
        for (int i = 0; i < 3; i++)
        {
            Instantiate(enemyBulletPrefab, firePoint.position, Quaternion.identity);
            yield return new WaitForSeconds(StraightAttackDelay);
        }
        yield return AttackDelay;
        attackRoutine = null;
    }
}
