using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{

	[SerializeField] float steerSpeed = 200f;
	[SerializeField] float moveSpeed = 20f;
	[SerializeField] float speedUp = 30f;
	[SerializeField] float speedDown = 10f;
	[SerializeField] float speedChangeDuration = 5f;

	//use this to bring driver speed to the intial speed after --> speedUp/speedDown
	void speedBack()
	{
		moveSpeed = 20f;
	}

  void OnTriggerEnter2D(Collider2D other) 
	{
		if(other.tag == "SpeedUp"){
			moveSpeed = speedUp;
		}
		else if(other.tag == "SpeedDown"){
			moveSpeed = speedDown;
		}
		Invoke("speedBack", speedChangeDuration);
	}
	// Update is called once per frame
	void Update()
	{
		//* speed so that speed is equal to our var
		//* Time.deltaTime so that the time frame is = in each computer
		float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
		float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
		transform.Rotate(0, 0, -steerAmount);
		transform.Translate(0, moveAmount, 0);
	}
}
