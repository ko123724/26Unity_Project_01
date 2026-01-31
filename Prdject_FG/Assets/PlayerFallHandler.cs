using UnityEngine;
using StarterAssets; // StarterAssets 네임스페이스가 필요할 수 있습니다.

public class PlayerFallHandler : MonoBehaviour
{
    [Header("설정")]
    public float fallThreshold = -10f; // 이 높이보다 낮아지면 리스폰

    private Vector3 _startPosition;
    private CharacterController _controller;

    void Start()
    {
        // 게임 시작 시점의 위치를 부활 지점으로 저장
        _startPosition = transform.position;
        _controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        // 현재 Y축 높이가 설정한 값보다 낮아지면
        if (transform.position.y < fallThreshold)
        {
            Respawn();
        }
    }

    public void Respawn()
    {
        // CharacterController가 켜져 있으면 transform.position 변경이 무시될 수 있습니다.
        if (_controller != null) _controller.enabled = false;

        // 위치 초기화
        transform.position = _startPosition;

        // 속도 초기화 (낙하 속도가 유지되는 것 방지)
        if (_controller != null)
        {
            _controller.enabled = true;
        }

        Debug.Log("플레이어가 추락하여 처음 위치로 돌아왔습니다.");
    }
}