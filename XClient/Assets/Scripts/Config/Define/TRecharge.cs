// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: Excels/TRecharge
// </auto-generated>
#pragma warning disable 1591, 0612, 3021, 8981
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
/// <summary>Holder for reflection information generated from Excels/TRecharge</summary>
public static partial class TRechargeReflection {

  #region Descriptor
  /// <summary>File descriptor for Excels/TRecharge</summary>
  public static pbr::FileDescriptor Descriptor {
    get { return descriptor; }
  }
  private static pbr::FileDescriptor descriptor;

  static TRechargeReflection() {
    byte[] descriptorData = global::System.Convert.FromBase64String(
        string.Concat(
          "ChBFeGNlbHMvVFJlY2hhcmdlIvUCCg1UUmVjaGFyZ2VEYXRhEgoKAklEGAEg",
          "ASgFEg4KBkdzVHlwZRgCIAEoBRIOCgZQc1R5cGUYAyABKAUSEgoKUmVjaGFy",
          "Z2VMdhgEIAEoBRIUCgxDdXJyZW5jeVR5cGUYBSABKAkSFQoNUmVjaGFyZ2VN",
          "b25leRgGIAEoBRIRCglTaG93UHJpY2UYByABKAUSGAoQUmVjaGFyZ2VEaWFt",
          "b25kcxgIIAEoBRIiChpGaXJzdFJlY2hhcmdlRXh0cmFEaWFtb25kcxgJIAEo",
          "BRIOCgZEaWFua2EYCiABKAUSJAocRGFpbHlSZWNoYXJnZUV4dHJhRGlhbW9u",
          "ZHNBThgLIAEoBRIlCh1EYWlseVJlY2hhcmdlRXh0cmFEaWFtb25kc0lPUxgM",
          "IAEoBRIjChtJT1NSZWNoYXJnZURhaWx5UmVzdHJpY3Rpb24YDSABKAUSEgoK",
          "UmVhbGFtb3VudBgOIAEoBRIQCghEZXNjcmlwdBgPIAEoCSIqCglUUmVjaGFy",
          "Z2USHQoFZGF0YXMYASADKAsyDi5UUmVjaGFyZ2VEYXRhYgZwcm90bzM="));
    descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
        new pbr::FileDescriptor[] { },
        new pbr::GeneratedClrTypeInfo(null, null, new pbr::GeneratedClrTypeInfo[] {
          new pbr::GeneratedClrTypeInfo(typeof(global::TRechargeData), global::TRechargeData.Parser, new[]{ "ID", "GsType", "PsType", "RechargeLv", "CurrencyType", "RechargeMoney", "ShowPrice", "RechargeDiamonds", "FirstRechargeExtraDiamonds", "Dianka", "DailyRechargeExtraDiamondsAN", "DailyRechargeExtraDiamondsIOS", "IOSRechargeDailyRestriction", "Realamount", "Descript" }, null, null, null, null),
          new pbr::GeneratedClrTypeInfo(typeof(global::TRecharge), global::TRecharge.Parser, new[]{ "Datas" }, null, null, null, null)
        }));
  }
  #endregion

}
#region Messages
[global::System.Diagnostics.DebuggerDisplayAttribute("{ToString(),nq}")]
public sealed partial class TRechargeData : pb::IMessage<TRechargeData>
#if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    , pb::IBufferMessage
#endif
{
  private static readonly pb::MessageParser<TRechargeData> _parser = new pb::MessageParser<TRechargeData>(() => new TRechargeData());
  private pb::UnknownFieldSet _unknownFields;
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public static pb::MessageParser<TRechargeData> Parser { get { return _parser; } }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public static pbr::MessageDescriptor Descriptor {
    get { return global::TRechargeReflection.Descriptor.MessageTypes[0]; }
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  pbr::MessageDescriptor pb::IMessage.Descriptor {
    get { return Descriptor; }
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public TRechargeData() {
    OnConstruction();
  }

  partial void OnConstruction();

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public TRechargeData(TRechargeData other) : this() {
    iD_ = other.iD_;
    gsType_ = other.gsType_;
    psType_ = other.psType_;
    rechargeLv_ = other.rechargeLv_;
    currencyType_ = other.currencyType_;
    rechargeMoney_ = other.rechargeMoney_;
    showPrice_ = other.showPrice_;
    rechargeDiamonds_ = other.rechargeDiamonds_;
    firstRechargeExtraDiamonds_ = other.firstRechargeExtraDiamonds_;
    dianka_ = other.dianka_;
    dailyRechargeExtraDiamondsAN_ = other.dailyRechargeExtraDiamondsAN_;
    dailyRechargeExtraDiamondsIOS_ = other.dailyRechargeExtraDiamondsIOS_;
    iOSRechargeDailyRestriction_ = other.iOSRechargeDailyRestriction_;
    realamount_ = other.realamount_;
    descript_ = other.descript_;
    _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public TRechargeData Clone() {
    return new TRechargeData(this);
  }

  /// <summary>Field number for the "ID" field.</summary>
  public const int IDFieldNumber = 1;
  private int iD_;
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public int ID {
    get { return iD_; }
    set {
      iD_ = value;
    }
  }

  /// <summary>Field number for the "GsType" field.</summary>
  public const int GsTypeFieldNumber = 2;
  private int gsType_;
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public int GsType {
    get { return gsType_; }
    set {
      gsType_ = value;
    }
  }

  /// <summary>Field number for the "PsType" field.</summary>
  public const int PsTypeFieldNumber = 3;
  private int psType_;
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public int PsType {
    get { return psType_; }
    set {
      psType_ = value;
    }
  }

  /// <summary>Field number for the "RechargeLv" field.</summary>
  public const int RechargeLvFieldNumber = 4;
  private int rechargeLv_;
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public int RechargeLv {
    get { return rechargeLv_; }
    set {
      rechargeLv_ = value;
    }
  }

  /// <summary>Field number for the "CurrencyType" field.</summary>
  public const int CurrencyTypeFieldNumber = 5;
  private string currencyType_ = "";
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public string CurrencyType {
    get { return currencyType_; }
    set {
      currencyType_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
    }
  }

  /// <summary>Field number for the "RechargeMoney" field.</summary>
  public const int RechargeMoneyFieldNumber = 6;
  private int rechargeMoney_;
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public int RechargeMoney {
    get { return rechargeMoney_; }
    set {
      rechargeMoney_ = value;
    }
  }

  /// <summary>Field number for the "ShowPrice" field.</summary>
  public const int ShowPriceFieldNumber = 7;
  private int showPrice_;
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public int ShowPrice {
    get { return showPrice_; }
    set {
      showPrice_ = value;
    }
  }

  /// <summary>Field number for the "RechargeDiamonds" field.</summary>
  public const int RechargeDiamondsFieldNumber = 8;
  private int rechargeDiamonds_;
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public int RechargeDiamonds {
    get { return rechargeDiamonds_; }
    set {
      rechargeDiamonds_ = value;
    }
  }

  /// <summary>Field number for the "FirstRechargeExtraDiamonds" field.</summary>
  public const int FirstRechargeExtraDiamondsFieldNumber = 9;
  private int firstRechargeExtraDiamonds_;
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public int FirstRechargeExtraDiamonds {
    get { return firstRechargeExtraDiamonds_; }
    set {
      firstRechargeExtraDiamonds_ = value;
    }
  }

  /// <summary>Field number for the "Dianka" field.</summary>
  public const int DiankaFieldNumber = 10;
  private int dianka_;
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public int Dianka {
    get { return dianka_; }
    set {
      dianka_ = value;
    }
  }

  /// <summary>Field number for the "DailyRechargeExtraDiamondsAN" field.</summary>
  public const int DailyRechargeExtraDiamondsANFieldNumber = 11;
  private int dailyRechargeExtraDiamondsAN_;
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public int DailyRechargeExtraDiamondsAN {
    get { return dailyRechargeExtraDiamondsAN_; }
    set {
      dailyRechargeExtraDiamondsAN_ = value;
    }
  }

  /// <summary>Field number for the "DailyRechargeExtraDiamondsIOS" field.</summary>
  public const int DailyRechargeExtraDiamondsIOSFieldNumber = 12;
  private int dailyRechargeExtraDiamondsIOS_;
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public int DailyRechargeExtraDiamondsIOS {
    get { return dailyRechargeExtraDiamondsIOS_; }
    set {
      dailyRechargeExtraDiamondsIOS_ = value;
    }
  }

  /// <summary>Field number for the "IOSRechargeDailyRestriction" field.</summary>
  public const int IOSRechargeDailyRestrictionFieldNumber = 13;
  private int iOSRechargeDailyRestriction_;
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public int IOSRechargeDailyRestriction {
    get { return iOSRechargeDailyRestriction_; }
    set {
      iOSRechargeDailyRestriction_ = value;
    }
  }

  /// <summary>Field number for the "Realamount" field.</summary>
  public const int RealamountFieldNumber = 14;
  private int realamount_;
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public int Realamount {
    get { return realamount_; }
    set {
      realamount_ = value;
    }
  }

  /// <summary>Field number for the "Descript" field.</summary>
  public const int DescriptFieldNumber = 15;
  private string descript_ = "";
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public string Descript {
    get { return descript_; }
    set {
      descript_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
    }
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public override bool Equals(object other) {
    return Equals(other as TRechargeData);
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public bool Equals(TRechargeData other) {
    if (ReferenceEquals(other, null)) {
      return false;
    }
    if (ReferenceEquals(other, this)) {
      return true;
    }
    if (ID != other.ID) return false;
    if (GsType != other.GsType) return false;
    if (PsType != other.PsType) return false;
    if (RechargeLv != other.RechargeLv) return false;
    if (CurrencyType != other.CurrencyType) return false;
    if (RechargeMoney != other.RechargeMoney) return false;
    if (ShowPrice != other.ShowPrice) return false;
    if (RechargeDiamonds != other.RechargeDiamonds) return false;
    if (FirstRechargeExtraDiamonds != other.FirstRechargeExtraDiamonds) return false;
    if (Dianka != other.Dianka) return false;
    if (DailyRechargeExtraDiamondsAN != other.DailyRechargeExtraDiamondsAN) return false;
    if (DailyRechargeExtraDiamondsIOS != other.DailyRechargeExtraDiamondsIOS) return false;
    if (IOSRechargeDailyRestriction != other.IOSRechargeDailyRestriction) return false;
    if (Realamount != other.Realamount) return false;
    if (Descript != other.Descript) return false;
    return Equals(_unknownFields, other._unknownFields);
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public override int GetHashCode() {
    int hash = 1;
    if (ID != 0) hash ^= ID.GetHashCode();
    if (GsType != 0) hash ^= GsType.GetHashCode();
    if (PsType != 0) hash ^= PsType.GetHashCode();
    if (RechargeLv != 0) hash ^= RechargeLv.GetHashCode();
    if (CurrencyType.Length != 0) hash ^= CurrencyType.GetHashCode();
    if (RechargeMoney != 0) hash ^= RechargeMoney.GetHashCode();
    if (ShowPrice != 0) hash ^= ShowPrice.GetHashCode();
    if (RechargeDiamonds != 0) hash ^= RechargeDiamonds.GetHashCode();
    if (FirstRechargeExtraDiamonds != 0) hash ^= FirstRechargeExtraDiamonds.GetHashCode();
    if (Dianka != 0) hash ^= Dianka.GetHashCode();
    if (DailyRechargeExtraDiamondsAN != 0) hash ^= DailyRechargeExtraDiamondsAN.GetHashCode();
    if (DailyRechargeExtraDiamondsIOS != 0) hash ^= DailyRechargeExtraDiamondsIOS.GetHashCode();
    if (IOSRechargeDailyRestriction != 0) hash ^= IOSRechargeDailyRestriction.GetHashCode();
    if (Realamount != 0) hash ^= Realamount.GetHashCode();
    if (Descript.Length != 0) hash ^= Descript.GetHashCode();
    if (_unknownFields != null) {
      hash ^= _unknownFields.GetHashCode();
    }
    return hash;
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public override string ToString() {
    return pb::JsonFormatter.ToDiagnosticString(this);
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public void WriteTo(pb::CodedOutputStream output) {
  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    output.WriteRawMessage(this);
  #else
    if (ID != 0) {
      output.WriteRawTag(8);
      output.WriteInt32(ID);
    }
    if (GsType != 0) {
      output.WriteRawTag(16);
      output.WriteInt32(GsType);
    }
    if (PsType != 0) {
      output.WriteRawTag(24);
      output.WriteInt32(PsType);
    }
    if (RechargeLv != 0) {
      output.WriteRawTag(32);
      output.WriteInt32(RechargeLv);
    }
    if (CurrencyType.Length != 0) {
      output.WriteRawTag(42);
      output.WriteString(CurrencyType);
    }
    if (RechargeMoney != 0) {
      output.WriteRawTag(48);
      output.WriteInt32(RechargeMoney);
    }
    if (ShowPrice != 0) {
      output.WriteRawTag(56);
      output.WriteInt32(ShowPrice);
    }
    if (RechargeDiamonds != 0) {
      output.WriteRawTag(64);
      output.WriteInt32(RechargeDiamonds);
    }
    if (FirstRechargeExtraDiamonds != 0) {
      output.WriteRawTag(72);
      output.WriteInt32(FirstRechargeExtraDiamonds);
    }
    if (Dianka != 0) {
      output.WriteRawTag(80);
      output.WriteInt32(Dianka);
    }
    if (DailyRechargeExtraDiamondsAN != 0) {
      output.WriteRawTag(88);
      output.WriteInt32(DailyRechargeExtraDiamondsAN);
    }
    if (DailyRechargeExtraDiamondsIOS != 0) {
      output.WriteRawTag(96);
      output.WriteInt32(DailyRechargeExtraDiamondsIOS);
    }
    if (IOSRechargeDailyRestriction != 0) {
      output.WriteRawTag(104);
      output.WriteInt32(IOSRechargeDailyRestriction);
    }
    if (Realamount != 0) {
      output.WriteRawTag(112);
      output.WriteInt32(Realamount);
    }
    if (Descript.Length != 0) {
      output.WriteRawTag(122);
      output.WriteString(Descript);
    }
    if (_unknownFields != null) {
      _unknownFields.WriteTo(output);
    }
  #endif
  }

  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  void pb::IBufferMessage.InternalWriteTo(ref pb::WriteContext output) {
    if (ID != 0) {
      output.WriteRawTag(8);
      output.WriteInt32(ID);
    }
    if (GsType != 0) {
      output.WriteRawTag(16);
      output.WriteInt32(GsType);
    }
    if (PsType != 0) {
      output.WriteRawTag(24);
      output.WriteInt32(PsType);
    }
    if (RechargeLv != 0) {
      output.WriteRawTag(32);
      output.WriteInt32(RechargeLv);
    }
    if (CurrencyType.Length != 0) {
      output.WriteRawTag(42);
      output.WriteString(CurrencyType);
    }
    if (RechargeMoney != 0) {
      output.WriteRawTag(48);
      output.WriteInt32(RechargeMoney);
    }
    if (ShowPrice != 0) {
      output.WriteRawTag(56);
      output.WriteInt32(ShowPrice);
    }
    if (RechargeDiamonds != 0) {
      output.WriteRawTag(64);
      output.WriteInt32(RechargeDiamonds);
    }
    if (FirstRechargeExtraDiamonds != 0) {
      output.WriteRawTag(72);
      output.WriteInt32(FirstRechargeExtraDiamonds);
    }
    if (Dianka != 0) {
      output.WriteRawTag(80);
      output.WriteInt32(Dianka);
    }
    if (DailyRechargeExtraDiamondsAN != 0) {
      output.WriteRawTag(88);
      output.WriteInt32(DailyRechargeExtraDiamondsAN);
    }
    if (DailyRechargeExtraDiamondsIOS != 0) {
      output.WriteRawTag(96);
      output.WriteInt32(DailyRechargeExtraDiamondsIOS);
    }
    if (IOSRechargeDailyRestriction != 0) {
      output.WriteRawTag(104);
      output.WriteInt32(IOSRechargeDailyRestriction);
    }
    if (Realamount != 0) {
      output.WriteRawTag(112);
      output.WriteInt32(Realamount);
    }
    if (Descript.Length != 0) {
      output.WriteRawTag(122);
      output.WriteString(Descript);
    }
    if (_unknownFields != null) {
      _unknownFields.WriteTo(ref output);
    }
  }
  #endif

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public int CalculateSize() {
    int size = 0;
    if (ID != 0) {
      size += 1 + pb::CodedOutputStream.ComputeInt32Size(ID);
    }
    if (GsType != 0) {
      size += 1 + pb::CodedOutputStream.ComputeInt32Size(GsType);
    }
    if (PsType != 0) {
      size += 1 + pb::CodedOutputStream.ComputeInt32Size(PsType);
    }
    if (RechargeLv != 0) {
      size += 1 + pb::CodedOutputStream.ComputeInt32Size(RechargeLv);
    }
    if (CurrencyType.Length != 0) {
      size += 1 + pb::CodedOutputStream.ComputeStringSize(CurrencyType);
    }
    if (RechargeMoney != 0) {
      size += 1 + pb::CodedOutputStream.ComputeInt32Size(RechargeMoney);
    }
    if (ShowPrice != 0) {
      size += 1 + pb::CodedOutputStream.ComputeInt32Size(ShowPrice);
    }
    if (RechargeDiamonds != 0) {
      size += 1 + pb::CodedOutputStream.ComputeInt32Size(RechargeDiamonds);
    }
    if (FirstRechargeExtraDiamonds != 0) {
      size += 1 + pb::CodedOutputStream.ComputeInt32Size(FirstRechargeExtraDiamonds);
    }
    if (Dianka != 0) {
      size += 1 + pb::CodedOutputStream.ComputeInt32Size(Dianka);
    }
    if (DailyRechargeExtraDiamondsAN != 0) {
      size += 1 + pb::CodedOutputStream.ComputeInt32Size(DailyRechargeExtraDiamondsAN);
    }
    if (DailyRechargeExtraDiamondsIOS != 0) {
      size += 1 + pb::CodedOutputStream.ComputeInt32Size(DailyRechargeExtraDiamondsIOS);
    }
    if (IOSRechargeDailyRestriction != 0) {
      size += 1 + pb::CodedOutputStream.ComputeInt32Size(IOSRechargeDailyRestriction);
    }
    if (Realamount != 0) {
      size += 1 + pb::CodedOutputStream.ComputeInt32Size(Realamount);
    }
    if (Descript.Length != 0) {
      size += 1 + pb::CodedOutputStream.ComputeStringSize(Descript);
    }
    if (_unknownFields != null) {
      size += _unknownFields.CalculateSize();
    }
    return size;
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public void MergeFrom(TRechargeData other) {
    if (other == null) {
      return;
    }
    if (other.ID != 0) {
      ID = other.ID;
    }
    if (other.GsType != 0) {
      GsType = other.GsType;
    }
    if (other.PsType != 0) {
      PsType = other.PsType;
    }
    if (other.RechargeLv != 0) {
      RechargeLv = other.RechargeLv;
    }
    if (other.CurrencyType.Length != 0) {
      CurrencyType = other.CurrencyType;
    }
    if (other.RechargeMoney != 0) {
      RechargeMoney = other.RechargeMoney;
    }
    if (other.ShowPrice != 0) {
      ShowPrice = other.ShowPrice;
    }
    if (other.RechargeDiamonds != 0) {
      RechargeDiamonds = other.RechargeDiamonds;
    }
    if (other.FirstRechargeExtraDiamonds != 0) {
      FirstRechargeExtraDiamonds = other.FirstRechargeExtraDiamonds;
    }
    if (other.Dianka != 0) {
      Dianka = other.Dianka;
    }
    if (other.DailyRechargeExtraDiamondsAN != 0) {
      DailyRechargeExtraDiamondsAN = other.DailyRechargeExtraDiamondsAN;
    }
    if (other.DailyRechargeExtraDiamondsIOS != 0) {
      DailyRechargeExtraDiamondsIOS = other.DailyRechargeExtraDiamondsIOS;
    }
    if (other.IOSRechargeDailyRestriction != 0) {
      IOSRechargeDailyRestriction = other.IOSRechargeDailyRestriction;
    }
    if (other.Realamount != 0) {
      Realamount = other.Realamount;
    }
    if (other.Descript.Length != 0) {
      Descript = other.Descript;
    }
    _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public void MergeFrom(pb::CodedInputStream input) {
  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    input.ReadRawMessage(this);
  #else
    uint tag;
    while ((tag = input.ReadTag()) != 0) {
    if ((tag & 7) == 4) {
      // Abort on any end group tag.
      return;
    }
    switch(tag) {
        default:
          _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
          break;
        case 8: {
          ID = input.ReadInt32();
          break;
        }
        case 16: {
          GsType = input.ReadInt32();
          break;
        }
        case 24: {
          PsType = input.ReadInt32();
          break;
        }
        case 32: {
          RechargeLv = input.ReadInt32();
          break;
        }
        case 42: {
          CurrencyType = input.ReadString();
          break;
        }
        case 48: {
          RechargeMoney = input.ReadInt32();
          break;
        }
        case 56: {
          ShowPrice = input.ReadInt32();
          break;
        }
        case 64: {
          RechargeDiamonds = input.ReadInt32();
          break;
        }
        case 72: {
          FirstRechargeExtraDiamonds = input.ReadInt32();
          break;
        }
        case 80: {
          Dianka = input.ReadInt32();
          break;
        }
        case 88: {
          DailyRechargeExtraDiamondsAN = input.ReadInt32();
          break;
        }
        case 96: {
          DailyRechargeExtraDiamondsIOS = input.ReadInt32();
          break;
        }
        case 104: {
          IOSRechargeDailyRestriction = input.ReadInt32();
          break;
        }
        case 112: {
          Realamount = input.ReadInt32();
          break;
        }
        case 122: {
          Descript = input.ReadString();
          break;
        }
      }
    }
  #endif
  }

  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  void pb::IBufferMessage.InternalMergeFrom(ref pb::ParseContext input) {
    uint tag;
    while ((tag = input.ReadTag()) != 0) {
    if ((tag & 7) == 4) {
      // Abort on any end group tag.
      return;
    }
    switch(tag) {
        default:
          _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, ref input);
          break;
        case 8: {
          ID = input.ReadInt32();
          break;
        }
        case 16: {
          GsType = input.ReadInt32();
          break;
        }
        case 24: {
          PsType = input.ReadInt32();
          break;
        }
        case 32: {
          RechargeLv = input.ReadInt32();
          break;
        }
        case 42: {
          CurrencyType = input.ReadString();
          break;
        }
        case 48: {
          RechargeMoney = input.ReadInt32();
          break;
        }
        case 56: {
          ShowPrice = input.ReadInt32();
          break;
        }
        case 64: {
          RechargeDiamonds = input.ReadInt32();
          break;
        }
        case 72: {
          FirstRechargeExtraDiamonds = input.ReadInt32();
          break;
        }
        case 80: {
          Dianka = input.ReadInt32();
          break;
        }
        case 88: {
          DailyRechargeExtraDiamondsAN = input.ReadInt32();
          break;
        }
        case 96: {
          DailyRechargeExtraDiamondsIOS = input.ReadInt32();
          break;
        }
        case 104: {
          IOSRechargeDailyRestriction = input.ReadInt32();
          break;
        }
        case 112: {
          Realamount = input.ReadInt32();
          break;
        }
        case 122: {
          Descript = input.ReadString();
          break;
        }
      }
    }
  }
  #endif

}

[global::System.Diagnostics.DebuggerDisplayAttribute("{ToString(),nq}")]
public sealed partial class TRecharge : pb::IMessage<TRecharge>
#if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    , pb::IBufferMessage
#endif
{
  private static readonly pb::MessageParser<TRecharge> _parser = new pb::MessageParser<TRecharge>(() => new TRecharge());
  private pb::UnknownFieldSet _unknownFields;
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public static pb::MessageParser<TRecharge> Parser { get { return _parser; } }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public static pbr::MessageDescriptor Descriptor {
    get { return global::TRechargeReflection.Descriptor.MessageTypes[1]; }
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  pbr::MessageDescriptor pb::IMessage.Descriptor {
    get { return Descriptor; }
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public TRecharge() {
    OnConstruction();
  }

  partial void OnConstruction();

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public TRecharge(TRecharge other) : this() {
    datas_ = other.datas_.Clone();
    _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public TRecharge Clone() {
    return new TRecharge(this);
  }

  /// <summary>Field number for the "datas" field.</summary>
  public const int DatasFieldNumber = 1;
  private static readonly pb::FieldCodec<global::TRechargeData> _repeated_datas_codec
      = pb::FieldCodec.ForMessage(10, global::TRechargeData.Parser);
  private readonly pbc::RepeatedField<global::TRechargeData> datas_ = new pbc::RepeatedField<global::TRechargeData>();
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public pbc::RepeatedField<global::TRechargeData> Datas {
    get { return datas_; }
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public override bool Equals(object other) {
    return Equals(other as TRecharge);
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public bool Equals(TRecharge other) {
    if (ReferenceEquals(other, null)) {
      return false;
    }
    if (ReferenceEquals(other, this)) {
      return true;
    }
    if(!datas_.Equals(other.datas_)) return false;
    return Equals(_unknownFields, other._unknownFields);
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public override int GetHashCode() {
    int hash = 1;
    hash ^= datas_.GetHashCode();
    if (_unknownFields != null) {
      hash ^= _unknownFields.GetHashCode();
    }
    return hash;
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public override string ToString() {
    return pb::JsonFormatter.ToDiagnosticString(this);
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public void WriteTo(pb::CodedOutputStream output) {
  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    output.WriteRawMessage(this);
  #else
    datas_.WriteTo(output, _repeated_datas_codec);
    if (_unknownFields != null) {
      _unknownFields.WriteTo(output);
    }
  #endif
  }

  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  void pb::IBufferMessage.InternalWriteTo(ref pb::WriteContext output) {
    datas_.WriteTo(ref output, _repeated_datas_codec);
    if (_unknownFields != null) {
      _unknownFields.WriteTo(ref output);
    }
  }
  #endif

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public int CalculateSize() {
    int size = 0;
    size += datas_.CalculateSize(_repeated_datas_codec);
    if (_unknownFields != null) {
      size += _unknownFields.CalculateSize();
    }
    return size;
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public void MergeFrom(TRecharge other) {
    if (other == null) {
      return;
    }
    datas_.Add(other.datas_);
    _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public void MergeFrom(pb::CodedInputStream input) {
  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    input.ReadRawMessage(this);
  #else
    uint tag;
    while ((tag = input.ReadTag()) != 0) {
    if ((tag & 7) == 4) {
      // Abort on any end group tag.
      return;
    }
    switch(tag) {
        default:
          _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
          break;
        case 10: {
          datas_.AddEntriesFrom(input, _repeated_datas_codec);
          break;
        }
      }
    }
  #endif
  }

  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  void pb::IBufferMessage.InternalMergeFrom(ref pb::ParseContext input) {
    uint tag;
    while ((tag = input.ReadTag()) != 0) {
    if ((tag & 7) == 4) {
      // Abort on any end group tag.
      return;
    }
    switch(tag) {
        default:
          _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, ref input);
          break;
        case 10: {
          datas_.AddEntriesFrom(ref input, _repeated_datas_codec);
          break;
        }
      }
    }
  }
  #endif

}

#endregion


#endregion Designer generated code
