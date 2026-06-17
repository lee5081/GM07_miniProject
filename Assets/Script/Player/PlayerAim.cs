using UnityEngine;

public class PlayerAim : MonoBehaviour
{
    [SerializeField] private Transform weaponHolder;
    [SerializeField] private PlayerGunController gunController;
    private SpriteRenderer gunRenderer;
    public Vector2 AimDirection { get; private set; }
    public void Start()
    {
        gunRenderer = gunController.CurrentGun.GunSprite;
    }

    private void Update()
    {
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);  // 마우스 좌표값을 카메라 기준으로 재계산
        mouseWorldPosition.z = 0f; 


        Vector3 mouseScreenPos = Input.mousePosition;   // 마우스좌표값
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(mouseScreenPos); // 게임월드 좌표값으로 변경
        Vector2 direction = mouseWorldPos - transform.position;   // 오브젝트(총)에서 마우스까지의 거리 계산
        AimDirection = ((Vector2)(mouseWorldPos - transform.position)).normalized; // 

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;  // 방향 벡터를 각도로 변경
        if (direction.x < 0)              // 총 스프라이트 좌우반전
        {
            gunRenderer.flipY = true;
        }
        else
        {
            gunRenderer.flipY = false;
        }

        weaponHolder.rotation = Quaternion.Euler(0, 0, angle);  // 최종 오브젝트 회전



    }
}