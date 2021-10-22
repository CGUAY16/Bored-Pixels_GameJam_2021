using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    [SerializeField] LayerMask playerLayerMask; // player's layer mask in order to check whether player is close to switch or not.
    [SerializeField] Sprite[] sprites; // sprite[0] will be sprite for off, sprite[1] will be sprite for on.

    private bool switchState;
    private bool spriteChanged; // trigger for checking if a change in a switch occured
    private SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        spriteChanged = false;
        switchState = false;
        sr = this.gameObject.GetComponent<SpriteRenderer>();

        DoorBehavior.OnSwitchsTriggered += GetSwitchState; // THERE IS AN ISSUE WHERE ONLY ONE "GETSWITCHSTATE" IS CALLED WHILE THE OTHER ISNT
    }

    private void OnDestroy()
    {
        DoorBehavior.OnSwitchsTriggered -= GetSwitchState;
    }

    // Update is called once per frame
    void Update()
    {
        if (spriteChanged)
        {
            if (switchState == true)
            {
                sr.sprite = sprites[1];
            }
            else
            {
                sr.sprite = sprites[0];
            }
            spriteChanged = false;
        }

        Collider2D circleCol = Physics2D.OverlapCircle(this.gameObject.transform.position, 0.5f, playerLayerMask);
        if (circleCol != null && Input.GetKeyDown(KeyCode.Q))
        {
            switchState = !switchState;
            spriteChanged = true;
        }
    }

    public bool GetSwitchState()
    {
        return switchState;
    }
}
