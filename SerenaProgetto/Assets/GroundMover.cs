﻿using UnityEngine;
using System.Collections;

public class GroundMover : MonoBehaviour {
    
    float speed = -2f;
	void FixedUpdate () 
    {
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
	}
}
