using System.Collections;
using UnityEngine;

public class EliteEnemy : EnemyBase
{
    [Header("공격 설정")]
    [SerializeField] private Transform firePoint;
    [SerializeField] private EnemyBullet enemyBulletPrefab;
    [SerializeField] private EnemyRaser enemyRaserPrefab;
    [SerializeField] private float StraightAttackDelay = 1.0f;

    [Header("이동 설정")]
    [SerializeField] private float rotateSpeed = 100f;
    [SerializeField] private float radius = 5f;

    [Header("다음 이동메서드까지의 쿨타임")]
    [SerializeField] private float moveWaitTime;

    //이동관련
    private Vector3 dir;
    private float dis;
    private Vector3 returnPos;
    private float angle;

    private void Awake()
    {
        StartCoroutine(MoveCo());
    }

    private void Update()
    {
        dir = (Player.Instance.transform.position - transform.position).normalized;
        dis = Vector3.Distance(Player.Instance.transform.position, transform.position);
        returnPos = Player.Instance.transform.position - (10 * dir);
    }
    private IEnumerator MoveCo()
    {
        while (true)
        {
            int pattern = Random.Range(0, 4);

            switch (pattern)
            {
                case 0: yield return StartCoroutine(MoveSlowCo()); break;
                case 1: yield return StartCoroutine(MoveCurveCo()); break;
                case 2: yield return StartCoroutine(MoveDashCo()); break;
                case 3: yield return StartCoroutine(MoveAroundCo()); break;
            }
            yield return StartCoroutine(ReturnPositionCo());

            yield return new WaitForSeconds(moveWaitTime);
        }
    }
    private IEnumerator MoveSlowCo()
    {
        float timer = 0f;
        while (dis > 3 && timer < 5f) 
        {
            transform.position += dir * moveSpeed * 3 * Time.deltaTime;
            timer += Time.deltaTime;
            yield return null;
        }
    }
    private IEnumerator MoveCurveCo()
    {
        float timer = 0f;
        while (dis > 3 && timer < 5f)
        {
            angle += moveSpeed * Time.deltaTime;
            Vector3 basemove = dir * moveSpeed * Time.deltaTime;
            Vector3 side = new Vector3(-dir.y, dir.x, 0f);
            Vector3 sideOffset = side * Mathf.Sin(angle * 3f) * 6f;
            transform.position += basemove + sideOffset * Time.deltaTime;
            timer += Time.deltaTime;
            yield return null;
        }
    }
    private IEnumerator MoveDashCo()
    {
        float timer = 0f;
        while (dis > 3 && timer < 3f)
        {
            transform.position += dir * moveSpeed * 7 * Time.deltaTime;
            timer += Time.deltaTime;
            yield return null;
        }
    }
    private IEnumerator MoveAroundCo()
    {
        float timer = 0f;
        while (dis > 3 && timer < 5f)
        {
            transform.RotateAround(Player.Instance.transform.position, Vector3.forward, rotateSpeed * Time.deltaTime);

            timer += Time.deltaTime;
            yield return null;
        }
    }
    private IEnumerator ReturnPositionCo()
    {
        while (Vector3.Distance(transform.position,returnPos) > 0.01)
        {
            transform.position = Vector3.MoveTowards(transform.position, returnPos, moveSpeed * 3 * Time.deltaTime);
            yield return null;
        }
    }
}