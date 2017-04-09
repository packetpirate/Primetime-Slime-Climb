using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeCamera : MonoBehaviour {
    public GameObject Player;
    public bool LockCameraLocation;

	// Use this for initialization
	void Start () {
        Player = GameObject.Find("Player");
    }
	
	// Update is called once per frame
	void Update () {
        if(!LockCameraLocation)
        {
            transform.position = new Vector3(this.gameObject.transform.position.x,
                                                    Player.transform.position.y,
                                                    -10);
        }

	}
    public void LockCamera()
    {
        LockCameraLocation = true;
    }
}
