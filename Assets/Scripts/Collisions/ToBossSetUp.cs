using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class ToBossSetUp : MonoBehaviour {

    public CameraShaker mainCamera;
    public GameObject diamondBar;
    public float waitTime;
    [Space]
    public GameObject bossBattleManager;
    public float shakeMagnitude, shakeRoughness, shakeFadeInTime, shakeFadeOutTime;
    private int i = 0;

    public void FixedUpdate()
    {
        if (mainCamera.cameraPos == new Vector3(24f, 0f, -10f) && i == 0)
        {
            i++;
            StartCoroutine(CloseDiamondBars(waitTime));
        }
    }

    IEnumerator CloseDiamondBars(float t)
    {
        yield return new WaitForSeconds(t);
        AnimationEffects();
        //disable this component
        gameObject.GetComponent<ToBossSetUp>().enabled = false;
        //start boss battle
        bossBattleManager.SetActive(true);
    }

    private void AnimationEffects()
    {
        //close the bar
        diamondBar.GetComponent<DiamondBarController>().CloseAnimation();
        //camera shake
        CameraShaker.Instance.ShakeOnce(shakeMagnitude, shakeRoughness, shakeFadeInTime, shakeFadeOutTime);
    }

}
