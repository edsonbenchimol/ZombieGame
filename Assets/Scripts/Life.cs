using UnityEngine;
using System.Collections;

public class Life : MonoBehaviour {

	public GameObject vida; // será o objeto que acabamos de criar com o GUITexture e GUIText
	public int maxVida; //será o HP máximo do personagem (10, 50, 100, 1000…) 
	private int vidaAtual; // é o quanto ele tem de vida no momento do jogo.



	// Use this for initialization
	void Start () {
	
		//Vida
		vidaAtual = maxVida; //A vida atual do personagem será igual ao máximo que ele pode ter de vida, ou seja, estará com o HP completo.
		vida.GetComponent<GUIText>().GetComponent<GUIText>().color = new Vector4(0.25f, 0.5f, 0.25f, 1f);
		vida.GetComponent<GUIText>().GetComponent<GUIText>().text = "HP: " + vidaAtual + "/" + maxVida;
		//O campo Text do objeto vida no componente GUIText vai receber “HP 100/100”, caso vidaAtual seja 100 e maxVida seja 100.
	}
	
	// Update is called once per frame
	void Update () {

	}

	//PERDE A VIDA;
	public void PerdeVida(int dano) {
		vidaAtual -= dano;
		/* Nessa linha dizemos que a vidaAtual do personagem vai ser reduzia pelo dano que ele levou. 
		O dano é passado como parâmetro na chamada do método PerdeVida(int dano). Logo se ele tem 100 
		de vida e levou um dano que 10 pontos, agora terá 90.
		*/

		if (vidaAtual <= 0) {
			Application.LoadLevel(Application.loadedLevel);
			//Se a vida atual do personagem for zero ou menor que isso, então reiniciará a fase. 
		} 

		if ((vidaAtual * 100 / maxVida) < 30) {
			/*
			 maxVida = 100
			 vidaAtual = X
			 Multiplicamos isso usando a regra de 3:
			 maxVida * X = 100 * vidaAtual
			 X = (vidaAtual * 100)/ maxVida
			 Se X for menos que 30, o texto ficará vermelho.		
			 */

			vida.GetComponent<GUIText>().GetComponent<GUIText>().color = Color.red;
			//Se a vida do personagem estiver abaixo de 30% mudamos a cor do texto para vermelho. 

		}

		vida.GetComponent<GUIText>().GetComponent<GUIText>().text = "HP: " + vidaAtual + "/" + maxVida;
		//Altera o texto do componente GUIText do Objeto Vida para “HP: 90/100” se ele levou um dano de 10 e estava com a vida cheia. 
	}

	//RECUPERA A VIDA;
	public void RecuperaVida(int recupera) {
		vidaAtual += recupera;
		/*A vida atual do personagem irá receber um valor a mais de acordo com o valor 
		  passado no parâmetro recupera na declaração do método RecuperaVida(int recupera).
		*/

		if (vidaAtual > maxVida) {
			vidaAtual = maxVida;
			/*Como a vida atual não pode ser maior que a vida máxima (Embora já vi alguns jogos que podia O.o), 
			  significa que ser o valor estiver maior, por exemplo eu tinha 90 de vida e recuperei 50,
			  para não ficar com 140/100, alteramos o vidaAtual para o mesmo valor de maxVida deixando: 100/100.
			 */
		}

		if ((vidaAtual * 100 / maxVida) >= 30) {
			vida.GetComponent<GUIText>().GetComponent<GUIText>().color = new Vector4(0.25f, 0.5f, 0.25f, 1f);
		}

		vida.GetComponent<GUIText>().GetComponent<GUIText>().text = "HP: " + vidaAtual + "/" + maxVida;
	}

}
