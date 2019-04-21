using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{


    //死亡時の爆発オブジェクト
    public GameObject Explosion;
    //弾丸オブジェクト
    public GameObject bullet;
    //発射間隔
    const float shotDelay = 0.5f;
    //死にフラグ
    bool isDead = false;

    bool Deadplayed　=false;

    float deadAnim = 0.0f;

    private AudioSource audioSource;


    // 移動スピード
    const float speed = 5;

    void Start()
    {

        audioSource = gameObject.GetComponent<AudioSource>();

        Deadplayed = false;

        isDead = false;

        deadAnim = 0;
        // 弾をうつ（コルーチン）
        StartCoroutine(Shoot());
    }
    
    //玉の射出部。メイン
    IEnumerator Shoot()
    {

        while (isDead == false)
        { 
                // shotDelay秒待つ
                yield return new WaitForSeconds(shotDelay);
                //玉を射出
                ObjectPool.instance.GetGameObject(bullet, transform.position, transform.rotation);
        }
        
    }

    void Update()
    {
        //死んだら爆発アニメーション生成しゲームオーバー画面に
        if (isDead == true)
        {
            
            // 移動する向きを求める
            Vector2 direction = new Vector2(0.0f, 0.0f).normalized;

            // 移動する向きとスピードを代入する
            GetComponent<Rigidbody2D>().velocity = direction * speed;

            if (Deadplayed == false)
            {
                //死亡時のアニメーション
                Instantiate(Explosion, transform.position, transform.rotation);
                //音再生
                audioSource.Play();
            }
            deadAnim += Time.deltaTime;
            Deadplayed = true;
        }
        else {
            // 右・左への移動
            float x = Input.GetAxisRaw("Horizontal");

            // 上・下への移動
            float y = Input.GetAxisRaw("Vertical");

            // 移動する向きを求める
            Vector2 direction = new Vector2(x, y).normalized;

            // 移動する向きとスピードを代入する
            GetComponent<Rigidbody2D>().velocity = direction * speed;
        }
        //死んでから三秒経過
        if (deadAnim >= 3.0f)
        {
            SceneManager.LoadScene("GameOver");
        }
    }
    //プレイヤーが敵にヒットすると起動
    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "Enemy")
        {


            isDead = true;

        }
    }

}
