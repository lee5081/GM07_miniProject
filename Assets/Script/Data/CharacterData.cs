using UnityEngine;

[CreateAssetMenu(
    fileName = "CharacterData",
    menuName = "Game/Character Data"
)]
public class CharacterData : ScriptableObject
{
    [Header("캐릭터이름")]
    public string characterName;

    [Header("캐릭터 기본 스텟")]
    public float moveSpeed = 5f;
    public float maxHealth = 100f;

    [Header("캐릭터 외형")]
    public Sprite bodySprite;
    public RuntimeAnimatorController animatorController;

    //[Header("캐릭터 시작 무기")]
    //public Gun startingGun;

}

