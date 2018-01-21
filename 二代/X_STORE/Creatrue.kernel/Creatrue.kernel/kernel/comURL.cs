using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Creatrue.kernel
{
public class Class_API
{
    private string _UrlValue;
    //这个参数可以在客户端循环读取所有参数

    public Hashtable ItemList = new Hashtable();
    public Class_API()
    {
    }

    public Class_API(string UrlValue)
    {
        _UrlValue = UrlValue;
        Reset(_UrlValue);
        //解析参数
    }

    public string GetItemValue(string ItemName)
    {
        string LowerItemName = ItemName.ToLower();
        if (ItemList.Contains(LowerItemName))
        {
            return Convert.ToString(ItemList[LowerItemName]).Replace("＝", "=").Replace("＆", "&");
        }
        else
        {
            return "ItemNull";
        }
    }

    public void AddItem(string Key, string Value)
    {
        try
        {
            Key = Key.ToLower().Replace("&", "＆");
        }
        catch (Exception ex)
        {
        }
        try
        {
            Value = Value.Replace("=", "＝");
        }
        catch (Exception ex)
        {
        }

        if (ItemList.Contains(Key))
        {
            ItemList[Key] = Value;
        }
        else
        {
            ItemList.Add(Key, Value);
        }
    }

    public string UrlValue
    {
        get
        {
            _UrlValue = "";

            foreach (System.Collections.DictionaryEntry r in ItemList)
            {
                _UrlValue += r.Key + "=" + r.Value + "&";
            }

            if (_UrlValue .Substring (_UrlValue .Length -2,1) == "&")
            //if (Strings.Right(_UrlValue, 1) == "&")
            {
                return _UrlValue.Substring(0, _UrlValue.Length  - 1).Trim();
                //return Strings.Left(_UrlValue, Strings.Len(_UrlValue) - 1).Trim();
            }
            else
            {
                return _UrlValue.Trim();
            }
        }
    }

    private void Reset(string UrlValue)
    {
        string[] Group = UrlValue.Split(Convert.ToChar("&"));
        foreach (string Item in Group)
        {
            string[] Items = Item.Split(Convert.ToChar("="));
            if (Items.Length >= 2)
            {
                if (ItemList.Contains(Items[0].ToLower()))
                {
                    ItemList[Items[0].ToLower()] = Items[1];
                }
                else
                {
                    ItemList.Add(Items[0].ToLower(), Items[1]);
                }
            }
        }
    }
}
}