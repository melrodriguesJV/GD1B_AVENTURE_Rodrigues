using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float speed;
    private Vector3 velocity = Vector3.zero;
    void Update()
    {
        transform.position = new Vector3(player.position.x, transform.position.y, transform.position.z);
    }
}
