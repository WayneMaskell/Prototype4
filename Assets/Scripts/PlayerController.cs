using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    public float Speed = 5.0f;
    private GameObject focalPoint;
    public PowerUpType currentPowerUpType = PowerUpType.None;
    public GameObject bulletPrefab;
    private GameObject tempBullet;
    private Coroutine PowerUpCountDown;
    private bool hasPowerUp= false;
    public float powerUpStrength = 25f;
    public bool hasPowerUp2 = false;
    public GameObject repelIndicator;
    public GameObject bulletIndicator;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("FocalPoint");
        
    }

    // Update is called once per frame
    void Update()
    {
        bulletIndicator.transform.position = transform.position;
        repelIndicator.transform.position = transform.position;
        float forwardInput = Input.GetAxis("Vertical");
        playerRb.AddForce(focalPoint.transform.forward * Speed * forwardInput);
        if (currentPowerUpType == PowerUpType.Bullet && Input.GetKeyDown(KeyCode.Space))
        {
            ShootBullets();
        }

        if (currentPowerUpType == PowerUpType.repel) 
        {
            hasPowerUp2 = true;
            hasPowerUp = false;
            repelIndicator.gameObject.SetActive(true);
            bulletIndicator.gameObject.SetActive(false);

           


            }


    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PowerUp"))
        {
            hasPowerUp = true;
            currentPowerUpType = other.gameObject.GetComponent<PowerUp>().powerUpType;
            Destroy(other.gameObject);
            bulletIndicator.gameObject.SetActive(true);

            if (PowerUpCountDown != null)
            {
                StopCoroutine(PowerUpCountDown);
            }
            PowerUpCountDown = StartCoroutine(PowerUpCountDownRoutine());

        }

        

        


    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && hasPowerUp2) 
        {
            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayfromPlayer = (collision.gameObject.transform.position - transform.position);
            enemyRigidbody.AddForce(awayfromPlayer * powerUpStrength , ForceMode.Impulse);
        }
    }


    IEnumerator PowerUpCountDownRoutine() 
    {
        yield return new WaitForSeconds(5);
        hasPowerUp= false;
        currentPowerUpType= PowerUpType.None;
        repelIndicator.gameObject.SetActive(false);
        bulletIndicator.gameObject.SetActive(false);
    }
    private void ShootBullets() 
    {
        foreach (var enemy in FindObjectsOfType<FightingEnemy>())
        {
            tempBullet = Instantiate(bulletPrefab, transform.position + Vector3.up, Quaternion.identity);
            tempBullet.GetComponent<Bullet>().Shoot(enemy.transform);
                
                }
    }
}
