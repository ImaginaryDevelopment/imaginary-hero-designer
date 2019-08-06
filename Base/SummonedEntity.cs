using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Base;

public class SummonedEntity
{
    int _nID = -1;
    int _nClassID;
    int[] _nPowerset = Array.Empty<int>();
    int[] _nUpgradePower = Array.Empty<int>();

    public string UID { get; set; } = string.Empty;
    public string DisplayName { get; set; } = string.Empty;
    public string[] PowersetFullName { get; private set; } = Array.Empty<string>();
    public string[] UpgradePowerFullName { get; private set; } = Array.Empty<string>();
    public string ClassName { get; set; } = string.Empty;
    public Enums.eSummonEntity EntityType { get; set; }

    // semi-props
    // would be properties, but shouldn't be serialized, and aren't outwardly mutable
    public IReadOnlyList<int> GetNPowerset() => _nPowerset;
    public IReadOnlyList<int> GetNUpgradePower() => _nUpgradePower;
    public int GetNId() => _nID;
    public int GetNClassId() => _nClassID;


    public SummonedEntity()
    {
    }

    public SummonedEntity(int nID) : this()
    {
        _nID = nID;
    }

    public SummonedEntity(BinaryReader reader) : this()
    {
        UID = reader.ReadString();
        DisplayName = reader.ReadString();
        EntityType = (Enums.eSummonEntity)reader.ReadInt32();
        ClassName = reader.ReadString();
        PowersetFullName = new string[reader.ReadInt32()];
        _nPowerset = new int[PowersetFullName.Length];
        for (int index = 0; index <= PowersetFullName.Length - 1; ++index)
            PowersetFullName[index] = reader.ReadString();
        UpgradePowerFullName = new string[reader.ReadInt32()];
        _nUpgradePower = new int[PowersetFullName.Length];
        for (int index = 0; index <= UpgradePowerFullName.Length - 1; ++index)
            UpgradePowerFullName[index] = reader.ReadString();
    }

    public static SummonedEntity AddEntity()
    {
        SummonedEntity iEntity = new SummonedEntity();
        int num1 = 0;
        bool stop;
        do
        {
            iEntity.UID = "NewEntity_" + num1;
            stop = true;
            int num2 = DatabaseAPI.Database.Entities.Length - 1;
            for (int index = 0; index <= num2; ++index)
            {
                if (String.Equals(DatabaseAPI.Database.Entities[index].UID, iEntity.UID, StringComparison.CurrentCultureIgnoreCase))
                    stop = false;
            }
            ++num1;
        }
        while (!stop);
        return iEntity;
    }

    public SummonedEntity(SummonedEntity template, int? nIdOverride = null)
    {
        UID = template.UID;
        EntityType = template.EntityType;
        ClassName = template.ClassName;
        _nClassID = template._nClassID;
        DisplayName = template.DisplayName;
        _nID = nIdOverride ?? template._nID;

        PowersetFullName = template.PowersetFullName.ToArray();
        _nPowerset = template._nPowerset.ToArray();
        UpgradePowerFullName = template.UpgradePowerFullName.ToArray();
        _nUpgradePower = template._nUpgradePower.ToArray();
    }

    public static void MatchSummonIDs(Func<string, int> nIdFromUidClass, Func<string, int> nidFromUidPowerset, Func<string, int> nidFromUidPower)
    {
        for (int ei = 0; ei <= DatabaseAPI.Database.Entities.Length - 1; ++ei)
        {
            SummonedEntity entity = DatabaseAPI.Database.Entities[ei];
            entity._nID = ei;
            entity._nClassID = nIdFromUidClass(entity.ClassName);
            entity._nPowerset = entity.PowersetFullName.Select(nidFromUidPowerset).ToArray();
            entity._nUpgradePower = entity.UpgradePowerFullName.Select(nidFromUidPower).ToArray();
        }
    }

    public bool UpdateNClassID(Func<string, int> nidFromUidClass)
    {
        int num3 = DatabaseAPI.NidFromUidClass(ClassName);
        if (num3 > -1)
            _nClassID = num3;
        return num3 > -1;
    }

    public void PAdd()
        => PowersetFullName = PowersetFullName.Append("Empty").ToArray();

    public void PDelete(int selectedIndex)
        => PowersetFullName = PowersetFullName.RemoveIndex(selectedIndex);

    public void StoreTo(BinaryWriter writer)
    {
        writer.Write(UID);
        writer.Write(DisplayName);
        writer.Write((int)EntityType);
        writer.Write(ClassName);
        writer.Write(PowersetFullName.Length);
        for (int index = 0; index <= PowersetFullName.Length - 1; ++index)
            writer.Write(PowersetFullName[index]);
        writer.Write(UpgradePowerFullName.Length);
        for (int index = 0; index <= UpgradePowerFullName.Length - 1; ++index)
            writer.Write(UpgradePowerFullName[index]);
    }

    public static void Parse(int index, string powersetFullName, string displayName, string uidEntity)
    {
        if (index < 0)
        {
            IDatabase database = DatabaseAPI.Database;
            database.Entities = database.Entities.Append(
                new SummonedEntity(nID: database.Entities.Length)
                {
                    UID = uidEntity
                }).ToArray();
            index = database.Entities.Length - 1;
        }

        SummonedEntity entity1 = DatabaseAPI.Database.Entities[index];
        entity1.DisplayName = displayName;
        entity1.ClassName = "Class_Minion_Pets";
        entity1._nClassID = DatabaseAPI.NidFromUidClass(entity1.ClassName);
        entity1.EntityType = Enums.eSummonEntity.Pet;
        entity1.PowersetFullName = new string[1];
        entity1._nPowerset = new int[1];
        entity1.PowersetFullName[0] = powersetFullName;
        entity1._nPowerset[0] = DatabaseAPI.NidFromUidPowerset(entity1.PowersetFullName[0]);
        entity1.UpgradePowerFullName = Array.Empty<string>();
        entity1._nUpgradePower = Array.Empty<int>();
    }

    public void UGAdd()
        => UpgradePowerFullName = UpgradePowerFullName.Append("Empty").ToArray();

    public void UGDelete(int selectedIndex) =>
        UpgradePowerFullName = UpgradePowerFullName.RemoveIndex(selectedIndex);
}
