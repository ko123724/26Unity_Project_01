using System;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

//.1. 어떻게 wasdㅋ받아올 것인가?
//2. 어디에 코드를 작성할것인가?
/*
 * class [이름] :MonoBehaviour{
 * 
 * class안 내용
 * 
 * }
 * 
 *
 *
 * Siart() : 한번만 실행된다
 * Update(): 게임이 종료될 때 까지 실행된다
 *
 *
 *
 *
 *
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
        float h= Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 dir =new Vector3(h,0,v);
        if (dir.sqrMagnitude > 1f) dir.Normalize();
       
        // (x, 0, z) <= Vector3 0~ ?? ~ 1 방향
        dir = Camera.main.transform.TransformDirection(dir);

       Vector3 targetVelocity= dir * moveSpeed;
        targetVelocity.y = rigid.linearVelocity.y;




        rigid.linearVelocity = targetVelocity;
        Jump();

        Debug.DrawRay(bottom.position, Vector3.down * 0.1f, Color.red);


    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
             if(IsGround() == false)
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
           1.5f,
           groundLayer);
    }
}