using System;
using UnityEngine;

// 1. 어떻게 wasd 받아올 것인가?
// 2. 어디에 코드를 작성할 것인가?
/*
 * class [이름] : MonoBehavior    // d\유니티에서 명령을 하기 위한 세팅
 * {
 *      중괄호 안에 있는 모드의 내용은 class의 내용이다.
 * }
 * 
 * Start() : 한번만 실행한다.
 * Update() : 게암이 종료될 때 까지 계속 실행한다. - Update의 어디에 작성을 해야 할까?
 * {
 * 
 * }
 */

public class PlayerMove : MonoBehaviour
{
    Rigidbody rigid;
    public float moveSpeed = 7f;
    public float jumpPower = 100f;

    public Transform bottom;
    public LayerMask groundLayer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rigid = GetComponent<Rigidbody>();

        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 dir = new Vector3(h, 0, v);
        if (dir.sqrMagnitude > 1f) dir.Normalize();

        // (x, 0, y) < =  Vector3 0 ~ ?? ~ 1 방향
        dir = Camera.main.transform.TransformDirection(dir);

        Vector3 targetVelocity = dir * moveSpeed;
        targetVelocity.y = rigid.linearVelocity.y;
        rigid.linearVelocity = targetVelocity;

        Jump();
        Debug.DrawRay(bottom.position, Vector3.down * 0.5f, Color.red);
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (IsGround() == false)
            {
                return;
            }

            // 물리법칙. Addforce
            rigid.AddRelativeForce(transform.up * jumpPower);
        }
    }

    private bool IsGround()
    {
        return Physics.Raycast(bottom.position + Vector3.up * 0.1f,
            Vector3.down,
            out RaycastHit hit,
            0.5f,
            groundLayer);
    }
}
