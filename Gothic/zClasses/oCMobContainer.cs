﻿using System;
using System.Collections.Generic;
using System.Text;
using WinApi;
using Gothic.zTypes;

namespace Gothic.zClasses
{
    public class oCMobContainer : oCMobLockable
    {
        #region OffsetLists
        public enum Offsets
        {
            ItemContainer = 628,
            ItemList = 632,//632
            Contains = 608//608
        }
        public enum FuncOffsets : uint
        {
            CreateContents = 0x00726190,
            Close = 0x00726640,
            Insert = 0x00725FC0,
            IsIn = 0x007264C0,
            Open = 0x00726500,
            Remove = 0x00725FF0,
            Remove_Item_Int = 0x00726080
        }

        public enum HookSize : uint
        {
            CreateContents = 7,
            Close = 6,
            Insert =5,
            IsIn = 8,
            Open = 6,
            Remove = 6,
            Remove_Item_Int = 0xA
        }

        #endregion

        public oCMobContainer()
        {

        }

        public oCMobContainer(Process process, int address)
            : base(process, address)
        {
        }

        public static oCMobContainer Create(Process process)
        {
            IntPtr ptr = process.Alloc(0x284);
            zCClassDef.ObjectCreated(process, ptr.ToInt32(), 0x00AB18B0);//0x00AB1518) => MobDoor;
            process.THISCALL<NullReturnCall>((uint)ptr.ToInt32(), (uint)0x0071D010, new CallValue[] { });

            return new oCMobContainer(process, ptr.ToInt32());
        }

        public List<oCItem> getItemList()
        {
            List<oCItem> items = new List<oCItem>();


            zCListSort<oCItem> itemList = this.ItemList;
            do
            {
                oCItem item = itemList.Data;

                if (item == null || item.Address == 0)
                    continue;
                items.Add(item);

            } while ((itemList = itemList.Next).Address != 0);

            return items;
        }

        public void CreateContents(zString str)
        {
            Process.THISCALL<NullReturnCall>((uint)Address, (uint)FuncOffsets.CreateContents, new CallValue[] { str });
        }

        public void Open(oCNpc vob)
        {
            Process.THISCALL<NullReturnCall>((uint)Address, (uint)FuncOffsets.Open, new CallValue[] { vob });
        }

        public void Close(oCNpc vob)
        {
            Process.THISCALL<NullReturnCall>((uint)Address, (uint)FuncOffsets.Close, new CallValue[] { vob });
        }

        public oCItemContainer ItemContainer
        {
            get { return new oCItemContainer(Process, Process.ReadInt(Address + (int)Offsets.ItemContainer)); }
        }

        public zCListSort<oCItem> ItemList
        {
            get { return new zCListSort<oCItem>(Process, Address + (int)Offsets.ItemList); }
        }

        public zString Contains
        {
            get { return new zString(Process, Address + (int)Offsets.Contains); }
        }

        public void Remove(oCItem item, int amount)
        {
            Process.THISCALL<NullReturnCall>((uint)Address, (int)FuncOffsets.Remove_Item_Int, new CallValue[] { item, new IntArg(amount) });
        }

        public void Remove(oCItem item)
        {
            Process.THISCALL<NullReturnCall>((uint)Address, (int)FuncOffsets.Remove, new CallValue[] { item });
        }

        public void Insert(oCItem item)
        {
            Process.THISCALL<NullReturnCall>((uint)Address, (int)FuncOffsets.Insert, new CallValue[] { item });
        }
    }
}
