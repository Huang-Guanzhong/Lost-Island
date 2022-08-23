using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MailBox : Interactive
{
    private SpriteRenderer spriteRender;

    private BoxCollider2D coll;

    public Sprite openSprite;

    private void Awake()
    {
        spriteRender = GetComponent<SpriteRenderer>();
        coll = GetComponent<BoxCollider2D>();
    }

    protected override void OnClickedAction()
    {
        spriteRender.sprite = openSprite;
    }
}
