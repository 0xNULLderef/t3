using System.Collections.Generic;

namespace T3.Core.Animation
{
    public static class ConstInterpolator
    {
        public static void UpdateTangents(List<KeyValuePair<double, VDefinition>> curveElements) { }

        public static double Interpolate(KeyValuePair<double, VDefinition> a, KeyValuePair<double, VDefinition> b, double u)
        {
            return a.Value.Value;
        }
    };

}
