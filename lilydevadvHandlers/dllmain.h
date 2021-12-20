// dllmain.h : Declaration of module class.

class ClilydevadvHandlersModule : public ATL::CAtlDllModuleT<ClilydevadvHandlersModule>
{
public :
	DECLARE_LIBID(LIBID_lilydevadvHandlersLib)
	DECLARE_REGISTRY_APPID_RESOURCEID(IDR_LILYDEVADVHANDLERS, "{d52e3172-dd49-4dc0-b8d4-428ccd4cd79f}")
};

extern class ClilydevadvHandlersModule _AtlModule;
