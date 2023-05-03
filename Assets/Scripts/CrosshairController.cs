using UnityEngine;

public class CrosshairController : MonoBehaviour
{
    [SerializeField]
    private Texture2D crosshairTexture;
    [SerializeField]
    private int size = 32;

    private Rect crosshairPosition;

    void Start()
    {
        // Установка положения прицела посередине экрана
        float posX = (Screen.width - size) / 2;
        float posY = (Screen.height - size) / 2;

        crosshairPosition = new Rect(posX, posY, size, size);
    }

    void OnGUI()
    {
        // Отображение прицела на экране
        GUI.DrawTexture(crosshairPosition, crosshairTexture);
    }
}
