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
    [SerializeField] private float radius = 5;
    [SerializeField] private float rotateSpeed = 50;

    private float moveRandom;
    private float angle;
    private Coroutine attackRoutine;

    private void Awake()
    {
        moveRandom = Random.Range(0, 2);
    }
    private void LateUpdate()
    {
        float dis = Vector3.Distance(Player.Instance.transform.position, transform.position);

        if (dis > toDistance)
        {
            MoveToPlayer();
        }
        else if (dis <= toDistance)
        {
            RoundPlayer();
        }
    }
    private void Update()
    {
        Attack();
    }
    protected override void MoveToPlayer()
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
        Vector3 dir = (Player.Instance.transform.position - transform.position).normalized;

        transform.position += dir * moveSpeed * Time.deltaTime;
    }
    private void CurveMove()
    {
        angle += moveSpeed * Time.deltaTime;

        Vector3 dir = (Player.Instance.transform.position - transform.position).normalized;

        Vector3 basemove = dir * moveSpeed * Time.deltaTime;

        Vector3 side = new Vector3(-dir.y, dir.x, 0f);

        Vector3 sideOffset = side * Mathf.Sin(angle * 3f) * 6f;

        transform.position += basemove + sideOffset * Time.deltaTime;
    }
    protected override void RoundPlayer()
    {
        transform.RotateAround(Player.Instance.transform.position, Vector3.forward, rotateSpeed * Time.deltaTime);

        Vector3 dir = (transform.position - Player.Instance.transform.position).normalized;
        transform.position = Player.Instance.transform.position + dir * radius;
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
        for (int i = 0; i < 3; i++)
        {
            Instantiate(enemyBulletPrefab, firePoint.position, Quaternion.identity);
            yield return new WaitForSeconds(StraightAttackDelay);
        }
        yield return AttackDelay;
        attackRoutine = null;
    }
}
