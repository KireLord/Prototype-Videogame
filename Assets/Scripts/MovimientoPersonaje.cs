using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoPersonaje : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Transform caveBoundary; // Asigna el límite de la cueva en el Inspector

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Accede al componente Rigidbody2D
    }
    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(horizontalInput, verticalInput).normalized;
        Vector2 velocity = movement * moveSpeed;

        rb.velocity = velocity;

        // Restringe el movimiento dentro de los límites de la cueva
        float xPos = Mathf.Clamp(transform.position.x, caveBoundary.position.x - caveBoundary.localScale.x / 2, caveBoundary.position.x + caveBoundary.localScale.x / 2);
        float yPos = Mathf.Clamp(transform.position.y, caveBoundary.position.y - caveBoundary.localScale.y / 2, caveBoundary.position.y + caveBoundary.localScale.y / 2);

        transform.position = new Vector3(xPos, yPos, transform.position.z);
    }
}
