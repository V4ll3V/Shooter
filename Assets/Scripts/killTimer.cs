using UnityEngine;
using System.Collections;

public class killTimer : MonoBehaviour {
	public float lifespan = 3.0f;
	
	// Use this for initialization
	void Start () {
		Destroy(gameObject, lifespan);
	}
}
