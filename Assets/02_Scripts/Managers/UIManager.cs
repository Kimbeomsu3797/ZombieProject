using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    //�ʿ��� UI�� ��� �����ϰ� ������ �� �ֵ��� ����ϴ� UI �Ŵ���
    public static UIManager instance
        //�̱��� ���ٿ� ������Ƽ
    {
        get
        {
            if(m_instance == null)
            {
                m_instance = FindObjectOfType<UIManager>(); //this
            }

            return m_instance;
        }
    }
    private static UIManager m_instance; // �̱����� �Ҵ�� ����

    public Text ammoText;
    public Text scoreText;
    public Text waveText;
    public GameObject gameoverUI;
    public Text EnemyText;
    public void UpdateAmmoText(int magAmmo, int remainAmmo) 
    { ammoText.text = magAmmo + "/" + remainAmmo; }
    public void UpdateScoreText(int Score)
    {
        scoreText.text = Score + "��";
    }
    public void UpdateWaveText(int Wave, int MaxWave)
    {
        waveText.text = Wave + "/" + MaxWave;
    }
    /*public void UpdateEnemyText(int Enemy, int MaxEnemy)
    {
        EnemyText.text = Enemy + "/" + MaxEnemy;
    }*/
    public void SetActiveGameoverUI(bool active)
    {
        gameoverUI.SetActive(active);
    }
    public void GameRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    void Start()
    {
        //������ �� ���ӿ���ui�� ����
    }

    void Update()
    {
        //�÷��̾��� ���°� ���� ���¶�� ���ӿ���uiȰ��ȭ
    }
    
}
