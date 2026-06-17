using UnityEngine;

public class PlayerCameraController : MonoBehaviour
{
    [SerializeField] private Vector3 offset =  new Vector3(0f, 0f, -10f);
    [SerializeField] private float followSpeed = 5f;
    [SerializeField] Transform cameraTransform;
    private Transform target;

    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }

    private void LateUpdate()
    {
        if (target == null)
            return;

        Vector3 targetPosition = target.position + offset;
        cameraTransform.position = Vector3.Lerp(cameraTransform.position,targetPosition,followSpeed * Time.deltaTime);
    }


}
