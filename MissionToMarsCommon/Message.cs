using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

namespace MissionToMarsCommon;

public class Message {
    public CommandFlags commandFlags;
    public string commandName;
    public bool hasPayload;
    public int payloadType;
    
    private void* payload;

    // FIXME: Add safe gruads
    public T getPayload<T>() {
        return Unsafe.As<T>(payload);
    }

    public RawMessage packageToRaw() {
        RawMessage raw = new RawMessage();

        raw.commandFlags = commandFlags;
        raw.commandName = Encoding.UTF8.GetBytes(commandName);
    }
}

[StructLayout(LayoutKind.Sequential)] public struct RawMessage {
    public CommandFlags commandFlags;
    public byte[16] commandName;
    public bool hasPayload;
    public int payloadType;
    public byte* payload;
    public int payloadLength;
}
