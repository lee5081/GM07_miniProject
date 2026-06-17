using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData", menuName = "GameData/Enemy Data")]
public class EnemyData : ScriptableObject
{
    [Header("Enemy 정보")]
    [SerializeField] private string enemyName;
    [SerializeField] private EnemyBase enemyPrefab;

    [Header("Enemy Sprite")]
    [SerializeField] private Sprite enemySprite;

    [Header("Enemy 능력치")]
    [SerializeField] private int maxHp = 30;
    [SerializeField] private int attack = 5;
    [SerializeField] private float moveSpeed = 1.0f;
    [SerializeField] private float attackDelay = 5f;
    [SerializeField] private float damageDelay = 0.1f;

    [Header("Enemy 처치 보상")]
    [SerializeField] private ItemBase[] rewards;
    [SerializeField] private float itemDropRadius;

    public string EnemyName { get { return enemyName; } }
    public EnemyBase EnemyPrefab {  get { return enemyPrefab; } }
    public Sprite EnemySprite { get { return enemySprite; } }
    public int MaxHp { get { return maxHp; } }
    public int Attack { get { return attack; } }
    public float MoveSpeed { get { return moveSpeed; } }
    public float AttackDelay { get { return attackDelay; } }
    public float DamageDelay { get { return damageDelay; } }
    public ItemBase[] Rewards { get { return rewards; } }
    public float ItemDropRadius { get { return itemDropRadius; } }
}
