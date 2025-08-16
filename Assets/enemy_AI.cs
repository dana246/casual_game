using System.Collections;
using UnityEngine;

public class EnemyLogicController : MonoBehaviour
{
    public float delayTime = 2f;
    public int randomLimit;    // 반복 간격
    public GameObject enemy;            // Inspector에서 연결: attack_power_player

    private attack_power playerAttackScript;

    void Start()
    {
        if (enemy != null)
        {
            playerAttackScript = enemy.GetComponent<attack_power>();
            if (playerAttackScript == null)
            {
                Debug.LogError("PlayerAttack 스크립트가 없습니다!");
                return;
            }
        }
        else
        {
            Debug.LogError("Enemy 슬롯이 비어 있습니다!");
            return;
        }

        StartCoroutine(EnemyLogicRoutine());
    }

    IEnumerator EnemyLogicRoutine()
    {
        while (true)
        {
            int value = playerAttackScript.ai_attack_power(); // 함수 호출

            Debug.Log("ai_attack_power: " + value);

            if (value >= randomLimit)
                yield break;

            yield return new WaitForSeconds(delayTime);
        }
    }
}
