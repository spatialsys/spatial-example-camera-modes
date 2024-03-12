using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CreatorToolkitCustomScripts
{
    public class Rotate : MonoBehaviour
    {
        void Update()
        {
            transform.Rotate(new Vector3(0, 15 * Time.deltaTime));
        }
    }
}
