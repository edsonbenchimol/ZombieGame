using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {


	public float velocidade;

	public Transform player;
	private Animator animator;
	private Animator animatory;
	private Animator AnimShoot;
	private Animator AnimidleShoot;



	public bool isGrounded = true;
	public float force; 

	public float jumpTime = 0.4f;
	public float jumpDelay = 0.4f;
	public bool jumped = false;
	public Transform ground;



	// Use this for initialization
	void Start () {


		animator = player.GetComponent<Animator> ();
		animatory = player.GetComponent<Animator> ();
		AnimShoot = player.GetComponent<Animator> ();
		AnimidleShoot = player.GetComponent<Animator> ();
		

	}
	
	// Update is called once per frame
	void Update () {
	

		Movimentar();
	}

	void Movimentar()
	{
		animator.SetFloat("walk",Mathf.Abs(Input.GetAxisRaw("Horizontal")));
		animatory.SetFloat("walky",Mathf.Abs(Input.GetAxisRaw("Vertical")));
		AnimShoot.SetFloat("shoot",Mathf.Abs(Input.GetAxisRaw("Fire1")));

		if (Input.GetAxisRaw ("Fire1") > 0) {

		
		}

		if (Input.GetAxisRaw ("Horizontal") > 0) {
			
			transform.Translate(Vector2.right * velocidade * Time.deltaTime);
			transform.eulerAngles = new Vector2(0,180);
		}

		if (Input.GetAxisRaw ("Horizontal") < 0) {
			transform.Translate(Vector2.right * velocidade * Time.deltaTime);
			transform.eulerAngles = new Vector2(0,0);
		}

		if (Input.GetAxisRaw ("Vertical") > 0) {
			transform.Translate(-Vector2.up* velocidade * Time.deltaTime);
		}
		if (Input.GetAxisRaw ("Vertical") < 0) {
			transform.Translate(Vector2.up * velocidade * Time.deltaTime);
		}

    }
}













