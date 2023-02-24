using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float playerSpeed;
    public float playerHp;
    public int weaponIndex;

    //public AudioSource walkSound;

    public GameObject akRifle;
    public GameObject shotgunRifle;

    private Vector3 moveVector;

    private CharacterController ch_controler;

    private Vector3 pastPosition;

    public Animator animatorPlayer;


    
    void Start()
    {
        animatorPlayer = GetComponent<Animator>();
        ch_controler = GetComponent<CharacterController>();
        pastPosition = transform.position;
        
        weaponIndex = 0;


        akRifle = GameObject.FindGameObjectWithTag("Ak47");
        shotgunRifle = GameObject.FindGameObjectWithTag("Shotgun");
        shotgunRifle.SetActive(false);

        playerHp = 100;


    }

   
    void Update()
    {        
        CharacterMove();
        CharacterRotate();
        WeaponSwap();
        transform.position = new Vector3(transform.position.x, 0f, transform.position.z);
    }
    
    
    private void WeaponSwap()
    {
        
        float mw = Input.GetAxis("Mouse ScrollWheel");
        if (mw > 0)
        {
            weaponIndex++;
            if(weaponIndex > 1)
            {
                weaponIndex = 0;
            }
        }
        if (mw < 0)
        {
            weaponIndex--;
            if (weaponIndex < 0)
            {
                weaponIndex = 1;
            }
        }

        switch(weaponIndex)
        {
            case 0:
                akRifle.SetActive(true);
                shotgunRifle.SetActive(false);               
                break;
            case 1:
                akRifle.SetActive(false);
                shotgunRifle.SetActive(true);             
                break;      
            default:            
            break;
        }
    }

    private void CharacterMove()//Move character
    {
        moveVector = Vector3.zero;
        moveVector.x = Input.GetAxis("Horizontal") * playerSpeed;
        moveVector.z = Input.GetAxis("Vertical") * playerSpeed;
        ch_controler.Move(moveVector * Time.deltaTime);

        transform.position = new Vector3(transform.position.x, 0f, transform.position.z);
       
        if(Input.GetKey(KeyCode.W)
            || Input.GetKey(KeyCode.A)
            || Input.GetKey(KeyCode.S)
            || Input.GetKey(KeyCode.D))
        {
            animatorPlayer.SetFloat("multiplier", 2f);
            
        }
        else
        {
            animatorPlayer.SetFloat("multiplier", 0f);
        }

    }
  
    private void CharacterRotate()//rotate character to mouse
    {

        Plane playerPlane = new Plane(Vector3.up, transform.position);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        float hitdist = 0; 

        if (playerPlane.Raycast(ray, out hitdist)) 
        {
            Vector3 targetPoint = ray.GetPoint(hitdist);
            Quaternion targetRotation = Quaternion.LookRotation(targetPoint - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, playerSpeed * Time.deltaTime); 
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("ZombieHit"))
        {
            playerHp -= 10;         
        }
    }
}
