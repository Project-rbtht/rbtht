using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBase : MonoBehaviour, Idamagable
{
    // Start is called before the first frame update
    public int healthPoint = 20;
    public int attack = 1;
    private SpriteRenderer spriteRenderer;
    public float flashDuration = 0.1f; // 点滅する際の白くなる時間
    public int flashCount = 4; // 点滅回数
    public float flashInterval = 0.5f; // 点滅の間隔（白から元の色に戻る間隔）
    private Color originalColor;
    public GameObject damageEffect;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color; // 元の色を保存
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Damage(int value)//ダメージ処理
    {
        UnityEngine.Debug.Log("on Damage");
        healthPoint -= value;//HPをvalueのぶんだけ減らす
        Instantiate(damageEffect, transform.position, transform.rotation);
        Debug.Log("hp = " + healthPoint);
        if (healthPoint <= 0)
        {//HPが0以下になったら死
            Death();
        }
        else
        {
            StartCoroutine(FlashWhiteMultipleTimes());
        }
    }

    IEnumerator FlashWhiteMultipleTimes()
    {
        for (int i = 0; i < flashCount; i++)
        {
            // スプライトを白に変更
            spriteRenderer.color = Color.black;

            // 少しの間白くしたままにする
            yield return new WaitForSeconds(flashDuration);

            // 元の色に戻す
            spriteRenderer.color = originalColor;

            // 次の点滅まで待機
            yield return new WaitForSeconds(flashInterval);
        }
    }

    public virtual void Death()
    {
        Destroy(this.gameObject);
        UnityEngine.Debug.Log("on Death");
    }
}
