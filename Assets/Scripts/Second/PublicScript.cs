using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PublicScript 
{
    static private PublicScript publicscript;
    //�ڼ����ؿ�
    public int levelnumber;

    public Dictionary<int, int> dic;

    public int starcount;
    //˽�й��캯��
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
