using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class atirarProjetil : MonoBehaviour {

	public Rigidbody projetil;
	public Transform finaldoCano;
	public float forcaTiro;
	public double fireRate = 0.5;
	private double lastShot = 0.0;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if (Time.time > fireRate + lastShot)
		{
			Shoot ();
			lastShot = Time.time;
		}


	}
	void Shoot (){
//		if (Input.GetKeyDown (KeyCode.F)) {
			
		if (GameObject.Find ("GameController")
			.GetComponent<GerenciadorPlacar> ()
			.jogoterminado == 0) {
			Rigidbody projetilInstanciado;
			projetilInstanciado = Instantiate (projetil, finaldoCano.position, finaldoCano.rotation) as Rigidbody;

			projetilInstanciado.AddForce (finaldoCano.forward * forcaTiro); 
		}


//		}
	}
}
