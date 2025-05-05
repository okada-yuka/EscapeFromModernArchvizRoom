using UnityEngine;

public class ExpandedKeypad: MonoBehaviour
{
        // public Transform target;  // Playerなど、追従対象
        // public Vector3 offset = new Vector3(0, 1.5f, 0);  // 追従する相対位置

    public Camera mainCamera;
    public GameObject expandedKeypad; // ExpandedKeypad をアサイン（Canvas + Keypad）

    public float distanceFromCamera = 1.0f;
    [SerializeField] GameObject itemBoxObject;

    void Update() {
        Vector3 forward = mainCamera.transform.forward;
        Vector3 cameraPosition = mainCamera.transform.position;

        // カメラ前方に位置調整
        expandedKeypad.transform.position = cameraPosition + forward * distanceFromCamera;

        // カメラの方向を向くように回転
        expandedKeypad.transform.rotation = Quaternion.LookRotation(forward, Vector3.up);
    }

    // 背景タップ時に閉じる
    public void Close() {
        this.gameObject.SetActive(false);
        itemBoxObject.SetActive(true);
    }
}
