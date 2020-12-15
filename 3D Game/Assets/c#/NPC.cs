using UnityEngine;

public class NPC : MonoBehaviour
{
    [Header("NPC 資料")]
    public NPCData data;

    public bool playerInArea;

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "機器人")
        {
            playerInArea = true;
            Dialog();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.name == "機器人")
        {
            playerInArea = false;
        }
    }

    private void Dialog()
    {
        for(int i = 0; i < data.dialogA.Length; i++)
        {
            print(data.dialogA[i]);
        }
    }
}
