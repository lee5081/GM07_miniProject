using UnityEngine;

public class PlayerMovement : MonoBehaviour // 플레이어의 움직임과 애니메이션을 담당하는 MonoBehaviour 클래스
{
    [SerializeField] private PlayerStats stats;

    private Animator animator;
    private Vector2 moveInput;
    private Rigidbody2D rb;
    private void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    public void SetMoveInput(Vector2 input)
    {
        moveInput = input;
    }

    private void FixedUpdate()
    {
       
        int ani_direction = -1;   // 애니메이션 상태는 기본 -1로 지정 (Idle 상태) 
        switch (moveInput.x)    // 수평값 case 구분하여 애니메이션 상태값 변수 변경
        {
            case -1:
                ani_direction = 3;
                break;
            case 1:
                ani_direction = 2;
                break;

        }
        switch (moveInput.y)    // 수직값 case 구분하여 애니메이션 상태값 변수 변경
        {
            case -1:
                ani_direction = 0;
                break;
            case 1:
                ani_direction = 1;
                break;

        }
        moveInput.Normalize(); // dir Vector의 길이를 1로 계산 (대각선 이동시 더 빨라지는걸 방지)
        animator.SetBool("IsMoving", moveInput.magnitude > 0);   // Bool 타입의 애니메이션 상태값 IsMoving 파라미터를 설정 (백터크기가 0보다크면 true) 
        animator.SetInteger("Direction", ani_direction); // 최종 애니메이션 상태값 변경

        rb.linearVelocity = stats.MoveSpeed * moveInput; // 최종 이동
    }


}

