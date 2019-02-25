using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBewegung : MonoBehaviour {

    private Rigidbody2D rb;

    public GameObject Spieler1;
    public GameObject Spieler2;

	// Use this for initialization
	void Start () {

        rb = GetComponent<Rigidbody2D>();

        Spieler1 = GameObject.Find("Spieler 1");
        Spieler2 = GameObject.Find("Spieler 2");

        Punktezähler.canAddScore = true;
        StartCoroutine(Pause());

	}
	
	// Update is called once per frame
	void Update () {

        if (Mathf.Abs(this.transform.position.x) >= 21f) {

            Punktezähler.canAddScore = true;

            this.transform.position = new Vector3(0f, 0f, 0f);
            StartCoroutine(Pause());
        }
        

	}

    IEnumerator Pause() {

        int directionX = Random.Range(-1, 2);
        int directionyY = Random.Range(-1, 2);

        

        if (directionX == 0) {
            directionX = 1;

        }


        rb.velocity = new Vector2(0f, 0f);
        yield return new WaitForSeconds(2);
        rb.velocity = new Vector2(12f * directionX, 8f * directionyY);
    }

     void OnCollisionEnter2D (Collision2D hit)
    {
        
        if(hit.gameObject.name == "Spieler 1")
        {
            if(Spieler1.GetComponent<Rigidbody2D> ().velocity.y > 0.5f) 
            {
                rb.velocity = new Vector2(8f, 8f);

            }else if (Spieler1.GetComponent<Rigidbody2D> ().velocity.y < -0.5) {

                rb.velocity = new Vector2(8f, -8f);

            }else {

                rb.velocity = new Vector2(12f, 0f);

            }
        }

        if (hit.gameObject.name == "Spieler 2")
        {
            if (Spieler2.GetComponent<Rigidbody2D>().velocity.y > 0.5f) 
            {
                rb.velocity = new Vector2(-8f, 8f);

            }else if (Spieler2.GetComponent<Rigidbody2D>().velocity.y < -0.5) {

                rb.velocity = new Vector2(-8f, -8f);

            }else {

                rb.velocity = new Vector2(-12f, 0f);

            }
        }
    }
}
