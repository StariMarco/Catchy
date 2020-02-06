using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOut : MonoBehaviour {

    public SpriteRenderer sprite;
    public float timeBeforeFadeOut;
    public float fadeOutSpeed;

    private Color spriteColor;

    public void Start()
    {
        spriteColor = sprite.color;
    }

    public void FixedUpdate()
    {
        timeBeforeFadeOut -= Time.fixedDeltaTime;
        if(timeBeforeFadeOut <= 0)
        {
            //destroy if alpha <= 0
            if (spriteColor.a <= 0)
                Destroy(gameObject);
            //fade out the sprite
            spriteColor.a -= 0.1f * fadeOutSpeed * Time.fixedDeltaTime;
            sprite.color = spriteColor;
        }
    }

}
