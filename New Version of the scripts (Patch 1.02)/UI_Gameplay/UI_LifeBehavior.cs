using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_LifeBehavior : MonoBehaviour
{
    [SerializeField] Sprite[] boneHeartSprites; // empty-> half -> full
    [SerializeField] Image[] heartObjects; // from leftmost heart to rightmost heart

    private void Awake()
    {
        // 6 -> full health/ 0 -> no health
        switch (PlayerController.health)
        {
            case (6):
                {
                    heartObjects[0].sprite = boneHeartSprites[2];
                    heartObjects[1].sprite = boneHeartSprites[2];
                    heartObjects[2].sprite = boneHeartSprites[2];
                    break;
                }
            case (5):
                {
                    heartObjects[0].sprite = boneHeartSprites[1];
                    heartObjects[1].sprite = boneHeartSprites[2];
                    heartObjects[2].sprite = boneHeartSprites[2];
                    break;
                }
            case (4):
                {
                    heartObjects[0].sprite = boneHeartSprites[0];
                    heartObjects[1].sprite = boneHeartSprites[2];
                    heartObjects[2].sprite = boneHeartSprites[2];
                    break;
                }
            case (3):
                {
                    heartObjects[0].sprite = boneHeartSprites[0];
                    heartObjects[1].sprite = boneHeartSprites[1];
                    heartObjects[2].sprite = boneHeartSprites[2];
                    break;
                }
            case (2):
                {
                    heartObjects[0].sprite = boneHeartSprites[0];
                    heartObjects[1].sprite = boneHeartSprites[0];
                    heartObjects[2].sprite = boneHeartSprites[2];
                    break;
                }
            case (1):
                {
                    heartObjects[0].sprite = boneHeartSprites[0];
                    heartObjects[1].sprite = boneHeartSprites[0];
                    heartObjects[2].sprite = boneHeartSprites[1];
                    break;
                }
            case (0):
                {
                    heartObjects[0].sprite = boneHeartSprites[0];
                    heartObjects[1].sprite = boneHeartSprites[0];
                    heartObjects[2].sprite = boneHeartSprites[0];
                    break;
                }
            default:
                {
                    break;
                }
        }
    }

    // Update is called once per frame
    void Update()
    {
        // 6 -> full health/ 0 -> no health
        switch (PlayerController.health)
        {
            case (6):
                {
                    heartObjects[0].sprite = boneHeartSprites[2];
                    heartObjects[1].sprite = boneHeartSprites[2];
                    heartObjects[2].sprite = boneHeartSprites[2];
                    break;
                }
            case (5):
                {
                    heartObjects[0].sprite = boneHeartSprites[1];
                    heartObjects[1].sprite = boneHeartSprites[2];
                    heartObjects[2].sprite = boneHeartSprites[2];
                    break;
                }
            case (4):
                {
                    heartObjects[0].sprite = boneHeartSprites[0];
                    heartObjects[1].sprite = boneHeartSprites[2];
                    heartObjects[2].sprite = boneHeartSprites[2];
                    break;
                }
            case (3):
                {
                    heartObjects[0].sprite = boneHeartSprites[0];
                    heartObjects[1].sprite = boneHeartSprites[1];
                    heartObjects[2].sprite = boneHeartSprites[2];
                    break;
                }
            case (2):
                {
                    heartObjects[0].sprite = boneHeartSprites[0];
                    heartObjects[1].sprite = boneHeartSprites[0];
                    heartObjects[2].sprite = boneHeartSprites[2];
                    break;
                }
            case (1):
                {
                    heartObjects[0].sprite = boneHeartSprites[0];
                    heartObjects[1].sprite = boneHeartSprites[0];
                    heartObjects[2].sprite = boneHeartSprites[1];
                    break;
                }
            case (0):
                {
                    heartObjects[0].sprite = boneHeartSprites[0];
                    heartObjects[1].sprite = boneHeartSprites[0];
                    heartObjects[2].sprite = boneHeartSprites[0];
                    break;
                }
            default:
                {
                    break;
                }
        }
    }
}
