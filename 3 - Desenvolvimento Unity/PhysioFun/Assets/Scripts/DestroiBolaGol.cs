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

			GameObject.Find ("GameController")
				.GetComponent<GerenciadorPlacar>()
				.addPonto (3);


			Destroy (gameObject);
			timeVida = 0;
		}
	}

	void OnCollisionEnter(Collision collision){
		if(collision.gameObject.name == "Gol"){

			GameObject.Find ("GameController")
				.GetComponent<GerenciadorPlacar>()
				.removerPonto (5);
			
			Destroy(this.gameObject);
		}
	}


}