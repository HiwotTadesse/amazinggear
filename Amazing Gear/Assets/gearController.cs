using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gearController : MonoBehaviour {

    float jumpForce = 7f;

    Rigidbody2D rigidbody;

    float speed = 20f;

    public GameObject box1;

    public GameObject box2;

    public GameObject box3;

    Vector3 pos1;

    Vector3 pos3;


    // Use this for initialization
    void Start () {

        rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.gravityScale = 0;
        pos1 = box1.transform.position;
        pos3 = box2.transform.position;
    }
	
	// Update is called once per frame
	void Update () {

 
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            rigidbody.gravityScale = 3;
            rigidbody.velocity = new Vector2(2f,  jumpForce) ;
            transform.Rotate(0f, 0f, speed * Time.deltaTime);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            rigidbody.gravityScale = 3;
            rigidbody.velocity = new Vector2(-2f, jumpForce);
            transform.Rotate(0f, 0f, -speed * Time.deltaTime);
        }
      
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "BoxCreater")
        {
         Spawner(col);
            ScoreManager.instance.IncrementScore();
        }
        else if(col.tag == "Box" || col.tag == "challenge")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        }
    }

    public void Spawner( Collider2D col)
    {
        Vector3 colpos;

        Vector3 lastPos = pos1;
        lastPos.y += 5f;
        pos1 = lastPos;

        int rand = Random.Range(0, 2);

        
            Instantiate(box1, new Vector3(box1.transform.position.x, lastPos.y, 0f), Quaternion.identity);
            Instantiate(box2, new Vector3(box2.transform.position.x, lastPos.y, 0f), Quaternion.identity);

            Instantiate(box3, new Vector3(Random.Range(-2.5f, 2.5f), lastPos.y - 1f,0f), Quaternion.identity);
            Instantiate(box3, new Vector3(Random.Range(-2.5f, 2.5f), lastPos.y - 3f, 0f), Quaternion.identity);
        


        colpos = new Vector3(col.transform.position.x, col.transform.position.y + 5f, 0f);
        col.transform.position = colpos;
    }
}
