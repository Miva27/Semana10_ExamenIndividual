using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private int baseDamage1 = 5;
    [SerializeField] private int baseDamage2 = 8;
    public float timeBetweenShots1 = 1.0f;
    public float timeBetweenShots2 = 2.5f;


    public GameObject Bullet1;
    public GameObject Bullet2;
    public Transform BulletPoint1;
    public Transform BulletPoint2;

    private float timer1;
    private float timer2;


    void Update()
    {

        timer1 += Time.deltaTime;
        timer2 += Time.deltaTime;

        if (Input.GetButtonDown("Bullet1") && timer1 >= timeBetweenShots1)
        {
            Shoot1();
            timer1 = 0f;
        }

        if (Input.GetButtonDown("Bullet2") && timer2 >= timeBetweenShots2)
        {
            Shoot2();
            timer2 = 0f;
        }

    }


    void Shoot1()
    {
        GameObject bullet = Instantiate(Bullet1, BulletPoint1.position, BulletPoint1.rotation);
        BulletMovement bulletComponent = bullet.GetComponent<BulletMovement>();
        bulletComponent.damage = baseDamage1;
    }

    void Shoot2()
    {
        GameObject bullet = Instantiate(Bullet2, BulletPoint2.position, BulletPoint2.rotation);
        BulletMovement bulletComponent = bullet.GetComponent<BulletMovement>();
        bulletComponent.damage = baseDamage2;
    }
}
