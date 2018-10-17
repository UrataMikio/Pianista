using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadText : MonoBehaviour
{
    // 読み込みファイル名
    public string fileName;

    // テキストオブジェクト
    public Text[] text;

    // 読み込みテキスト
    private TextAsset textAsset;

    // 読み込みデータ
    private string data;

    // 改行適応データ
    private string[] str;

    // 現在のインデックス
    private int index;

    private int flam;

    // 初期化
    private void Awake()
    {
        textAsset = new TextAsset();
    }
    // 初期化
    private void Start()
    {
        //読み込み
        textAsset = Resources.Load(fileName, typeof(TextAsset)) as TextAsset;

        //ファイルの文字すべて
        data = textAsset.text;

        //改行で分ける
        str = data.Split(char.Parse("\n"));

        index = 0;
        flam = 0;
    }

    // 処理
    private void Update()
    {
        for (int i = 0; i < text.Length; ++i)
        {
            text[i].text = str[index];
        }
        ++flam;
        if(flam >= 60)
        {
            index = (index + 1 >= str.Length) ? 0 : index + 1;
            flam = 0;
        }
    }
}
