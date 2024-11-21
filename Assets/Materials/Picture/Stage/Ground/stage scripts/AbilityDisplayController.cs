using UnityEngine;

[System.Serializable]
public class AbilityDisplayItem
{
    [Tooltip("�\���Ώۂ̃I�u�W�F�N�g")]
    public GameObject targetObject;

    [Tooltip("�\�������ƂȂ�\�͂̃C���f�b�N�X (��: �r�[��=1, �C�e=2)")]
    public int requiredAbilityIndex;
}

public class AbilityDisplayController : MonoBehaviour
{
    [Tooltip("�\��������ݒ肷��I�u�W�F�N�g�̃��X�g")]
    public AbilityDisplayItem[] displayItems;

    private PlayerScript player;

    void Start()
    {
        // �v���C���[�L�����N�^�[���擾
        player = FindObjectOfType<PlayerScript>();

        if (player == null)
        {
            Debug.LogError("PlayerScript���V�[�����Ɍ�����܂���ł����B");
            return;
        }

        // ������ԂőS�ẴI�u�W�F�N�g���\���ɂ���
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

        // �e�I�u�W�F�N�g�ɑ΂��ď������`�F�b�N���A�\��/��\����؂�ւ���
        foreach (var item in displayItems)
        {
            if (item.targetObject == null) continue;

            // �K�v�Ȕ\�͂��v���C���[�������Ă��邩�m�F
            if (item.requiredAbilityIndex >= 0 && item.requiredAbilityIndex < player.attackActivated.Length)
            {
                bool hasAbility = player.attackActivated[item.requiredAbilityIndex];
                item.targetObject.SetActive(hasAbility);
            }
            else
            {
                Debug.LogWarning($"�w�肳�ꂽ�\�̓C���f�b�N�X ({item.requiredAbilityIndex}) ���v���C���[��attackActivated�z��͈̔͊O�ł��B");
            }
        }
    }
}
