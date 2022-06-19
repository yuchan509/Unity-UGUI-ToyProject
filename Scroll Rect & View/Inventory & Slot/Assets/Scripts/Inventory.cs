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
        // Veiwport �Ʒ��� �ִ� Content�� �����ϴ� Clone�� ItemPrefab�� ��������.
        ItemPrefab = transform.GetChild(0).gameObject;
        
        // Resource/Inventrory�� ���� Sprite Type�� ������.
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


            // Clone �� Obj �̸� ���� -> �� ���� clone �Ǿ������� �˱� ���� Index �߰�.
            int idx = obj.name.IndexOf("(Clone)");
            if (idx > 0)
                obj.name = obj.name.Substring(0, idx);

            obj.name += index;
            index ++;
        }

        Destroy(ItemPrefab);
    }

}
