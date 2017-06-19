using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroiPowerUP : MonoBehaviour {

	private float timeVida;
	public int tipoPower;






	void Start () {
		

	}

	void Update () {
		
	}

	void OnCollisionEnter(Collision collision){
		

		if ((collision.gameObject.name == "joint_Char") && (tipoPower == 0)) {


			GameObject.Find ("GameController").GetComponent<GerenciadorPlacar> ().golsTomados -= 2;
			GameObject.Find ("GameController").GetComponent<GerenciadorPlacar> ().atualizarPontuacao ();

			AudioSource audio = GameObject.Find ("Bola_Sucesso").GetComponent<AudioSource> ();
			audio.Play ();


			Destroy (this.gameObject);
		} 

		if((collision.gameObject.name == "joint_Char") && (tipoPower == 1)) {

			GameObject.Find ("GameController").GetComponent<GerenciadorPlacar>().removerPonto (6);


			AudioSource audio = GameObject.Find ("Bola_Falha").GetComponent<AudioSource>();
			audio.Play();


			Destroy(this.gameObject);

		} 

	
	}




}