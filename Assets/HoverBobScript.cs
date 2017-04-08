using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverBobScript : MonoBehaviour {
    Vector3 initialPosition;
    float minimum;
    float maximum;

    // Use this for initialization
    void Start () {
        initialPosition = transform.position;
        minimum = initialPosition.y - 2;
        maximum = initialPosition.y + 2;
        Debug.Log(initialPosition);
	}

    // starting value for the Lerp
    float t = 0.0f;

    // Update is called once per frame
    void Update () {
        // animate the position of the game object...
        transform.position = new Vector3(initialPosition.x, Mathf.Lerp(minimum, maximum, t), 0);
        Debug.Log(transform.position);

        // .. and increate the t interpolater
        t += 0.5f * Time.deltaTime;

        // now check if the interpolator has reached 1.0
        // and swap maximum and minimum so game object moves
        // in the opposite direction.
        if (t > 1.0f)
        {
            float temp = maximum;
            maximum = minimum;
            minimum = temp;
            t = 0.0f;
        }
    }
}
