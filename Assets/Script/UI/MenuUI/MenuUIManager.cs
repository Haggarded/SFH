using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Coffee.UIEffects;


public class MenuUIManager : MonoBehaviour
{
    // Start is called before the first frame update
    public void PointIN()
    {
        UITransitionEffect transformEffect = GetComponent<UITransitionEffect>();
        transformEffect.Show(false);
    }
    public void PointOut()
    {
        UITransitionEffect transformEffect = GetComponent<UITransitionEffect>();
        transformEffect.Hide(false);
    }
    public void Gradually()
    {
        UITransitionEffect transformEffect = GetComponent<UITransitionEffect>();
        transformEffect.Hide(false);
        Destroy(this.gameObject, 1);
    }
    public void Fade()
    {
        UITransitionEffect transformEffect = GetComponent<UITransitionEffect>();
        transformEffect.Show(false);
    }
    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif

    }
}
