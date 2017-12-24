using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate : MonoBehaviour {
    float speed = 1;
	void Update () {
        speed += 0.1f;
        transform.Rotate(0, 0, speed);
	}
}
