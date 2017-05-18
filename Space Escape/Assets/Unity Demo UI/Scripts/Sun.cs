using UnityEngine;
using System.Collections;

public class Sun : MonoBehaviour {
     LensFlare flare;

	// Use this for initialization
	void Start () {
        flare = gameObject.GetComponent<LensFlare>();
        flare.color = Color.red;
	}
}
