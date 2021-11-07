using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingBlock : MonoBehaviour
{

    public Vector2 speedMinMax;
    float speed;
    float screenHalfWidthInWorldUnits;

    private void Start() {
        screenHalfWidthInWorldUnits = Camera.main.orthographicSize;
        speed = Mathf.Lerp(speedMinMax.x, speedMinMax.y, Difficulty.GetDifficultPercent());
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime, Space.Self);

        if (transform.position.y < -screenHalfWidthInWorldUnits) {
            transform.position = new Vector2(transform.position.x, screenHalfWidthInWorldUnits);
        }
    }
}
