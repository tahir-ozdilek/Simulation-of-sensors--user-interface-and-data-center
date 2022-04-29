using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace thesis_UI1
{
    public class Holder
    {
        public Sensor sensor { get; set; }

        public Question question { get; set; }
    }

    public class BaseSpecifiedConcreteClassConverter : DefaultContractResolver
    {
        protected override JsonConverter ResolveContractConverter(Type objectType)
        {
            if ((typeof(Sensor).IsAssignableFrom(objectType) && !objectType.IsAbstract) ||
                (typeof(GeneratingParameterDayLight).IsAssignableFrom(objectType) && !objectType.IsAbstract))
                return null; // pretend TableSortRuleConvert is not specified (thus avoiding a stack overflow)
            return base.ResolveContractConverter(objectType);
        }
    }

    public class BaseConverter : JsonConverter
    {
        static JsonSerializerSettings SpecifiedSubclassConversion = new JsonSerializerSettings() { ContractResolver = new BaseSpecifiedConcreteClassConverter() };

        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(Sensor) || objectType == typeof(GeneratingParameterDayLight));
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject jo = JObject.Load(reader);
            switch (jo["subClassType"].Value<int>())
            {
                case (int)Sensor.subClassTypes.BloodSugar:
                    return JsonConvert.DeserializeObject<BloodSugar>(jo.ToString(), SpecifiedSubclassConversion);
                case (int)Sensor.subClassTypes.BloodPressure:
                    return JsonConvert.DeserializeObject<BloodPressure>(jo.ToString(), SpecifiedSubclassConversion);
                case (int)Sensor.subClassTypes.HeartRate:
                    return JsonConvert.DeserializeObject<HeartRate>(jo.ToString(), SpecifiedSubclassConversion);
                case (int)GeneratingParameterDayLight.subClassTypes.ExerciseIntensity:
                    return JsonConvert.DeserializeObject<ExerciseIntensity>(jo.ToString(), SpecifiedSubclassConversion);
                default:
                    throw new Exception();
            }
            throw new NotImplementedException();
        }

        public override bool CanWrite
        {
            get { return false; }
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException(); // won't be called because CanWrite returns false
        }

    }
}
