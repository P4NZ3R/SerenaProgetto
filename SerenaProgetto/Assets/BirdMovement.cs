using UnityEngine;
using System.Collections;

public class BirdMovement : MonoBehaviour {

    Vector3 velocity = Vector3.zero;
    public Vector3 gravity;
    public Vector3 flapVelocity;
    public float maxSpeed = 5f;

    bool didFlap = false;

	void Start () {
	
	}
	
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)   ||  Input.GetMouseButtonDown(0) )
        {
            didFlap = true;
        }
    }
    


	void FixedUpdate () 
    {
        velocity += gravity * Time.deltaTime;
        if (didFlap == true)
        {
            didFlap = false;
            velocity += flapVelocity;  
        }

        velocity = Vector3.ClampMagnitude(velocity, maxSpeed);
        transform.position += velocity * Time.deltaTime;
        float angle = 0; 
        if(velocity.y < 0)
        {
            angle = Mathf.Lerp(0, -90, -velocity.y / maxSpeed);
        }        

        transform.rotation = Quaternion.Euler(0, 0, angle);
        
    }

}