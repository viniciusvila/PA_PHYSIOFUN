using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GerenciadorPlacar : MonoBehaviour {
	public Text gols;
	public Text defesas;
	public Text score;

	public int pontuacaoTotal = 0; 
	public int golsTomados = 0 ;
	public int bolasDefendidas = 0;
	public int pontosVitoria;
	public int pontosDerrota;
	public AudioClip Bola_falha;
	AudioSource audio;


	public void addPonto(int valor) {
		pontuacaoTotal += valor;
		bolasDefendidas += 1;
		atualizarPontuacao ();
	}


	private float timeVida = 10f;
	private int voltaMenu = 0;
	void Start () {
		
	}

	void Update () {
		if (voltaMenu == 1) {
			timeVida -= Time.deltaTime;
			if (timeVida <= 0) {
				SceneManager.LoadScene ("MenuInicial");
				Debug.Log (timeVida);

			}
		}
	}

	public void removerPonto(int valor) {
		pontuacaoTotal -= valor;
		golsTomados += 1;
		atualizarPontuacao ();

	}

	public void atualizarPontuacao () {
		gols.text = "Gols Levados: " + golsTomados;
		defesas.text = "Defesas: " + bolasDefendidas;
		score.text = "Pontuação: " + pontuacaoTotal;


		if (pontuacaoTotal >= pontosVitoria) {


			AudioSource audio = GameObject.Find ("MusicaJogo").GetComponent<AudioSource>();
			audio.Stop();

			audio = GameObject.Find ("Fim_sucesso").GetComponent<AudioSource>();
			audio.Play();


			GameObject.Find ("vitoria").GetComponent<Image> ().enabled = true;
			GameObject.Find ("botaoMenu").GetComponent<Image> ().enabled = true;
			GameObject.Find ("textobotaoMenu").GetComponent<Text> ().enabled = true;

			voltaMenu = 1;

			//SceneManager.LoadScene ("MenuInicial");
			
		} else if (pontuacaoTotal <= pontosDerrota) {


			AudioSource audio = GameObject.Find ("MusicaJogo").GetComponent<AudioSource>();
			audio.Stop();

			audio = GameObject.Find ("Fim_falha").GetComponent<AudioSource>();
			audio.Play();


			GameObject.Find ("gameover").GetComponent<Image> ().enabled = true;
			GameObject.Find ("botaoMenu").GetComponent<Image> ().enabled = true;
			GameObject.Find ("textobotaoMenu").GetComponent<Text> ().enabled = true;

			voltaMenu = 1;

			//SceneManager.LoadScene ("MenuInicial");
		}

	}


}
