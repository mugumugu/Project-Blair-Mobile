using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class screenJoystick : MonoBehaviour {
	public float moveSpeed = 8f;
    public FloatingJoystick joystickMove,joystickLook;
	public FirstPersonController firstPerson;
	public Camera c;

	void Start(){
		c = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
	}

	void Update () 
	{
		firstPerson.horizontal = joystickMove.Horizontal;
		firstPerson.vertical = joystickMove.Vertical;

		rotateCamera();
	}

	Quaternion originalRotation;

	float rotationX = 0,
		  rotationY = 0;

	void rotateCamera(){
		rotationX += joystickLook.Horizontal * moveSpeed;
		rotationY += joystickLook.Vertical * moveSpeed;

		c.transform.localEulerAngles = new Vector3(-rotationY,0,0);
		firstPerson.transform.localEulerAngles = new Vector3(0,rotationX,0);

	}
}
