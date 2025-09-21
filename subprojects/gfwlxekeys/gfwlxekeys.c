#include <Windows.h>
#include <stdio.h>
#include <Shlobj.h>
#include <Shlwapi.h>

// exports for Bink so Shadowrun can link to this DLL rather than the original
__declspec(dllexport) void __stdcall BinkOpen(int a1, int a2) {}
__declspec(dllexport) void __stdcall BinkPause(int a1, int a2) {}
__declspec(dllexport) void __stdcall BinkSetSoundTrack(int a1, int a2) {}
__declspec(dllexport) void __stdcall BinkSetSoundSystem(int a1, int a2) {}
__declspec(dllexport) void __stdcall BinkRegisterFrameBuffers(int a1, int a2) {}
__declspec(dllexport) void __stdcall BinkGetFrameBuffersInfo(int a1, int a2) {}
__declspec(dllexport) void __stdcall BinkNextFrame(int a1) {}
__declspec(dllexport) void __stdcall BinkDoFrame(int a1) {}
__declspec(dllexport) void __stdcall BinkWait(int a1) {}
__declspec(dllexport) void __stdcall BinkOpenDirectSound(int a1) {}
__declspec(dllexport) void __stdcall BinkShouldSkip(int a1) {}
__declspec(dllexport) void __stdcall BinkClose(int a1) {}
__declspec(dllexport) void __stdcall BinkSetIOSize(int a1) {}

// return codes for the process for GfWLUtility to check for
typedef enum _ErrorCode_e {
	kReturnSuccess = -4000,
	kReturnBadXlive = -4001,
	kReturnNoInFile = -4002,
	kReturnBadInFile = -4003,
	kReturnBadMsidCrl = -4004
} ErrorCode_e;

// XeKeysUnObfuscate in xlive.dll
typedef int (*__stdcall XeKeysUnObfuscate_t)(BOOL roaming, void* input, DWORD input_size, void* output, int* output_size);
XeKeysUnObfuscate_t XeKeysUnObfuscate = NULL;

// injects an x86 JMP instruction to a given destination
void InjectJump(DWORD source, DWORD destination)
{
	DWORD oldProtect;
	DWORD newProtect;
	BYTE* origFunc = (BYTE*)source;
	// set the page to be writable
	VirtualProtect((void*)source, 5, PAGE_EXECUTE_READWRITE, &oldProtect);
	// write the jump instruction
	origFunc[0] = 0xE9;
	*(DWORD*)&origFunc[1] = destination - source - 5;
	// set the page permissions back to normal
	VirtualProtect((void*)source, 5, oldProtect, &newProtect);
}

// decrypts a GfWL account file for a given XUID
BOOL DecryptAccountFile(ULONGLONG ullXuid)
{
	char localAppDataPath[MAX_PATH];
	char encryptedFilePath[MAX_PATH];
	char decryptedFilePath[MAX_PATH];
	PCHAR encbuf;
	PCHAR decbuf;
	FILE *in;
	FILE *out;
	int decsize = 0x198;
	// get the local appdata folder path
	if (SHGetFolderPathA(NULL, CSIDL_LOCAL_APPDATA, NULL, SHGFP_TYPE_CURRENT, localAppDataPath) != S_OK)
		return FALSE;
	printf("AppData: %s\n", localAppDataPath);
	// build the paths to the encrypted file and the decrypted output
	sprintf(encryptedFilePath, "%s\\Microsoft\\Xlive\\Content\\%016llX\\FFFE07D1\\00010000\\%016llX_MountPt\\Account", localAppDataPath, ullXuid, ullXuid);
	sprintf(decryptedFilePath, "%s\\GfWLUtility\\ProfileCache\\%016llX.bin", localAppDataPath, ullXuid);
	// allocate buffers to store the encrypted and decrypted content
	encbuf = (PCHAR)malloc(0x198);
	if (encbuf == NULL)
		return FALSE;
	decbuf = (PCHAR)malloc(0x198);
	if (decbuf == NULL)
		return FALSE;
	// read the encrypted file
	in = fopen(encryptedFilePath, "rb");
	if (in == NULL)
		return FALSE;
	if (fread(encbuf, 1, 0x198, in) != 0x198)
		return FALSE;
	fclose(in);
	// deobfuscate
	if (!XeKeysUnObfuscate(TRUE, encbuf, 0x198, decbuf, &decsize))
		return FALSE;
	// write the output file
	out = fopen(decryptedFilePath, "wb");
	if (out == NULL)
		return FALSE;
	fwrite(decbuf, 1, decsize, out);
	fclose(out);
	// free the buffers
	free(encbuf);
	free(decbuf);
	return TRUE;
}

void TerminateCurrentProcess(int result)
{
	TerminateProcess(GetCurrentProcess(), result);
}

HRESULT WINAPI NewMSIDCRLInitializeEx(IN REFGUID GuidClientApplication, IN LONG lPPCRLVersion, IN DWORD dwFlags, IN LPVOID pOptions, IN DWORD dwOptions)
{
	FILE *infile;
	int numXuids = 0;
	int i = 0;
	// get the function offset for XeKeysUnObfuscate
	// TODO: dynamically look up the offsets for this so we work on more than just latest
	HMODULE h = GetModuleHandleA("xlive.dll");
	CHAR origFuncBytes[8] = { 0x8B, 0xFF, 0x55, 0x8B, 0xEC, 0x83, 0xEC, 0x24 }; // 3.5.95.0
	XeKeysUnObfuscate = (XeKeysUnObfuscate_t)((DWORD)h + 0xF8121);
	// verify that the function is right
	if (memcmp((void *)((DWORD)h + 0xF8121), origFuncBytes, sizeof(origFuncBytes)) != 0) {
		// function isn't right, just bail out immediately
		TerminateCurrentProcess(kReturnBadXlive);
		return -1;
	}

	// open the data file
	infile = fopen("xuids.dat", "rb");
	if (infile == NULL) {
		TerminateCurrentProcess(kReturnNoInFile);
		return -1;
	}
	// read the number of accounts to decrypt
	if (fread(&numXuids, sizeof(int), 1, infile) != 1) {
		TerminateCurrentProcess(kReturnBadInFile);
		return -1;
	}
	// decrypt each account
	for (i = 0; i < numXuids; i++) {
		ULONGLONG xuid;
		if (fread(&xuid, sizeof(ULONGLONG), 1, infile) != 1) {
			TerminateCurrentProcess(kReturnBadInFile);
			return -1;
		}
		DecryptAccountFile(xuid);
	}

	// we have to terminate the process immediately since xlive will crash if we don't
	// (i suspect either xlive knows we're bad or the XeKeysUnObfuscate call breaks the stack)
	TerminateCurrentProcess(kReturnSuccess);
	return -1;
}

void InitializeHook()
{
	char identityCrlPath[MAX_PATH];
	DWORD identityCrlPathLen = sizeof(identityCrlPath);
	char dllPath[MAX_PATH];
	DWORD type;
	HMODULE ms;
	DWORD pAddr;
	strcpy(dllPath, "msidcrl40.dll");
	// get the address of msidcrl40.dll
	if (SHRegGetValueA(HKEY_LOCAL_MACHINE, "Software\\Microsoft\\IdentityCRL", "TargetDir",
		SRRF_RT_REG_SZ, &type, identityCrlPath, &identityCrlPathLen) == ERROR_SUCCESS) {
		sprintf(dllPath, "%s\\msidcrl40.dll", identityCrlPath);
	}
	// this function is always called during XLive intialization and isn't verified
	ms = LoadLibraryA(dllPath);
	if (ms == NULL) {
		TerminateCurrentProcess(kReturnBadMsidCrl);
		return;
	}
	pAddr = (DWORD)GetProcAddress(ms, "InitializeEx");
	if (pAddr == 0) {
		TerminateCurrentProcess(kReturnBadMsidCrl);
		return;
	}
	InjectJump(pAddr, (DWORD)NewMSIDCRLInitializeEx);
}

BOOL WINAPI DllMain(HINSTANCE hinstDLL, DWORD fdwReason, LPVOID lpvReserved)
{
	if (fdwReason == DLL_PROCESS_ATTACH) {
		InitializeHook();
	}
	return TRUE;
}
