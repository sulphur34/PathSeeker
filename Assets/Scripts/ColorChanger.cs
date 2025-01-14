using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ColorChanger : MonoBehaviour
{

    [SerializeField] Image[] images;

    private Color[] GenerateColorShades(Color baseColor, int numShades)
    {
        float h, s, l;
        Color.RGBToHSV(baseColor, out h, out s, out l);

        Color[] shades = new Color[numShades];

        for (int i = 0; i < numShades; i++)
        {
            l += (i / (float)numShades);
            shades[i] = Color.HSVToRGB(h, s, l);
        }

        return shades;
    }

    void Start()
    {
        Color baseColor = images[0].color;

        Color[] shades = GenerateColorShades(baseColor, images.Length);

        for (int i = 0; i < shades.Length; i++)
        {
            images[i].color = shades[i]; 
        }
    }


    //[SerializeField] Image _image;
    //[SerializeField] Color[] _colors;
    //[SerializeField] TextMeshProUGUI _text;

    //private int _score;
    //private int _currentIndex;
    //private int _nextIndex;

    //private void Awake()
    //{
    //    _score = 1;
    //    _currentIndex = 0;
    //    _nextIndex = _currentIndex + 1;
    //    SetNextColor();
    //}

    //private void SetNextColor()
    //{
    //    StartCoroutine(SwitchColor(_colors[_currentIndex], _colors[_currentIndex + 1]));
    //    _nextIndex = _nextIndex < _colors.Length - 1 ? _nextIndex += 1 : 0;
    //    _currentIndex = _currentIndex < _colors.Length - 1 ? _currentIndex += 1 : 0;
    //}


    //private IEnumerator SwitchColor(Color colorStart, Color colorEnd)
    //{
    //    Color color = colorStart;
    //    float interpolateValue = 0;
    //    float stepValue = 0.1f;

    //    while (color != colorEnd)
    //    {
    //        interpolateValue += stepValue;
    //        color = Color.Lerp(colorStart, colorEnd, interpolateValue);
    //        _image.color = color;
    //        yield return new WaitForSeconds(0.1f);
    //    }

    //    SetNextColor();
    //}

    //private IEnumerator ChangeHex()
    //{
    //    while (true)
    //    {
    //        string hexColor = "#" + _score.ToString("X6");
    //        _text.text = hexColor;
    //        ColorUtility.TryParseHtmlString(hexColor, out Color color);
    //        _image.color = color;
    //        yield return null;
    //        _score += 1000;
    //    }
    //}
}
