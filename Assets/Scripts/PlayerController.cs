using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] public bool isGameOver = false;
    
    private float speed = 5.0f;
    private Rigidbody playerRigidBody = null;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }

    /// <summary>
    ///  Move the player based on inputs
    /// </summary>
    void MovePlayer()
    {
        // simple movement
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        playerRigidBody.AddForce(Vector3.forward * speed * verticalInput);
        playerRigidBody.AddForce(Vector3.right * speed * horizontalInput);
    }
}
