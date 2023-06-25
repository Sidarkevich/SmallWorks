using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderObject : MonoBehaviour
{
    private enum  BorderType
    {
        Other,
        Top,
        Bottom,
        Left,
        Right
    }

    [SerializeField] private BorderType _border;

    private void Awake()
    {
        Camera camera = Camera.main;

        var lefBottom = camera.ScreenToWorldPoint(Vector3.zero);
        var rightTop = camera.ScreenToWorldPoint(new Vector3(camera.pixelWidth, camera.pixelHeight, 0));

        Debug.Log(rightTop);

        switch (_border)
        {
            case BorderType.Top :
            {
                transform.position = new Vector3(0, rightTop.y, transform.position.z);
                break;
            }
            case BorderType.Bottom :
            {
                transform.position = new Vector3(0, lefBottom.y, transform.position.z);     
                break;
            }
            case BorderType.Left :
            {
                transform.position = new Vector3(lefBottom.x, 0, transform.position.z);               
                break;
            }
            case BorderType.Right :
            {
                transform.position = new Vector3(rightTop.x, 0, transform.position.z);                
                break;
            }
            default :
            {
                break;
            }
        }       
    }
}
