using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GiraTurreta : MonoBehaviour {

	public double maxesquerda;
	public double maxdireita;
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
		// Rotate the object around its local X axis at 1 degree per second
		//UP DOWN
		//transform.Rotate(Vector3.right * Time.deltaTime);

		// ...also rotate around the World's Y axis
		//transform.Rotate(Vector3.up * Time.deltaTime * velocidade, Space.World);

		/*if( (transform.rotation.eulerAngles.z < 180) && (transform.rotation.eulerAngles.z >= maxesquerda) ){
			transform.Rotate ((Vector3.up * Time.deltaTime * velocidade) * -1, Space.World);
		}else 
			if ( (transform.rotation.eulerAngles.z > 180) && (transform.rotation.eulerAngles.z <= maxdireita) ){
			transform.Rotate ((Vector3.up * Time.deltaTime * velocidade) * 1, Space.World);
		}*/



		if ((vaiEsquerda == 1) && (vaiDireita == 0)) {
			transform.Rotate ((Vector3.up * Time.deltaTime * velocidade) * -1, Space.World);
			Debug.Log ("ESQUERDA " + transform.rotation.eulerAngles.y);
		} else if ((vaiDireita == 1) && (vaiEsquerda == 0)) {
			transform.Rotate ((Vector3.up * Time.deltaTime * velocidade) * 1, Space.World);
			Debug.Log ("DIREITA " + transform.rotation.eulerAngles.y);
		} 


		if (transform.rotation.eulerAngles.y < maxesquerda) {
			vaiDireita = 1;
			vaiEsquerda = 0;
			Debug.Log ("DIREITA1 " + transform.rotation.eulerAngles.y);
		} else if (transform.rotation.eulerAngles.y > maxdireita) {
			vaiDireita = 0;
			vaiEsquerda = 1;
			Debug.Log ("ESQUERDA1 " + transform.rotation.eulerAngles.y);
		}
	}

}