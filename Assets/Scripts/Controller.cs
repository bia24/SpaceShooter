using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float xMin = -6.73f;
    public float xMax = 6.68f;
    public float zMin = -3.21f;
    public float zMax = 13.84f;
}

public class Controller : MonoBehaviour {

    public float speed = 10f;
    public Boundary boundary = new Boundary(); //范围限定条件

    public GameObject bolt;
    public Transform spawnPos;

    public float fireRate = 0.25f;//发射速率 4个/秒  ，时间间隔0.25s
    private float nextFireTime;//下次发射时间

    public AudioClip fire;
    private void Update()
    {
        if(Input.GetButton("Jump")&&nextFireTime<=Time.time)
        {
            nextFireTime = Time.time + fireRate;
            Instantiate(bolt,spawnPos.position,spawnPos.rotation);
            AudioSource audio = this.GetComponent<AudioSource>();
            audio.PlayOneShot(fire);
        }
    }

    private void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal"); //左右 x轴
        float v = Input.GetAxis("Vertical");// 前后 z轴
        

        Vector3 move = new Vector3(h, 0f, v);
        Rigidbody rb=this.GetComponent<Rigidbody>();
        rb.velocity = move * speed; //物体移动；
        rb.position = new Vector3(
            Mathf.Clamp(rb.position.x,boundary.xMin,boundary.xMax),
            0f,
            Mathf.Clamp(rb.position.z,boundary.zMin,boundary.zMax)
         );//限制物体移动在边界范围内
        
        

    }

}


