using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private PlayerController player;
    [SerializeField] private PlayerCameraController cameraController; // 메인카메라 조절하는 컨트롤러


    private void Awake()
    {
        cameraController = GetComponent<PlayerCameraController>();
        cameraController.SetTarget(player.transform);   
    }
}
