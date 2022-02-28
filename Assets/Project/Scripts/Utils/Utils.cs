using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utils {

    public static bool IsLayerInMask(int layer, LayerMask mask) {
        return mask == (mask | (1 << layer));
    }
}
