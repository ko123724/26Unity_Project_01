using UnityEngine;
using UnityEngine.SceneManagement; // 씬 재시작을 위해 필요

public class TrapHandler : MonoBehaviour
{
    // 트리거 구역에 들어갔을 때 실행
    private void OnTriggerEnter(Collider other)
    {
        // 닿은 물체의 태그가 "Trap"이라면
        if (other.CompareTag("Finish"))
        {
            Debug.Log("거짓 구역입니다! 게임 종료.");
            GameOver();
        }
    }

    void GameOver()
    {
        // 1. 실제 빌드된 게임이라면 프로그램을 종료
        // Application.Quit(); 

        // 2. 점프맵 특성상 '죽으면 처음부터'가 일반적이므로 현재 씬 재시작
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}