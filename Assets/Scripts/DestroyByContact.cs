using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour
{

    public GameObject astroidExplosion;
    public GameObject playerExplosion;
    public GameObject enemyExplosion;
    public int destroyScore = 10;
    private GameController gameController;

    private void Start()
    {
        GameObject gameControllerObject = GameObject.Find("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        else
        {
            Debug.Log("Can not find GameController GameObject");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Boundary")
        {
            return;
        }
        if (other.gameObject.tag == "Enemy" && this.tag == "Enemy")
        {
            return;
        }
        if (other.gameObject.tag == "Enemy"&&this.tag=="Asteroid")
        {
            return;
        }
        if (other.gameObject.tag == "Asteroid" && this.tag == "Enemy")
        {
            return;
        }
        if (this.gameObject.tag == "Asteroid" || this.gameObject.tag == "Enemy")
        {
            if (other.gameObject.tag == "Player")
            {
                Instantiate(playerExplosion, this.transform.position, this.transform.rotation);
                gameController.GameOver();//游戏结束
                Destroy(other.gameObject);
                Destroy(this.gameObject);
                gameController.AddScore(destroyScore);
                return;
            }
            else if(other.gameObject.tag!="EnemyBolt")//被子弹摧毁
            {
                if(this.gameObject.tag == "Asteroid")
                {
                    Instantiate(astroidExplosion, this.transform.position, this.transform.rotation);
                    Destroy(other.gameObject);
                    Destroy(this.gameObject);
                    gameController.AddScore(destroyScore);
                }
                if(this.gameObject.tag == "Enemy")
                {
                    Instantiate(enemyExplosion, this.transform.position, this.transform.rotation);
                    Destroy(other.gameObject);
                    Destroy(this.gameObject);
                    gameController.AddScore(destroyScore);
                }
                return;
            }
        }

        if (this.gameObject.tag == "Player")
        {
            Instantiate(playerExplosion, this.transform.position, this.transform.rotation);
            gameController.GameOver();//游戏结束
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
        return;

       
    }
}