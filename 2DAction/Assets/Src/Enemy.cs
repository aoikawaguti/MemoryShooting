using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    // 弾のスピード
    private const int speed = -300;

    // 弾が表示された時に呼び出される
    void OnEnable()
    {
       GetComponent<Rigidbody2D>().AddForce(new Vector3(speed, 0.0f, 0.0f), ForceMode2D.Force);
    }

    // 弾が何らかのトリガーに当たった時に呼び出される
    void OnTriggerEnter2D(Collider2D other)
    {
        
        // 弾の削除。実際には非アクティブにする
        ObjectPool.instance.ReleaseGameObject(gameObject);
    }
}
