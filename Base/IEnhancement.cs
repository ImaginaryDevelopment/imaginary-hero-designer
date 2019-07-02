
using HeroDesigner.Schema;
using System.IO;

public interface IEnhancement
{
    bool HasEnhEffect { get; }

    bool HasPowerEffect { get; }

    eSchedule Schedule { get; }

    float Probability { get; }

    bool IsModified { get; set; }

    bool IsNew { get; set; }

    int StaticIndex { get; set; }

    string Name { get; set; }

    string ShortName { get; set; }

    string Desc { get; set; }

    eType TypeID { get; set; }

    eSubtype SubTypeID { get; set; }

    int[] ClassID { get; set; }

    string Image { get; set; }

    int ImageIdx { get; set; }

    int nIDSet { get; set; }

    string UIDSet { get; set; }

    //IPower Power { get; set; }
    IPower GetPower();
    void SetPower(IPower power);

    Enums.sEffect[] Effect { get; set; }

    float EffectChance { get; set; }

    int LevelMin { get; set; }

    int LevelMax { get; set; }

    bool Unique { get; set; }

    eEnhMutex MutExID { get; set; }

    eBuffDebuff BuffMode { get; set; }

    string RecipeName { get; set; }

    int RecipeIDX { get; set; }

    string UID { get; set; }

    bool Superior { get; set; }

    string LongName { get; }

    int CheckAndFixIOLevel(int level);

    void StoreTo(BinaryWriter writer);

    string GetSpecialName();
}
