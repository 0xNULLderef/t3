using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace T3.Core.Animation.Curves
{
    public class VDefinition
    {
        public enum Interpolation
        {
            Constant = 0,
            Linear,
            Spline,
        };

        public enum EditMode
        {
            Linear = 0,
            Smooth,
            Horizontal,
            Tangent,
            Constant,
            Cubic,
        }

        public double U { get; set; }
        public double Value { get; set; }
        public Interpolation InType { get; set; }
        public Interpolation OutType { get; set; }

        public EditMode InEditMode { get; set; }
        public EditMode OutEditMode { get; set; }

        public double InTangentAngle { get; set; }
        public double OutTangentAngle { get; set; }
        public bool Weighted { get; set; }
        public bool BrokenTangents { get; set; }

        public VDefinition()
        {
            Value = 0.0;
            InType = Interpolation.Spline;
            OutType = Interpolation.Spline;
            InEditMode = EditMode.Smooth;
            OutEditMode = EditMode.Smooth;
            InTangentAngle = 0.0;
            OutTangentAngle = 0.0;
        }

        public VDefinition Clone()
        {
            return new VDefinition()
            {
                Value = Value,
                U = U,
                InType = InType,
                OutType = OutType,
                InEditMode = InEditMode,
                OutEditMode = OutEditMode,
                InTangentAngle = InTangentAngle,
                OutTangentAngle = OutTangentAngle
            };
        }

        public void Read(JToken jsonV)
        {
            Value = jsonV["Value"].Value<double>();
            InType = (Interpolation)Enum.Parse(typeof(Interpolation), jsonV["InType"].Value<string>());
            OutType = (Interpolation)Enum.Parse(typeof(Interpolation), jsonV["OutType"].Value<string>());

            InTangentAngle = jsonV.Value<double>("InTangentAngle");
            OutTangentAngle = jsonV.Value<double>("OutTangentAngle");

            InEditMode = (EditMode)Enum.Parse(typeof(EditMode), jsonV["InEditMode"].Value<string>());
            OutEditMode = (EditMode)Enum.Parse(typeof(EditMode), jsonV["OutEditMode"].Value<string>());
        }

        public void Write(JsonTextWriter writer)
        {
            writer.WriteValue("Value", Value);
            writer.WriteValue("InType", InType);
            writer.WriteValue("OutType", OutType);
            writer.WriteValue("InEditMode", InEditMode);
            writer.WriteValue("OutEditMode", OutEditMode);
            writer.WriteValue("InTangentAngle", InTangentAngle);
            writer.WriteValue("OutTangentAngle", OutTangentAngle);
        }
    };
}