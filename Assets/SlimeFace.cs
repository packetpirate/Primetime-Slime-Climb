using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeFace : MonoBehaviour {
    public Sprite[] slimeFaces;
     
	// Use this for initialization
	void Start () {
        slimeFaces = Resources.LoadAll<Sprite>("sprites/Slimetime");
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
