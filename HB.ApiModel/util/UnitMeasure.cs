﻿using System;
using Newtonsoft.Json;

namespace HB.ApiModel.util
{
    public class UnitMeasure
    {
        public enum UnitMeasureType
        {
            m,
            km
        }

        public class typeConverter : JsonConverter
        {
            public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
            {
                var type = (UnitMeasureType) value;

                switch (type)
                {
                    case UnitMeasureType.km:
                        writer.WriteValue("km");
                        break;
                    case UnitMeasureType.m:
                        writer.WriteValue("m");
                        break;
                }
            }

            public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
                JsonSerializer serializer)
            {
                var value = (string) reader.Value;
                UnitMeasureType? type = null;

                if (value == "km")
                    type = UnitMeasureType.km;
                else if (value == "m")
                    type = UnitMeasureType.m;

                return type;
            }

            public override bool CanConvert(Type objectType)
            {
                return objectType == typeof (string);
            }
        }
    }
}