
using UnityEngine;

public class ChaserWithRange : MonoBehaviour
{
    public Transform target;      // 플레이어 위치
    public float speed = 3.0f;    // 이동 속도
    public float detectionRange = 10.0f; // 감지 거리 (이 안에 들어오면 추격)

    void Update()
    {
        if (target != null)
        {
            // 1. 플레이어와 장애물 사이의 거리를 계산합니다.
            float distance = Vector3.Distance(transform.position, target.position);

            // 2. 거리가 감지 범위(detectionRange)보다 작을 때만 움직입니다.
            if (distance <= detectionRange)
            {
                // 플레이어 방향으로 이동
                transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

                // (선택) 플레이어를 바라보게 함
                transform.LookAt(target);

                Debug.Log("플레이어 감지! 추격을 시작합니다.");
            }
        }
    }

    // 에디터 뷰에서 감지 범위를 시각적으로 확인하기 위한 기능 (디버그용)
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRange);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("잡혔다!");
            // 씬을 재시작하거나, 시작 지점으로 이동시키는 코드를 여기에 넣으세요.
            UnityEngine.SceneManagement.SceneManager.LoadScene(
                UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
        }
    }














}


