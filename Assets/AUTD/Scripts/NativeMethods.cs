﻿/*
*
*  Created by Shun Suzuki on 02/07/2018.
*
*/

using System;
using System.Runtime.InteropServices;

using AUTDGainPtr = System.IntPtr;
using AUTDModulationPtr = System.IntPtr;

#if DEBUG
using DebugLogFunc = System.IntPtr;
#endif

namespace AUTD3Sharp
{
    internal static unsafe class NativeMethods
    {
        const string DllName = "autd3capi";

        #region Controller
        [DllImport(DllName, CallingConvention = CallingConvention.StdCall)] public static extern void AUTDCreateController(out IntPtr handle);
        [DllImport(DllName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)] public static extern int AUTDOpenController(AUTDControllerHandle handle, string location);
        [DllImport(DllName, CallingConvention = CallingConvention.StdCall)] public static extern int AUTDAddDevice(AUTDControllerHandle handle, float x, float y, float z, float rz1, float ry, float rz2, int groupId);
        [DllImport(DllName, CallingConvention = CallingConvention.StdCall)] public static extern int AUTDAddDeviceQuaternion(AUTDControllerHandle handle, float x, float y, float z, float quaW, float quaX, float quaY, float quaZ, int groupId);
        [DllImport(DllName, CallingConvention = CallingConvention.StdCall)] public static extern void AUTDDelDevice(AUTDControllerHandle handle, int devId);
        [DllImport(DllName, CallingConvention = CallingConvention.StdCall)] public static extern void AUTDCloseController(AUTDControllerHandle handle);
        [DllImport(DllName, CallingConvention = CallingConvention.StdCall)] public static extern void AUTDFreeController(IntPtr handle);
        [DllImport(DllName, CallingConvention = CallingConvention.StdCall)] public static extern void AUTDSetSilentMode(AUTDControllerHandle handle, [MarshalAs(UnmanagedType.U1)] bool mode);
        #endregion

        #region Property
        [DllImport(DllName, CallingConvention = CallingConvention.StdCall)] [return: MarshalAs(UnmanagedType.U1)] public static extern bool AUTDIsOpen(AUTDControllerHandle handle);
        [DllImport(DllName, CallingConvention = CallingConvention.StdCall)] [return: MarshalAs(UnmanagedType.U1)] public static extern bool AUTDIsSilentMode(AUTDControllerHandle handle);
        [DllImport(DllName, CallingConvention = CallingConvention.StdCall)] public static extern int AUTDNumDevices(AUTDControllerHandle handle);
        [DllImport(DllName, CallingConvention = CallingConvention.StdCall)] public static extern int AUTDNumTransducers(AUTDControllerHandle handle);
        [DllImport(DllName, CallingConvention = CallingConvention.StdCall)] public static extern float AUTDFrequency(AUTDControllerHandle handle);
        [DllImport(DllName, CallingConvention = CallingConvention.StdCall)] public static extern long AUTDRemainingInBuffer(AUTDControllerHandle handle);
        #endregion region

        #region Gain
        [DllImport(DllName, CallingConvention = CallingConvention.StdCall)] public static extern void AUTDFocalPointGain(out AUTDGainPtr gain, float x, float y, float z, byte amp);
        [DllImport(DllName, CallingConvention = CallingConvention.StdCall)] public static extern void AUTDGroupedGain(out AUTDGainPtr gain, int* groupIDs, AUTDGainPtr* gains, int size);
        [DllImport(DllName, CallingConvention = CallingConvention.StdCall)] public static extern void AUTDBesselBeamGain(out AUTDGainPtr gain, float x, float y, float z, float nX, float nY, float nZ, float thetaZ);
        [DllImport(DllName, CallingConvention = CallingConvention.StdCall)] public static extern void AUTDPlaneWaveGain(out AUTDGainPtr gain, float nX, float nY, float nZ);
        [DllImport(DllName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)] public static extern void AUTDMatlabGain(out AUTDGainPtr gain, string filename, string varName);
        [DllImport(DllName, CallingConvention = CallingConvention.StdCall)] public static extern void AUTDCustomGain(out AUTDGainPtr gain, ushort* data, int dataLength);
        [DllImport(DllName, CallingConvention = CallingConvention.StdCall)] public static extern void AUTDHoloGain(out AUTDGainPtr gain, float* points, float* amps, int size);
        [DllImport(DllName, CallingConvention = CallingConvention.StdCall)] public static extern void AUTDNullGain(out AUTDGainPtr gain);
        [DllImport(DllName, CallingConvention = CallingConvention.StdCall)] public static extern void AUTDDeleteGain(AUTDGainPtr gain);
        [DllImport(DllName, CallingConvention = CallingConvention.StdCall)] public static extern void AUTDFixGain(AUTDGainPtr gain);
        #endregion

        #region Modulation
        [DllImport(DllName, CallingConvention = CallingConvention.StdCall)] public static extern void AUTDModulation(out AUTDModulationPtr mod, byte amp);
        [DllImport(DllName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)] public static extern void AUTDRawPCMModulation(out AUTDModulationPtr mod, string filename, float samplingFrequency);
        [DllImport(DllName, CallingConvention = CallingConvention.StdCall)] public static extern void AUTDSawModulation(out AUTDModulationPtr mod, float freq);
        [DllImport(DllName, CallingConvention = CallingConvention.StdCall)] public static extern void AUTDSineModulation(out AUTDModulationPtr mod, float freq, float amp, float offset);
        [DllImport(DllName, CallingConvention = CallingConvention.StdCall)] public static extern void AUTDDeleteModulation(AUTDGainPtr gainHandle);
        #endregion

        #region LowLevelInterface
        [DllImport(DllName, CallingConvention = CallingConvention.StdCall)] public static extern void AUTDAppendGain(AUTDControllerHandle handle, Gain gain);
        [DllImport(DllName, CallingConvention = CallingConvention.StdCall)] public static extern void AUTDAppendGainSync(AUTDControllerHandle handle, Gain gain);
        [DllImport(DllName, CallingConvention = CallingConvention.StdCall)] public static extern void AUTDAppendModulation(AUTDControllerHandle handle, Modulation mod);
        [DllImport(DllName, CallingConvention = CallingConvention.StdCall)] public static extern void AUTDAppendModulationSync(AUTDControllerHandle handle, Modulation mod);
        [DllImport(DllName, CallingConvention = CallingConvention.StdCall)] public static extern void AUTDAppendLateralGain(AUTDControllerHandle handle, Gain gainHandle);
        [DllImport(DllName, CallingConvention = CallingConvention.StdCall)] public static extern void AUTDStartLateralModulation(AUTDControllerHandle handle, float freq);
        [DllImport(DllName, CallingConvention = CallingConvention.StdCall)] public static extern void AUTDFinishLateralModulation(AUTDControllerHandle handle);
        [DllImport(DllName, CallingConvention = CallingConvention.StdCall)] public static extern void AUTDResetLateralGain(AUTDControllerHandle handle);
        [DllImport(DllName, CallingConvention = CallingConvention.StdCall)] public static extern void AUTDSetGain(AUTDControllerHandle handle, int deviceIndex, int transIndex, int amp, int phase);
        [DllImport(DllName, CallingConvention = CallingConvention.StdCall)] public static extern void AUTDFlush(AUTDControllerHandle handle);
        [DllImport(DllName, CallingConvention = CallingConvention.StdCall)] public static extern int AUTDDevIdForDeviceIdx(AUTDControllerHandle handle, int devIdx);
        [DllImport(DllName, CallingConvention = CallingConvention.StdCall)] public static extern int AUTDDevIdForTransIdx(AUTDControllerHandle handle, int transIdx);
        [DllImport(DllName, CallingConvention = CallingConvention.StdCall)] public static extern float* AUTDTransPosition(AUTDControllerHandle handle, int transIdx);
        [DllImport(DllName, CallingConvention = CallingConvention.StdCall)] public static extern float* AUTDTransDirection(AUTDControllerHandle handle, int transIdx);
        [DllImport(DllName, CallingConvention = CallingConvention.StdCall)] public static extern float* GetAngleZYZ(float* rotationMatrix);
        #endregion

        #region Debug
#if DEBUG
        [UnmanagedFunctionPointer(CallingConvention.StdCall)] public delegate void DebugLogDelegate(string str);

        [DllImport(DllName, CallingConvention = CallingConvention.StdCall)] public static extern void SetDebugLog(DebugLogFunc func);
        [DllImport(DllName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)] public static extern void DebugLog(string msg);
        [DllImport(DllName, CallingConvention = CallingConvention.StdCall)] public static extern void DebugLogTest();
#endif
        #endregion
    }
}