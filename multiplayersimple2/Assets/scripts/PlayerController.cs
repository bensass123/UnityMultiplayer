using UnityEngine;
using UnityEngine.Networking;

public class PlayerController : NetworkBehaviour
{
    public GameObject bulletPrefab;

    public Transform bulletSpawn;

    
    public override void OnStartLocalPlayer()
    {
        GetComponent<MeshRenderer>().material.color = Color.blue;
    }

    void Update()
    {
        if (!isLocalPlayer)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log(Input.mousePosition);
            CmdFire();
        }

        

    }

    [Command]
    void CmdFire()
    {
        // Create Bullet
        // position is captured by mouse clicks for pc version
        var b = (GameObject)Instantiate(bulletPrefab, bulletSpawn.position);

        b.GetComponent<Rigidbody>().velocity = b.transform.forward * 6;

        //spawn bullet
        NetworkServer.Spawn(b);

        Destroy(b, 2.0f);
    }

    

}