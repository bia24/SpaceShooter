using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class EnemyAI : MonoBehaviour {

    private Vector3 startVector;
    public float foward=1f;
    public float right=1f;
    public float speed = 10f;
    public float changeXTime = 1f;
    public float shootTime = 1f;
    private float nextShootTime;
    public GameObject enemyBolt;
    public AudioClip enemyShoot;
    public Transform SpawnPos;
    public Boundary boundary;

    

    // Use this for initialization
    void Start () {
        startVector = new Vector3(Random.Range(-right, right), 0, -foward);
        this.GetComponent<Rigidbody>().velocity = startVector * speed;
        StartCoroutine(ChangeX());
        Instantiate(enemyBolt, SpawnPos.position, SpawnPos.rotation);
        AudioSource audio = this.GetComponent<AudioSource>();
        audio.PlayOneShot(enemyShoot);
        nextShootTime = Time.time+shootTime;
	}
	
	// Update is called once per frame
	void Update () {
        if (nextShootTime < Time.time)
        {
            Instantiate(enemyBolt, SpawnPos.position, SpawnPos.rotation);
            AudioSource audio = this.GetComponent<AudioSource>();
            audio = this.GetComponent<AudioSource>();
            audio.PlayOneShot(enemyShoot);
            nextShootTime = Time.time + shootTime;
        }
        Transform tr = this.GetComponent<Transform>();
        tr.position = new Vector3(
            Mathf.Clamp(tr.position.x, boundary.xMin, boundary.xMax),
            0f,
            Mathf.Clamp(tr.position.z, -99, boundary.zMax)
         );//限制物体移动在边界范围内
    }

    IEnumerator ChangeX()
    {
        yield return new WaitForSeconds(Random.Range(0,changeXTime));
        while (true)
        {
            startVector = new Vector3(-startVector.x, 0, startVector.z);
            this.GetComponent<Rigidbody>().velocity = startVector * speed;
            yield return new WaitForSeconds(Random.Range(0, changeXTime));
        }
    }

}
