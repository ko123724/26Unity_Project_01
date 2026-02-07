using UnityEngine;

public class RespawnHandler : MonoBehaviour
{
    [Header("부활 위치")]
    public Transform spawnPoint; // 시작 지점의 위치

    private void OnTriggerEnter(Collider other)
    {
        // 닿은 오브젝트가 플레이어라면
        if (other.CompareTag("Player"))
        {
            Debug.Log("실패! 처음 위치로 돌아갑니다.");

            // 플레이어의 위치를 스폰 포인트로 이동
            other.transform.position = spawnPoint.position;

            // 만약 리지드바디(물리)를 사용 중이라면 속도를 0으로 초기화해줘야 튕기지 않음
            Rigidbody rb = other.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.linearVelocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
            }
        }
    }
}