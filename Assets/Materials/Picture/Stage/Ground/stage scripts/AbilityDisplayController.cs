using UnityEngine;

[System.Serializable]
public class AbilityDisplayItem
{
    [Tooltip("表示対象のオブジェクト")]
    public GameObject targetObject;

    [Tooltip("表示条件となる能力のインデックス (例: ビーム=1, 砲弾=2)")]
    public int requiredAbilityIndex;
}

public class AbilityDisplayController : MonoBehaviour
{
    [Tooltip("表示条件を設定するオブジェクトのリスト")]
    public AbilityDisplayItem[] displayItems;

    private PlayerScript player;

    void Start()
    {
        // プレイヤーキャラクターを取得
        player = FindObjectOfType<PlayerScript>();

        if (player == null)
        {
            Debug.LogError("PlayerScriptがシーン内に見つかりませんでした。");
            return;
        }

        // 初期状態で全てのオブジェクトを非表示にする
        foreach (var item in displayItems)
        {
            if (item.targetObject != null)
            {
                item.targetObject.SetActive(false);
            }
        }
    }

    void Update()
    {
        if (player == null) return;

        // 各オブジェクトに対して条件をチェックし、表示/非表示を切り替える
        foreach (var item in displayItems)
        {
            if (item.targetObject == null) continue;

            // 必要な能力をプレイヤーが持っているか確認
            if (item.requiredAbilityIndex >= 0 && item.requiredAbilityIndex < player.attackActivated.Length)
            {
                bool hasAbility = player.attackActivated[item.requiredAbilityIndex];
                item.targetObject.SetActive(hasAbility);
            }
            else
            {
                Debug.LogWarning($"指定された能力インデックス ({item.requiredAbilityIndex}) がプレイヤーのattackActivated配列の範囲外です。");
            }
        }
    }
}
