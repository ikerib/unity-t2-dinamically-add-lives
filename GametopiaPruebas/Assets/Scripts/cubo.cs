using UnityEngine;
using System.Collections;

public class cubo : MonoBehaviour {

	public float velocidad;
	public float maxPosX;
	public float minPosX;
	public int vidas;
	Transform myTransform;
	int sentido;

	// Use this for initialization
	void Start () {
		// Nos guardamos la referencia al transform del objeto.
		myTransform = this.transform;
		// Prevenimos los valores 0 de velocidad.
		if (velocidad == 0) velocidad = 1;
		// Prevenimos los valores 0 para máximo y mínimo.
		if (maxPosX == 0) maxPosX = 6.0f;
		if (minPosX == 0) minPosX = -6.0f;
		sentido = 1;
	}
	// Update is called once per frame
	void Update () {
		if ((myTransform.position.x >= maxPosX && sentido == 1) ||
		    (myTransform.position.x <= minPosX && sentido == -1)) {
			sentido *= -1;
			vidas--;
		}
		myTransform.Translate(Vector3.right * velocidad * sentido * Time.deltaTime);
	}
	public int GetVidas() {
		return vidas;
	}
}