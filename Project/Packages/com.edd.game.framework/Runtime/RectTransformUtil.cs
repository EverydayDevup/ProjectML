using UnityEngine;

namespace EDD
{
    public static class RectTransformUtil
    {
        public static RectTransform GetCanvasRectTransform(this RectTransform rectTrans)
        {
            var parent = rectTrans.parent;
            return parent != null ? parent.GetComponent<RectTransform>() : null;
        }
    }
}