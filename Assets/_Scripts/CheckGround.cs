using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckGround : MonoBehaviour
{
    public static bool isGrounded;
    [SerializeField]private float distance;

    private void Update() {
        Debug.DrawRay(transform.position, Vector2.down * distance, Color.yellow);
        isGrounded = (Physics2D.Raycast(transform.position, Vector2.down, distance) ? true : false);
    }

}
