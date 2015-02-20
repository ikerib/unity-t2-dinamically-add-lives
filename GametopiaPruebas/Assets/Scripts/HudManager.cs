using UnityEngine;
using System.Collections;

public class HudManager : MonoBehaviour {

	public GameObject spawnObject;
	// El array marcadorVidas será el que contenga Cube_0, Cube_1 y Cube_2
	//public GameObject[] marcadorVidas;
	System.Collections.Generic.List<GameObject> marcadorVidas = new System.Collections.Generic.List<GameObject> ();
	//List<GameObject> gameObjectReturnees = new List<GameObject>();

	// La referencia al GO Cube.
	public cubo miCubo;
	// Esta variable entera contiene el valor de las vidas del cubo.
	int valorVidas;

	// Use this for initialization
	void Start () {
		valorVidas = miCubo.GetVidas();

		for (int i = 0; i < valorVidas; i++) {
			float temp = -87 + i;
			GameObject tGO;
			tGO = GameObject.Instantiate(spawnObject,new Vector3( temp, 1.39f, -18f),Quaternion.identity) as GameObject;
			marcadorVidas.Add( tGO );
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (valorVidas != miCubo.GetVidas()) {
			// Si ha cambiado, me guardo el nuevo valor y actualizo el display.
			valorVidas = miCubo.GetVidas();
			ActualizarVidas();
		}
	}

	void ActualizarVidas() {
		// Para evitar errores en este ejemplo, me aseguro que valorVidas es mayor o
		// igual que 0, porque voy a utilizar este valor para activar o desactivar los
		// cubos pequeños.
		if (valorVidas >= 0) {
			for (int i = 0; i < marcadorVidas.Count; i++) {
				// Si valorVidas = 2, tengo que activar los GOs 0 y 1.
				if (i >= valorVidas) {
					marcadorVidas[i].SetActive(false);
				} else {
					marcadorVidas[i].SetActive(true);
				}
			}
		}
	}
}
