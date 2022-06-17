using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


/// <summary>
/// Button Onclick AddListener.
/// </summary>
public static class ButtonExtension
{
    public static void AddEventListener<T>(this Button button, T Param, Action<T> OnClick)
    {
        button.onClick.AddListener(delegate ()
        {
            OnClick(Param);
        });
    }
}

public class Inventory : MonoBehaviour
{
    private GameObject ItemPrefab;
    private GameObject obj;
    private Sprite [] sprites;

    private void Start()
    {
        // Veiwport 아래에 있는 Content에 존재하는 Clone할 ItemPrefab을 가져오기.
        ItemPrefab = transform.GetChild(0).gameObject;
        
        // Resource/Inventrory로 부터 Sprite Type을 가져옴.
        sprites = Resources.LoadAll<Sprite>("Inventroy");

        if (sprites == null)
        {
            Debug.Log("Sprite is Null");
            return;
        }

        int index = 0;
        foreach (var sprite in sprites)
        {
            obj = Instantiate(ItemPrefab, transform);
            obj.transform.GetChild(0).GetComponent<Image>().sprite = sprite;


            // Clone 될 Obj 이름 변경 -> 몇 개가 clone 되었는지를 알기 위해 Index 추가.
            int idx = obj.name.IndexOf("(Clone)");
            if (idx > 0)
                obj.name = obj.name.Substring(0, idx);

            obj.name += index;
            index ++;
        }

        Destroy(ItemPrefab);
    }

}
