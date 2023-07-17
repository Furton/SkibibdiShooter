using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.IO;
using UnityEngine.Networking;

public class ChangeCharacter : MonoBehaviour
{
    public enum TypeEnum { character, back };
    public TypeEnum typeEnum = TypeEnum.character;

    public string url = "/item/";
    public string spriteName = "";


    public IntObject maxNumber;
    public Image characterImage;
    public Sprite initSprite;
    public Data data;


    private Dictionary<int, Sprite> sprites = new Dictionary<int, Sprite>();
    private bool isRoutineEnd = true;


    private void Start()
    {
        if (typeEnum == TypeEnum.character)
        {
            StartCoroutine(Load(data.skinNumber));
        }
        else
        {
            StartCoroutine(Load(data.backNumber));
        }
    }


    public void Change()
    {
        if(isRoutineEnd)
        {
            if (typeEnum == TypeEnum.character)
            {
                data.skinNumber++;
                data.skinNumber = data.skinNumber % maxNumber.myInt;
                SaveAndLoad.instance.Save();
                StartCoroutine(Load(data.skinNumber));
            }
            else
            {
                data.backNumber++;
                data.backNumber = data.backNumber % maxNumber.myInt;
                SaveAndLoad.instance.Save();
                StartCoroutine(Load(data.backNumber));
            }
        }

    }

    public void Reset()
    {
        StartCoroutine(Load(0));
    }

    private IEnumerator Load(int loadNumber)
    {
        isRoutineEnd = false;
        Color colorTemp = characterImage.color;
        characterImage.color = Color.black;

        if (sprites.ContainsKey(loadNumber))
        {
            Sprite value;
            sprites.TryGetValue(loadNumber, out value);
            characterImage.sprite = value;
        }
        else
        {

            if (loadNumber == 0)
            {
                characterImage.sprite = initSprite;
                if (!sprites.ContainsKey(loadNumber))
                {
                    sprites.Add(loadNumber, initSprite);
                }
            }
            else
            {


                string path = Application.streamingAssetsPath + url + loadNumber;
                using (UnityWebRequest www = UnityWebRequestAssetBundle.GetAssetBundle(path))
                {
                    yield return www.SendWebRequest();
                    if (www.result == UnityWebRequest.Result.Success)
                    {
                        var asssetBundle = DownloadHandlerAssetBundle.GetContent(www);
                        if (asssetBundle != null)
                        {
                            characterImage.sprite = asssetBundle.LoadAsset<Sprite>(spriteName + $"{loadNumber}");
                            if (!sprites.ContainsKey(loadNumber))
                            {
                                sprites.Add(loadNumber, characterImage.sprite);
                            }
                        }
                    }
                }   
            }
        }
        characterImage.enabled = true;



        yield return new WaitForSeconds(0.35f);
        characterImage.color = colorTemp;
        isRoutineEnd = true;


    }
}
