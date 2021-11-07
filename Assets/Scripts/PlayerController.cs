using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject playerObject;
    
    [SerializeField] float horizontalSpeed=3;
    [SerializeField] float verticalSpeed=2;
    float horizontal;
    float vertical;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
    }

    void PlayerMove(){
        horizontal = Time.deltaTime * Input.GetAxis("Horizontal") * horizontalSpeed;
        vertical = Time.deltaTime * Input.GetAxis("Vertical") * verticalSpeed;

        playerObject.transform.position += new Vector3(horizontal,0,vertical);
        playerObject.transform.localScale += new Vector3(0,0.1f * Time.deltaTime,0);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Fire")){
            playerObject.transform.localScale += new Vector3(0,-0.1f,0);
            Debug.Log("in fire");
        }
    }
}
