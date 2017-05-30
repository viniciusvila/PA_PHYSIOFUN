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

	public int tocouMusica = 0;
	public int jogoterminado = 0;

	private float timeVida;
	private int voltaMenu = 0;
	void Start () {
		
	}

	void Update () {
		if (voltaMenu == 1) {
			timeVida -= Time.deltaTime;
			if (timeVida <= 0) {
				SceneManager.LoadScene ("Cenas/MenuInicial");

			}
		}
	}

	public void addPonto(int valor) {
		pontuacaoTotal += valor;
		bolasDefendidas += 1;
		if (jogoterminado == 0) {
			atualizarPontuacao ();
		}
	}

	public void removerPonto(int valor) {
		pontuacaoTotal -= valor;
		golsTomados += 1;
		if (jogoterminado == 0) {
			atualizarPontuacao ();
		}
	}


	public void tocaaMusica (int tipoMusica) {
		if ((tocouMusica == 0) && (tipoMusica == 0)) {
			AudioSource audio = GameObject.Find ("MusicaJogo").GetComponent<AudioSource>();
			audio.Stop();
			audio = GameObject.Find ("Fim_sucesso").GetComponent<AudioSource>();
			audio.Play();
			tocouMusica = 1;
			//jogoterminado = 1;
		
		} else if ((tocouMusica == 0) && (tipoMusica == 1)) {
			AudioSource audio = GameObject.Find ("MusicaJogo").GetComponent<AudioSource>();
			audio.Stop();
			audio = GameObject.Find ("Fim_falha").GetComponent<AudioSource>();
			audio.Play();
			tocouMusica = 1;
			//jogoterminado = 1;
		}
			
		
	}

	public void atualizarPontuacao () {
		gols.text = "Gols Levados: " + golsTomados;
		defesas.text = "Defesas: " + bolasDefendidas;
		score.text = "Pontuação: " + pontuacaoTotal;


		if (pontuacaoTotal >= pontosVitoria) {
			
			tocaaMusica (0);
			GameObject.Find ("vitoria").GetComponent<Image> ().enabled = true;
			timeVida = 23f;
			jogoterminado = 1;
			voltaMenu = 1;

		} else if (pontuacaoTotal <= pontosDerrota) {

			tocaaMusica (1);
			GameObject.Find ("gameover").GetComponent<Image> ().enabled = true;
			timeVida = 5f;
			jogoterminado = 1;
			voltaMenu = 1;

		}

	}


}
