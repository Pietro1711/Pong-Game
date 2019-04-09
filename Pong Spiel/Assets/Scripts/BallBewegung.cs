using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBewegung : MonoBehaviour {

    private Rigidbody2D rb;

    public GameObject Spieler1;
    public GameObject Spieler2;
    public float acceleration = 2f;

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
        float directionX = Random.Range(-1f, 1f);
        Vector3 temp = new Vector3(
            directionX,
            directionX / Random.Range(1f, 3f) * Mathf.Sign(Random.value-0.5f),
            0f).normalized;

        

        if (temp.x == 0) {
            temp.x = 1;
        }


        rb.velocity = new Vector2(0f, 0f);
        yield return new WaitForSeconds(2);
        rb.velocity = new Vector2(12 * temp.x, 8f * temp.y);
    }


     void OnCollisionEnter2D (Collision2D hit)
    {
        
        if(hit.gameObject.tag == "Spieler")
        {    
            if (hit.gameObject.GetComponent<Rigidbody2D>().velocity.y > 0.5f)
            {
                if (this.transform.position.x < 0) rb.velocity = new Vector2(Mathf.Abs(rb.velocity.x), 8f);
                else rb.velocity = new Vector2(-Mathf.Abs(rb.velocity.x), 8f);
            }
            else if (hit.gameObject.GetComponent<Rigidbody2D>().velocity.y < -0.5)
            {                
                if (this.transform.position.x < 0) rb.velocity = new Vector2(Mathf.Abs(rb.velocity.x), -8f);
                else rb.velocity = new Vector2(-Mathf.Abs(rb.velocity.x), -8f);
            }
            else
            {
                if (this.transform.position.x < 0) rb.velocity = new Vector2(Mathf.Abs(rb.velocity.x), 0f);
                else rb.velocity = new Vector2(-Mathf.Abs(rb.velocity.x), 0f);
            }
            acceleration += 0.2f;
        }

        

    }
}
