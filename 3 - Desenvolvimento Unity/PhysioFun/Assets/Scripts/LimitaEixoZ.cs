using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitaEixoZ : MonoBehaviour {
	private GameObject boneco;

	float zMin = -4.5f;
	float zMax = -5.11f;


	// Use this for initialization
	void Start () {
		boneco = GameObject.FindGameObjectWithTag ("Boneco");
	}
	
	// Update is called once per frame
	void Update () {

		if (boneco.transform.position.z > zMin) {
			boneco.transform.position = new Vector3 (boneco.transform.position.x, boneco.transform.position.y, zMin);
			//boneco.transform.position = new Vector3 (0, 0, Mathf.Clamp (Time.time, zMax, zMin));
			Debug.Log ("mudando posicao");
		}

		if (boneco.transform.position.z < zMax) {
			boneco.transform.position = new Vector3 (boneco.transform.position.x, boneco.transform.position.y, zMax);
			//boneco.transform.position = new Vector3 (0, 0, Mathf.Clamp (Time.time, zMax, zMin));
			Debug.Log ("mudando posicao");
		}

	}
}
