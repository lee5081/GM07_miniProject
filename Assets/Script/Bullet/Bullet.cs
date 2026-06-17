using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] protected Rigidbody2D rb;
    protected BulletData data;  // 총알의 스크립터블 오브젝트
    protected float damage;    //  데미지
    protected int remainingPierce; // 총알 관통
    protected GameObject owner;  // 총알을 발사한 게임오브젝트 (적, 플레이어 등)

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    public virtual void Initialize(BulletData bulletData, Vector2 direction, GameObject bulletOwner, float damageMultiplier = 1f) //(나중에 아이템같은걸 먹었을때, 총알의 데미지를 공식을 여기에 넣어주면됨)
    {
        owner = bulletOwner;
        data = bulletData;

        damage = data.damage * damageMultiplier; // 대미지 배율 설정 
        remainingPierce = data.pierceCount; // 관통 할수있는수 (나중에 총알에 효과같은걸 붙일예정 ex)적관통가능,벽튕기기 등)


        rb.linearVelocity = direction.normalized * data.speed;  // 해당 방향으로 ScriptableObject BulletData의 속도만큼 이동, 대각이동빨라짐 방지하기위해 방향에 normalized

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;    

        transform.rotation = Quaternion.Euler(0f, 0f, angle);   //해당 총알 오브젝트의 회전값을 방향에 맞게 설정 현재는  총알이 구 형태여서 상관없음

        Destroy(gameObject, data.lifeTime);      // ScriptableObject BulletData의 lifeTime시간이 지나면 제거
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player") return;    // 플레이어 접촉시 무시, 나중에 Tag말고 GameObject 비교로 if문 작성필요할듯

        if (collision.TryGetComponent(out IDamageable damageable))
        {
            damageable.TakeDamage(damage);

            OnHit(collision);   // 나중에 특수총알 ex) 폭팔, 연쇄 등 특수효과를 넣을때 따로 실행되는 로직

            if (remainingPierce > 0)    // 현재총알의 남은 관통수치 나중에 기능추가할려고 넣어둠 현재는 아무영향 안끼침
            {
                remainingPierce--;
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }

    protected virtual void OnHit(Collider2D collision)
    {

    }
}