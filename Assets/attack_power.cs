using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class attack_power : MonoBehaviour
{
    public int max_num, min_num;
    int pAttackPower, aAttackPower;
    public TextMeshProUGUI pAttackPowerText;
    public TextMeshProUGUI aAttackPowerText;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightShift))
        {
            player_attack_power();
        }
    }

    public int player_attack_power()
    {
        pAttackPower =  Random.Range(min_num, max_num);
        pAttackPowerText.text = pAttackPower.ToString();
        return pAttackPower;
    }

    public int ai_attack_power()
    {
        aAttackPower = Random.Range(min_num, max_num);
        aAttackPowerText.text = aAttackPower.ToString();
        return aAttackPower;
    }
}
