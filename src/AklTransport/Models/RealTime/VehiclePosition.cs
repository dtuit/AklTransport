namespace AklTransport.Models.RealTime
{
    [global::System.Serializable, global::ProtoBuf.ProtoContract(Name = @"VehiclePosition")]
    public partial class VehiclePosition : global::ProtoBuf.IExtensible
    {
        public VehiclePosition() { }


        private TripDescriptor _trip = null;
        [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name = @"trip", DataFormat = global::ProtoBuf.DataFormat.Default)]
        [global::System.ComponentModel.DefaultValue(null)]
        public TripDescriptor trip
        {
            get { return _trip; }
            set { _trip = value; }
        }

        private VehicleDescriptor _vehicle = null;
        [global::ProtoBuf.ProtoMember(8, IsRequired = false, Name = @"vehicle", DataFormat = global::ProtoBuf.DataFormat.Default)]
        [global::System.ComponentModel.DefaultValue(null)]
        public VehicleDescriptor vehicle
        {
            get { return _vehicle; }
            set { _vehicle = value; }
        }

        private Position _position = null;
        [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name = @"position", DataFormat = global::ProtoBuf.DataFormat.Default)]
        [global::System.ComponentModel.DefaultValue(null)]
        public Position position
        {
            get { return _position; }
            set { _position = value; }
        }

        private uint _current_stop_sequence = default(uint);
        [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name = @"current_stop_sequence", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
        [global::System.ComponentModel.DefaultValue(default(uint))]
        public uint current_stop_sequence
        {
            get { return _current_stop_sequence; }
            set { _current_stop_sequence = value; }
        }

        private string _stop_id = "";
        [global::ProtoBuf.ProtoMember(7, IsRequired = false, Name = @"stop_id", DataFormat = global::ProtoBuf.DataFormat.Default)]
        [global::System.ComponentModel.DefaultValue("")]
        public string stop_id
        {
            get { return _stop_id; }
            set { _stop_id = value; }
        }

        private VehiclePosition.VehicleStopStatus _current_status = VehiclePosition.VehicleStopStatus.IN_TRANSIT_TO;
        [global::ProtoBuf.ProtoMember(4, IsRequired = false, Name = @"current_status", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
        [global::System.ComponentModel.DefaultValue(VehiclePosition.VehicleStopStatus.IN_TRANSIT_TO)]
        public VehiclePosition.VehicleStopStatus current_status
        {
            get { return _current_status; }
            set { _current_status = value; }
        }

        private ulong _timestamp = default(ulong);
        [global::ProtoBuf.ProtoMember(5, IsRequired = false, Name = @"timestamp", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
        [global::System.ComponentModel.DefaultValue(default(ulong))]
        public ulong timestamp
        {
            get { return _timestamp; }
            set { _timestamp = value; }
        }

        private VehiclePosition.CongestionLevel _congestion_level = VehiclePosition.CongestionLevel.UNKNOWN_CONGESTION_LEVEL;
        [global::ProtoBuf.ProtoMember(6, IsRequired = false, Name = @"congestion_level", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
        [global::System.ComponentModel.DefaultValue(VehiclePosition.CongestionLevel.UNKNOWN_CONGESTION_LEVEL)]
        public VehiclePosition.CongestionLevel congestion_level
        {
            get { return _congestion_level; }
            set { _congestion_level = value; }
        }

        private VehiclePosition.OccupancyStatus _occupancy_status = VehiclePosition.OccupancyStatus.EMPTY;
        [global::ProtoBuf.ProtoMember(9, IsRequired = false, Name = @"occupancy_status", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
        [global::System.ComponentModel.DefaultValue(VehiclePosition.OccupancyStatus.EMPTY)]
        public VehiclePosition.OccupancyStatus occupancy_status
        {
            get { return _occupancy_status; }
            set { _occupancy_status = value; }
        }
        [global::ProtoBuf.ProtoContract(Name = @"VehicleStopStatus")]
        public enum VehicleStopStatus
        {

            [global::ProtoBuf.ProtoEnum(Name = @"INCOMING_AT", Value = 0)]
            INCOMING_AT = 0,

            [global::ProtoBuf.ProtoEnum(Name = @"STOPPED_AT", Value = 1)]
            STOPPED_AT = 1,

            [global::ProtoBuf.ProtoEnum(Name = @"IN_TRANSIT_TO", Value = 2)]
            IN_TRANSIT_TO = 2
        }

        [global::ProtoBuf.ProtoContract(Name = @"CongestionLevel")]
        public enum CongestionLevel
        {

            [global::ProtoBuf.ProtoEnum(Name = @"UNKNOWN_CONGESTION_LEVEL", Value = 0)]
            UNKNOWN_CONGESTION_LEVEL = 0,

            [global::ProtoBuf.ProtoEnum(Name = @"RUNNING_SMOOTHLY", Value = 1)]
            RUNNING_SMOOTHLY = 1,

            [global::ProtoBuf.ProtoEnum(Name = @"STOP_AND_GO", Value = 2)]
            STOP_AND_GO = 2,

            [global::ProtoBuf.ProtoEnum(Name = @"CONGESTION", Value = 3)]
            CONGESTION = 3,

            [global::ProtoBuf.ProtoEnum(Name = @"SEVERE_CONGESTION", Value = 4)]
            SEVERE_CONGESTION = 4
        }

        [global::ProtoBuf.ProtoContract(Name = @"OccupancyStatus")]
        public enum OccupancyStatus
        {

            [global::ProtoBuf.ProtoEnum(Name = @"EMPTY", Value = 0)]
            EMPTY = 0,

            [global::ProtoBuf.ProtoEnum(Name = @"MANY_SEATS_AVAILABLE", Value = 1)]
            MANY_SEATS_AVAILABLE = 1,

            [global::ProtoBuf.ProtoEnum(Name = @"FEW_SEATS_AVAILABLE", Value = 2)]
            FEW_SEATS_AVAILABLE = 2,

            [global::ProtoBuf.ProtoEnum(Name = @"STANDING_ROOM_ONLY", Value = 3)]
            STANDING_ROOM_ONLY = 3,

            [global::ProtoBuf.ProtoEnum(Name = @"CRUSHED_STANDING_ROOM_ONLY", Value = 4)]
            CRUSHED_STANDING_ROOM_ONLY = 4,

            [global::ProtoBuf.ProtoEnum(Name = @"FULL", Value = 5)]
            FULL = 5,

            [global::ProtoBuf.ProtoEnum(Name = @"NOT_ACCEPTING_PASSENGERS", Value = 6)]
            NOT_ACCEPTING_PASSENGERS = 6
        }

        private global::ProtoBuf.IExtension extensionObject;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
        { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
    }
}