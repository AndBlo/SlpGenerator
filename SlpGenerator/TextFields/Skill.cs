using SlpGenerator.TextFields.Lists;

namespace SlpGenerator.TextFields
{
    public static class Skill
    {
        public static NameList Skills { get; set; } = new NameList();

        public static PointList SkillPoints { get; set; } = new PointList();
    }
}
