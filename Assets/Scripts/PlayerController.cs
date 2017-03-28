using UnityEngine;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour {

    //void Update(){} // Se llama antes de renderizar un frame

    private Rigidbody rb;
    public float speed;
    private int count;
    public Text countText;
    public Text winText;

    void Start() {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winText.text = "";
    }

    // Se llama antes de realizar cualquier cálculo de física
    void FixedUpdate() {
        //Recoge los datos de entrada (de Player) a través de teclado
        float moveHorizontal = Input.GetAxis("Horizontal"); // x = mueve la pelota de izquierda a derecha
        float moveVertical = Input.GetAxis("Vertical"); // z = 

        //Los valores x,y,z determinan la dirección de la fuerza que se le da a Player
        //Vector3 movement = new Vector3(x, y, z); 
        //y = 0 (novimientos de arriba a abajo)
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical); 
        rb.AddForce(movement * speed); 
    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("PickUp")) {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }
    }

    void SetCountText() {
        countText.text = "Count: " + count.ToString();
        if(count >= 11) {
            winText.text = "YOU WIN";
        }
    }
}
