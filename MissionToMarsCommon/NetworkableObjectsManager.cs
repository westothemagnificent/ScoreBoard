using System;

namespace MissionToMarsCommon;

public static class NetworkObjectManager {

    // vars

    private List<RegisteredNetworkable> networkables = new List<RegisteredNetworkable>();
    private uint idCounter = 1;

    ////////////////////////////////////////////////////////

    static NetworkObjectManager() {
        // Add networkable objects here
        // DO NOT REORDER REGISTER CALLS


    }

    ////////////////////////////////////////////////////////
    
    // functions

    public void register<T>() {
        Type type = typeof(T);

        networkables.Add(new RegisteredNetworkable(p));
        idCounter++;
    }

    // FIXME: Implement
    public bool isTypeNetworkable(Type pType) {
        return true;
    }

    public bool isTypeNetworkable<T>() {
        return isTypeNetworkable(typeof(T));
    }

    public bool isTypeNetworkable<T>() {
        return getNetworkableById(typeof(T)) != null;
    }

    public RegisteredNetworkable getNetworkableById(uint pId) {
        if (pId > networkables.Count - 1) { return null; }

        return networkables[pId];
    }

    public int getNetworkableId(RegisteredNetworkable pType) {
        return pType?.id ?? 0;
    }

    private class RegisteredNetworkable {
        public Type type;
        public uint id;

        public static RegisteredNetworkable create(Type pType, uint pId) {
            if (pType == null) {
                return null;
            }

            type = pType;
            id = pId;
        }
    } 
}