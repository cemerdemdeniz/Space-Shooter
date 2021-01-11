using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OyunKontrol : MonoBehaviour
{
    public GameObject Asteroid;
    public Vector3 randomPos;
    public float baslangıcbekleme;
    public float olusturmabekleme;
    public float dongubekleme;
    public Text text;
    public Text GameOverText;
    public Text RestartText;
    bool GameOverKontrol = false;
    bool RestartGameKontrol = false;
    int score;
    void Start()
    {
        
        score = 0;
        text.text = "SCORE =" + score;
        StartCoroutine(Olustur()); 
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && RestartGameKontrol)

        {
            SceneManager.LoadScene ("Level1");
        }   
    }
    IEnumerator Olustur()
    {
        yield return new WaitForSeconds(baslangıcbekleme);
        while (true)
        {
            for (int i = 0; i < 4; i++)

            {
                Vector3 vec = new Vector3(Random.Range(-randomPos.x, randomPos.x), 0, randomPos.z);
                Instantiate(Asteroid, vec, Quaternion.identity);
                yield return new WaitForSeconds(olusturmabekleme);
            }
            if (GameOverKontrol)
            {
                RestartText.text = "Yeniden Başlamak İçin R Tuşuna Basınız";
                RestartGameKontrol = true;
                
                break;
            }
            yield return new WaitForSeconds(dongubekleme);

           
        }
       
        
    }
    public void ScoreArttir(int gelenScore)
    {
        score += gelenScore;
        text.text = "SCORE =" + score;
       
    }
   
    public void GameOver()
    {
        GameOverText.text = "GAME OVER";
        GameOverKontrol = true;
    }


}
