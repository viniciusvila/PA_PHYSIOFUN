using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GerenciadorPlacar : MonoBehaviour {

	public int pontuacaoTotal = 0; 
	public int golsTomados = 0 ;
	public int bolasDefendidas = 0;

	public void addPonto(int valor) {
		pontuacaoTotal += valor;
		bolasDefendidas += 1;
		atualizarPontuacao ();
	}

	public void removerPonto(int valor) {
		pontuacaoTotal -= valor;
		golsTomados += 1;
		atualizarPontuacao ();
	}

	public void atualizarPontuacao () {
		
	}


}
