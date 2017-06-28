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

	public int comboDefesa = 0;
	public int comboCoracao = 0;
	public int coracaoAtivo = 4;
	public int bombaAtivo = 1;

	public int progressaoContador = 0;
	public int comboDefesaMax = 0;

	public int tocouMusica = 0;
	public float pausaInicial;
	public int jogoAtivo = 0;
	public int jogoterminado = 0;

	private float timeVida;
	private int voltaMenu = 0;


	void Start () {
		//pausaInicial = 10f;
	}



	void Update () {

		pausaInicial -= Time.deltaTime;
		if (pausaInicial <= 0) {
			GameObject.Find ("gols").GetComponent<Text> ().enabled = true;
			GameObject.Find ("defendidas").GetComponent<Text> ().enabled = true;
			GameObject.Find ("pontosObitidos").GetComponent<Text> ().enabled = true;
			jogoAtivo = 1;

		}

		//testa FIM DE JOGO , VOLTA MENU
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
		comboDefesa += 1;

		// TESTA SE O JOGADOR VAI BEM PARA AUMENTAR DIFICULDADE
		comboDefesaMax ++;
		if (comboDefesaMax >= 3) {
			progressaoContador ++;
			comboDefesaMax = 0;

			//AUMENTA ROTACAO TURRETA
			GameObject.Find ("TorreD")
				.GetComponent<GiraTurreta> ()
				.velocidade = GameObject.Find ("TorreD")
					.GetComponent<GiraTurreta> ()
					.velocidade + 5;
			//AUMENTA FORCA BOLA
			GameObject.Find ("TorreD")
				.GetComponent<atirarProjetil> ()
				.forcaTiro = GameObject.Find ("TorreD")
					.GetComponent<atirarProjetil> ()
					.forcaTiro + 5;
		}
	

		if (jogoterminado == 0) {
			atualizarPontuacao ();
		}
	}

	public void removerPonto(int valor) {
		pontuacaoTotal -= valor;
		golsTomados += 1;
		comboDefesa = 0;
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

		// CONDICAO DE DERROTA
		if (golsTomados >= pontosDerrota) {

			tocaaMusica (1);
			GameObject.Find ("gameover").GetComponent<Image> ().enabled = true;
			timeVida = 10f;
			jogoterminado = 1;
			voltaMenu = 1;

		} 
		// CONDICAO DE VITORIA
		/* else if (bolasDefendidas >= pontosVitoria) {

			tocaaMusica (0);
			GameObject.Find ("vitoria").GetComponent<Image> ().enabled = true;
			timeVida = 23f;
			jogoterminado = 1;
			voltaMenu = 1;
		}
		*/

	}


}
