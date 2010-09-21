﻿using RomTools;

namespace GbcEmulator.Memory
{
    public class MbcRumble : Mbc5
    {
        public MbcRumble(RomInfo romInfo) : base(romInfo)
        {
        }

        public bool RumbleOn { get; protected set; }

        // Rambank Select -or- Motor On/Off
        //
        //  Writing a value (XXXXMBBB - X = Don't care, M = motor, B = bank select bits) into 4000-5FFF area
        public override void Write4000_5FFF(int addr, byte b)
        {
            RamBank &= b & 0x7;
            RumbleOn = b.GetBit(3);
        }
    }
}