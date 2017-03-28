using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject player;
    private Vector3 offset;

    // Use this for initialization
    void Start() {
        offset = transform.position - player.transform.position;
    }

    void LateUpdate() {
        // A medida que movamos al jugador con el teclado la cámara se mueve a la nueva posición
        // alineada con el jugador
        transform.position = player.transform.position + offset;
    }
}
