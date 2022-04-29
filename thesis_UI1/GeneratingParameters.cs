using Newtonsoft.Json;
using System.Windows.Forms;

namespace thesis_UI1
{
    public class GeneratingParameterReadyToAssign
    {
        [JsonProperty(ItemIsReference = true)]
        public SelectionRange timeIntervalForParameter;

        [JsonProperty(ItemIsReference = true)]
        public GeneratingParameterDayLight generatingParameter;

        public GeneratingParameterReadyToAssign(SelectionRange timeIntervalForParameter, GeneratingParameterDayLight generatingParameter)
        {
            this.timeIntervalForParameter = timeIntervalForParameter;
            this.generatingParameter = generatingParameter;
        }
    }

    [JsonConverter(typeof(BaseConverter))]
    abstract public class GeneratingParameterDayLight
    {
        public enum subClassTypes { ExerciseIntensity = 100 };
        public int subClassType { get; set; }

        abstract public string Name { get; set; }
        abstract public int Value { get; set; }
        abstract public ExerciseIntensity newExerciseIntensityInstance(int value);
    }


    public class ExerciseIntensity : GeneratingParameterDayLight
    {
        override public string Name {get; set;}
        override public int Value { get; set; } // percentage. 30-50 idle, 50+ exercising.
                                // (i.e. when sleeping) A normal heart rate can range anywhere from 40 to 100 beats per minute (BPM) 

        public ExerciseIntensity(int value)
        {
            Name = "ExerciseIntensity";
            this.Value = value;
            subClassType = (int)subClassTypes.ExerciseIntensity;
        }

        override public ExerciseIntensity newExerciseIntensityInstance(int value)
        {
            return new ExerciseIntensity(value);
        }
    }
}
