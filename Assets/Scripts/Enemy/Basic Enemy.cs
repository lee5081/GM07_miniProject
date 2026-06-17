using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class BasicEnemy : EnemyBase
{
    [SerializeField] Transform firePoint;
    [SerializeField] EnemyBullet enemyBulletPrefab;
    [SerializeField] float StraightAttackDelay = 1.0f;
    private float angle;
    private Coroutine attackRoutine;

    private void LateUpdate()
    {
        Move();
    }
    private void Update()
    {
        Attack();
    }
    protected override void Move()
    {
        StraightMove();
        CurveMove();
    }
    private void StraightMove()
    {
        Vector3 dir = (Player.Instance.transform.position - transform.position).normalized;

        transform.position += dir * moveSpeed * Time.deltaTime;
    }
    private void CurveMove()
    {
        angle += moveSpeed * Time.deltaTime;
        Vector3 targetPos = Player.Instance.transform.position + new Vector3(Mathf.Cos(angle) * 3, Mathf.Sin(angle) * 3, 0);
        transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
    }
    protected override void Attack()
    {
        if (attackRoutine == null)
        {
            attackRoutine = StartCoroutine(StraightAttackCo());
        }
    }
    private IEnumerator StraightAttackCo()
    {
        for (int i=0; i< 3; i++)
        {
            Instantiate(enemyBulletPrefab, firePoint.position, Quaternion.identity);
            yield return new WaitForSeconds(StraightAttackDelay);
        }
        yield return AttackDelay;
        attackRoutine = null;
    }
}
