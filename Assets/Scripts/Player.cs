using UnityEngine;
using System.Collections;


public class Player : MonoBehaviour {
	CharacterController cc;
	
	public KeyCode forward = KeyCode.RightArrow;
	public KeyCode backward = KeyCode.LeftArrow;
	public KeyCode jump = KeyCode.UpArrow;
	public KeyCode drop = KeyCode.DownArrow;
	public float moveSpeed = 4.0f; // meters per second
	public float jumpLength = 2.0f; // jump lifetime in seconds
	public float jumpForce = 13.0f;	// how much upwards force is applied initially (decays over lifetime)
	float jumpedAt = 0.0f;
	float curVelocity = 0.0f;
	
	// Use this for initialization
	void Start () {
		cc = GetComponent<CharacterController>();
		jumpedAt = -jumpLength;
	}
	
	// Update is called once per frame
	void Update () {
		if (cc.isGrounded && Input.GetKeyDown(jump)) {
			jumpedAt = Time.time;
		}
		if (Input.GetKey(forward)) {
			transform.forward = Vector3.right;
			cc.Move(transform.forward*moveSpeed*Time.deltaTime);
		}
		else if (Input.GetKey(backward)) {
			transform.forward = -Vector3.right;
			cc.Move(transform.forward*moveSpeed*Time.deltaTime);
		}
		
		
		if (Time.time - jumpedAt <= jumpLength) {
			float curForce = Mathf.Lerp(jumpForce, 0.0f, (Time.time-jumpedAt)/jumpLength);
			curVelocity = curForce;
		}
		if (!cc.isGrounded) {
			curVelocity -= 9.8f;
		}
		curVelocity = Mathf.Clamp(curVelocity, -9.8f, 100.0f);
		
		if (curVelocity != 0.0f) {
			cc.Move(transform.up*curVelocity*Time.deltaTime);
		}
	}
	
	
	void OnGUI() {
		GUI.Label(new Rect(10.0f, 10.0f, 256.0f, 32.0f), "Grounded: " + ((cc.isGrounded)?"Yes":"No"));
		GUI.Label(new Rect(10.0f, 44.0f, 256.0f, 32.0f), "Velocity: " + curVelocity);
	}
}
