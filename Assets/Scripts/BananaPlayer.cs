using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BananaPlayer : MonoBehaviour, IKeyObserver
{
    private List<KeyCode> keys = new List<KeyCode>(); // 이제 private
    private MoveMgr _moveMgr;

    // IKeyObserver 인터페이스에서 Keys를 노출해야 하므로 explicit 구현
    List<KeyCode> IKeyObserver.Keys => keys;

    private void Start()
    {
        // 다섯 개 키 고정 등록
        keys.Add(KeyCode.Space);        // 점프
        keys.Add(KeyCode.A);            // 왼쪽 이동
        keys.Add(KeyCode.D);            // 오른쪽 이동
        keys.Add(KeyCode.LeftArrow);    // 왼쪽 이동
        keys.Add(KeyCode.RightArrow);   // 오른쪽 이동

        // KeyChecker 찾고 등록
        var checker = FindObjectOfType<KeyChecker>();
        if (checker != null)
        {
            checker.RegisterObserver(this);
        }

        // 같은 오브젝트에 있는 MoveMgr 가져오기
        _moveMgr = GetComponent<MoveMgr>();
    }

    private void OnDestroy()
    {
        var checker = FindObjectOfType<KeyChecker>();
        if (checker != null)
        {
            checker.UnregisterObserver(this);
        }
    }

    public void OnKeyPressed(KeyCode key)
    {
        if (_moveMgr == null) return;

        switch (key)
        {
            case KeyCode.Space:
                _moveMgr.StartJump();
                break;

            case KeyCode.A:
            case KeyCode.LeftArrow:
                _moveMgr.MoveLeft();
                break;

            case KeyCode.D:
            case KeyCode.RightArrow:
                _moveMgr.MoveRight();
                break;

            default:
                Debug.Log($"[{gameObject.name}] Key pressed: {key}");
                break;
        }
    }
}
