using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
	[SerializeField]
	private float xMax;

	[SerializeField]
	private float yMax;

	[SerializeField]
	private float xMin;

	[SerializeField]
	private float yMin;

	private Transform target;

	// Use this for initialization
	void Start () {

		target = GameObject.Find("Player").transform;
		//pegando as informaçoes do player;
	}


	void LateUpdate(){

		/* 
-------------------------------------------------------------------------------------------------------------------------

		Por esse transform, sao passados e aplicados a camera as informaçoes referentes a posicao X e Y 
		do jogador, e definido tambem e o X e Y maximo que a camera ira cobrir.  

		 */
		transform.position = new Vector3 (Mathf.Clamp (target.position.x +0.6f, xMin, xMax), 
		Mathf.Clamp (target.position.y, yMin, yMax),
		transform.position.z);
		


	}

}
