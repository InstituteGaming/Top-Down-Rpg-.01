using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceMouseController : MonoBehaviour {


    public float speed = 5f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        var direction = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rot = Quaternion.AngleAxis(angle, Vector3.forward);
        
        transform.rotation = Quaternion.Slerp(transform.rotation, rot, speed * Time.deltaTime);
		
	}
}
