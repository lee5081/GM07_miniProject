using UnityEngine;

public class PlayerStats : MonoBehaviour, IDamageable
{
    [SerializeField] private CharacterData data;
    public static PlayerStats instacne;
    public float MoveSpeed { get; private set; } // 이동속도
    public float MaxHealth { get; private set; } // 최대체력
    public float CurrentHealth { get; private set; } // 현재 체력


    private void Awake()
    {
        InitializeStats(); // 초기화

        if (instacne == null)  // 싱글톤
        {
            instacne = this;
        }
        else
        {
            Destroy(gameObject);
        }

    }

    private void InitializeStats() // 플레이어 데이터 초기화
    {
        MoveSpeed = data.moveSpeed;
        MaxHealth = data.maxHealth;
        CurrentHealth = MaxHealth;
    }

    public void TakeDamage(float damage) // IDamageable 
    {
        CurrentHealth -= damage;
        if (CurrentHealth <= 0f)
        {
            CurrentHealth = 0f;
            Die();
        }
    }

    public void Heal(float amount) 
    {
        CurrentHealth = Mathf.Min(CurrentHealth + amount, MaxHealth);
    }

    private void Die()
    {
        Debug.Log($"{data.name} 사망");
    }
}
