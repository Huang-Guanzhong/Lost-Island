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

    private void OnEnable()
    {
        EventHandler.AfterSceneloadEvent += OnAfterSceneloadEvent;
    }

    private void OnDisable()
    {
        EventHandler.AfterSceneloadEvent -= OnAfterSceneloadEvent;
    }

    private void OnAfterSceneloadEvent()
    {
        if (!isDone)
        {
            transform.GetChild(0).gameObject.SetActive(false);
        }
        else
        {
            spriteRender.sprite = openSprite;
            coll.enabled = false;
        }
    }

    protected override void OnClickedAction()
    {
        spriteRender.sprite = openSprite;
    }
}
