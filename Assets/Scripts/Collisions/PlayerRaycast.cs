using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class PlayerRaycast : MonoBehaviour {

    public float rayDistance;
    private bool shootRay = false;
    public GameObject diamondBar;
    [Space]
    public float shakeMagnitude, shakeRoughness, shakeFadeInTime, shakeFadeOutTime;

    private void Update()
    {
        //instantiate ray2d and check only the diamond bar layermask
        if (shootRay)
        {
            RaycastHit2D rayHitRight = Physics2D.Raycast(transform.position, Vector2.right, rayDistance, 1 << 9);
            Debug.DrawRay(transform.position, Vector2.right * rayDistance, Color.green, 0);

            //check if a ray hitted the diamond bar
            if (rayHitRight.collider != null)
            {
                AnimationEffects();
                shootRay = false;
            }
        }
        
    }

    private void AnimationEffects()
    {
        //camera shake
        CameraShaker.Instance.ShakeOnce(shakeMagnitude, shakeRoughness, shakeFadeInTime, shakeFadeOutTime);
        //open the bars
        diamondBar.GetComponent<DiamondBarController>().OpenAnimation();
    }

    public void EnablerRay()
    {
        shootRay = true;
    }

}
