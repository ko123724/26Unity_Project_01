using UnityEngine;

// 이 스크립트가 붙으면 Rigidbody를 자동으로 추가해줍니다.
[RequireComponent(typeof(Rigidbody))]
public class StableVerticalPlatform : MonoBehaviour
{
    [Header("이동 설정")]
    public float height = 4f;    // 올라갈 높이
    public float speed = 2f;     // 이동 속도

    private Rigidbody rb;
    private Vector3 startPos;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        // 물리 엔진 설정 (플레이어를 받치기 위해 필수)
        rb.isKinematic = true;
        rb.useGravity = false;
        rb.interpolation = RigidbodyInterpolation.Interpolate; // 움직임을 부드럽게 보정

        startPos = rb.position;
    }

    void FixedUpdate()
    {
        // 바닥(0)에서 시작해 height까지 왕복하는 값 계산
        float currentY = Mathf.PingPong(Time.fixedTime * speed, height);

        // 새로운 위치 계산
        Vector3 nextPos = startPos + new Vector3(0, currentY, 0);

        // transform.position 대신 rb.MovePosition을 써야 
        // 위에 올라탄 캐릭터가 같이 움직이고 점프도 안정적입니다.
        rb.MovePosition(nextPos);
    }
}