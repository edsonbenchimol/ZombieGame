using UnityEngine;
using System.Collections;

public class PlayerNovo : MonoBehaviour {
	
	public float velocidade;
	public Transform player;
	private Animator Anime;
	public bool isGrounded = true;
	public float force; 
	public float jumpTime = 0.4f;
	public float jumpDelay = 0.4f;
	public bool jumped = false;
	public Transform ground;
	public bool atiro;
	public bool atiracorrendo;
	public float tiroTemp;
	public float tiroTempCorrendo;
	private float timeTemp;
	public bool correndo_e_atirando;


	void Start () {
		Anime = player.GetComponent<Animator> ();
	}

	void Update () {
		Movimentar();
	}



	void Movimentar(){
		
		Anime.SetFloat("walk",Mathf.Abs(Input.GetAxisRaw("Horizontal")));

		//Atirar Parado.
		if (Input.GetMouseButtonDown (0)) {
			atiro = true;
			Anime.SetBool("shootidle",atiro);
			//Debug.Log("Apertou");
			timeTemp = 0;
		}
			//verficando o tempo do tiro;
			if(atiro == true){
				timeTemp += Time.deltaTime;
				if(timeTemp >= tiroTemp){
				Anime.SetBool("shootidle",!atiro);
				//Debug.Log("Tempo Atingido");
				}
			}	

	
		if (Input.GetAxisRaw ("Horizontal")>0) {
			// Se apertar nas teclas, corre normal...

			transform.Translate(Vector2.right * velocidade * Time.deltaTime);
			transform.eulerAngles = new Vector2(0,180);

			//Apertando na tecla e atirando ....
			if (Input.GetAxisRaw ("Horizontal")>0 && Input.GetMouseButtonDown (0)) {
				correndo_e_atirando = true;
			//	Debug.Log("Esta certo ate aqui, dois botoes ao mesmo tempo foram pressionados");
				Anime.SetBool("shotrunningout",correndo_e_atirando);
				timeTemp = 0;
				//Debug.Log("Atira Correndo");

			}
		}

	
		//verficando o tempo do tiro;
		if(correndo_e_atirando == true){
			timeTemp += Time.deltaTime;
			if(timeTemp >= tiroTempCorrendo){
				correndo_e_atirando = false;
				Anime.SetBool("shotrunningout",correndo_e_atirando);
				//Debug.Log("Tempo Atingido");
			}
		}


		if (Input.GetAxisRaw ("Horizontal")<0) {
			transform.Translate(Vector2.right * velocidade * Time.deltaTime);
			transform.eulerAngles = new Vector2(0,0);

			//Apertando na tecla e atirando ....
			if (Input.GetAxisRaw ("Horizontal")<0 && Input.GetMouseButtonDown (0)) {
				correndo_e_atirando = true;
				//	Debug.Log("Esta certo ate aqui, dois botoes ao mesmo tempo foram pressionados");
				Anime.SetBool("shotrunningout",correndo_e_atirando);
				timeTemp = 0;
				//Debug.Log("Atira Correndo");

			}

		}


		//verficando o tempo do tiro;
		if(correndo_e_atirando == true){
			timeTemp += Time.deltaTime;
			if(timeTemp >= tiroTempCorrendo){
				correndo_e_atirando = false;
				Anime.SetBool("shotrunningout",correndo_e_atirando);
				//Debug.Log("Tempo Atingido");
			}
		}

		if (Input.GetAxisRaw ("Vertical") > 0) {
			transform.Translate(-Vector2.up* velocidade * Time.deltaTime);
			Anime.SetFloat("walk",Mathf.Abs(Input.GetAxisRaw("Vertical")));

		}
		if (Input.GetAxisRaw ("Vertical") < 0) {
			transform.Translate(Vector2.up * velocidade * Time.deltaTime);
			Anime.SetFloat("walk",Mathf.Abs(Input.GetAxisRaw("Vertical")));

		}

	}
}