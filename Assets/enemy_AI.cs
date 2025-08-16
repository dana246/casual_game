using System.Collections;
using UnityEngine;

public class EnemyLogicController : MonoBehaviour
{
    public float delayTime = 2f;
    public int randomLimit;    // �ݺ� ����
    public GameObject enemy;            // Inspector���� ����: attack_power_player

    private attack_power playerAttackScript;

    void Start()
    {
        if (enemy != null)
        {
            playerAttackScript = enemy.GetComponent<attack_power>();
            if (playerAttackScript == null)
            {
                Debug.LogError("PlayerAttack ��ũ��Ʈ�� �����ϴ�!");
                return;
            }
        }
        else
        {
            Debug.LogError("Enemy ������ ��� �ֽ��ϴ�!");
            return;
        }

        StartCoroutine(EnemyLogicRoutine());
    }

    IEnumerator EnemyLogicRoutine()
    {
        while (true)
        {
            int value = playerAttackScript.ai_attack_power(); // �Լ� ȣ��

            Debug.Log("ai_attack_power: " + value);

            if (value >= randomLimit)
                yield break;

            yield return new WaitForSeconds(delayTime);
        }
    }
}
