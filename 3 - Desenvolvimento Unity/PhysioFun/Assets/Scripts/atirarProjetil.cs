using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class atirarProjetil : MonoBehaviour {

	public Rigidbody projetil;
	public Rigidbody projetilVida;
	public Rigidbody projetilBomba;
	public Transform finaldoCano;
	public float forcaTiro;
	public double fireRate = 0.5;
	private double lastShot = 0.0;
	// Use this for initialization

	public Component controlador;

	void Start () {
		controlador = GameObject.Find ("GameController").GetComponent<GerenciadorPlacar> ();
	}

	// Update is called once per frame
		void Update () {
		if ((Time.time > fireRate + lastShot) && ( controlador.GetComponent<GerenciadorPlacar>().jogoAtivo == 1))
		{
			Shoot ();
			lastShot = Time.time;
		}


	} 
	void Shoot (){

		//if (Input.GetKeyDown (KeyCode.F)) {
		if ((controlador.GetComponent<GerenciadorPlacar> ().jogoterminado == 0)  && (controlador.GetComponent<GerenciadorPlacar> ().comboDefesa >= 4) 
			&& (controlador.GetComponent<GerenciadorPlacar> ().golsTomados < 4)  && (controlador.GetComponent<GerenciadorPlacar> ().bombaAtivo <= 0) )
			{
				Rigidbody projetilInstanciado;
				projetilInstanciado = Instantiate (projetilBomba, finaldoCano.position, Quaternion.Euler(180, 0, 0)) as Rigidbody;
				projetilInstanciado.AddForce (finaldoCano.forward * forcaTiro); 

			controlador.GetComponent<GerenciadorPlacar> ().bombaAtivo = 5;
			
		}else if ((controlador.GetComponent<GerenciadorPlacar> ().jogoterminado == 0)  && (controlador.GetComponent<GerenciadorPlacar> ().golsTomados >= 4)
			&& (controlador.GetComponent<GerenciadorPlacar> ().coracaoAtivo <= 0))
			{
				Rigidbody projetilInstanciado;
				projetilInstanciado = Instantiate (projetilVida, finaldoCano.position, Quaternion.Euler(-90, 0, 0) ) as Rigidbody;

				projetilInstanciado.AddForce (finaldoCano.forward * forcaTiro); 
				controlador.GetComponent<GerenciadorPlacar> ().coracaoAtivo = 0;
				controlador.GetComponent<GerenciadorPlacar> ().coracaoAtivo = 5;


		}else if (controlador.GetComponent<GerenciadorPlacar> ().jogoterminado == 0)  
			{
				Rigidbody projetilInstanciado;
				projetilInstanciado = Instantiate (projetil, finaldoCano.position, finaldoCano.rotation) as Rigidbody;

				controlador.GetComponent<GerenciadorPlacar> ().bombaAtivo -= 1;
				controlador.GetComponent<GerenciadorPlacar> ().coracaoAtivo -= 1;

				projetilInstanciado.AddForce (finaldoCano.forward * forcaTiro); 
			}
		//}

		/*
		//********************************************************
		// CODIGO ABAIXO USADO PARA TESTES ---- Q = GOL / E = DEFESA
		if (Input.GetKeyDown (KeyCode.Q)) {
			GameObject.Find ("GameController")
				.GetComponent<GerenciadorPlacar>()
				.removerPonto (5);

			AudioSource audio = GameObject.Find ("Bola_Falha").GetComponent<AudioSource>();
			audio.Play();

		}
		if (Input.GetKeyDown (KeyCode.E)) {
			GameObject.Find ("GameController")
				.GetComponent<GerenciadorPlacar>()
				.addPonto (3);

			AudioSource audio = GameObject.Find ("Bola_Sucesso").GetComponent<AudioSource>();
			audio.Play();
		//********************************************************
		*/

		//}
	


	}
}
