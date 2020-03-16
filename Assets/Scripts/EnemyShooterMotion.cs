
using UnityEngine;

public class EnemyShooterMotion : MonoBehaviour
{
    public float speed = 5f;
    public float step;
    

    // Update is called once per frame
    void Update()
    {
        step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, GameObject.FindGameObjectWithTag("ShooterCollider").transform.position, step);
    }
}
