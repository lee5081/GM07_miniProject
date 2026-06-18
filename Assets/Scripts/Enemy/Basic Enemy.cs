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

    private float moveRandom;
    private float angle;
    private Coroutine attackRoutine;

    private Vector3 dir;
    private void Awake()
    {
        moveRandom = Random.Range(0, 2);
    }
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
    protected void Move()
    {
        if (moveRandom == 0)
        {
            StraightMove();
        }
        else
        {
            CurveMove();
        }
    }
    private void StraightMove()
    {
        transform.position += dir * moveSpeed * Time.deltaTime;
    }
    private void CurveMove()
    {
        angle += moveSpeed * Time.deltaTime;

        Vector3 basemove = dir * moveSpeed * Time.deltaTime;

        Vector3 side = new Vector3(-dir.y, dir.x, 0f);

        Vector3 sideOffset = side * Mathf.Sin(angle * 3f) * 6f;

        transform.position += basemove + sideOffset;
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
