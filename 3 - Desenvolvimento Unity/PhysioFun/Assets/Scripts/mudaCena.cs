using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mudaCena : MonoBehaviour {

	// Use this for initialization
	public void mudarCena () {
		SceneManager.LoadScene ("MenuInicial");
	}

}
