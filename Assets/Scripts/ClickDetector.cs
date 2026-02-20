using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickDetector : MonoBehaviour
{
    public Texture2D cursornormal;
    public Texture2D hovercursor;
    private Vector2 hotspot = new Vector2(0.5f, 0.5f);
   public Teleport teleport;
    public bool spawnenemy = false;
    public Spawnerenemy spawnerenemy;






    private void Start()
    {
        
    }





    private void OnMouseEnter()
    {
        Cursor.SetCursor(hovercursor, hotspot, CursorMode.Auto);
        Cursor.visible = true;

    }

    private void OnMouseExit()
    { 
        Cursor.SetCursor(cursornormal, hotspot, CursorMode.Auto);
       
        Cursor.visible = false;
       

    }

    private void OnMouseDown()
    {
        Debug.Log("игрок нажал на кнопку" + gameObject.name);
        if (teleport != null )
        {
            teleport.Onclick();
        }
        
        if (spawnenemy)
        {
            spawnerenemy.SpawnOnbutton();

        }


    }




}
