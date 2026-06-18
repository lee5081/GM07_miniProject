using UnityEngine;

public class EnemyScript : MonoBehaviour , IDamageable // 테스트 적 스크립트
{
    float hp = 100;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float damage)
    {
        hp -= damage;
        Debug.Log($"Take Damage{damage}");
        if(hp <= 0)
        {
            Debug.Log("Die");
            Destroy(gameObject);
        }
    }
}
