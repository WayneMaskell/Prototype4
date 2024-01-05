using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightingEnemy : MonoBehaviour
{
    private GameObject player;
    private Rigidbody enemyRb;
    private bool isAttacking = false;
    [SerializeField] private float distanceToPlayer;
    public float enemySpeed = 1f;
   
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void Awake()
    {
        player = GameObject.Find("Player");
        enemyRb = GetComponent<Rigidbody>();
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if ((Vector3.Distance(transform.position, player.transform.position)< distanceToPlayer) && isAttacking == false) 
        {
            Attack();
        
        }

        if (transform.position.y < -10) { Destroy(gameObject); }
       

        
        
    }
    public void Attack() 
    {
        if (isAttacking == false) {
            
            enemyRb.AddForce(transform.forward * enemySpeed, ForceMode.Impulse);
            isAttacking = true;
        }
    
    
    }
}
