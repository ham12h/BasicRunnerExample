using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] GameObject playerObject;
    [SerializeField] float horizontalSpeed = 3;
    [SerializeField] float verticalSpeed = 2;
    [SerializeField] float addCube = 0.3f;
    [SerializeField] float melting = 0.3f;
    public bool finish =false;
    public bool gameOver =false;
    float horizontal;
    float vertical;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {



        if(finish){

            FinishEffect();
        }else if(gameOver){
            Destroy(playerObject);
        }else{
            PlayerMove();
        }
    }

    void PlayerMove()
    {
        horizontal = Time.deltaTime * Input.GetAxis("Horizontal") * horizontalSpeed;
        //vertical = Time.deltaTime * Input.GetAxis("Vertical") * verticalSpeed;

        // playerObject.transform.position += new Vector3(horizontal, 0, vertical);
        playerObject.transform.position += new Vector3(horizontal, 0, Time.deltaTime * verticalSpeed);
    }

    void FinishEffect(){
            if (playerObject.transform.position.x < 12)
            {
                playerObject.transform.position += new Vector3(0,2 * Time.deltaTime,0);    
            }else{

                playerObject.transform.position += new Vector3(0,-2 * Time.deltaTime,0);
            }
    }

    void GameOverState(){
        if(playerObject.transform.localScale.y < 1){
            gameOver=true;
        }
    }

    void OnTriggerStay(Collider other)
    {

        if (other.gameObject.tag == "Fire")
        {
            playerObject.transform.localScale += new Vector3(0, -melting * Time.deltaTime, 0);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Cube"))
        {
            playerObject.transform.localScale += new Vector3(0, addCube, 0);
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("Finish"))
        {
            finish=true;
        }
    }

}
