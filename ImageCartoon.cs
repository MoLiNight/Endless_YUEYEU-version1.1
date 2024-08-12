using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ImageCartoon : MonoBehaviour
{
    public int TextureNode = 0;
    public float RestTime;
    public float alpha;
    public float OperationTime = 3.0f;
    public bool StartFade = false;
    public bool StartAppear = false;

    private string path = "/Picture/CardPersonalImage";
    public List<Texture2D> allTex2d = new List<Texture2D>();
    
    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            path = "/Picture/MenuBackground";
        }
        if(SceneManager.GetActiveScene().buildIndex == 1)
        {
            path = "/Picture/PlatformBackground";
        }
        if (SceneManager.GetActiveScene().buildIndex == 16)
        {
            path = "/Picture/KitchenImage";
        }
        LoadAllImage();
        if (SceneManager.GetActiveScene().buildIndex == 0 || SceneManager.GetActiveScene().buildIndex == 1)
        {
            Fade();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (path != "/Picture/CardPersonalImage" && path != "/Picture/KitchenImage") 
        {
            gameObject.GetComponent<RawImage>().texture = allTex2d[TextureNode];
            if (StartFade)
            {
                RestTime -= Time.deltaTime;
                if (RestTime < 3)
                {
                    alpha = RestTime / OperationTime;
                    gameObject.GetComponent<RawImage>().color = new Color(gameObject.GetComponent<RawImage>().color.r, gameObject.GetComponent<RawImage>().color.g, gameObject.GetComponent<RawImage>().color.b, alpha);
                    if (RestTime < 0)
                    {
                        StartFade = false;
                        TextureNode++;
                        if (TextureNode >= allTex2d.Count)
                        {
                            TextureNode = 0;
                        }
                        Appear();
                    }
                }
            }
            else
        if (StartAppear)
            {
                RestTime -= Time.deltaTime;
                alpha = (OperationTime - RestTime) / OperationTime;
                gameObject.GetComponent<RawImage>().color = new Color(gameObject.GetComponent<RawImage>().color.r, gameObject.GetComponent<RawImage>().color.g, gameObject.GetComponent<RawImage>().color.b, alpha);
                if (RestTime < 0)
                {
                    StartAppear = false;
                    Fade();
                }
            }
        }
    }

    public void Fade()
    {
        StartFade = true;
        RestTime = 18.0f;
    }

    public void Appear()
    {
        StartAppear = true;
        RestTime = 3.0f;
    }

    public void LoadAllImage()
    {
        
        if(allTex2d.Count > 0)
        {
            allTex2d.Clear();
        }

        List<string> filePaths = new List<string>();
        string imgtype = "*.BMP|*.JPG|*.GIF|*.PNG";
        string[] ImageType = imgtype.Split('|');
        for (int i = 0; i < ImageType.Length; i++)
        {
            string[] dirs = Directory.GetFiles((Application.dataPath + path), ImageType[i]);
            for (int j = 0; j < dirs.Length; j++)
            {
                filePaths.Add(dirs[j]);
            }
        }

        for (int i = 0; i < filePaths.Count; i++)
        {
            Texture2D tx = new Texture2D(100, 100);
            tx.LoadImage(getImageByte(filePaths[i]));
            allTex2d.Add(tx);
        }
    }
    
    private static byte[] getImageByte(string imagePath)
    {
        FileStream files = new FileStream(imagePath, FileMode.Open);
        byte[] imageByte=new byte[files.Length];
        files.Read(imageByte, 0, imageByte.Length);
        files.Close();
        return imageByte;
    }
}
