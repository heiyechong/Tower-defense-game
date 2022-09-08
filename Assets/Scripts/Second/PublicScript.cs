using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PublicScript 
{
    static private PublicScript publicscript;
    //第几个关卡
    public int levelnumber;

    public Dictionary<int, int> dic;

    public int starcount;
    //私有构造函数
    private PublicScript()
    {
        dic = new Dictionary<int, int>();
    }
    static public PublicScript danli()
    {
        if (publicscript == null)
        {
            publicscript = new PublicScript();
           
        }
        return publicscript;

    }

   


}
