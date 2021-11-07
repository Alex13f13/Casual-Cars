using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Transform world;
    private float goBullet;
    public int bulletSpeed;

    void Start()
    {
        transform.rotation = world.rotation;
    }

    void Update()
    {
        goBullet = transform.position.y + bulletSpeed * Time.deltaTime;
        transform.position = new Vector2(transform.position.x , goBullet);

		if (transform.position.y > 12)
		{
            Destroy(gameObject);
		}
    }

    #region Funciones


    #endregion
}
