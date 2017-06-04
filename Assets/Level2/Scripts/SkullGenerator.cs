using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkullGenerator : MonoBehaviour {

    public GameObject skullPrefab;
    public float rate = 1;
    public int quantity = 50;
    
    public void GenerateSkulls()
    {
        for (int i = 0; i < quantity; i++)
        {
            Invoke("GenerateSkull", i / rate);
        } 
    }

    void GenerateSkull()
    {
        float x = transform.position.x;
        float y = transform.position.y;
        float z = transform.position.z;
        int rand = Random.Range(-1, 1);
        Vector3 position = new Vector3(x + rand, y + rand, z + rand);

        Instantiate(skullPrefab, transform.position, Quaternion.identity);
    }
}
