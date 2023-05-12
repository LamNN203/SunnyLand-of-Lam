using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePointOfLV1 : MonoBehaviour, IDataPersistence
{
    public BoxCollider2D coll;
    public DataPersistenceManager save;
    public PlayerController thispoint;
    public GameData Data;
    public int dk = 0; 
    public int TempHigh = 0 ;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if (thispoint.Coins > TempHigh)
            {
                 save.SaveGameLV1();
            }

        }
    }

    public void LoadData(GameData data)
    {
        TempHigh = data.Lv1High;
    }

    public void SaveData(ref GameData data )
    {
        
    }
}
