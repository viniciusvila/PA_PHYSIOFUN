using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroiPowerUP : MonoBehaviour {

	private float timeVida;
	public int tipoPower;
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
		


		if ((collision.gameObject.name == "joint_Char") || (collision.gameObject.name == "CUBO_COLISAO_ES") || (collision.gameObject.name == "CUBO_COLISAO_DT") && (tipoPower == 0)) {

			GameObject.Find ("GameController").GetComponent<GerenciadorPlacar> ().golsTomados -= 2;
			GameObject.Find ("GameController").GetComponent<GerenciadorPlacar> ().atualizarPontuacao ();

			AudioSource audio = GameObject.Find ("Bola_Sucesso").GetComponent<AudioSource> ();
			audio.Play ();


			Destroy (this.gameObject);
		} 

		if((collision.gameObject.name == "joint_Char") || (collision.gameObject.name == "CUBO_COLISAO_ES") || (collision.gameObject.name == "CUBO_COLISAO_DT")  && (tipoPower == 1)) {

			GameObject.Find ("GameController").GetComponent<GerenciadorPlacar>().removerPonto (6);


			AudioSource audio = GameObject.Find ("Bola_Falha").GetComponent<AudioSource>();
			audio.Play();


			Destroy(this.gameObject);

		} 

	
	}




}