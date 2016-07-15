using UnityEngine;
using System.Collections;

public class BirdMovement : MonoBehaviour {

    Vector3 velocity = Vector3.zero;
  
    public Vector3 flapVelocity;
    public float flapSpeed = 100f;
    public float forwardSpeed = 1f;

    bool didFlap = false;

	void Start () {
	
	}
    void Update ()
    {
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0) )
        {
            didFlap = true;
        }
                
    }
	
    void FixedUpdate()
    {
        //gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.right * forwardSpeed);
        if (didFlap)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * flapSpeed);
            didFlap = false;
        }
        if (gameObject.GetComponent<Rigidbody2D>().velocity.y < 0)
        {
            float angle = Mathf.Lerp(0, -90, gameObject.GetComponent<Rigidbody2D>().velocity.y / 2f);
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }
    }

}