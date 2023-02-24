using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    public int zombieHp;
    public int zombieSpeed;

    public AudioSource zombieSound;

    private bool isWalking = true;
    private Vector3 distantionToPlayer;

    public GameObject bloodPrefab;
    public Animator animatorZombie;
    public Transform goal;
    public UnityEngine.AI.NavMeshAgent agent;

    void Start()
    {
        animatorZombie = GetComponent<Animator>();
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        goal = GameObject.FindGameObjectsWithTag("Player")[0].transform;

        zombieHp = 30;
    }

   
    void FixedUpdate()
    {

        agent.destination = GetComponent<Transform>().position;
        distantionToPlayer = goal.position - transform.position;

        if (distantionToPlayer.magnitude < 2f)
        {
            Attack();
        }

        

        if (isWalking)
        {
            agent.destination = goal.position;
            animatorZombie.Play("ZombieWalkAnim");
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            zombieHp -= 10;

            if (zombieHp <= 0)
            {
                Death();
            }
            else 
            {
                GetHitted();
            }
        }
    }

    private void Attack()
    {
        isWalking = false;
        //zombieSound.Play();
        animatorZombie.Play("ZombieAttackAnim");
        
        StartCoroutine(HitAnimationCorutine());
    }

    private void Death()
    {
        isWalking = false;
        animatorZombie.Play("ZombieDeathAnim");
        Destroy(gameObject, 5f);

    }

    private void GetHitted()//play hitted anim
    {
        isWalking = false;
        animatorZombie.Play("ZombieGetHittedAnim");
        SpawnBloodParticle();
        StartCoroutine(HitAnimationCorutine());
    }


    IEnumerator HitAnimationCorutine()// stopping zombie when he is hitted 
    {
        yield return new WaitForSeconds(1f);
        isWalking = true;
    }

    void SpawnBloodParticle()//spawn blood particles when get hitted
    {
        GameObject blood = Instantiate(bloodPrefab, transform.position, transform.rotation);
        var bloodParticle = blood.GetComponent<ParticleSystem>();
        bloodParticle.Play();
    }
}
