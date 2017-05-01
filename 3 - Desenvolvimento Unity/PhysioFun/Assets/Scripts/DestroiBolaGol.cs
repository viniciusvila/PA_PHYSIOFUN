using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroiBolaGol : MonoBehaviour {

	private float timeVida;
	public float tempoMaximoVida;

	void Start () {
		timeVida = 0;
	}

	void Update () {
		timeVida += Time.deltaTime;
		if (timeVida >= tempoMaximoVida) {
			Destroy (gameObject);
			timeVida = 0;
		}
	}

	void OnCollisionEnter(Collision collision){
		if(collision.gameObject.name == "Gol"){
			Destroy(this.gameObject);
		}
	}


}