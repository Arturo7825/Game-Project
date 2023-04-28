using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        Vector2 target = new Vector2(transform.position.x + 0.01f, transform.position.y);
        transform.position = Vector2.MoveTowards(transform.position, target, 1);
    }
}
