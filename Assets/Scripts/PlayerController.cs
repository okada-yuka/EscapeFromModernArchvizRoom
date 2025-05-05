using UnityEngine;

public class PlayerController : MonoBehaviour {
    float speed = 5f;
    float turnSpeed = 300f;
    float move;
    float turn;

    void Update() {
        // ↑の場合1、↓の場合-1、入力なしの場合0
        move = Input.GetAxis("Vertical");
        // ←の場合、1、右の場合-1
        turn = Input.GetAxis("Horizontal");

        // Time.deltaTime はフレームレートに依存しない動きを実現するために必要
        transform.Translate(Vector3.forward * move * speed * Time.deltaTime);
        transform.Rotate(Vector3.up, turn * turnSpeed * Time.deltaTime);
    }
}