using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FenceScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        var slimePosition = GetComponent<Movement>();
        slimePosition.GetPosition();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
