using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public GameObject [] astroids;
    public GameObject enemy;
    public Vector3 createAstroidPostionValue;

    public float startWaitTime = 3f;
    public int numPerWave = 10;
    public float createWaitTime = 1f;
    public float waveWaitTime = 5f;
    private bool gameOver = false;
    private int score=0;
	// Use this for initialization
	void Start () {
        Debug.Log("Space Shooter Game Start.!!!");
        StartCoroutine(CreateWave());
        StartCoroutine(CreateWaveEnemy());
        GameObject.Find("ScoreText").GetComponent<Text>().text = "Score: " + score;
        GameObject.Find("GameOverText").GetComponent<Text>().text = "";
        GameObject.Find("ReplayText").GetComponent<Text>().text = "";
    }


    private void Update()
    {
        if (gameOver && Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("SpaceShooterGame", LoadSceneMode.Single);
        }
    }



    IEnumerator CreateWave()
    {
        yield return new WaitForSeconds(startWaitTime);

        while (true)
        {
            for (int i = 0; i < numPerWave; i++)
            {
                if (gameOver == true)
                    yield break;
                CreateAstroid();
                //产生一个陨石后需要间隔一下
                 yield return new WaitForSeconds(Random.Range(createWaitTime / 2, createWaitTime));
            }
            yield return new WaitForSeconds(Random.Range(waveWaitTime / 2, waveWaitTime));
        }
    }

    IEnumerator CreateWaveEnemy()
    {
        yield return new WaitForSeconds(startWaitTime);
        while (true)
        {
            if (gameOver == true)
                yield break;
            CreateEnemy();
            yield return new WaitForSeconds(Random.Range(createWaitTime / 2, createWaitTime));
        }
    }




    void CreateAstroid()
    {
        GameObject astroid = astroids[Random.Range(0,astroids.Length)]; //在陨石库中随机生成一个陨石
        Vector3 createPosition = new Vector3(Random.Range(-createAstroidPostionValue.x, createAstroidPostionValue.x),
            1,
            createAstroidPostionValue.z);//产生一个随机位置
        Quaternion createRotate = Quaternion.identity;//产生一个随机角度
        Instantiate(astroid, createPosition, createRotate);//生成一个副本实例
    }


    void CreateEnemy()
    {
        Vector3 createPosition = new Vector3(Random.Range(-createAstroidPostionValue.x, createAstroidPostionValue.x),
            0,
            createAstroidPostionValue.z);//产生一个随机位置
        Quaternion createRotate = Quaternion.identity;//产生一个随机角度
        Instantiate(enemy, createPosition, enemy.GetComponent<Transform>().rotation);
    }


    public void  AddScore(int v)
    {
        score += v;
        GameObject.Find("ScoreText").GetComponent<Text>().text = "Score: " + score;
    }

    public void GameOver()
    {
        gameOver = true;
        GameObject.Find("GameOverText").GetComponent<Text>().text = "Game over ! ";
        GameObject.Find("ReplayText").GetComponent<Text>().text = "Press 'R' to play again.";
    }

}
