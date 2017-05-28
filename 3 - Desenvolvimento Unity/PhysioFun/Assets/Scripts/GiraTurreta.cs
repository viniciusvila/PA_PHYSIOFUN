using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GiraTurreta : MonoBehaviour {

	public double maxesquerda; //165
	public double maxdireita;  //193
	public int velocidade ;
	public int vaiDireita = 1;
	public int vaiEsquerda = 0;
	// Use this for initialization

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {


			girarturreta ();


	}

	void girarturreta () {


		if ((vaiEsquerda == 1) && (vaiDireita == 0)) {
			transform.Rotate ((Vector3.up * Time.deltaTime * velocidade) * -1, Space.World);
			//Debug.Log ("ESQUERDA " + transform.rotation.eulerAngles.y);
		} else if ((vaiDireita == 1) && (vaiEsquerda == 0)) {
			transform.Rotate ((Vector3.up * Time.deltaTime * velocidade) * 1, Space.World);
			//Debug.Log ("DIREITA " + transform.rotation.eulerAngles.y);
		} 


		if (transform.rotation.eulerAngles.y < maxesquerda) {
			vaiDireita = 1;
			vaiEsquerda = 0;
			//Debug.Log ("DIREITA1 " + transform.rotation.eulerAngles.y);
		} else if (transform.rotation.eulerAngles.y > maxdireita) {
			vaiDireita = 0;
			vaiEsquerda = 1;
			//Debug.Log ("ESQUERDA1 " + transform.rotation.eulerAngles.y);
		}
	}

}