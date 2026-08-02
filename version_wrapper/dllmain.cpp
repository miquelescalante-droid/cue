// dllmain.cpp : Defines the entry point for the DLL application.
#define WIN32_LEAN_AND_MEAN
#include <windows.h>
#include <tchar.h>
#include <cstdint>
#include <string>

#include <winver.h>

#include <winhttp.h>
#pragma comment(lib, "winhttp.lib")
#include <Shlwapi.h>
#pragma comment(lib, "shlwapi.lib")
#include <json/json.hpp>
#include <fstream>
#include <sstream>
#include <vector>
#include <algorithm>

#include <shellapi.h>
#pragma comment(lib, "shell32.lib")

EXTERN_C IMAGE_DOS_HEADER __ImageBase;

// Function Name     : GetFileVersionInfoA
// Ordinal           : 1 (0x1)
namespace P { BOOL(WINAPI* GetFileVersionInfoA)(LPCSTR lptstrFilename, DWORD dwHandle, DWORD dwLen, LPVOID lpData); }
extern "C"    BOOL WINAPI  GetFileVersionInfoA(LPCSTR lptstrFilename, DWORD dwHandle, DWORD dwLen, LPVOID lpData) {
	return  P::GetFileVersionInfoA(lptstrFilename, dwHandle, dwLen, lpData);
}



// Function Name     : GetFileVersionInfoByHandle
// Ordinal           : 2 (0x2)
namespace P { int(WINAPI* GetFileVersionInfoByHandle)(int hMem, LPCWSTR lpFileName, int v2, int v3); }
extern "C"    int WINAPI  GetFileVersionInfoByHandle(int hMem, LPCWSTR lpFileName, int v2, int v3) {
	return P::GetFileVersionInfoByHandle(hMem, lpFileName, v2, v3);
}


// Function Name     : GetFileVersionInfoExA
// Ordinal           : 3 (0x3)
namespace P { BOOL(WINAPI* GetFileVersionInfoExA)(DWORD dwFlags, LPCSTR lpwstrFilename, DWORD dwHandle, DWORD dwLen, LPVOID lpData); }
extern "C"    BOOL WINAPI  GetFileVersionInfoExA(DWORD dwFlags, LPCSTR lpwstrFilename, DWORD dwHandle, DWORD dwLen, LPVOID lpData) {
	return  P::GetFileVersionInfoExA(dwFlags, lpwstrFilename, dwHandle, dwLen, lpData);
}


// Function Name     : GetFileVersionInfoExW
// Ordinal           : 4 (0x4)
namespace P { BOOL(WINAPI* GetFileVersionInfoExW)(DWORD dwFlags, LPCWSTR lpwstrFilename, DWORD dwHandle, DWORD dwLen, LPVOID lpData); }
extern "C"    BOOL WINAPI  GetFileVersionInfoExW(DWORD dwFlags, LPCWSTR lpwstrFilename, DWORD dwHandle, DWORD dwLen, LPVOID lpData) {
	return  P::GetFileVersionInfoExW(dwFlags, lpwstrFilename, dwHandle, dwLen, lpData);
}


// Function Name     : GetFileVersionInfoSizeA
// Ordinal           : 5 (0x5)
namespace P { DWORD(WINAPI* GetFileVersionInfoSizeA)(LPCSTR lptstrFilename, LPDWORD lpdwHandle); }
extern "C"    DWORD WINAPI  GetFileVersionInfoSizeA(LPCSTR lptstrFilename, LPDWORD lpdwHandle) {
	return  P::GetFileVersionInfoSizeA(lptstrFilename, lpdwHandle);
}


// Function Name     : GetFileVersionInfoSizeExA
// Ordinal           : 6 (0x6)
namespace P { DWORD(WINAPI* GetFileVersionInfoSizeExA)(DWORD dwFlags, LPCSTR lpwstrFilename, LPDWORD lpdwHandle); }
extern "C"    DWORD WINAPI  GetFileVersionInfoSizeExA(DWORD dwFlags, LPCSTR lpwstrFilename, LPDWORD lpdwHandle) {
	return   P::GetFileVersionInfoSizeExA(dwFlags, lpwstrFilename, lpdwHandle);
}


// Function Name     : GetFileVersionInfoSizeExW
// Ordinal           : 7 (0x7)
#undef F
#define F GetFileVersionInfoSizeExW
namespace P { DWORD(WINAPI* GetFileVersionInfoSizeExW)(DWORD dwFlags, LPCWSTR lpwstrFilename, LPDWORD lpdwHandle); }
extern "C"    DWORD  WINAPI  GetFileVersionInfoSizeExW(DWORD dwFlags, LPCWSTR lpwstrFilename, LPDWORD lpdwHandle) {
	return    P::GetFileVersionInfoSizeExW(dwFlags, lpwstrFilename, lpdwHandle);
}


// Function Name     : GetFileVersionInfoSizeW
// Ordinal           : 8 (0x8)
namespace P { DWORD(WINAPI* GetFileVersionInfoSizeW)(LPCWSTR lptstrFilename, LPDWORD lpdwHandle); }
extern "C"    DWORD WINAPI   GetFileVersionInfoSizeW(LPCWSTR lptstrFilename, LPDWORD lpdwHandle) {
	return    P::GetFileVersionInfoSizeW(lptstrFilename, lpdwHandle);
}


// Function Name     : GetFileVersionInfoW
// Ordinal           : 9 (0x9)
namespace P { BOOL(WINAPI* GetFileVersionInfoW)(LPCWSTR lptstrFilename, DWORD dwHandle, DWORD dwLen, LPVOID lpData); }
extern "C"    BOOL  WINAPI  GetFileVersionInfoW(LPCWSTR lptstrFilename, DWORD dwHandle, DWORD dwLen, LPVOID lpData) {
	return   P::GetFileVersionInfoW(lptstrFilename, dwHandle, dwLen, lpData);
}


// Function Name     : VerFindFileA
// Ordinal           : 10 (0xa)
namespace P { DWORD(WINAPI* VerFindFileA)(DWORD uFlags, LPCSTR szFileName, LPCSTR szWinDir, LPCSTR szAppDir, LPSTR szCurDir, PUINT lpuCurDirLen, LPSTR szDestDir, PUINT lpuDestDirLen); }
extern "C"    DWORD  WINAPI  VerFindFileA(DWORD uFlags, LPCSTR szFileName, LPCSTR szWinDir, LPCSTR szAppDir, LPSTR szCurDir, PUINT lpuCurDirLen, LPSTR szDestDir, PUINT lpuDestDirLen) {
	return    P::VerFindFileA(uFlags, szFileName, szWinDir, szAppDir, szCurDir, lpuCurDirLen, szDestDir, lpuDestDirLen);
}


// Function Name     : VerFindFileW
// Ordinal           : 11 (0xb)
namespace P { DWORD(WINAPI* VerFindFileW)(DWORD uFlags, LPCWSTR szFileName, LPCWSTR szWinDir, LPCWSTR szAppDir, LPWSTR szCurDir, PUINT lpuCurDirLen, LPWSTR szDestDir, PUINT lpuDestDirLen); }
extern "C"    DWORD  WINAPI  VerFindFileW(DWORD uFlags, LPCWSTR szFileName, LPCWSTR szWinDir, LPCWSTR szAppDir, LPWSTR szCurDir, PUINT lpuCurDirLen, LPWSTR szDestDir, PUINT lpuDestDirLen) {
	return    P::VerFindFileW(uFlags, szFileName, szWinDir, szAppDir, szCurDir, lpuCurDirLen, szDestDir, lpuDestDirLen);
}


// Function Name     : VerInstallFileA
// Ordinal           : 12 (0xc)
namespace P { DWORD(WINAPI* VerInstallFileA)(DWORD uFlags, LPCSTR szSrcFileName, LPCSTR szDestFileName, LPCSTR szSrcDir, LPCSTR szDestDir, LPCSTR szCurDir, LPSTR szTmpFile, PUINT lpuTmpFileLen); }
extern "C"    DWORD  WINAPI  VerInstallFileA(DWORD uFlags, LPCSTR szSrcFileName, LPCSTR szDestFileName, LPCSTR szSrcDir, LPCSTR szDestDir, LPCSTR szCurDir, LPSTR szTmpFile, PUINT lpuTmpFileLen) {
	return    P::VerInstallFileA(uFlags, szSrcFileName, szDestFileName, szSrcDir, szDestDir, szCurDir, szTmpFile, lpuTmpFileLen);
}


// Function Name     : VerInstallFileW
// Ordinal           : 13 (0xd)
namespace P { DWORD(WINAPI* VerInstallFileW)(DWORD uFlags, LPCWSTR szSrcFileName, LPCWSTR szDestFileName, LPCWSTR szSrcDir, LPCWSTR szDestDir, LPCWSTR szCurDir, LPWSTR szTmpFile, PUINT lpuTmpFileLen); }
extern "C"    DWORD  WINAPI  VerInstallFileW(DWORD uFlags, LPCWSTR szSrcFileName, LPCWSTR szDestFileName, LPCWSTR szSrcDir, LPCWSTR szDestDir, LPCWSTR szCurDir, LPWSTR szTmpFile, PUINT lpuTmpFileLen) {
	return    P::VerInstallFileW(uFlags, szSrcFileName, szDestFileName, szSrcDir, szDestDir, szCurDir, szTmpFile, lpuTmpFileLen);
}


// Function Name     : VerLanguageNameA
// Ordinal           : 14 (0xe)
namespace P { DWORD(WINAPI* VerLanguageNameA)(DWORD wLang, LPSTR szLang, DWORD cchLang); }
extern "C"    DWORD  WINAPI  VerLanguageNameA(DWORD wLang, LPSTR szLang, DWORD cchLang) {
	return    P::VerLanguageNameA(wLang, szLang, cchLang);
}


// Function Name     : VerLanguageNameW
// Ordinal           : 15 (0xf)
namespace P { DWORD(WINAPI* VerLanguageNameW)(DWORD wLang, LPWSTR szLang, DWORD cchLang); }
extern "C"    DWORD  WINAPI  VerLanguageNameW(DWORD wLang, LPWSTR szLang, DWORD cchLang) {
	return    P::VerLanguageNameW(wLang, szLang, cchLang);
}


// Function Name     : VerQueryValueA
// Ordinal           : 16 (0x10)
namespace P { BOOL(WINAPI* VerQueryValueA)(LPCVOID pBlock, LPCSTR lpSubBlock, LPVOID* lplpBuffer, PUINT puLen); }
extern "C"    BOOL  WINAPI  VerQueryValueA(LPCVOID pBlock, LPCSTR lpSubBlock, LPVOID* lplpBuffer, PUINT puLen) {
	return   P::VerQueryValueA(pBlock, lpSubBlock, lplpBuffer, puLen);
}


// Function Name     : VerQueryValueW
// Ordinal           : 17 (0x11)
namespace P { BOOL(WINAPI* VerQueryValueW)(LPCVOID pBlock, LPCWSTR lpSubBlock, LPVOID* lplpBuffer, PUINT puLen); }
extern "C"    BOOL  WINAPI  VerQueryValueW(LPCVOID pBlock, LPCWSTR lpSubBlock, LPVOID* lplpBuffer, PUINT puLen) {
	return   P::VerQueryValueW(pBlock, lpSubBlock, lplpBuffer, puLen);
}

template<typename T>
void setup(T*& funcPtr, HMODULE library, const char* funcName) {
	if (funcPtr != nullptr) {
		return;
	}
	funcPtr = reinterpret_cast<T*>(GetProcAddress(library, funcName));
}

#define ASSIGN_PROC(Name, library) \
	setup(P::##Name, library, #Name);


DWORD WINAPI CUEHookThread(LPVOID Arg)
{
#ifdef _DEBUG
	while (!::IsDebuggerPresent())
		::Sleep(100);
#endif

	HMODULE winTrustModule = GetModuleHandle(_T("WINTRUST.dll"));
	while ((winTrustModule = GetModuleHandle(_T("WINTRUST.dll"))) == nullptr)
	{
		::Sleep(10); // Wait for WINTRUST.dll to be loaded
		//It seems that from V5.22 of iCUE , the WINTRUST.dll is loaded after this dll
	}
	if (winTrustModule) {
		FARPROC winVerifyTrust = GetProcAddress(winTrustModule, "WinVerifyTrust");
		if (winVerifyTrust) {


			//BYTE bypass[] = { 0x31, 0xC0, 0xC3 };
			// xor eax, eax
			// ret

			BYTE bypass[] = { 0x48, 0x31, 0xC0, 0xC3 };
			// xor rax, rax
			// ret
			// clear the entire 64 bit register, not just the lower 32 bits

			DWORD d, ds;

			VirtualProtect((LPVOID)winVerifyTrust, 1, PAGE_EXECUTE_READWRITE, &d);
			memcpy((PBYTE)winVerifyTrust, bypass, sizeof(bypass));
			VirtualProtect((LPVOID)winVerifyTrust, 1, d, &ds);

		}


	}

	return 0;
}

static std::wstring Utf8ToWide(const std::string& str)
{
	if (str.empty()) return std::wstring();
	int size = MultiByteToWideChar(CP_UTF8, 0, str.c_str(), (int)str.size(), nullptr, 0);
	std::wstring result(size, L'\0');
	MultiByteToWideChar(CP_UTF8, 0, str.c_str(), (int)str.size(), &result[0], size);
	return result;
}

// Simple synchronous HTTPS GET. Returns false on any failure
static bool HttpGet(const std::wstring& host, const std::wstring& path, std::string& outBody)
{
	bool ok = false;
	HINTERNET hSession = WinHttpOpen(L"CUEORGBPlugin-Updater/1.0",
		WINHTTP_ACCESS_TYPE_AUTOMATIC_PROXY,
		WINHTTP_NO_PROXY_NAME, WINHTTP_NO_PROXY_BYPASS, 0);
	if (!hSession) return false;

	// Don't let a hung connection block execution load indefinitely
	WinHttpSetTimeouts(hSession, 5000, 5000, 5000, 5000);

	HINTERNET hConnect = WinHttpConnect(hSession, host.c_str(), INTERNET_DEFAULT_HTTPS_PORT, 0);
	if (hConnect)
	{
		HINTERNET hRequest = WinHttpOpenRequest(hConnect, L"GET", path.c_str(),
			nullptr, WINHTTP_NO_REFERER, WINHTTP_DEFAULT_ACCEPT_TYPES, WINHTTP_FLAG_SECURE);
		if (hRequest)
		{
			if (WinHttpSendRequest(hRequest, WINHTTP_NO_ADDITIONAL_HEADERS, 0, WINHTTP_NO_REQUEST_DATA, 0, 0, 0) &&
				WinHttpReceiveResponse(hRequest, nullptr))
			{
				std::string body;
				DWORD dwSize = 0;
				do
				{
					if (!WinHttpQueryDataAvailable(hRequest, &dwSize) || dwSize == 0)
						break;

					std::vector<char> buffer(dwSize);
					DWORD dwDownloaded = 0;
					if (!WinHttpReadData(hRequest, buffer.data(), dwSize, &dwDownloaded))
						break;

					body.append(buffer.data(), dwDownloaded);
				} while (dwSize > 0);

				outBody = body;
				ok = !body.empty();
			}
			WinHttpCloseHandle(hRequest);
		}
		WinHttpCloseHandle(hConnect);
	}
	WinHttpCloseHandle(hSession);
	return ok;
}

static std::vector<int> ParseVersion(const std::string& version)
{
	std::vector<int> parts;
	std::stringstream ss(version);
	std::string segment;
	while (std::getline(ss, segment, '.'))
	{
		try { parts.push_back(std::stoi(segment)); }
		catch (...) { parts.push_back(0); }
	}
	while (parts.size() < 3) parts.push_back(0);
	return parts;
}

// Returns <0 if a<b, 0 if equal, >0 if a>b
static int CompareVersions(const std::string& a, const std::string& b)
{
	auto pa = ParseVersion(a);
	auto pb = ParseVersion(b);
	for (size_t i = 0; i < (std::max)(pa.size(), pb.size()); ++i)
	{
		int va = i < pa.size() ? pa[i] : 0;
		int vb = i < pb.size() ? pb[i] : 0;
		if (va != vb) return va < vb ? -1 : 1;
	}
	return 0;
}

static void ShowUpdateDialog(bool localIsNewer, const std::string& localVersion, const std::string& remoteVersion, const std::string& changelog)
{
	std::wstring wLocal = Utf8ToWide(localVersion);
	std::wstring wRemote = Utf8ToWide(remoteVersion);
	std::wstring wChangelog = Utf8ToWide(changelog);

	std::wstringstream message;
	int result;

	if (localIsNewer)
	{
		message << L"Your current version (v" << wLocal << L") is newer than the latest build (v" << wRemote << L").\n\n"
			<< L"If this is a development build, you can ignore this message. Otherwise, contact Hepi34 on GitHub.\n\n"
			<< L"Would you like to open the issues page?";

		result = MessageBoxW(nullptr, message.str().c_str(), L"CUEORGBPlugin - Version Check", MB_YESNO | MB_ICONWARNING | MB_TOPMOST | MB_SETFOREGROUND);
		if (result == IDYES)
			ShellExecuteW(nullptr, L"open", L"https://github.com/Hepi34/CUEORGBPlugin/issues", nullptr, nullptr, SW_SHOWNORMAL);
	}
	else
	{
		message << L"Your current version (v" << wLocal << L") is older than the latest build (v" << wRemote << L").\n\n"
			<< L"Please update to get the following changes:\n" << wChangelog << L"\n\n"
			<< L"Would you like to open the releases page?";

		result = MessageBoxW(nullptr, message.str().c_str(), L"CUEORGBPlugin - Update Available", MB_YESNO | MB_ICONWARNING | MB_TOPMOST | MB_SETFOREGROUND);
		if (result == IDYES)
			ShellExecuteW(nullptr, L"open", L"https://github.com/Hepi34/CUEORGBPlugin/releases", nullptr, nullptr, SW_SHOWNORMAL);
	}
}

constexpr const char* CURRENT_VERSION = "0.3.0";

DWORD WINAPI UpdateCheckThread(LPVOID)
{

	// iCUE loads version.dll more than once
	// Only the first process to grab this mutex actually runs the check to avoid having multiple update dialogs pop up at once
	// The mutex isn't destroyed on purpose as it will automatically be cleaned up when the process exits
	HANDLE hMutex = CreateMutexW(nullptr, TRUE, L"CUEORGBPlugin_UpdateCheck");
	if (!hMutex || GetLastError() == ERROR_ALREADY_EXISTS)
		return 0;

	std::string body;
	if (!HttpGet(L"raw.githubusercontent.com", L"/Hepi34/CUEORGBPlugin/master/version.json", body))
		return 0;

	std::string remoteVersion, changelog;
	try
	{
		auto j = nlohmann::json::parse(body);
		remoteVersion = j.value("version", "");
		changelog = j.value("changelog", "");
	}
	catch (...)
	{
		return 0;
	}

	if (remoteVersion.empty())
		return 0;

	int cmp = CompareVersions(CURRENT_VERSION, remoteVersion);
	if (cmp == 0)
		return 0;

	ShowUpdateDialog(cmp > 0, CURRENT_VERSION, remoteVersion, changelog);
	return 0;
}

BOOL APIENTRY DllMain(HMODULE hModule, DWORD fdwReason, LPVOID lpReserved)
{
	UNREFERENCED_PARAMETER(lpReserved);

	static HMODULE versiondll;

	switch (fdwReason)
	{
	case DLL_PROCESS_ATTACH:
		// Load dll
		TCHAR path[MAX_PATH];
		GetSystemDirectory(path, MAX_PATH);
		_tcscat_s(path, _T("\\version.dll"));
		versiondll = LoadLibrary(path);

		ASSIGN_PROC(GetFileVersionInfoA, versiondll);
		ASSIGN_PROC(GetFileVersionInfoByHandle, versiondll)
			ASSIGN_PROC(GetFileVersionInfoExA, versiondll)
			ASSIGN_PROC(GetFileVersionInfoExW, versiondll)
			ASSIGN_PROC(GetFileVersionInfoSizeA, versiondll)
			ASSIGN_PROC(GetFileVersionInfoSizeExA, versiondll)
			ASSIGN_PROC(GetFileVersionInfoSizeExW, versiondll)
			ASSIGN_PROC(GetFileVersionInfoSizeW, versiondll)
			ASSIGN_PROC(GetFileVersionInfoW, versiondll)
			ASSIGN_PROC(VerFindFileA, versiondll)
			ASSIGN_PROC(VerFindFileW, versiondll)
			ASSIGN_PROC(VerInstallFileA, versiondll)
			ASSIGN_PROC(VerInstallFileW, versiondll)
			ASSIGN_PROC(VerLanguageNameA, versiondll)
			ASSIGN_PROC(VerLanguageNameW, versiondll)
			ASSIGN_PROC(VerQueryValueA, versiondll)
			ASSIGN_PROC(VerQueryValueW, versiondll)

			//CUEHookThread(nullptr);
			CreateThread(nullptr, 0, CUEHookThread, nullptr, 0, nullptr);
			//This dll has to be loaded on a speerate thread because it is loaded before the dll we're trying to modify

			CreateThread(nullptr, 0, UpdateCheckThread, nullptr, 0, nullptr);
			//This thread checks for updates and needs to be seperated from the bypass as the bypass can fail and thus need a new version
						
		break;

	case DLL_PROCESS_DETACH:
		FreeLibrary(versiondll);
		break;
	}

	return TRUE;
}
