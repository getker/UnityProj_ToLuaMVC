﻿#region

using System;
using System.IO;
using System.Text;
using LuaInterface;

#endregion

namespace Framework.Network
{
    public class ByteBuffer
    {
        private BinaryReader _reader;
        private MemoryStream _stream;
        private BinaryWriter _writer;

        public ByteBuffer()
        {
            _stream = new MemoryStream();
            _writer = new BinaryWriter(_stream);
        }

        public ByteBuffer(byte[] data)
        {
            if (data != null)
            {
                _stream = new MemoryStream(data);
                _reader = new BinaryReader(_stream);
            }
            else
            {
                _stream = new MemoryStream();
                _writer = new BinaryWriter(_stream);
            }
        }

        public void Close()
        {
            if (_writer != null) _writer.Close();
            if (_reader != null) _reader.Close();

            _stream.Close();
            _writer = null;
            _reader = null;
            _stream = null;
        }

        public void WriteByte(byte v)
        {
            _writer.Write(v);
        }

        public void WriteInt(int v)
        {
            _writer.Write(v);
        }

        public void WriteShort(ushort v)
        {
            _writer.Write(v);
        }

        public void WriteLong(long v)
        {
            _writer.Write(v);
        }

        public void WriteFloat(float v)
        {
            var temp = BitConverter.GetBytes(v);
            Array.Reverse(temp);
            _writer.Write(BitConverter.ToSingle(temp, 0));
        }

        public void WriteDouble(double v)
        {
            var temp = BitConverter.GetBytes(v);
            Array.Reverse(temp);
            _writer.Write(BitConverter.ToDouble(temp, 0));
        }

        /// <summary>
        /// （此游戏通过Json协议，不再通过WriteString）
        /// </summary>
        /// <returns></returns>
        public void WriteString(string v)
        {
            var bytes = Encoding.UTF8.GetBytes(v);
            _writer.Write((ushort) bytes.Length);
            _writer.Write(bytes);
        }

        public void WriteBytes(byte[] v)
        {
            _writer.Write(v.Length);
            _writer.Write(v);
        }

        public void WriteBuffer(LuaByteBuffer strBuffer)
        {
            WriteBytes(strBuffer.buffer);
        }

        public byte ReadByte()
        {
            return _reader.ReadByte();
        }

        public int ReadInt()
        {
            return _reader.ReadInt32();
        }

        public ushort ReadShort()
        {
            return (ushort) _reader.ReadInt16();
        }

        public long ReadLong()
        {
            return _reader.ReadInt64();
        }

        public float ReadFloat()
        {
            var temp = BitConverter.GetBytes(_reader.ReadSingle());
            Array.Reverse(temp);
            return BitConverter.ToSingle(temp, 0);
        }

        public double ReadDouble()
        {
            var temp = BitConverter.GetBytes(_reader.ReadDouble());
            Array.Reverse(temp);
            return BitConverter.ToDouble(temp, 0);
        }

        /// <summary>
        /// （此游戏通过Json协议，不再通过ReadString）
        /// </summary>
        /// <returns></returns>
        public string ReadString()
        {
            var len = ReadShort();
            var buffer = _reader.ReadBytes(len);
            return Encoding.UTF8.GetString(buffer);
        }

        public byte[] ReadBytes()
        {
            var len = ReadInt();
            return _reader.ReadBytes(len);
        }

        public LuaByteBuffer ReadBuffer()
        {
            var bytes = ReadBytes();
            return new LuaByteBuffer(bytes);
        }

        public byte[] ToBytes()
        {
            _writer.Flush();
            return _stream.ToArray();
        }

        public void Flush()
        {
            _writer.Flush();
        }
    }
}