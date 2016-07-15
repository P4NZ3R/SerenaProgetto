using UnityEngine;
using System.Collections;

public class BirdMovement : MonoBehaviour {

    Vector3 velocity = Vector3.zero;
  
    public Vector3 flapVelocity;
    public float flapSpeed = 100f;
    public float forwardSpeed = 1f;

    bool didFlap = false;
    bool isAlive = true;
	void Start () {
	
	}
    void Update ()
    {
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0) && isAlive)
        {
            didFlap = true;
        }
                
    }
	
    void FixedUpdate()
    {
        if (isAlive)
        {
            //gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.right * forwardSpeed);
            if (didFlap)
            {
                gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * flapSpeed);
                didFlap = false;
            }
            if (gameObject.GetComponent<Rigidbody2D>().velocity.y > 0)
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
                
            }
            else
            {
                float angle = Mathf.Lerp(0, -90, gameObject.GetComponent<Rigidbody2D>().velocity.y / 2f);
                transform.rotation = Quaternion.Euler(0, 0, angle);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("death");
        isAlive = false;
        Invoke("ReloadGame", 1f);
        Time.timeScale = 0.5f;
    }

    void ReloadGame()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
}