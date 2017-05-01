using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GiraTurreta : MonoBehaviour {

	public int ladoturreta;
	public double maxesquerda;
	public double maxdireita;
	public int velocidade ;
	private int girar=1;
	// Use this for initialization

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		// Rotate the object around its local X axis at 1 degree per second
		//UP DOWN
		//transform.Rotate(Vector3.right * Time.deltaTime);

		// ...also rotate around the World's Y axis
		//transform.Rotate(Vector3.up * Time.deltaTime * velocidade, Space.World);

		if ((transform.rotation.eulerAngles.z > maxdireita) && (ladoturreta == 0) && (girar == 1)) {

			transform.Rotate ((Vector3.up * Time.deltaTime * velocidade) * -1, Space.World);

			if (transform.rotation.eulerAngles.z > maxdireita) {
				girar = 0;
			}
		}
		/*	else if ( (transform.rotation.eulerAngles.z > maxdireita) && (ladoturreta ==0) ){
			transform.Rotate(Vector3.up * Time.deltaTime * velocidade, Space.World);
		
		}*/


		if( (transform.rotation.eulerAngles.z > maxdireita) && (ladoturreta ==1) ){
			transform.Rotate(Vector3.up * Time.deltaTime * velocidade, Space.World);
		}
	}
}