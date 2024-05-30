using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stuffs_tester : MonoBehaviour {

	public GameObject[] stuffs;
	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
		stuffs[0].transform.RotateAround (Vector3.up, Time.deltaTime);
		stuffs[1].transform.RotateAround (Vector3.up, -Time.deltaTime);
		stuffs[2].transform.RotateAround (Vector3.up, Time.deltaTime);
		stuffs[3].transform.RotateAround (Vector3.up, -Time.deltaTime);
		stuffs[4].transform.RotateAround (Vector3.up, Time.deltaTime);
		stuffs[5].transform.RotateAround (Vector3.up, -Time.deltaTime);
		stuffs[6].transform.RotateAround (Vector3.up, Time.deltaTime);
		stuffs[7].transform.RotateAround (Vector3.up, -Time.deltaTime);
		stuffs[8].transform.RotateAround (Vector3.up, Time.deltaTime);
		stuffs[9].transform.RotateAround (Vector3.up, -Time.deltaTime);
	
	}
}
