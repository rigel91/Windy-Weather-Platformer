using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Freeze : MonoBehaviour
{
    public GameObject Player;
    public float freezetime = 5f;
    public Animator anim;
    private Moving movingscript;
    private ThrowWeapon throwingscript;

    // Use this for initialization
    void Start()
    {
        movingscript = GameObject.Find("PlayerSpriteNew").GetComponent<Moving>();
        throwingscript = GameObject.Find("PlayerSpriteNew").GetComponent<ThrowWeapon>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator Frozen()
    {
        anim.SetBool("frozen", true);
        movingscript.enabled = false;
        throwingscript.enabled = false;
        yield return new WaitForSecondsRealtime(freezetime);
        anim.SetBool("frozen", false);
        movingscript.enabled = true;
        throwingscript.enabled = true;
    }
}
