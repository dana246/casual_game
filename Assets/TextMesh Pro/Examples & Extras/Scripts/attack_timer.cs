using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class attack_timer : MonoBehaviour
{
    public float startTime = 1.5f;   // 시작 시간 (둘 다 같은 값)
    private float currentTime;

    public TMP_Text playerTimerText; // 플레이어 타이머 UI
    public TMP_Text aiTimerText;     // AI 타이머 UI

    private bool finished = false;   // 되돌린 뒤 멈췄느지 표시
    void Start()
    {
        currentTime = startTime;
        UpdateUI();
    }

    void Update()
    {
        if (finished) return; // 이미 되돌리고 멈췄으면 더 이상 진행 x

        if (currentTime > 0f)
        {
            currentTime -= Time.deltaTime;
            if (currentTime < 0f) currentTime = 0f;
            UpdateUI();
        }

        // 0에 도달하면: 1) 0으로 보여줬다가 2) 시작값으로 되돌리고 3) 멈춤
        if (currentTime <= 0f && !finished)
        {
            // 1) 0 표시가 한 프레임이라도 보이게 이미 UpdateUI 됨
            // 2) 원상복귀
            currentTime = startTime;
            UpdateUI();

            // 3) 멈춤
            finished = true;
            // 성능상 더 깔끔히 하고싶으면
            // enabled = false;
        }
    }
            
    void UpdateUI()
    {
        string t = currentTime.ToString("F1");
        if (playerTimerText) playerTimerText.text = t;
        if (aiTimerText) aiTimerText.text = t;
    }
}
