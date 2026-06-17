using UnityEngine;

public class PlayerGunController : MonoBehaviour
{
    [SerializeField] private Transform weaponHolder; // 총의 위치값
    [SerializeField] private Gun startingGunPrefab; // 스타팅 무기 프리팹
    [SerializeField] private Gun currentGun;  // 현재 사용중인 무기

    public Gun CurrentGun => currentGun;  // 외부에서 currentGun을 쓸수있게
    public void Start()
    {
        if (startingGunPrefab != null) 
        {
            EquipWeapon(startingGunPrefab); // 스타팅 무기 장착
        }
    }

    public void EquipWeapon(Gun weaponPrefab) // 무기장착 함수
    {
        if (currentGun != null)    // 현재 사용중인 무기가 있으면
        {
            Destroy(currentGun.gameObject);  // 오브젝트 삭제
        }

        currentGun = Instantiate(weaponPrefab,weaponHolder.position,weaponHolder.rotation,weaponHolder); // 새 무기 프리팹 생성
    }

    public void Fire(Vector2 direction) // 사격
    {
        if (currentGun == null)
            return;

        currentGun.TryFire(direction);
    }

    public void Reload() // 재장전
    {
        if (currentGun == null)
            return;

        currentGun.TryReload();
    }
}