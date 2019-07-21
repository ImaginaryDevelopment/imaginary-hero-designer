using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Base;

public class SummonedEntity
{
    int _nID = -1;
    int _nClassID;
    int[] _nPowerset = Array<int>.Empty();
    int[] _nUpgradePower = Array<int>.Empty();

    public string UID { get; set; } = string.Empty;
    public string DisplayName { get; set; } = string.Empty;
    public string[] PowersetFullName { get; private set; } = Array<string>.Empty();
    public string[] UpgradePowerFullName { get; private set; } = Array<string>.Empty();
    public string ClassName { get; set; } = string.Empty;
    public Enums.eSummonEntity EntityType { get; set; }

    // semi-props
    // would be properties, but shouldn't be serialized, and aren't outwardly mutable
    public IReadOnlyList<int> GetNPowerset() => _nPowerset.AsReadOnly();
    public IReadOnlyList<int> GetNUpgradePower() => _nUpgradePower.AsReadOnly();
    public int GetNId() => _nID;
    public int GetNClassId() => _nClassID;


    public SummonedEntity()
    {
    }

    public SummonedEntity(int nID) : this()
    {
        this._nID = nID;
    }

    public SummonedEntity(BinaryReader reader) : this()
    {
        this.UID = reader.ReadString();
        this.DisplayName = reader.ReadString();
        this.EntityType = (Enums.eSummonEntity)reader.ReadInt32();
        this.ClassName = reader.ReadString();
        this.PowersetFullName = new string[reader.ReadInt32()];
        this._nPowerset = new int[this.PowersetFullName.Length];
        for (int index = 0; index <= this.PowersetFullName.Length - 1; ++index)
            this.PowersetFullName[index] = reader.ReadString();
        this.UpgradePowerFullName = new string[reader.ReadInt32()];
        this._nUpgradePower = new int[this.PowersetFullName.Length];
        for (int index = 0; index <= this.UpgradePowerFullName.Length - 1; ++index)
            this.UpgradePowerFullName[index] = reader.ReadString();
    }

    public static SummonedEntity AddEntity()
    {
        SummonedEntity iEntity = new SummonedEntity();
        int num1 = 0;
        bool stop;
        do
        {
            iEntity.UID = "NewEntity_" + num1.ToString();
            stop = true;
            int num2 = DatabaseAPI.Database.Entities.Length - 1;
            for (int index = 0; index <= num2; ++index)
            {
                if (DatabaseAPI.Database.Entities[index].UID.ToLower() == iEntity.UID.ToLower())
                    stop = false;
            }
            ++num1;
        }
        while (!stop);
        return iEntity;
    }

    public SummonedEntity(SummonedEntity template, int? nIdOverride = null)
    {
        this.UID = template.UID;
        this.EntityType = template.EntityType;
        this.ClassName = template.ClassName;
        this._nClassID = template._nClassID;
        this.DisplayName = template.DisplayName;
        this._nID = nIdOverride ?? template._nID;

        this.PowersetFullName = template.PowersetFullName.ToArray();
        this._nPowerset = template._nPowerset.ToArray();
        this.UpgradePowerFullName = template.UpgradePowerFullName.ToArray();
        this._nUpgradePower = template._nUpgradePower.ToArray();
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
        int num3 = DatabaseAPI.NidFromUidClass(this.ClassName);
        if (num3 > -1)
            this._nClassID = num3;
        return num3 > -1;
    }

    public void PAdd()
        => this.PowersetFullName = this.PowersetFullName.Append("Empty").ToArray();

    public void PDelete(int selectedIndex)
        => this.PowersetFullName = this.PowersetFullName.RemoveIndex(selectedIndex);

    public void StoreTo(BinaryWriter writer)
    {
        writer.Write(this.UID);
        writer.Write(this.DisplayName);
        writer.Write((int)this.EntityType);
        writer.Write(this.ClassName);
        writer.Write(this.PowersetFullName.Length);
        for (int index = 0; index <= this.PowersetFullName.Length - 1; ++index)
            writer.Write(this.PowersetFullName[index]);
        writer.Write(this.UpgradePowerFullName.Length);
        for (int index = 0; index <= this.UpgradePowerFullName.Length - 1; ++index)
            writer.Write(this.UpgradePowerFullName[index]);
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
        entity1.UpgradePowerFullName = Array<string>.Empty();
        entity1._nUpgradePower = Array<int>.Empty();
    }

    public void UGAdd()
        => this.UpgradePowerFullName = this.UpgradePowerFullName.Append("Empty").ToArray();

    public void UGDelete(int selectedIndex) =>
        this.UpgradePowerFullName = this.UpgradePowerFullName.RemoveIndex(selectedIndex);
}
