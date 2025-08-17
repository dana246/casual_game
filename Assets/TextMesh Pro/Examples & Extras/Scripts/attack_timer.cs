using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class attack_timer : MonoBehaviour
{
    public float startTime = 1.5f;   // ���� �ð� (�� �� ���� ��)
    private float currentTime;

    public TMP_Text playerTimerText; // �÷��̾� Ÿ�̸� UI
    public TMP_Text aiTimerText;     // AI Ÿ�̸� UI

    private bool finished = false;   // �ǵ��� �� ������� ǥ��
    void Start()
    {
        currentTime = startTime;
        UpdateUI();
    }

    void Update()
    {
        if (finished) return; // �̹� �ǵ����� �������� �� �̻� ���� x

        if (currentTime > 0f)
        {
            currentTime -= Time.deltaTime;
            if (currentTime < 0f) currentTime = 0f;
            UpdateUI();
        }

        // 0�� �����ϸ�: 1) 0���� ������ٰ� 2) ���۰����� �ǵ����� 3) ����
        if (currentTime <= 0f && !finished)
        {
            // 1) 0 ǥ�ð� �� �������̶� ���̰� �̹� UpdateUI ��
            // 2) ���󺹱�
            currentTime = startTime;
            UpdateUI();

            // 3) ����
            finished = true;
            // ���ɻ� �� ����� �ϰ������
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
