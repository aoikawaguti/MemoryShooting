using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    // 弾のスピード
    private const int speed = 300;
    // 画面の一番上のy座標。画面外かどうかの判定に使用
    private float _screenTop;

    private Rigidbody2D _rb;

    // 弾が表示された時に呼び出される
    void OnEnable()
    {

        GetComponent<Rigidbody2D>().AddForce(new Vector3(speed, 0.0f,0.0f), ForceMode2D.Force);
    }

    // 弾が何らかのトリガーに当たった時に呼び出される
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            // 弾の削除。実際には非アクティブにする
            ObjectPool.instance.ReleaseGameObject(gameObject);
        }
    }
}
