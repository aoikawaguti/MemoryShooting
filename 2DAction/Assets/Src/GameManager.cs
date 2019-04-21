using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public GameObject Ene;

    float summonDelay = 0.5f;



    // 移動スピード
    public float speed = 5;

    void Start()
    {
        // 敵を出す（コルーチン）
        StartCoroutine(Summon());
    }

    IEnumerator Summon()
    {
        while (true)
        {

            // summonDelay秒待つ
            yield return new WaitForSeconds(summonDelay);

            //敵出現
            ObjectPool.instance.GetGameObject(Ene, new Vector2(10.0f,Random.Range(-5,5)),transform.rotation);

        }
    }
}
