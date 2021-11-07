using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed = 7;
    float screenHalfWidthInWorldUnits;
    public event System.Action OnPlayerDeath;

    // Start is called before the first frame update
    void Start() {
        float playerHalfWidth = transform.localScale.x / 2f;
        screenHalfWidthInWorldUnits = Camera.main.aspect * Camera.main.orthographicSize + playerHalfWidth; 
    }

    // Update is called once per frame
    void Update()
    {
        float inputx = Input.GetAxisRaw("Horizontal");
        float velocity = inputx * speed;
        transform.Translate(Vector2.right * velocity * Time.deltaTime);

        /* If player moves off screen, then wrap them over to the other side */
        if (transform.position.x < -screenHalfWidthInWorldUnits) {
            transform.position = new Vector2(screenHalfWidthInWorldUnits, transform.position.y);
        }

        if (transform.position.x > screenHalfWidthInWorldUnits) {
            transform.position = new Vector2(-screenHalfWidthInWorldUnits, transform.position.y);
        }
    }

    private void OnTriggerEnter2D(Collider2D triggerCollider) {
        if (triggerCollider.tag == "Falling Block") {
            if (OnPlayerDeath != null) {
                OnPlayerDeath();
            }
            Destroy(gameObject);
        }
    }
}
