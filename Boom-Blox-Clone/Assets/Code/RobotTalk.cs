using System;
using UnityEngine;
using UnityEngine.UI;

public class RobotTalk : MonoBehaviour { 

    private static Text robotDialogue;
    public static int collisionCount = 0;
    public static bool firstHit = true;

    private static String[] dialoguePool = {"lol do you even lift bro?", "You hit like that wimp Megatron", "Really? I don't even move...","Are you even trying?","Pfft, almost as pathetic as my design"};

    internal void Start()
    {
        robotDialogue = GetComponent<Text>();

    }

    public static void DeathText()
    {
        robotDialogue.text = "NOOOO! Curse my hubris!";
    }

    public static void ChangeText()
    {
        if (GameObject.FindGameObjectWithTag("Bomb"))
        {
            if(firstHit || collisionCount >= 2)
            {
                int index = UnityEngine.Random.Range(0, dialoguePool.Length);
                robotDialogue.text = dialoguePool[index];
                firstHit = false;
                collisionCount = 0;
            }

            else
                collisionCount++;
        }  
    }


}