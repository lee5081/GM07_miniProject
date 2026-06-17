using UnityEngine;
using UnityEngine.UIElements;

public class BasicEnemy : EnemyBase
{
    //    [Header("플레이어와의 거리차")]
    //    [SerializeField] Vector2 Offset = new Vector2(3, 3);

    //    private float angle;
    //    protected override void Move()
    //    {
    //        int moveRandom = Random.Range(0, 2);
    //        if(moveRandom == 0)
    //        {
    //            StraightMove();
    //        }
    //        if(moveRandom == 1)
    //        {
    //            CurveMove();
    //        }
    //    }
    //    protected override void Attack()
    //    {

    //    }
    //    private void StraightMove()
    //    {
    //        Vector3 dir = (player.transform.position - transform.position).normalized;

    //        transform.position += dir * moveSpeed * Time.deltaTime;
    //    }
    //    private void CurveMove()
    //    {
    //        angle += moveSpeed * Time.deltaTime;
    //        float x = Mathf.Cos(angle) * 3;
    //        float y = Mathf.Sin(angle) * 3;

    //        transform.position = player.transform.position + new Vector3(x, y, 0);
    //    }

    protected override void Move()
    {
        
    }
    protected override void Attack()
    {
        
    }
}
