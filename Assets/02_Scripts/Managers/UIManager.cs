using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    //필요한 UI에 즉시 접근하고 변경할 수 있도록 허용하는 UI 매니저
    public static UIManager instance
        //싱글톤 접근용 프로퍼티
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
    private static UIManager m_instance; // 싱글톤이 할당될 변수

    public Text ammoText;
    public Text scoreText;
    public Text waveText;
    public GameObject gameoverUI;
    public Text EnemyText;
    public void UpdateAmmoText(int magAmmo, int remainAmmo) 
    { ammoText.text = magAmmo + "/" + remainAmmo; }
    public void UpdateScoreText(int Score)
    {
        scoreText.text = Score + "점";
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
        //시작할 때 게임오버ui를 끄고
    }

    void Update()
    {
        //플레이어의 상태가 죽은 상태라면 게임오버ui활성화
    }
    
}
