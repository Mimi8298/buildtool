using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace SuperUnityBuild.BuildTool
{
    [Serializable]
    public class ProductParameters
    {
        public string awsBuildCounterFunctionUrl = string.Empty;
        public string awsBuildVersionFunctionUrl = string.Empty;
        public string awsRegion = string.Empty;
    }
}
